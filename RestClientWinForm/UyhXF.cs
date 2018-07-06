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
    public partial class UyhXF : DevExpress.XtraEditors.XtraForm
    {
        public UyhXF()
        {
            InitializeComponent();
        }

        private void UyhXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            mainDataSet.UYH.Clear();
            Task.Run(async () => { res = await mainDataSet.UYHfill(); }).Wait();
            //MessageBox.Show(res);
            //toolStripStatusLabel1.Text = res;

            treeList1.ExpandAll();
            //treeList1.ExpandToLevel(0);
            treeList1.MoveFirst();
        }

    }
}