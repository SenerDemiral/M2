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

            nnnGridControl.ExternalRepository = Program.MF.persistentRepository;
            //colAHPbrc.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;
            colBRM.ColumnEdit = Program.MF.NeBrmRepositoryItemLookUpEdit;
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
            nnnGridControl.DataSource = null;
            mainDataSet.KFT.Clear();
            Task.Run(async () => { res = await mainDataSet.NNNfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            nnnGridControl.DataSource = nnnBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            nnnBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (mainDataSet.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.NNNupdate();
                    gridView1.UnselectRow(gridView1.FocusedRowHandle);
                    if (err != string.Empty)
                    {
                        MessageBox.Show(err);
                        dr = DialogResult.Abort;
                    }
                }
            }

            return dr;
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
        }


        private void uretenDepartmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            ToBrXF frm = new ToBrXF();
            frm.Text = $"{gridView1.GetFocusedRowCellValue(colAd)} Üretim Departmanları";

            frm.Mtyp = "NNN";
            frm.Dtyp = "KDT";
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);

            frm.ShowDialog();

        }

        private void relationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            NnrXF frm = new NnrXF();
            frm.Text = $"{gridView1.GetFocusedRowCellValue(colAd)} Relations";

            frm.P = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);

            frm.ShowDialog();

        }
    }
}