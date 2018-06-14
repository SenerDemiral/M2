﻿using System;
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
            afbGridControl.DataSource = null;
            accDataSet.AFB.Clear();
            Task.Run(async () => { res = await accDataSet.AFBfill(); }).Wait();
            toolStripStatusLabel1.Text = res;
            afbGridControl.DataSource = afbBindingSource;
        }

        private bool UpdateDB()
        {
            gridView1.PostEditor();
            //gridView1.CloseEditor();
            //gridView1.SetFocusedRowModified();
            gridView1.UpdateCurrentRow();
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

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //accDataSet.AFB.Rows[0].SetModified();
            UpdateDB();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
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
            accDataSet.AFB.Rows[gridView1.GetFocusedDataSourceRowIndex()].RejectChanges();
        }
    }
}