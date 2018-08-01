namespace RestClientWinForm
{
    partial class AhpXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AhpXF));
            this.accDataSet = new RestClientWinForm.AccDataSet();
            this.ahpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ahpBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colHspNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAdT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsW = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRowKeyT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasH = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBrc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAlc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingNavigator)).BeginInit();
            this.ahpBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // accDataSet
            // 
            this.accDataSet.DataSetName = "AccDataSet";
            this.accDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ahpBindingSource
            // 
            this.ahpBindingSource.DataMember = "AHP";
            this.ahpBindingSource.DataSource = this.accDataSet;
            // 
            // ahpBindingNavigator
            // 
            this.ahpBindingNavigator.AddNewItem = null;
            this.ahpBindingNavigator.AutoSize = false;
            this.ahpBindingNavigator.CountItem = null;
            this.ahpBindingNavigator.DeleteItem = null;
            this.ahpBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.ahpBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.toolStripSeparator2,
            this.deleteToolStripButton,
            this.toolStripSeparator3,
            this.refreshToolStripButton,
            this.toolStripSeparator4,
            this.revertToolStripButton});
            this.ahpBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.ahpBindingNavigator.MoveFirstItem = null;
            this.ahpBindingNavigator.MoveLastItem = null;
            this.ahpBindingNavigator.MoveNextItem = null;
            this.ahpBindingNavigator.MovePreviousItem = null;
            this.ahpBindingNavigator.Name = "ahpBindingNavigator";
            this.ahpBindingNavigator.PositionItem = null;
            this.ahpBindingNavigator.Size = new System.Drawing.Size(886, 30);
            this.ahpBindingNavigator.TabIndex = 0;
            this.ahpBindingNavigator.Text = "bindingNavigator1";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // revertToolStripButton
            // 
            this.revertToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.revertToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("revertToolStripButton.Image")));
            this.revertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revertToolStripButton.Name = "revertToolStripButton";
            this.revertToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.revertToolStripButton.Text = "toolStripButton6";
            this.revertToolStripButton.Click += new System.EventHandler(this.revertToolStripButton_Click);
            // 
            // treeList1
            // 
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colHspNoT,
            this.colNoT,
            this.colAdT,
            this.colIsW,
            this.colRowKeyT,
            this.colPT,
            this.colHasH,
            this.colBrc,
            this.colAlc});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.ahpBindingSource;
            this.treeList1.KeyFieldName = "RowKey";
            this.treeList1.Location = new System.Drawing.Point(12, 46);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsBehavior.ImmediateEditor = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeList1.OptionsFind.AllowFindPanel = true;
            this.treeList1.OptionsFind.FindFilterColumns = "HspNo;Ad";
            this.treeList1.OptionsNavigation.AutoFocusNewNode = true;
            this.treeList1.OptionsNavigation.UseTabKey = true;
            this.treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.ParentFieldName = "P";
            this.treeList1.Size = new System.Drawing.Size(886, 400);
            this.treeList1.TabIndex = 7;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            // 
            // colHspNoT
            // 
            this.colHspNoT.Caption = "HspNo";
            this.colHspNoT.FieldName = "HspNo";
            this.colHspNoT.Name = "colHspNoT";
            this.colHspNoT.OptionsColumn.ReadOnly = true;
            this.colHspNoT.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colHspNoT.Visible = true;
            this.colHspNoT.VisibleIndex = 3;
            this.colHspNoT.Width = 146;
            // 
            // colNoT
            // 
            this.colNoT.FieldName = "Kd";
            this.colNoT.Name = "colNoT";
            this.colNoT.Visible = true;
            this.colNoT.VisibleIndex = 0;
            this.colNoT.Width = 112;
            // 
            // colAdT
            // 
            this.colAdT.FieldName = "Ad";
            this.colAdT.Name = "colAdT";
            this.colAdT.Visible = true;
            this.colAdT.VisibleIndex = 2;
            this.colAdT.Width = 291;
            // 
            // colIsW
            // 
            this.colIsW.FieldName = "IsW";
            this.colIsW.Name = "colIsW";
            this.colIsW.Visible = true;
            this.colIsW.VisibleIndex = 1;
            // 
            // colRowKeyT
            // 
            this.colRowKeyT.Caption = "Key";
            this.colRowKeyT.FieldName = "RowKey";
            this.colRowKeyT.Name = "colRowKeyT";
            this.colRowKeyT.OptionsColumn.ReadOnly = true;
            this.colRowKeyT.Visible = true;
            this.colRowKeyT.VisibleIndex = 4;
            this.colRowKeyT.Width = 89;
            // 
            // colPT
            // 
            this.colPT.Caption = "ObjP";
            this.colPT.FieldName = "P";
            this.colPT.Name = "colPT";
            this.colPT.OptionsColumn.ReadOnly = true;
            this.colPT.Visible = true;
            this.colPT.VisibleIndex = 5;
            this.colPT.Width = 89;
            // 
            // colHasH
            // 
            this.colHasH.Caption = "H";
            this.colHasH.FieldName = "HasH";
            this.colHasH.Name = "colHasH";
            this.colHasH.OptionsColumn.FixedWidth = true;
            this.colHasH.OptionsColumn.ReadOnly = true;
            this.colHasH.Visible = true;
            this.colHasH.VisibleIndex = 6;
            this.colHasH.Width = 28;
            // 
            // colBrc
            // 
            this.colBrc.FieldName = "Brc";
            this.colBrc.Format.FormatString = "n";
            this.colBrc.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBrc.Name = "colBrc";
            this.colBrc.OptionsColumn.AllowFocus = false;
            this.colBrc.OptionsColumn.ReadOnly = true;
            this.colBrc.Visible = true;
            this.colBrc.VisibleIndex = 7;
            // 
            // colAlc
            // 
            this.colAlc.FieldName = "Alc";
            this.colAlc.Format.FormatString = "n";
            this.colAlc.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAlc.Name = "colAlc";
            this.colAlc.OptionsColumn.AllowFocus = false;
            this.colAlc.OptionsColumn.ReadOnly = true;
            this.colAlc.Visible = true;
            this.colAlc.VisibleIndex = 8;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.ahpBindingNavigator);
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1010, 283, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(910, 482);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(886, 20);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(910, 482);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeList1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(890, 404);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ahpBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(890, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 438);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(890, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // AhpXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 482);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AhpXF";
            this.Text = "Hesap Planı [AhpXF]";
            this.Load += new System.EventHandler(this.AhpXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingNavigator)).EndInit();
            this.ahpBindingNavigator.ResumeLayout(false);
            this.ahpBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccDataSet accDataSet;
        private System.Windows.Forms.BindingSource ahpBindingSource;
        private System.Windows.Forms.BindingNavigator ahpBindingNavigator;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHspNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAdT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRowKeyT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasH;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsW;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBrc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAlc;
    }
}