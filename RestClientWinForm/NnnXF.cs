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
    public partial class NnnXF : DevExpress.XtraEditors.XtraForm
    {
        public NnnXF()
        {
            InitializeComponent();

            nNNGridControl.ExternalRepository = Program.MF.persistentRepository;
            //colAHPbrc.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;
        }

        private void NnnXF_Load(object sender, EventArgs e)
        {
            // KKK.TUR deki F yi bul
            //DataRow[] xgtRows = Program.MF.mainDataSet.XGT.Select($"P = {Program.MF.XgtDic["KKK.TUR"]} AND Kd = 'F'");
            //ObjTur = xgtRows[0]["RowKey"];

            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            nNNGridControl.DataSource = null;
            mainDataSet.KFT.Clear();
            Task.Run(async () => { res = await mainDataSet.NNNfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            nNNGridControl.DataSource = nNNBindingSource;
        }

        private void uretenDepartmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            ToKdtXF frm = new ToKdtXF();
            frm.P = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);

            frm.ShowDialog();

        }
    }
}