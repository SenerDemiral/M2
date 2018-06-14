using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Grpc.Core;
using Rest;
using DevExpress.XtraTreeList.Nodes;

namespace RestClientWinForm
{
    public partial class AhpXF : DevExpress.XtraEditors.XtraForm
    {
        public AhpXF()
        {
            InitializeComponent();

            treeList1.OptionsBehavior.EnableFiltering = true;
            treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            // Filter/Find da Parentlari da gosteriyor
            treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;

            treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            treeList1.OptionsFind.AllowFindPanel = true;
        }

        private void AhpXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = treeList1.FocusedNode.Id;
            MessageBox.Show(treeList1.FocusedNode.Id.ToString());
            var row = accDataSet.AHP.Rows[id];

            var frm = new AhpEditXF();
            frm.bs = ahpBindingSource;
            frm.ds = accDataSet;
            frm.dt = accDataSet.AHP;
            frm.dr = row;
            frm.id = id;
            frm.ObjP = row["RowPK"];
            frm.ShowDialog();

            //aHPBindingSource.EndEdit();
            //string err = accDataSet.AHPupdate();
            //if (err != string.Empty)
            //    MessageBox.Show(err);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {


        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            //Text = e.Node.Level.ToString();
            //if (e.Node.Level == 2)

            if (!e.Node.HasChildren)
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            if (e.Node.Level == 0)
                e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 10.0F);
        }

        async Task xxAHPfill()
        {
            var dt = accDataSet.AHP;

            dt.BeginLoadData();
            int nor = 0, ml = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.AHPfill(new QryProxy { Query = "abc" }))
            {
                while (await response.ResponseStream.MoveNext(token))
                {
                    //var proxy = response.ResponseStream.Current;

                    row = dt.NewRow();
                    ProxyHelper.ProxyToRow(dt, row, response.ResponseStream.Current);
                    dt.Rows.Add(row);

                    nor++;
                    //ml += proxy.CalculateSize();
                    //MessageBox.Show(rec.Message);
                }
            }
            sw.Stop();
            dt.AcceptChanges();
            dt.EndLoadData();
            //MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
        }

        private void xxAHPupdate()
        {
            var dt = accDataSet.AHP;
            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            var request = new AHPproxy();

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i].ClearErrors();

                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);

                if (rs == "A" || rs == "M")
                {
                    request.RowState = rs;

                    ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.AHPupdate(request);

                    if (string.IsNullOrEmpty(reply.RowErr))
                    {
                        ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                        dt.Rows[i].AcceptChanges();
                    }
                    else
                    {
                        dt.Rows[i].RowError = reply.RowErr;
                        dt.Rows[i].RejectChanges();

                    }
                }
            }
            channel.ShutdownAsync().Wait();


        }

        private void FillDB()
        {
            string res = "";
            accDataSet.AHP.Clear();
            Task.Run(async () => { res = await accDataSet.AHPfill(); }).Wait();
            //MessageBox.Show(res);
            toolStripStatusLabel1.Text = res;

            treeList1.ExpandAll();
            //treeList1.ExpandToLevel(0);
            treeList1.MoveFirst();
        }

        private bool UpdateDB()
        {
            //aHPBindingSource.EndEdit();
            treeList1.PostEditor();
            treeList1.EndCurrentEdit();
            string err = accDataSet.AHPupdate();
            if (err != string.Empty)
            {
                MessageBox.Show(err);
                return false;
            }
            return true;
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            /*
            int id = treeList1.FocusedNode.Id;
            var aaa = accDataSet.AHP.Rows;
            AccDataSet.AHPRow oldRow = accDataSet.AHP.Rows[treeList1.FocusedNode.Id] as AccDataSet.AHPRow;
            //aHPBindingSource.AddNew();
            //AccDataSet.AHPRow newRow = accDataSet.AHP.Rows[aHPBindingSource.Position] as AccDataSet.AHPRow;
            //newRow.ObjP = oldRow.RowPk;


            AccDataSet.AHPRow row = (AccDataSet.AHPRow)accDataSet.AHP.NewRow();
            row.ObjP = oldRow.RowPk;
            accDataSet.AHP.AddAHPRow(row);
            */

            //TreeListNode newNode = treeList1.AppendNode(new object[] { "Sener" }, treeList1.FocusedNode);
            //treeList1.FocusedNode = newNode;
            if ((bool)treeList1.FocusedNode.GetValue(colHasH))     // Hareketi varsa alt hesabi olamaz
                XtraMessageBox.Show("Hesabın hareketleri var, Alt hesap ekleyemezsiniz.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            { 
                bool ok = true;
                if (accDataSet.HasChanges(DataRowState.Added))
                    ok = UpdateDB();
                if (ok)
                    treeList1.FocusedNode = treeList1.AppendNode(new object[] { "Sener" }, treeList1.FocusedNode);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void revertToolStripButton_Click(object sender, EventArgs e)
        {
            treeList1.PostEditor();
            treeList1.EndCurrentEdit();
            accDataSet.AHP.Rows[treeList1.FocusedNode.Id].RejectChanges();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            treeList1.PostEditor();
            treeList1.EndCurrentEdit();
            if (accDataSet.HasChanges())
            {
                var res = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Refresh", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.Yes)
                    saveToolStripButton.PerformClick();
            }
            FillDB();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            var aaa = treeList1.FocusedNode.Id;
            var bbb = accDataSet.AHP.Rows[aaa];
            if (treeList1.FocusedNode.HasChildren)
                XtraMessageBox.Show("Alt hesabı var silemezsiniz.", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                accDataSet.AHP.Rows[treeList1.FocusedNode.Id].Delete();
        }
    }
}