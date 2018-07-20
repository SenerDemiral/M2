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

namespace RestClientWinForm
{
    public partial class MainXF : DevExpress.XtraEditors.XtraForm
    {
        public Dictionary<string, ulong> XgtDic;

        public MainXF()
        {
            InitializeComponent();
        }

        public void FillTanimlar()
        {
            Task.Run(async () => {
                await mainDataSet.XGTfill();
                await mainDataSet.AHPfill();
                InitLookups();
            }); //.Wait();

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

            DataView AfbTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["AFB.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            AfbTurRepositoryItemLookUpEdit.DataSource = AfbTurDV;

            DataView KkkTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["KKK.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            KkkTurRepositoryItemLookUpEdit.DataSource = KkkTurDV;

            DataView AbbTurDV = new DataView(mainDataSet.XGT, $"P = {XgtDic["ABB.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            AbbTurRepositoryItemLookUpEdit.DataSource = AbbTurDV;

        }

        private void AHPbutton_Click(object sender, EventArgs e)
        {
            AhpXF frm = new AhpXF();
            frm.Show();
        }

        private void AFBbutton_Click(object sender, EventArgs e)
        {
            var aaa = mainDataSet.XGT;
            AfbXF frm = new AfbXF();
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
            AbbXF frm = new AbbXF();
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

        private void KidsInParentsButton_Click(object sender, EventArgs e)
        {
            KidsInParentsXF frm = new KidsInParentsXF();
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
    }
}