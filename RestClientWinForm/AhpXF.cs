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

namespace RestClientWinForm
{
    public partial class AhpXF : DevExpress.XtraEditors.XtraForm
    {
        public AhpXF()
        {
            InitializeComponent();

        }

        private void AhpXF_Load(object sender, EventArgs e)
        {
            string res = "";
            Task.Run(async () => { res = await accDataSet.AHPfill(); }).Wait();
            //MessageBox.Show(res);
            toolStripStatusLabel1.Text = res;

            treeList1.ExpandAll();
            //treeList1.ExpandToLevel(0);
            treeList1.MoveFirst();

            treeList1.OptionsBehavior.EnableFiltering = true;
            treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            // Filter/Find da Parentlari da gosteriyor
            treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;

            treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            treeList1.OptionsFind.AllowFindPanel = true;

        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = treeList1.FocusedNode.Id;
            MessageBox.Show(treeList1.FocusedNode.Id.ToString());
            var row = accDataSet.AHP.Rows[id];

            var frm = new AhpEditXF();
            frm.bs = aHPBindingSource;
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

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            Text = e.Node.Level.ToString();
            //if (e.Node.Level == 2)

            if (!e.Node.HasChildren)
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
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

        private void aHPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            aHPBindingSource.EndEdit();
            string err = accDataSet.AHPupdate();
            if (err != string.Empty)
                MessageBox.Show(err);
        }
    }
}