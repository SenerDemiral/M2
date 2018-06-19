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
using Rest;

namespace RestClientWinForm
{
    public partial class XdkXF : DevExpress.XtraEditors.XtraForm
    {
        public XdkXF()
        {
            InitializeComponent();

            xdkGridControl.ExternalRepository = Program.MF.persistentRepository;
            colObjDvz.ColumnEdit = Program.MF.DvzRepositoryItemLookUpEdit;

            dateEdit1.DateTime = DateTime.Today;
        }

        private void FillDB()
        {
            string res = "";
            xdkGridControl.DataSource = null;
            mainDataSet.XDK.Clear();

            gridView1.OptionsBehavior.ReadOnly = false;
            QryProxy qp = new QryProxy();
            qp.Query = "Trh";
            qp.Param = dateEdit1.DateTime.Ticks.ToString();
            if (qp.Param == "0")
            {
                qp.Query = "";
                gridView1.OptionsBehavior.ReadOnly = true;
            }
            Task.Run(async () => { res = await mainDataSet.XDKfill(qp); }).Wait();
            toolStripStatusLabel1.Text = res;
            xdkGridControl.DataSource = xdkBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (mainDataSet.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.XDKupdate();
                    if (err != string.Empty)
                    {
                        MessageBox.Show(err);
                        dr = DialogResult.Abort;
                    }
                }
            }

            return dr;
        }

        private void XdkXF_Load(object sender, EventArgs e)
        {
            FillDB();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateDB();

        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (UpdateDB() != DialogResult.Abort)
                FillDB();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.GetFocusedRowCellDisplayText(colObjDvz) == "TRL")
                e.Cancel = true;

        }
    }
}