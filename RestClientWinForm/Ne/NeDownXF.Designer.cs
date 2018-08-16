namespace RestClientWinForm
{
    partial class NeDownXF
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
            this.neDownBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetNe = new RestClientWinForm.DataSetNe();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colA = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colF = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasKid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUreten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calcTopMikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcFiyatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.neDownBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neDownBindingSource
            // 
            this.neDownBindingSource.DataMember = "NeDown";
            this.neDownBindingSource.DataSource = this.dataSetNe;
            // 
            // dataSetNe
            // 
            this.dataSetNe.DataSetName = "DataSetNe";
            this.dataSetNe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colL,
            this.colA,
            this.colN,
            this.colM,
            this.colP,
            this.colK,
            this.colMT,
            this.colF,
            this.treeListColumn1,
            this.colHasKid,
            this.colUreten});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.neDownBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "K";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "P";
            this.treeList1.Size = new System.Drawing.Size(619, 318);
            this.treeList1.TabIndex = 2;
            this.treeList1.HiddenEditor += new System.EventHandler(this.treeList1_HiddenEditor);
            this.treeList1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.treeList1_ShowingEditor);
            // 
            // colL
            // 
            this.colL.FieldName = "L";
            this.colL.Name = "colL";
            this.colL.Visible = true;
            this.colL.VisibleIndex = 4;
            this.colL.Width = 63;
            // 
            // colA
            // 
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
            this.colN.Visible = true;
            this.colN.VisibleIndex = 7;
            this.colN.Width = 64;
            // 
            // colM
            // 
            this.colM.FieldName = "M";
            this.colM.Format.FormatString = "n";
            this.colM.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colM.Name = "colM";
            this.colM.Visible = true;
            this.colM.VisibleIndex = 1;
            this.colM.Width = 64;
            // 
            // colP
            // 
            this.colP.FieldName = "P";
            this.colP.Name = "colP";
            this.colP.Visible = true;
            this.colP.VisibleIndex = 5;
            // 
            // colK
            // 
            this.colK.FieldName = "K";
            this.colK.Name = "colK";
            this.colK.Visible = true;
            this.colK.VisibleIndex = 6;
            // 
            // colMT
            // 
            this.colMT.FieldName = "MT";
            this.colMT.Format.FormatString = "n";
            this.colMT.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMT.Name = "colMT";
            // 
            // colF
            // 
            this.colF.FieldName = "F";
            this.colF.Format.FormatString = "n";
            this.colF.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colF.Name = "colF";
            this.colF.Visible = true;
            this.colF.VisibleIndex = 2;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "T";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.Format.FormatString = "n";
            this.treeListColumn1.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.UnboundExpression = "[M] * [F]";
            this.treeListColumn1.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Decimal;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 3;
            // 
            // colHasKid
            // 
            this.colHasKid.FieldName = "HasKid";
            this.colHasKid.Name = "colHasKid";
            this.colHasKid.Visible = true;
            this.colHasKid.VisibleIndex = 8;
            // 
            // colUreten
            // 
            this.colUreten.Caption = "Üreten(ler)";
            this.colUreten.FieldName = "Ureten";
            this.colUreten.Name = "colUreten";
            this.colUreten.Visible = true;
            this.colUreten.VisibleIndex = 9;
            this.colUreten.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcTopMikToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.collapseToolStripMenuItem,
            this.calcFiyatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 92);
            // 
            // calcTopMikToolStripMenuItem
            // 
            this.calcTopMikToolStripMenuItem.Name = "calcTopMikToolStripMenuItem";
            this.calcTopMikToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.calcTopMikToolStripMenuItem.Text = "Calc TopMik";
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // calcFiyatToolStripMenuItem
            // 
            this.calcFiyatToolStripMenuItem.Name = "calcFiyatToolStripMenuItem";
            this.calcFiyatToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.calcFiyatToolStripMenuItem.Text = "Calc Fiyat";
            this.calcFiyatToolStripMenuItem.Click += new System.EventHandler(this.calcFiyatToolStripMenuItem_Click);
            // 
            // NeDownXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 318);
            this.Controls.Add(this.treeList1);
            this.Name = "NeDownXF";
            this.Text = "NeDownXF";
            this.Load += new System.EventHandler(this.NeDownXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neDownBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource neDownBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calcTopMikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colF;
        private System.Windows.Forms.ToolStripMenuItem calcFiyatToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasKid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUreten;
        private DataSetNe dataSetNe;
    }
}