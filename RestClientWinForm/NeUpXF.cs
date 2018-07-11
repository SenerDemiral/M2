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
    public partial class NeUpXF : DevExpress.XtraEditors.XtraForm
    {
        public NeUpXF()
        {
            InitializeComponent();
        }

        private void NeUpXF_Load(object sender, EventArgs e)
        {
            string res = "";
            Task.Run(async () => { res = await mainDataSet.NeUpFill(); }).Wait();

        }

        private void calcTopMikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var table = mainDataSet.NeUp;
            /*
            DataRow[] dr0 = table.Select($"L = 0");
            foreach (var r0 in dr0)
                r0["MT"] = 1;
*/
            for (int L = 1; L < 10; L++)
            {
                DataRow[] dr = table.Select($"L = {L}");
                foreach (var r in dr)
                {
                    var pR = table.FindByK((int)r["P"]);
                    r["MT"] = (double)r["M"] * (double)pR["MT"];

                }
            }
            /*
             foreach (DataRow row in mainDataSet.NeUp.Rows)
            {
                if((int)row["P"] != 0)
                {
                    var pRow = mainDataSet.NeUp.FindByK((int)row["P"]);
                    row["N"] = (double)row["M"] * (double)pRow["M"];
                }
            }*/
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

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
    }
}