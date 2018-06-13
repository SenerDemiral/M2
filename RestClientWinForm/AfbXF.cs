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
    public partial class AfbXF : DevExpress.XtraEditors.XtraForm
    {
        public AfbXF()
        {
            InitializeComponent();
        }

        private void FillDB()
        {
            string res = "";
            aFBGridControl.DataSource = null;
            accDataSet.AFB.Clear();
            Task.Run(async () => { res = await accDataSet.AFBfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            aFBGridControl.DataSource = aFBBindingSource;
        }

        private bool UpdateDB()
        {
            //aHPBindingSource.EndEdit();
            gridView1.PostEditor();
            string err = accDataSet.AFBupdate();
            if (err != string.Empty)
            {
                MessageBox.Show(err);
                return false;
            }
            return true;
        }

        private void AfbXF_Load(object sender, EventArgs e)
        {
            //FillDB();
        }

        private void aFBBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            accDataSet.AFB.Rows[0].SetModified();


        }
    }
}