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
    public partial class TomXF : DevExpress.XtraEditors.XtraForm
    {
        public TomXF()
        {
            InitializeComponent();

            GridLocalizer.Active = new CustomGridLocalizer();

            gridView1.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused;
            gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False;
            gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

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

        private void TomXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void TomXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
                UpdateDB(true);
            else
                UpdateDB();
        }

        private void FillDB()
        {
            string res = "";
            tomGridControl.DataSource = null;
            dataSetTrnsfr.TOM.Rows.Clear();
            Task.Run(async () => { res = await dataSetTrnsfr.TOMfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            tomGridControl.DataSource = tomBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (dataSetTrnsfr.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = dataSetTrnsfr.TOMupdate();
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
            dataSetTrnsfr.TOM.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            /*
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
            */
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.IsRowSelected(e.PrevFocusedRowHandle))
            {
                UpdateDB(true);
                gridView1.UnselectRow(e.PrevFocusedRowHandle);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            /*
            if ((ulong)gridView1.GetFocusedRowCellValue(colORG) != 0)   // Otomatik uretilmis
                e.Cancel = true;

            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                e.Cancel = true;

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowKey) != 0 && !gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                e.Cancel = true;
                */
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            /*
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colTrh, DateTime.Today);
            gridView1.SetFocusedRowCellValue(colDrm, "A");
            */
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
        private void tomGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            // Ctrl+A ile hepsini secmemesi icin MultiSelect
            if (e.Control && e.KeyValue == 65)
                e.Handled = true;

        }

    }
}