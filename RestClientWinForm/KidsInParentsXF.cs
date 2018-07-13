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
    public partial class KidsInParentsXF : DevExpress.XtraEditors.XtraForm
    {
        public KidsInParentsXF()
        {
            InitializeComponent();
        }

        private void KidsInParentsXF_Load(object sender, EventArgs e)
        {
            string res = "";
            Task.Run(async () => { res = await mainDataSet.KidsInParentsFill(); }).Wait();

        }
    }
}