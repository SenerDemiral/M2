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
    public partial class AhpEditXF : DevExpress.XtraEditors.XtraForm
    {
        public BindingSource bs;
        public DataTable dt;
        public DataRow dr;
        public int id;
        public object ObjP;
        public AccDataSet ds;

        public AhpEditXF()
        {
            InitializeComponent();
        }

        private void AhpEditXF_Load(object sender, EventArgs e)
        {
            dataLayoutControl1.DataSource = bs;
            bs.AddNew();
            ObjPTextEdit.Text = ObjP.ToString();
            var aaa = bs.Current;
            //layoutView1.FocusedRowHandle = layoutView1.GetRowHandle(id);
        }

        private void AhpEditXF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ds.AHPupdate();
            //if (ds.AHP.HasErrors)
            bs.EndEdit();
            string err = ds.AHPupdate();
            if (err != string.Empty)
            {
                e.Cancel = true;
                MessageBox.Show(err);
            }

            //bs.CancelEdit();

        }
    }
}