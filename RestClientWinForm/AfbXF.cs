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
    public partial class AfbXF : DevExpress.XtraEditors.XtraForm
    {
        public AfbXF()
        {
            InitializeComponent();

            afbGridControl.ExternalRepository = Program.MF.persistentRepository;
            colObjTur.ColumnEdit = Program.MF.AfbTurRepositoryItemLookUpEdit;
            colTrh.ColumnEdit = Program.MF.DateRepositoryItemDateEdit;

        }

        private void FillDB()
        {
            string res = "";
            afbGridControl.DataSource = null;
            accDataSet.AFB.Clear();
            Task.Run(async () => { res = await accDataSet.AFBfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            afbGridControl.DataSource = afbBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (accDataSet.HasChanges())
            {
                if(silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = accDataSet.AFBupdate();
                    if (err != string.Empty)
                    {
                        MessageBox.Show(err);
                        dr = DialogResult.Abort;
                    }
                }
            }

            return dr;
        }

        private void AfbXF_Load(object sender, EventArgs e)
        {
            FillDB();
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
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if(UpdateDB() != DialogResult.Abort)
                FillDB();
        }

        private void revertToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void fisDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDB();
            AfdXF frm = new AfdXF();
            object rowPk = gridView1.GetFocusedRowCellValue(colRowPk);
            frm.AFBRow = (AccDataSet.AFBRow)accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            var dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].SetModified();
                UpdateDB(true);
            }

            //gridView1.SetFocusedRowModified();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(colAoK).ToString() == "K")
                e.Cancel = true;
        }
    }
}