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

namespace RestClientWinForm
{
    public partial class TwdXF : DevExpress.XtraEditors.XtraForm
    {
        public object M = (ulong)0;
        public DataSetTrnsfr.TWMRow MRow;
        public bool readOnly = true;

        public TwdXF()
        {
            InitializeComponent();

            twdGridControl.ExternalRepository = Program.MF.persistentRepository;
        }

        private void TwdXF_Load(object sender, EventArgs e)
        {
            M = MRow.RowKey;
            if (readOnly)
            {
                gridView1.OptionsBehavior.ReadOnly = true;
                twdBindingNavigator.Enabled = !readOnly;
                Text += " Kapalı";
            }
            /*
            QryProxy qp = new QryProxy
            {
                Query = "Trh",
                Param = TOMRow.Trh.Ticks.ToString(),
            };
            Task.Run(async () => { await dataSetGnl.XDKfill(qp); }).Wait();

            DataRow[] xdkRows = dataSetGnl.XDK.Select("Dvz = 'TRL'");
            ObjDvzTRL = xdkRows[0]["DVT"];
            */
            FillDB();
        }

        private void TwdXF_FormClosing(object sender, FormClosingEventArgs e)
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
            twdGridControl.DataSource = null;
            dataSetTrnsfr.TOD.Rows.Clear();
            Task.Run(async () => { res = await dataSetTrnsfr.TWDfill((ulong)M); }).Wait();
            toolStripStatusLabel1.Text = res;
            twdGridControl.DataSource = twdBindingSource;
        }

        private DialogResult UpdateDB()
        {
            if (!Validate())
                return DialogResult.Cancel;
            twdBindingSource.EndEdit();

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.OK;

            // Ok:    No change
            // Yes:   Update succesfull
            // Abort: Hata
            // No:    Update var kaydetmedi

            if (dataSetTrnsfr.HasChanges())
            {
                dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = dataSetTrnsfr.TODupdate();
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
            dataSetTrnsfr.TOD.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colTOM, M);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;
            //if (View.GetFocusedRowCellDisplayText(colDVT) == "TRL" && View.FocusedColumn == colKur)
            //    e.Cancel = true;
        }

    }
}