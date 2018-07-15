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

        private void calcFiyatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var table = mainDataSet.NeDown;
            /*
            DataRow[] dr0 = table.Select($"L = 0");
            foreach (var r0 in dr0)
                r0["MT"] = 1;
            */
            foreach(DataRow r in table.Rows)
            {
                if ((bool)r["HasKid"])
                    r["F"] = 0;
            }

            double f = 0;
            for (int L = 9; L > 0; L--)
            {
                DataRow[] dr = table.Select($"L = {L}");
                foreach (var r in dr)
                {
                    var pR = table.FindByK((int)r["P"]);
                    f = (double)r["M"] * (double)r["F"];
                    pR["F"] = (double)pR["F"] + f;

                }
            }

        }

        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (treeList1.FocusedColumn == colF && !treeList1.FocusedNode.HasChildren)
                e.Cancel = false;
            else if (treeList1.FocusedColumn == colKim)
                e.Cancel = false;
            else
                e.Cancel = true;
            /*
            if (treeList1.FocusedNode.HasChildren)
            {
                e.Cancel = true;
            }
            if (treeList1.FocusedColumn != colF)
            {
                e.Cancel = true;
            }*/
        }

        private void treeList1_HiddenEditor(object sender, EventArgs e)
        {
            if (treeList1.FocusedColumn == colF)
            {
                double f = 0;
                f = (double)treeList1.FocusedNode.GetValue(colF);
                var cr = mainDataSet.NeDown.Rows[treeList1.FocusedNode.Id];
                var n = cr["N"];    // Ne.ObjNo
                DataRow[] dr = mainDataSet.NeDown.Select($"N = {n}");
                foreach (var r in dr)
                {
                    r["F"] = f;
                }
                calcFiyatToolStripMenuItem.PerformClick();
            }
            if (treeList1.FocusedColumn == colKim)
            {
                string kim = treeList1.FocusedNode.GetValue(colKim).ToString();
                var cr = mainDataSet.NeDown.Rows[treeList1.FocusedNode.Id];
                var n = cr["N"];    // Ne.ObjNo
                DataRow[] dr = mainDataSet.NeDown.Select($"N = {n}");
                foreach (var r in dr)
                {
                    r["Kim"] = kim;
                }
            }
        }
    }
}