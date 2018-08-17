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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraGrid.Localization;

namespace RestClientWinForm
{
    public partial class AvmXF : DevExpress.XtraEditors.XtraForm
    {
        public AvmXF()
        {
            InitializeComponent();

            GridLocalizer.Active = new CustomGridLocalizer();

            avmGridControl.ExternalRepository = Program.MF.persistentRepository;
            colTUR.ColumnEdit = Program.MF.AvkLrepositoryItemLookUpEdit;
            colTrh.ColumnEdit = Program.MF.DateRepositoryItemDateEdit;

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = false;
            gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False;
            // Ctrl+A ile hepsini secmemesini engelle
            // MouseClick ve SpaceBar ile secilmesini engelle
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

        private void AvmXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void AvmXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
                UpdateDB(true);
            else
                UpdateDB();
        }

        private void FillDB()
        {
            string res = "";
            avmGridControl.DataSource = null;
            dataSetAcc.AVM.Rows.Clear();
            Task.Run(async () => { res = await dataSetAcc.AVMfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            avmGridControl.DataSource = avmBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (dataSetAcc.HasChanges())
            {
                if(silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = dataSetAcc.AVMupdate();
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
            if(UpdateDB() != DialogResult.Abort)
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
            dataSetAcc.AVM.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
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

        private void fisDetayToolStripMenuItem_Click(object sender, EventArgs e)
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
            AvdXF frm = new AvdXF();
            frm.AVMRow = (AccDataSet.AVMRow)dataSetAcc.AVM.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            frm.readOnly = readOnly;
            var dr = frm.ShowDialog();
            if (!readOnly)
            {
                gridView1.SetFocusedRowCellValue(colDrm, "A");
                UpdateDB(true);
                gridView1.UnselectRow(gridView1.FocusedRowHandle);
            }

            /*
            //var prxy = dataSetAcc.AFBgetByPK((ulong)Key);
            //string sonDrm = prxy.Drm;

            if (sonDrm == "P") // Baska bir tarafindan degistirilyor, Revert
            {
                XtraMessageBox.Show("Baska bir tarafindan degistirilyor", "Fis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (sonDrm == "A")
            {
                gridView1.SetFocusedRowCellValue(colDrm, "P");  // Mark pending
                UpdateDB(true);

            }
            AfdXF frm = new AfdXF();
            frm.AFBRow = (AccDataSet.AFBRow)dataSetAcc.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            var dr = frm.ShowDialog();
            if (sonDrm == "A") // && dr == DialogResult.Yes)
            {
                //dataSetAcc.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].SetModified();
                gridView1.SetFocusedRowCellValue(colDrm, "A");  // Pending Mark kaldir
                UpdateDB(true);
            }
            */
            /*
            UpdateDB();
            // Update'den sonra refresh oldugu icin son deger gelir ama Drm da degisir!!
            // Update etmeden Drm kontrol edilmeli, AFB okunduktan sonra baska biri degistirmis olabilir!!

            AfdXF frm = new AfdXF();
            frm.AFBRow = (AccDataSet.AFBRow)dataSetAcc.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            var dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                dataSetAcc.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].SetModified();
                UpdateDB(true);
            }
            */
            //gridView1.SetFocusedRowModified();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var aaa = gridView1.FocusedColumn.Caption;

            if ((ulong)gridView1.GetFocusedRowCellValue(colORG) != 0)   // Otomatik uretilmis
                e.Cancel = true;

            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                e.Cancel = true;

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowKey) != 0 && !gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                e.Cancel = true;
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colTrh, DateTime.Today);
            gridView1.SetFocusedRowCellValue(colDrm, "A");
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
        private void avmGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            // Ctrl+A ile hepsini secmemesi icin MultiSelect
            if (e.Control && e.KeyValue == 65)
                e.Handled = true;

        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToolStripButton.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editToolStripButton.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }
    }
}