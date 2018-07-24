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
using Rest;
using DevExpress.XtraGrid.Views.Grid;

namespace RestClientWinForm
{
    public partial class AvdXF : DevExpress.XtraEditors.XtraForm
    {
        public object ObjAVM = (ulong)469;
        public AccDataSet.AVMRow AVMRow;
        public bool readOnly = true;
        private object ObjDvzTRL;


        public AvdXF()
        {
            InitializeComponent();

            avdGridControl.ExternalRepository = Program.MF.persistentRepository;
            //colObjAHP.ColumnEdit = Program.MF.AHPrepositoryItemSearchLookUpEdit;
            colAHP.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;
            colDVT.ColumnEdit = Program.MF.DVTrepositoryItemLookUpEdit;
        }

        private void AvdXF_Load(object sender, EventArgs e)
        {
            ObjAVM = AVMRow.RowKey;
            if (readOnly)
            {
                gridView1.OptionsBehavior.ReadOnly = true;
                avdBindingNavigator.Enabled = !readOnly;
                Text += " Kapalı";
            }

            QryProxy qp = new QryProxy
            {
                Query = "Trh",
                Param = AVMRow.Trh.Ticks.ToString(),
            };
            Task.Run(async () => { await mainDataSet.XDKfill(qp); }).Wait();

            DataRow[] xdkRows = mainDataSet.XDK.Select("Dvz = 'TRL'");
            ObjDvzTRL = xdkRows[0]["DVT"];

            FillDB();
        }

        private void AvdXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (readOnly)
                return;

            DialogResult dr = UpdateDB();
            if (dr == DialogResult.Cancel)
                e.Cancel = true;
            else
                DialogResult = DialogResult.Yes;
        }

        private void FillDB()
        {
            string res = "";
            avdGridControl.DataSource = null;
            accDataSet.AVD.Clear();
            Task.Run(async () => { res = await accDataSet.AVDfill((ulong)ObjAVM); }).Wait();
            toolStripStatusLabel1.Text = res;
            avdGridControl.DataSource = avdBindingSource;
        }

        private DialogResult UpdateDB()
        {
            if (!Validate())
                return DialogResult.Cancel;
            avdBindingSource.EndEdit();

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.OK;

            // Ok:    No change
            // Yes:   Update succesfull
            // Abort: Hata
            // No:    Update var kaydetmedi

            if (accDataSet.HasChanges())
            {
                dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = accDataSet.AVDupdate();
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
            accDataSet.AVD.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colAVM, ObjAVM);
            gridView1.SetFocusedRowCellValue(colDVT, ObjDvzTRL);
            gridView1.SetFocusedRowCellValue(colTut, 0.0);
            gridView1.SetFocusedRowCellValue(colKur, 1.0);
        }

        private void DVTrepositoryItemLookUpEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var editValue = (sender as LookUpEdit).EditValue;
            var oldEditValue = (sender as LookUpEdit).OldEditValue;
            if (editValue != oldEditValue)
            {
                DataRowView drv = (DataRowView)(sender as LookUpEdit).GetSelectedDataRow();
                gridView1.SetFocusedRowCellValue(colKur, drv.Row["Kur"]);

                // Bu da calisiyor
                //DataRow[] xdkRows = mainDataSet.XDK.Select($"ObjDvz = {editValue}");
                //gridView1.SetFocusedRowCellValue(colKur, xdkRows[0]["Kur"]);

                ///ComputeRow();
            }
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            ComputeRow();
        }

        private void ComputeRow()
        {
            object tut = gridView1.GetFocusedRowCellValue(colTut);
            object kur = gridView1.GetFocusedRowCellValue(colKur);
            if (tut != DBNull.Value && kur != DBNull.Value)
            {
                double tutTL = Math.Round((double)tut * (float)kur, 2);
                gridView1.SetFocusedRowCellValue(colTutTL, tutTL);
                //gridView1.PostEditor();
                gridView1.UpdateCurrentRow();
                gridView1.UpdateSummary();
            }
        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Info != null)
            {
                if (e.Column.FieldName == "TutTL" && (double)e.Info?.Value < 0)
                {
                    e.Appearance.ForeColor = Color.MediumVioletRed;
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView View = sender as GridView;
            var aaa = View.GetRowCellValue(e.RowHandle, colAHP);
            if (View.GetRowCellValue(e.RowHandle, colAHP) == DBNull.Value)
            {
                View.SetColumnError(colAHP, "Hesap girin");
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
                View.SetRowCellValue(e.RowHandle, colTutTL, View.GetRowCellValue(e.RowHandle, colTut));
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;
            if (View.GetFocusedRowCellDisplayText(colDVT) == "TRL" && View.FocusedColumn == colKur)
                e.Cancel = true;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addToolStripButton.PerformClick();
        }
    }
}