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

namespace RestClientWinForm
{
    public partial class MainXF : DevExpress.XtraEditors.XtraForm
    {
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

        public void InitLookups()
        {
            Dictionary<string, ulong> XgtDic = new Dictionary<string, ulong>();
            foreach(MainDataSet.XGTRow r in mainDataSet.XGT.Rows)
            {
                if(r.ObjP == 0)
                {
                    XgtDic[r.Kd] = r.RowPk;
                }
            }
                 
            DataView DvzDV = new DataView(mainDataSet.XGT, $"ObjP = {XgtDic["DVZ"]}", "Kd", DataViewRowState.CurrentRows);
            DvzRepositoryItemLookUpEdit.DataSource = DvzDV;
            DataView AfbTurDV = new DataView(mainDataSet.XGT, $"ObjP = {XgtDic["AFB.TUR"]}", "Kd", DataViewRowState.CurrentRows);
            AfbTurRepositoryItemLookUpEdit.DataSource = AfbTurDV;

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

        private void AHPrepositoryItemSearchLookUpEdit_QueryCloseUp(object sender, CancelEventArgs e)
        {
        }

        private void AHPrepositoryItemSearchLookUpEdit_Validating(object sender, CancelEventArgs e)
        {

        }

        private void AHPrepositoryItemSearchLookUpEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void AHPrepositoryItemTreeListLookUpEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
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
                if(f.Name != "MainXF")
                    f.Close();
            }

        }
    }
}