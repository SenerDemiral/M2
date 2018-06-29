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
            object rowPk = gridView1.GetFocusedRowCellValue(colRowPk);
            var prxy = accDataSet.AFBgetByPK((ulong)rowPk);
            string sonDrm = prxy.Drm;

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
            frm.AFBRow = (AccDataSet.AFBRow)accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            var dr = frm.ShowDialog();
            if (sonDrm == "A") // && dr == DialogResult.Yes)
            {
                //accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].SetModified();
                gridView1.SetFocusedRowCellValue(colDrm, "A");  // Pending Mark kaldir
                UpdateDB(true);
            }
            /*
            UpdateDB();
            // Update'den sonra refresh oldugu icin son deger gelir ama Drm da degisir!!
            // Update etmeden Drm kontrol edilmeli, AFB okunduktan sonra baska biri degistirmis olabilir!!

            AfdXF frm = new AfdXF();
            frm.AFBRow = (AccDataSet.AFBRow)accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()];
            var dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].SetModified();
                UpdateDB(true);
            }
            */
            //gridView1.SetFocusedRowModified();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var aaa = gridView1.FocusedColumn.Caption;
            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                e.Cancel = true;

            if ((ulong)gridView1.GetFocusedRowCellValue(colRowPk) != 0 && !gridView1.IsRowSelected(gridView1.FocusedRowHandle))
                e.Cancel = true;
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(colDrm).ToString() == "K")
                return;

            gridView1.SetFocusedRowCellValue(colDrm, "P");
            gridView1.SetFocusedRowModified();

            if (UpdateDB(true) != DialogResult.Abort)
            {
                gridView1.SetFocusedRowCellValue(colDrm, "A");
                //gridView1.OptionsBehavior.Editable = true;
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

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            /*
            if (e.Column.FieldName == "DX$CheckboxSelectorColumn")
            {
                GridView gv = (GridView)sender;
                string sApproved = gv.GetRowCellValue(e.RowHandle, gv.Columns[9]).ToString();
                if (sApproved == "1")
                {
                    e.RepositoryItem.ReadOnly = true;
                }
            }*/
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.Column.FieldName == "DX$CheckboxSelectorColumn")
            {
                DXMouseEventArgs ea = DXMouseEventArgs.GetMouseArgs(e);
                ea.Handled = true;
            }

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.FocusedColumn.AbsoluteIndex == -1)
                e.SuppressKeyPress = true;
        }

        private void AfbXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
                UpdateDB(true);
            else
                UpdateDB();
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowPk, 0);
            gridView1.SetFocusedRowCellValue(colTrh, DateTime.Today);
            gridView1.SetFocusedRowCellValue(colDrm, "A");
        }

    }
}