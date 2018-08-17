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
    public partial class ToBrXF : DevExpress.XtraEditors.XtraForm
    {
        public ulong M = 0;
        public string Mtyp = "";
        public string Dtyp = "";
        bool IsP2C = false;


        public ToBrXF()
        {
            InitializeComponent();

            brGridControl.ExternalRepository = Program.MF.persistentRepository;
        }

        private void ToBrXF_Load(object sender, EventArgs e)
        {
            Text += " [ToBrXF]";    // Text geldigi yerde hazirlaniyor.
            if (string.Compare(Mtyp, Dtyp) <= 0)
                IsP2C = true;

            Task.Run(async () => { await mainDataSet.BRparentsFill(M); }).Wait();
            string parents = mainDataSet.BrParents.Rows[0]["Parents"].ToString();
            ulong key = 0;
            foreach (DataRow row in Program.MF.dataSetLookup.KDTL.Rows)
            {
                key = (ulong)row["RowKey"];
                row["Avl"] = true;
                if (parents.Contains($"<{key}>"))
                    row["Avl"] = false;
            }

            if (Mtyp == "KDT" && Dtyp == "KDT")
            {
                if (IsP2C)
                {
                    colC.ColumnEdit = Program.MF.KdtLrepositoryItemGridLookUpEdit;
                    colC.Caption = "Alt Departmanlar";
                    colOthers.Caption = "Diğer Üst Departmanları";
                    colP.OptionsColumn.ReadOnly = true;
                    colP.Visible = false;
                }
            }
            else if (Dtyp == "KDT")
            {
                if (IsP2C)
                {
                    colC.ColumnEdit = Program.MF.KdtLrepositoryItemGridLookUpEdit;
                    colC.Caption = "Üretim Departmanı";
                    colOthers.Caption = "Diğer Ürünleri";
                    colP.OptionsColumn.ReadOnly = true;
                    colP.Visible = false;
                }
                else
                {
                    colP.ColumnEdit = Program.MF.KdtLrepositoryItemGridLookUpEdit;
                    colP.Caption = "Üretim Departmanı";
                    colOthers.Caption = "Diğer Ürünleri";
                    colC.OptionsColumn.ReadOnly = true;
                    colC.Visible = false;
                }
            }
            else if (Dtyp == "KPT")
            {
                if (IsP2C)
                {
                    colC.ColumnEdit = Program.MF.KptLrepositoryItemGridLookUpEdit;
                    colC.Caption = "Personel";
                    colOthers.Caption = "Diğer Departmanları";
                    colP.OptionsColumn.ReadOnly = true;
                    colP.Visible = false;
                }
                else
                {
                    colP.ColumnEdit = Program.MF.KptLrepositoryItemGridLookUpEdit;
                    colP.Caption = "Personel";
                    colOthers.Caption = "Diğer Departmanları";
                    colC.OptionsColumn.ReadOnly = true;
                    colC.Visible = false;
                }
            }
            else if (Dtyp == "NNN")
            {
                if (IsP2C)
                {
                    colC.ColumnEdit = Program.MF.NntLrepositoryItemGridLookUpEdit;
                    colC.Caption = "Ürün";
                    colOthers.Caption = "Diğer Departmanları";
                    colP.OptionsColumn.ReadOnly = true;
                    colP.Visible = false;
                }
                else
                {
                    colP.ColumnEdit = Program.MF.NntLrepositoryItemGridLookUpEdit;
                    colP.Caption = "Ürün";
                    colOthers.Caption = "Diğer Departmanları";
                    colC.OptionsColumn.ReadOnly = true;
                    colC.Visible = false;
                }
            }

            FillDB();
        }

        private void FillDB()
        {
            string res = "";
            brGridControl.DataSource = null;
            mainDataSet.BR.Rows.Clear();
            Task.Run(async () => { res = await mainDataSet.BRfill(M, Mtyp, Dtyp); }).Wait();
            //toolStripStatusLabel1.Text = res;
            brGridControl.DataSource = brBindingSource;
        }

        private DialogResult UpdateDB(bool silent = false)
        {
            if (!Validate())
                return DialogResult.Cancel;
            brBindingSource.EndEdit();

            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            DialogResult dr = DialogResult.Yes;
            if (mainDataSet.HasChanges())
            {
                if (silent == false)
                    dr = XtraMessageBox.Show("Değişiklik var. Kaydetmek istiyormusunuz?", "Update", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    string err = mainDataSet.BRupdate();
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
            if(IsP2C)
                gridView1.SetFocusedRowCellValue(colP, M);
            else
                gridView1.SetFocusedRowCellValue(colC, M);

        }

    }
}