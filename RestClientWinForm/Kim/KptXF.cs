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
    public partial class KptXF : DevExpress.XtraEditors.XtraForm
    {
        public ulong M = 1; // Firma=Sirket

        public KptXF()
        {
            InitializeComponent();
        }

        private void KptXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            kptGridControl.DataSource = null;
            dataSetKim.KPT.Rows.Clear();
            Task.Run(async () => { res = await dataSetKim.KPTfill(M); }).Wait();
            //toolStripStatusLabel1.Text = res;
            kptGridControl.DataSource = kptBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            kptBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (dataSetKim.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = dataSetKim.KPTupdate();
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colKFT, M);
            gridView1.SetFocusedRowCellValue(colYtkAlsNo, 0);
            gridView1.SetFocusedRowCellValue(colYtkStsNo, 0);
            gridView1.SetFocusedRowCellValue(colYtkTrnNo, 0);
        }

        private void haberlesmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            KhtXF frm = new KhtXF();
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);
            frm.Mtyp = "KFT";
            frm.ShowDialog();
        }
    }
}