using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars.Docking;
using System.Diagnostics;

namespace RestClientWinForm
{
    public partial class MainXF : DevExpress.XtraEditors.XtraForm
    {
        public Dictionary<string, ulong> XgtDic;
        Stopwatch sw = new Stopwatch();
        int nor = 0;

        public MainXF()
        {
            InitializeComponent();

            /*
            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(KeyDown);
            this.menuStrip1.MenuDeactivate += (s, e) => this.menuStrip1.Visible = false;
            //this.menuStrip1.Visible = false;
            */
        }
        private void MainXF_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if(e.KeyCode == Keys.Menu)
            {
                menuStrip1.Visible = true;
                contextMenuStrip1.Show(this, new Point(0, 0));
            }*/
        }

        private void MainXF_Load(object sender, EventArgs e)
        {
            /*
            menuStrip1.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();
            });*/

            if(sw.ElapsedMilliseconds > 1000)
                toolStripStatusLabel1.Text = $"{nor} recs read in {sw.ElapsedMilliseconds / 1000L} sec";
            else
                toolStripStatusLabel1.Text = $"{nor} recs read in {sw.ElapsedMilliseconds} msec (1/1000sec)";
            //double seconds = (double)sw.ElapsedTicks / Stopwatch.Frequency;
            //toolStripStatusLabel1.Text = $"{nor} recssss read in {sw.ElapsedTicks / Stopwatch.Frequency} msec {Stopwatch.Frequency} {sw.ElapsedTicks} === {seconds}";
        }

        public void FillTanimlar()
        {
            nor = 0;

            Task.Run(async () => {
                sw.Restart();

                /*
                await mainDataSet.XGTfill();
                await mainDataSet.AVKfill();
                await mainDataSet.ABKfill();
                await mainDataSet.AHPfill();
                await mainDataSet.KDTfill();
                await mainDataSet.KPTfill();
                await mainDataSet.NNNfill();
                */
                nor += await dataSetLookup.BbL();
                //nor += await dataSetLookup.KftL();
                //nor += await dataSetLookup.NntL();
                nor += await dataSetLookup.AhpL();
                //string sss = await mainDataSet.AHPfill();

                sw.Stop();
                var bbb = dataSetLookup.AHPL.Count;
                InitLookups();
            });//.Wait();
        }

        private void MainXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Form> of = new List<Form>();
            foreach (Form f in Application.OpenForms)
            {
                of.Add(f);
            }
            foreach (Form f in of)
            {
                if (f.Name != "MainXF")
                    f.Close();
            }
            grpcService.channel.ShutdownAsync().Wait();

        }

        public void InitLookups()
        {
            XgtDic = new Dictionary<string, ulong>();
            foreach(MainDataSet.XGTRow r in mainDataSet.XGT.Rows)
            {
                if(r.P == 0)
                {
                    XgtDic[r.Kd] = r.RowKey;
                }
            }
            DataView DvzDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["DVZ"]}", "Kd", DataViewRowState.CurrentRows);
            DVTrepositoryItemLookUpEdit.DataSource = DvzDV;

            DataView AvmTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["AVM.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            AvmTurRepositoryItemLookUpEdit.DataSource = AvmTurDV;

            DataView AbmTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["ABM.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            AbmTurRepositoryItemLookUpEdit.DataSource = AbmTurDV;

            DataView KkkTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["KKK.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            KkkTurRepositoryItemLookUpEdit.DataSource = KkkTurDV;

            DataView NeBrmDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["NNN.BRM"]}", "Kd", DataViewRowState.CurrentRows);
            NeBrmRepositoryItemLookUpEdit.DataSource = NeBrmDV;
        }

        private void AHPbutton_Click(object sender, EventArgs e)
        {
            AhpXF frm = new AhpXF();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AFBbutton_Click(object sender, EventArgs e)
        {
            var aaa = mainDataSet.XGT;
            AvmXF frm = new AvmXF();
            frm.Show();
        }

        private void XDKbutton_Click(object sender, EventArgs e)
        {
            XdkXF frm = new XdkXF();
            frm.Show();
        }

        private void AHPrepositoryItemTreeListLookUpEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //  AHPrepositoryItemTreeListLookUpEdit_QueryCloseUp kullan
            /*
            var aa = (((AHPrepositoryItemTreeListLookUpEdit.DataSource as BindingSource).Current as DataRowView).Row as MainDataSet.AHPRow).HspNo;
            Text = $"{e.Value} -- {e.CloseMode} -- {aa}";

            if(e.CloseMode == PopupCloseMode.Normal)
            {
                MainDataSet.AHPRow row = (MainDataSet.AHPRow)mainDataSet.AHP.Rows.Find(e.Value);
                if (!row.IsW)
                {
                    e.Value = DBNull.Value;
                    //e.AcceptValue = false;
                }              
            }
            */
        }

        private void AHPrepositoryItemTreeListLookUpEdit_QueryCloseUp(object sender, CancelEventArgs e)
        {
            TreeList tl = (sender as TreeListLookUpEdit).Properties.TreeList;
            TreeListNode focusedNode = tl.FocusedNode;
            e.Cancel = (bool)focusedNode["IsW"] == false;
        }

        private void NNNrepositoryItemGridLookUpEdit_QueryCloseUp(object sender, CancelEventArgs e)
        {
            var view = (sender as GridLookUpEdit).Properties.View;
            bool avl = (bool)view.GetFocusedRowCellValue("Avl");    // Availability
            e.Cancel = !avl;
        }

        private void KDTrepositoryItemGridLookUpEdit_QueryCloseUp(object sender, CancelEventArgs e)
        {
            var view = (sender as GridLookUpEdit).Properties.View;
            bool avl = (bool)view.GetFocusedRowCellValue("Avl");    // Availability
            e.Cancel = !avl;
        }

        private void KFTbutton_Click(object sender, EventArgs e)
        {
            KftXF frm = new KftXF();
            frm.Show();
        }

        private void UYHbutton_Click(object sender, EventArgs e)
        {
            UyhXF frm = new UyhXF();
            frm.Show();
        }

        private void ABBbutton_Click(object sender, EventArgs e)
        {
            AbmXF frm = new AbmXF();
            frm.Show();
        }

        private void NeUpButton_Click(object sender, EventArgs e)
        {
            NeUpXF frm = new NeUpXF();
            frm.Show();
        }

        private void NeDownButton_Click(object sender, EventArgs e)
        {
            NeDownXF frm = new NeDownXF();
            frm.Show();

        }

        private void NodesInParentsButton_Click(object sender, EventArgs e)
        {
            NodesInParentsXF frm = new NodesInParentsXF();
            frm.Show();

        }

        private void NNNbutton_Click(object sender, EventArgs e)
        {
            NnnXF frm = new NnnXF();
            frm.Show();

        }

        private void KPTbutton_Click(object sender, EventArgs e)
        {
            KptXF frm = new KptXF();
            frm.Show();
        }

        private void KDTbutton_Click(object sender, EventArgs e)
        {
            KdtXF frm = new KdtXF();
            frm.Show();
        }

        private void FillLookupsButton_Click(object sender, EventArgs e)
        {
            FillTanimlar();
        }

        private void cccccccccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dadfadfasd");
        }

        AvmXF frmAvm;
        AbmXF frmAbm;
        AhpXF frmAhp;
        NnnXF frmNnn;
        KptXF frmKpt;
        KdtXF frmKdt;
        KdtTreeDownXF frmKdtTreeDown;
        KftXF frmKft;
        XdkXF frmXdk;
        NeDownXF frmNeDown;
        NeUpXF frmNeUp;
        NodesInParentsXF frmNodesInParents;

        private void AVMnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmAvm);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmAvm = new AvmXF();
                frmAvm.MdiParent = this;
                frmAvm.Show();
            }

        }

        private void ABMnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmAbm);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmAbm = new AbmXF();
                frmAbm.MdiParent = this;
                frmAbm.Show();
            }

        }

        private void AHPnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmAhp);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmAhp = new AhpXF();
                frmAhp.MdiParent = this;
                frmAhp.Show();
            }

        }

        private void NNNnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmNnn);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmNnn = new NnnXF();
                frmNnn.MdiParent = this;
                frmNnn.Show();
            }
        }

        private void KPTnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmKpt);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmKpt = new KptXF();
                frmKpt.MdiParent = this;
                frmKpt.Show();
            }
        }

        private void KFTnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmKft);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmKft = new KftXF();
                frmKft.MdiParent = this;
                frmKft.Show();
            }
        }

        private void KDTnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmKdt);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmKdt = new KdtXF();
                frmKdt.MdiParent = this;
                frmKdt.Show();
            }
        }
        private void KdtTreeDownNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmKdtTreeDown);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmKdtTreeDown = new KdtTreeDownXF();
                frmKdtTreeDown.MdiParent = this;
                frmKdtTreeDown.Show();
            }
        }

        private void NodesInParentsNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmNodesInParents);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmNodesInParents = new NodesInParentsXF();
                frmNodesInParents.MdiParent = this;
                frmNodesInParents.Show();
            }
        }

        private void FillLookupsNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FillTanimlar();
        }

        private void NeDownNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmNeDown);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmNeDown = new NeDownXF();
                frmNeDown.MdiParent = this;
                frmNeDown.Show();
            }
        }

        private void NeUpNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmNeUp);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmNeUp = new NeUpXF();
                frmNeUp.MdiParent = this;
                frmNeUp.Show();
            }
        }

        private void XDTnavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var doc = documentManager1.GetDocument(frmXdk);
            if (doc != null)
                tabbedView1.Controller.Activate(doc);
            else
            {
                frmXdk = new XdkXF();
                frmXdk.MdiParent = this;
                frmXdk.Show();
            }
        }

    }
}