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
    public partial class AfdXF : DevExpress.XtraEditors.XtraForm
    {
        public object ObjAFB = (ulong)469;

        public AfdXF()
        {
            InitializeComponent();

            afdGridControl.ExternalRepository = Program.MF.persistentRepository;
            colObjAHP.ColumnEdit = Program.MF.AHPrepositoryItemSearchLookUpEdit;
        }

        private void AfdXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            afdGridControl.DataSource = null;
            accDataSet.AFD.Clear();
            Task.Run(async () => { res = await accDataSet.AFDfill((ulong)ObjAFB); }).Wait();
            toolStripStatusLabel1.Text = res;
            afdGridControl.DataSource = afdBindingSource;
        }

        private DialogResult UpdateDB()
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.OK;

            // Ok:    No change
            // Yes:   Update succesfull
            // Abort: Hata
            // No:    Update var kadetmedi

            if (accDataSet.HasChanges())
            {
                dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = accDataSet.AFDupdate();
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

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {

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
            accDataSet.AFD.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void AfdXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = UpdateDB();
            if (dr == DialogResult.Cancel)
                e.Cancel = true;
            else
                DialogResult = DialogResult.Yes;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colObjAFB, ObjAFB);
        }
    }
}