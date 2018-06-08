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
            this.aHPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aHPBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aHPBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colHspNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAdT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRowPkT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colObjPT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingNavigator)).BeginInit();
            this.aHPBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // accDataSet
            // 
            this.accDataSet.DataSetName = "AccDataSet";
            this.accDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aHPBindingSource
            // 
            this.aHPBindingSource.DataMember = "AHP";
            this.aHPBindingSource.DataSource = this.accDataSet;
            // 
            // aHPBindingNavigator
            // 
            this.aHPBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.aHPBindingNavigator.AutoSize = false;
            this.aHPBindingNavigator.BindingSource = this.aHPBindingSource;
            this.aHPBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.aHPBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.aHPBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.aHPBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.aHPBindingNavigatorSaveItem});
            this.aHPBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.aHPBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.aHPBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.aHPBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.aHPBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.aHPBindingNavigator.Name = "aHPBindingNavigator";
            this.aHPBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.aHPBindingNavigator.Size = new System.Drawing.Size(886, 30);
            this.aHPBindingNavigator.TabIndex = 0;
            this.aHPBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 27);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // aHPBindingNavigatorSaveItem
            // 
            this.aHPBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aHPBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("aHPBindingNavigatorSaveItem.Image")));
            this.aHPBindingNavigatorSaveItem.Name = "aHPBindingNavigatorSaveItem";
            this.aHPBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 27);
            this.aHPBindingNavigatorSaveItem.Text = "Save Data";
            this.aHPBindingNavigatorSaveItem.Click += new System.EventHandler(this.aHPBindingNavigatorSaveItem_Click);
            // 
            // treeList1
            // 
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colHspNoT,
            this.colNoT,
            this.colAdT,
            this.colRowPkT,
            this.colObjPT});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.aHPBindingSource;
            this.treeList1.KeyFieldName = "RowPk";
            this.treeList1.Location = new System.Drawing.Point(12, 62);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeList1.OptionsFind.AllowFindPanel = true;
            this.treeList1.OptionsFind.FindFilterColumns = "HspNo;Ad";
            this.treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.ParentFieldName = "ObjP";
            this.treeList1.Size = new System.Drawing.Size(886, 380);
            this.treeList1.TabIndex = 7;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            // 
            // colHspNoT
            // 
            this.colHspNoT.FieldName = "HspNo";
            this.colHspNoT.Name = "colHspNoT";
            this.colHspNoT.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colHspNoT.Visible = true;
            this.colHspNoT.VisibleIndex = 0;
            this.colHspNoT.Width = 125;
            // 
            // colNoT
            // 
            this.colNoT.FieldName = "No";
            this.colNoT.Name = "colNoT";
            this.colNoT.Visible = true;
            this.colNoT.VisibleIndex = 1;
            this.colNoT.Width = 125;
            // 
            // colAdT
            // 
            this.colAdT.FieldName = "Ad";
            this.colAdT.Name = "colAdT";
            this.colAdT.Visible = true;
            this.colAdT.VisibleIndex = 2;
            this.colAdT.Width = 125;
            // 
            // colRowPkT
            // 
            this.colRowPkT.FieldName = "RowPk";
            this.colRowPkT.Name = "colRowPkT";
            this.colRowPkT.Visible = true;
            this.colRowPkT.VisibleIndex = 3;
            this.colRowPkT.Width = 124;
            // 
            // colObjPT
            // 
            this.colObjPT.FieldName = "ObjP";
            this.colObjPT.Name = "colObjPT";
            this.colObjPT.Visible = true;
            this.colObjPT.VisibleIndex = 4;
            this.colObjPT.Width = 124;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(97, 26);
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.yeniToolStripMenuItem.Text = "Yeni";
            this.yeniToolStripMenuItem.Click += new System.EventHandler(this.yeniToolStripMenuItem_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.aHPBindingNavigator);
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
            this.layoutControlItem1.Size = new System.Drawing.Size(890, 400);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.aHPBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(890, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(886, 24);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 434);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(890, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // AhpXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 482);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AhpXF";
            this.Text = "AhpXF";
            this.Load += new System.EventHandler(this.AhpXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingNavigator)).EndInit();
            this.aHPBindingNavigator.ResumeLayout(false);
            this.aHPBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccDataSet accDataSet;
        private System.Windows.Forms.BindingSource aHPBindingSource;
        private System.Windows.Forms.BindingNavigator aHPBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton aHPBindingNavigatorSaveItem;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHspNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAdT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRowPkT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colObjPT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}