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
    public partial class AfdXF : DevExpress.XtraEditors.XtraForm
    {
        public object ObjAFB = (ulong)350;

        public AfdXF()
        {
            InitializeComponent();
        }

        private void FillDB()
        {
            string res = "";
            afdGridControl.DataSource = null;
            accDataSet.AFD.Clear();
            Task.Run(async () => { res = await accDataSet.AFDfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            afdGridControl.DataSource = afdBindingSource;
        }

        private bool UpdateDB()
        {
            gridView1.PostEditor();
            //gridView1.CloseEditor();
            //gridView1.SetFocusedRowModified();
            gridView1.UpdateCurrentRow();
            string err = accDataSet.AFDupdate();
            if (err != string.Empty)
            {
                MessageBox.Show(err);
                return false;
            }
            return true;
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
            if (accDataSet.HasChanges())
            {
                var res = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Refresh", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.Yes)
                    UpdateDB();
            }
            FillDB();
        }

        private void revertToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            accDataSet.AFD.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }
    }
}