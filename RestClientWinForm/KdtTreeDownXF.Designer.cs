namespace RestClientWinForm
{
    partial class KdtTreeDownXF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.kdtTreeDownBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colA = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdtTreeDownBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kdtTreeDownBindingSource
            // 
            this.kdtTreeDownBindingSource.DataMember = "KdtTreeDown";
            this.kdtTreeDownBindingSource.DataSource = this.mainDataSet;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colL,
            this.colA,
            this.colN,
            this.colP,
            this.colK});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.kdtTreeDownBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "K";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "P";
            this.treeList1.Size = new System.Drawing.Size(661, 318);
            this.treeList1.TabIndex = 3;
            // 
            // colL
            // 
            this.colL.FieldName = "L";
            this.colL.Name = "colL";
            this.colL.Width = 63;
            // 
            // colA
            // 
            this.colA.Caption = "Departman";
            this.colA.FieldName = "A";
            this.colA.Name = "colA";
            this.colA.Visible = true;
            this.colA.VisibleIndex = 0;
            this.colA.Width = 64;
            // 
            // colN
            // 
            this.colN.FieldName = "N";
            this.colN.Name = "colN";
            this.colN.Width = 64;
            // 
            // colP
            // 
            this.colP.FieldName = "P";
            this.colP.Name = "colP";
            // 
            // colK
            // 
            this.colK.FieldName = "K";
            this.colK.Name = "colK";
            // 
            // KdtTreeDownXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 318);
            this.Controls.Add(this.treeList1);
            this.Name = "KdtTreeDownXF";
            this.Text = "Departman Hiyerarşi [KdtTreeDownXF]";
            this.Load += new System.EventHandler(this.KdtTreeDownXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdtTreeDownBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource kdtTreeDownBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colK;
    }
}