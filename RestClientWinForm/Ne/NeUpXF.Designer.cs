namespace RestClientWinForm
{
    partial class NeUpXF
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
            this.neUpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colA = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colF = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calcTopMikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetNe = new RestClientWinForm.DataSetNe();
            ((System.ComponentModel.ISupportInitialize)(this.neUpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).BeginInit();
            this.SuspendLayout();
            // 
            // neUpBindingSource
            // 
            this.neUpBindingSource.DataMember = "NeUp";
            this.neUpBindingSource.DataSource = this.dataSetNe;
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
            this.colF});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.neUpBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "K";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "P";
            this.treeList1.Size = new System.Drawing.Size(632, 349);
            this.treeList1.TabIndex = 1;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
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
            this.colMT.Visible = true;
            this.colMT.VisibleIndex = 2;
            // 
            // colF
            // 
            this.colF.FieldName = "F";
            this.colF.Format.FormatString = "n";
            this.colF.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colF.Name = "colF";
            this.colF.Visible = true;
            this.colF.VisibleIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcTopMikToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.collapseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 70);
            // 
            // calcTopMikToolStripMenuItem
            // 
            this.calcTopMikToolStripMenuItem.Name = "calcTopMikToolStripMenuItem";
            this.calcTopMikToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.calcTopMikToolStripMenuItem.Text = "Calc TopMik";
            this.calcTopMikToolStripMenuItem.Click += new System.EventHandler(this.calcTopMikToolStripMenuItem_Click);
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
            // dataSetNe
            // 
            this.dataSetNe.DataSetName = "DataSetNe";
            this.dataSetNe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NeUpXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 349);
            this.Controls.Add(this.treeList1);
            this.Name = "NeUpXF";
            this.Text = "NeUpXF";
            this.Load += new System.EventHandler(this.NeUpXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neUpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource neUpBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calcTopMikToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMT;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colF;
        private DataSetNe dataSetNe;
    }
}