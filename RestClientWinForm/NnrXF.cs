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
    public partial class NnrXF : DevExpress.XtraEditors.XtraForm
    {
        public ulong P = 0;

        public NnrXF()
        {
            InitializeComponent();

            nnrGridControl.ExternalRepository = Program.MF.persistentRepository;
            //colNC.ColumnEdit = Program.MF.NNNrepositoryItemLookUpEdit;
            colNC.ColumnEdit = Program.MF.NNNrepositoryItemGridLookUpEdit;


        }

        private void NnrXF_Load(object sender, EventArgs e)
        {
            // KKK.TUR deki F yi bul
            //DataRow[] xgtRows = Program.MF.mainDataSet.XGT.Select($"P = {Program.MF.XgtDic["KKK.TUR"]} AND Kd = 'F'");
            //ObjTur = xgtRows[0]["RowKey"];

            Task.Run(async () => { await mainDataSet.NeParentsFill(P); }).Wait();
            string parents = mainDataSet.NeParents.Rows[0]["Parents"].ToString();
            ulong key = 0;
            foreach(DataRow row in Program.MF.mainDataSet.NNN.Rows)
            {
                key = (ulong)row["RowKey"];
                row["Avl"] = true;
                if(parents.Contains($"<{key}>"))
                   row["Avl"] = false;
            }

            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            nnrGridControl.DataSource = null;
            mainDataSet.KFT.Clear();
            Task.Run(async () => { res = await mainDataSet.NNRfill(P); }).Wait();
            toolStripStatusLabel1.Text = res;
            nnrGridControl.DataSource = nnrBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            nnrBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (mainDataSet.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.NNNupdate();
                    gridView1.UnselectRow(gridView1.FocusedRowHandle);
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
        }

    }
}