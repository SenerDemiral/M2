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
    public partial class KftXF : DevExpress.XtraEditors.XtraForm
    {
        private object ObjTur;  // KimTur Musteri KULLANILMIYOR

        public KftXF()
        {
            InitializeComponent();

            kftGridControl.ExternalRepository = Program.MF.persistentRepository;
            colAHPbrc.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;
            colAHPalc.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;

        }

        private void KmtXF_Load(object sender, EventArgs e)
        {
            // KKK.TUR deki F yi bul
            //DataRow[] xgtRows = Program.MF.mainDataSet.XGT.Select($"P = {Program.MF.XgtDic["KKK.TUR"]} AND Kd = 'F'");
            //ObjTur = xgtRows[0]["RowKey"];

            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            kftGridControl.DataSource = null;
            mainDataSet.KFT.Clear();
            Task.Run(async () => { res = await mainDataSet.KFTfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            kftGridControl.DataSource = kftBindingSource;
        }

        private DialogResult UpdateDB()
        {
            if (!Validate())
                return DialogResult.Cancel;
            kftBindingSource.EndEdit();

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.OK;

            // Ok:    No change
            // Yes:   Update succesfull
            // Abort: Hata
            // No:    Update var kaydetmedi

            if (mainDataSet.HasChanges())
            {
                dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.KFTupdate();
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

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateDB();
            FillDB();
        }

        private void revertToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            mainDataSet.KFT.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);

        }

        private void haberlesmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;
            KhtXF frm = new KhtXF();
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);
            frm.Mtyp = "KFT";
            frm.ShowDialog();

            /*
            ToKhtXF frm = new ToKhtXF();
            frm.P = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);
            frm.Ptyp = "KFT";
            frm.ShowDialog();*/

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            KctXF frm = new KctXF();
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);
            frm.Mtyp = "KFT";
            frm.ShowDialog();

        }
    }
}