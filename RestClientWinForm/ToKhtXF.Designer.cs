namespace RestClientWinForm
{
    partial class ToKhtXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToKhtXF));
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.toKHTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toKHTBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toKHTGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSkl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOncelik = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTBindingNavigator)).BeginInit();
            this.toKHTBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toKHTBindingSource
            // 
            this.toKHTBindingSource.DataMember = "ToKHT";
            this.toKHTBindingSource.DataSource = this.mainDataSet;
            // 
            // toKHTBindingNavigator
            // 
            this.toKHTBindingNavigator.AddNewItem = null;
            this.toKHTBindingNavigator.AutoSize = false;
            this.toKHTBindingNavigator.BindingSource = this.toKHTBindingSource;
            this.toKHTBindingNavigator.CountItem = null;
            this.toKHTBindingNavigator.DeleteItem = null;
            this.toKHTBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.toKHTBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton});
            this.toKHTBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.toKHTBindingNavigator.MoveFirstItem = null;
            this.toKHTBindingNavigator.MoveLastItem = null;
            this.toKHTBindingNavigator.MoveNextItem = null;
            this.toKHTBindingNavigator.MovePreviousItem = null;
            this.toKHTBindingNavigator.Name = "toKHTBindingNavigator";
            this.toKHTBindingNavigator.PositionItem = null;
            this.toKHTBindingNavigator.Size = new System.Drawing.Size(719, 30);
            this.toKHTBindingNavigator.TabIndex = 1;
            this.toKHTBindingNavigator.Text = "bindingNavigator1";
            // 
            // toKHTGridControl
            // 
            this.toKHTGridControl.DataSource = this.toKHTBindingSource;
            this.toKHTGridControl.Location = new System.Drawing.Point(12, 46);
            this.toKHTGridControl.MainView = this.gridView1;
            this.toKHTGridControl.Name = "toKHTGridControl";
            this.toKHTGridControl.Size = new System.Drawing.Size(719, 223);
            this.toKHTGridControl.TabIndex = 0;
            this.toKHTGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colP,
            this.colKd,
            this.colAd,
            this.colSkl,
            this.colOncelik});
            this.gridView1.GridControl = this.toKHTGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.OptionsColumn.FixedWidth = true;
            this.colRowKey.OptionsColumn.ReadOnly = true;
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 0;
            // 
            // colP
            // 
            this.colP.FieldName = "P";
            this.colP.Name = "colP";
            this.colP.OptionsColumn.FixedWidth = true;
            this.colP.OptionsColumn.ReadOnly = true;
            this.colP.Visible = true;
            this.colP.VisibleIndex = 1;
            // 
            // colKd
            // 
            this.colKd.FieldName = "Kd";
            this.colKd.Name = "colKd";
            this.colKd.Visible = true;
            this.colKd.VisibleIndex = 4;
            // 
            // colAd
            // 
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 3;
            // 
            // colSkl
            // 
            this.colSkl.FieldName = "Skl";
            this.colSkl.Name = "colSkl";
            this.colSkl.Visible = true;
            this.colSkl.VisibleIndex = 2;
            // 
            // colOncelik
            // 
            this.colOncelik.FieldName = "Oncelik";
            this.colOncelik.Name = "colOncelik";
            this.colOncelik.Visible = true;
            this.colOncelik.VisibleIndex = 5;
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
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.deleteToolStripButton.Text = "Delete";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.refreshToolStripButton.Text = "Refresh";
            // 
            // revertToolStripButton
            // 
            this.revertToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.revertToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("revertToolStripButton.Image")));
            this.revertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revertToolStripButton.Name = "revertToolStripButton";
            this.revertToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.revertToolStripButton.Text = "toolStripButton6";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.toKHTBindingNavigator);
            this.layoutControl1.Controls.Add(this.toKHTGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(743, 305);
            this.layoutControl1.TabIndex = 2;
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
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(743, 305);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.toKHTGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(723, 227);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.toKHTBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(723, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 273);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 20);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 261);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(723, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ToKhtXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 305);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ToKhtXF";
            this.Text = "KftKhtXF";
            this.Load += new System.EventHandler(this.KhtXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTBindingNavigator)).EndInit();
            this.toKHTBindingNavigator.ResumeLayout(false);
            this.toKHTBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toKHTGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource toKHTBindingSource;
        private System.Windows.Forms.BindingNavigator toKHTBindingNavigator;
        private DevExpress.XtraGrid.GridControl toKHTGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colP;
        private DevExpress.XtraGrid.Columns.GridColumn colKd;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colSkl;
        private DevExpress.XtraGrid.Columns.GridColumn colOncelik;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}