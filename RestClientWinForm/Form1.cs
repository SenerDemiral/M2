using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Grpc.Core;
using Rest;

namespace RestClientWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            //gridControl1.DataMember = null;
            dataSet1.Tables[0].Clear();
            Task.Run (async () => { await TestTblaFill(); }).Wait();
            gridControl1.DataSource = dataSet1;
            gridControl1.DataMember = "Table1";
        }

        async Task TestTblaFill()
        {
            //Dynamically create Table from class.
            //Not fullfil our requirements. Table structure should be created at design time
            //to use in Controls. Create maunally now.
            //var aaaa = CreateDataTable<TblaRec>();
            //dataSet1.Tables.Add(aaaa);

            var dt = dataSet1.Tables[0];
            //if (dt.Rows[0].RowState == DataRowState.

            dt.BeginLoadData();
            int nor = 0, ml = 0;
            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);
            CancellationToken token = new CancellationToken();

            DataRow row;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = client.TblaFill(new QryProxy { Query = "abc" }))
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
            MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestTblaUpdate();
        }

        void TestTblaUpdate()
        {
            var dt = dataSet1.Tables[0];
            string rs = "";

            Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
            //Channel channel = new Channel($"217.160.13.102:50051", ChannelCredentials.Insecure);
            var client = new CRUDs.CRUDsClient(channel);

            var request = new TblaProxy();

            // Unchanged disindakileri gonder, deleted disindakileri reply ile guncelle, hata yoksa her rec icin AcceptChanges

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                // States: Added, Modified, Deletede, Unchanged
                rs = dt.Rows[i].RowState.ToString().Substring(0, 1);
                if (rs == "A" || rs == "M")
                {
                    request.RowState = rs;

                    ProxyHelper.RowToProxy(dt, dt.Rows[i], request);

                    var reply = client.TblaUpdate(request);

                    ProxyHelper.ProxyToRow(dt, dt.Rows[i], reply);
                    //dt.Rows[i]["RowPk"] = reply.RowPk;

                    if (string.IsNullOrEmpty(reply.RowErr))
                        dt.Rows[i].AcceptChanges();
                    else
                        dt.Rows[i].RowError = reply.RowErr;
                }
            }
            channel.ShutdownAsync().Wait();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
            //gridControl1.DataMember = null;
            dataSet1.Tables[1].Clear();
            Task.Run(async () => { await AHPfill(); }).Wait();
            gridControl2.DataSource = dataSet1;
            gridControl2.DataMember = "AHP";

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

        async Task AHPfill()
        {
            //Dynamically create Table from class.
            //Not fullfil our requirements. Table structure should be created at design time
            //to use in Controls. Create maunally now.
            //var aaaa = CreateDataTable<TblaRec>();
            //dataSet1.Tables.Add(aaaa);

            var dt = dataSet1.Tables[1];
            //if (dt.Rows[0].RowState == DataRowState.

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
            MessageBox.Show($"Time elapsed: {nor:n0}recs  {sw.ElapsedMilliseconds:n0}ms  {nor / sw.ElapsedMilliseconds}recs/ms TotalSize:{ml:n0}");
        }

        private void gridControl2_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            
            ControlNavigator navigator = sender as ControlNavigator;
            GridControl grid = navigator.NavigatableControl as GridControl;
            GridView view = grid.FocusedView as GridView;
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                grid.BeginInvoke(new Action(view.ShowPopupEditForm)); //ShowEditForm));
            }
        }

        private void altHesapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = dataSet1.Tables[1];

            object rowPk = treeList1.FocusedNode.GetValue(colRowPkT);
            object rowHspNo = treeList1.FocusedNode.GetValue(colHspNoT);
            DataRow row = dt.NewRow();
            //ObjectToRow(dt, row, response.ResponseStream.Current);
            row["ObjP"] = rowPk;
            row["No"] = "x";
            row["Ad"] = "XXXXX";
            row["HspNo"] = $"{rowHspNo}.x";
            dt.Rows.Add(row);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dt = dataSet1.Tables[1];
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
                        dt.Rows[i].RejectChanges();
                        dt.Rows[i].RowError = reply.RowErr;

                    }
                }
            }
            channel.ShutdownAsync().Wait();

        }
    }
}
