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
    public partial class KdtXF : DevExpress.XtraEditors.XtraForm
    {
        public KdtXF()
        {
            InitializeComponent();
        }

        private void KdtXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            kdtGridControl.DataSource = null;
            mainDataSet.KDT.Clear();
            Task.Run(async () => { res = await mainDataSet.KDTfill(); }).Wait();
            //toolStripStatusLabel1.Text = res;
            kdtGridControl.DataSource = kdtBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            kdtBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (mainDataSet.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.KDTupdate();
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
        }

        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            ToBrXF frm = new ToBrXF();
            frm.Text = $"{gridView1.GetFocusedRowCellValue(colAd)} Departman Personeli";

            frm.Mtyp = "KDT";
            frm.Dtyp = "KPT";
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);

            frm.ShowDialog();

        }

        private void urunlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            ToBrXF frm = new ToBrXF();
            frm.Text = $"{gridView1.GetFocusedRowCellValue(colAd)} Departman Üretimleri";

            frm.Mtyp = "KDT";
            frm.Dtyp = "NNN";
            frm.M = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);

            frm.ShowDialog();

        }

        private void haberlesmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gridView1.IsDataRow(gridView1.FocusedRowHandle))
                return;

            ToKhtXF frm = new ToKhtXF();
            frm.P = (ulong)gridView1.GetFocusedRowCellValue(colRowKey);
            frm.Ptyp = "KDT";
            frm.ShowDialog();
        }
    }
}