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

namespace RestClientWinForm
{
    public partial class AfdXF : DevExpress.XtraEditors.XtraForm
    {
        public object ObjAFB = (ulong)469;
        public int AfbRowIndex;
        public AccDataSet.AFBRow AFBRow;
        private object ObjDvzTRL;


        public AfdXF()
        {
            InitializeComponent();

            afdGridControl.ExternalRepository = Program.MF.persistentRepository;
            //colObjAHP.ColumnEdit = Program.MF.AHPrepositoryItemSearchLookUpEdit;
            colObjAHP.ColumnEdit = Program.MF.AHPrepositoryItemTreeListLookUpEdit;
            //colObjDvz.ColumnEdit = Program.MF.DvzRepositoryItemLookUpEdit;
        }

        private void AfdXF_Load(object sender, EventArgs e)
        {
            ObjAFB = AFBRow.RowPk;
            if (AFBRow.AoK == "K")
            {
                gridView1.OptionsBehavior.ReadOnly = true;
                Text += " Kapalı";
            }

            QryProxy qp = new QryProxy
            {
                Query = "Trh",
                Param = AFBRow.Trh.Ticks.ToString(),
            };
            Task.Run(async () => { await mainDataSet.XDKfill(qp); }).Wait();

            DataRow[] xdkRows = mainDataSet.XDK.Select("Dvz = 'TRL'");
            ObjDvzTRL = xdkRows[0]["ObjDvz"];

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
            // No:    Update var kaydetmedi

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
            gridView1.SetFocusedRowCellValue(colObjDvz, ObjDvzTRL);
            gridView1.SetFocusedRowCellValue(colTut, 0.0);
            gridView1.SetFocusedRowCellValue(colKur, 1.0);
        }

        private void DvzRepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //var aaa = (sender as LookUpEdit).EditValue;
            DataRowView drv = (DataRowView)(sender as LookUpEdit).GetSelectedDataRow();
            //var ccc = (drv.Row as MainDataSet.XDKRow).Kur;
            var kur = (float)drv.Row["Kur"];
            gridView1.SetFocusedRowCellValue(colKur, kur);
            ComputeRow();
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
                gridView1.UpdateSummary();
            }

        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName == "TutTL" && (double)e.Info.Value < 0)
            {
                e.Appearance.ForeColor = Color.MediumVioletRed;
            }
        }

    }
}