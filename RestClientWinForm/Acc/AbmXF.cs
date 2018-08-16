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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace RestClientWinForm
{
    public partial class AbmXF : DevExpress.XtraEditors.XtraForm
    {
        public AbmXF()
        {
            InitializeComponent();
            GridLocalizer.Active = new CustomGridLocalizer();

            abmGridControl.ExternalRepository = Program.MF.persistentRepository;
            colTUR.ColumnEdit = Program.MF.ABKrepositoryItemLookUpEdit;
            //colTUR.ColumnEdit = Program.MF.AbmTurRepositoryItemLookUpEdit;
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

        private void AbmXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void AbmXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
                UpdateDB(true);
            else
                UpdateDB();
        }

        private void FillDB()
        {
            string res = "";
            abmGridControl.DataSource = null;
            dataSetAcc.ABM.Rows.Clear();
            Task.Run(async () => { res = await dataSetAcc.ABMfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            abmGridControl.DataSource = abmBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            abmBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (dataSetAcc.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = dataSetAcc.ABMupdate();
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
            dataSetAcc.ABM.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
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

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowKey) == 0)
            {
                readOnly = false;
                gridView1.SetFocusedRowCellValue(colDrm, "P");
                gridView1.SetFocusedRowModified();
                UpdateDB(true);
            }

            object Key = gridView1.GetFocusedRowCellValue(colRowKey);
            AbdXF frm = new AbdXF();
            frm.ABMRow = (AccDataSet.ABMRow)dataSetAcc.ABM.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            frm.readOnly = readOnly;
            var dr = frm.ShowDialog();
            if (!readOnly)
            {
                gridView1.SetFocusedRowCellValue(colDrm, "A");
                UpdateDB(true);
                gridView1.UnselectRow(gridView1.FocusedRowHandle);
            }

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colDrm, "A");
            gridView1.SetFocusedRowCellValue(colKur, 1);

        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var aaa = gridView1.FocusedColumn.Caption;
            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                e.Cancel = true;

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowKey) != 0 && !gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                e.Cancel = true;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView View = sender as GridView;
            var aaa = View.GetRowCellValue(e.RowHandle, colKFT);
            if (View.GetRowCellValue(e.RowHandle, colKFT) == DBNull.Value)
            {
                View.SetColumnError(colKFT, "Hesap girin");
                e.Valid = false;
            }
            else
            {
                View.ClearColumnErrors();
                e.Valid = true;
            }

            if (View.GetRowCellDisplayText(e.RowHandle, colDVT) == "TRL")
            {
                View.SetRowCellValue(e.RowHandle, colKur, 1.0);
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // SelectCheckBox MouseClick ile secilmesini engelle
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.Column?.FieldName == "DX$CheckboxSelectorColumn")
            {
                DXMouseEventArgs ea = DXMouseEventArgs.GetMouseArgs(e);
                ea.Handled = true;
            }
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // SelectCheckBox SpaceBar ile secilmesini engelle
            if (gridView1.FocusedColumn.AbsoluteIndex == -1)
                e.SuppressKeyPress = true;
        }
        private void abmGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            // Ctrl+A ile hepsini secmemesi icin MultiSelect
            if (e.Control && e.KeyValue == 65)
                e.Handled = true;

        }

    }
}