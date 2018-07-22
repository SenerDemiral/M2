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
    public partial class ToKhtXF : DevExpress.XtraEditors.XtraForm
    {
        public ulong P = 0;
        public string Ptyp = "";

        public ToKhtXF()
        {
            InitializeComponent();
        }

        private void KhtXF_Load(object sender, EventArgs e)
        {
            // KKK.TUR deki F yi bul
            //DataRow[] xgtRows = Program.MF.mainDataSet.XGT.Select($"P = {Program.MF.XgtDic["KKK.TUR"]} AND Kd = 'F'");
            //ObjTur = xgtRows[0]["RowKey"];

            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            toKHTGridControl.DataSource = null;
            mainDataSet.KFT.Clear();
            Task.Run(async () => { res = await mainDataSet.ToKHTfill(P, Ptyp); }).Wait();
            //toolStripStatusLabel1.Text = res;
            toKHTGridControl.DataSource = toKHTBindingSource;
        }

        private DialogResult UpdateDB()
        {
            if (!Validate())
                return DialogResult.Cancel;
            toKHTBindingSource.EndEdit();

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.OK;

            // Ok:    No change
            // Yes:   Update succesfull
            // Abort: Hata
            // No:    Update var kaydetmedi

            if (mainDataSet.HasChanges())
            {
                dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.ToKHTupdate();
                    if (err != string.Empty)
                    {
                        MessageBox.Show(err);
                        dr = DialogResult.Abort;
                    }
                }
            }
            return dr;
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colRowKey, 0);
            gridView1.SetFocusedRowCellValue(colP, P);

        }


    }
}