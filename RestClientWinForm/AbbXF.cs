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
using DevExpress.XtraGrid.Localization;

namespace RestClientWinForm
{
    public partial class AbbXF : DevExpress.XtraEditors.XtraForm
    {
        public AbbXF()
        {
            InitializeComponent();
            GridLocalizer.Active = new CustomGridLocalizer();

            abbGridControl.ExternalRepository = Program.MF.persistentRepository;
        }

        public class CustomGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                if (id == GridStringId.CheckboxSelectorColumnCaption)
                {
                    return "E?";
                }
                return base.GetLocalizedString(id);
            }
        }

        private void AbbXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void AbbXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
                UpdateDB(true);
            else
                UpdateDB();
        }

        private void FillDB()
        {
            string res = "";
            abbGridControl.DataSource = null;
            accDataSet.ABB.Clear();
            Task.Run(async () => { res = await accDataSet.ABBfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            abbGridControl.DataSource = abbBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (accDataSet.HasChanges())
            {
                if (silent == false)
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
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;
            // Edit modunda olmali
            if (!gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                return;

            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (UpdateDB() != DialogResult.Abort)
                FillDB();
        }

        private void revertToolStripButton_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;
            // Edit modunda olMAMAli
            if (gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                return;
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                return;

            if (gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                return;

            gridView1.SetFocusedRowCellValue(colDrm, "P");
            gridView1.SetFocusedRowModified();

            if (UpdateDB(true) != DialogResult.Abort)
            {
                gridView1.SetFocusedRowCellValue(colDrm, "A");
                gridView1.SelectRow(gridView1.FocusedRowHandle);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.IsRowSelected(e.PrevFocusedRowHandle))
            {
                UpdateDB(true);
                gridView1.UnselectRow(e.PrevFocusedRowHandle);
            }
        }

        private void faturaDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            bool readOnly = true;
            if (gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                readOnly = false;

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowPk) == 0)
            {
                readOnly = false;
                gridView1.SetFocusedRowCellValue(colDrm, "P");
                gridView1.SetFocusedRowModified();
                UpdateDB(true);
            }

            object rowPk = gridView1.GetFocusedRowCellValue(colRowPk);
            AbdXF frm = new AbdXF();
            frm.ABBRow = (AccDataSet.ABBRow)accDataSet.ABB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            frm.readOnly = readOnly;
            var dr = frm.ShowDialog();
            if (!readOnly)
            {
                gridView1.SetFocusedRowCellValue(colDrm, "A");
                gridView1.CloseEditor();
                UpdateDB(true);
                gridView1.UnselectRow(gridView1.FocusedRowHandle);
            }

        }
    }
}