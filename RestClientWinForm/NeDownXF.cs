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
    public partial class NeDownXF : DevExpress.XtraEditors.XtraForm
    {
        public NeDownXF()
        {
            InitializeComponent();
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeList1.ExpandAll();
            treeList1.BestFitColumns();

        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeList1.CollapseAll();

        }

        private void NeDownXF_Load(object sender, EventArgs e)
        {
            string res = "";
            Task.Run(async () => { res = await mainDataSet.NeDownFill(); }).Wait();

        }
    }
}