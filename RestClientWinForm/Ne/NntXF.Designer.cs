namespace RestClientWinForm
{
    partial class NnnXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NnnXF));
            this.nnnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetNe = new RestClientWinForm.DataSetNe();
            this.nnnBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nnnGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uretenDepartmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBRM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFyt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.nnnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nnnBindingNavigator)).BeginInit();
            this.nnnBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnnGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // nnnBindingSource
            // 
            this.nnnBindingSource.DataMember = "NNT";
            this.nnnBindingSource.DataSource = this.dataSetNe;
            // 
            // dataSetNe
            // 
            this.dataSetNe.DataSetName = "DataSetNe";
            this.dataSetNe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nnnBindingNavigator
            // 
            this.nnnBindingNavigator.AddNewItem = null;
            this.nnnBindingNavigator.AutoSize = false;
            this.nnnBindingNavigator.BindingSource = this.nnnBindingSource;
            this.nnnBindingNavigator.CountItem = null;
            this.nnnBindingNavigator.DeleteItem = null;
            this.nnnBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.nnnBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton,
            this.editToolStripButton});
            this.nnnBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.nnnBindingNavigator.MoveFirstItem = null;
            this.nnnBindingNavigator.MoveLastItem = null;
            this.nnnBindingNavigator.MoveNextItem = null;
            this.nnnBindingNavigator.MovePreviousItem = null;
            this.nnnBindingNavigator.Name = "nnnBindingNavigator";
            this.nnnBindingNavigator.PositionItem = null;
            this.nnnBindingNavigator.Size = new System.Drawing.Size(740, 30);
            this.nnnBindingNavigator.TabIndex = 0;
            this.nnnBindingNavigator.Text = "bindingNavigator1";
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
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.editToolStripButton.Text = "toolStripButton1";
            // 
            // nnnGridControl
            // 
            this.nnnGridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.nnnGridControl.DataSource = this.nnnBindingSource;
            this.nnnGridControl.Location = new System.Drawing.Point(12, 46);
            this.nnnGridControl.MainView = this.gridView1;
            this.nnnGridControl.Name = "nnnGridControl";
            this.nnnGridControl.Size = new System.Drawing.Size(740, 230);
            this.nnnGridControl.TabIndex = 1;
            this.nnnGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uretenDepartmanToolStripMenuItem,
            this.relationsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 48);
            // 
            // uretenDepartmanToolStripMenuItem
            // 
            this.uretenDepartmanToolStripMenuItem.Name = "uretenDepartmanToolStripMenuItem";
            this.uretenDepartmanToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.uretenDepartmanToolStripMenuItem.Text = "Üretim Departmanları";
            this.uretenDepartmanToolStripMenuItem.Click += new System.EventHandler(this.uretenDepartmanToolStripMenuItem_Click);
            // 
            // relationsToolStripMenuItem
            // 
            this.relationsToolStripMenuItem.Name = "relationsToolStripMenuItem";
            this.relationsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.relationsToolStripMenuItem.Text = "Relations";
            this.relationsToolStripMenuItem.Click += new System.EventHandler(this.relationsToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colKd,
            this.colAd,
            this.colBRM,
            this.colFyt});
            this.gridView1.GridControl = this.nnnGridControl;
            this.gridView1.Name = "gridView1";
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
            // colKd
            // 
            this.colKd.FieldName = "Kd";
            this.colKd.Name = "colKd";
            this.colKd.Visible = true;
            this.colKd.VisibleIndex = 1;
            // 
            // colAd
            // 
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 2;
            // 
            // colBRM
            // 
            this.colBRM.FieldName = "BRM";
            this.colBRM.Name = "colBRM";
            this.colBRM.Visible = true;
            this.colBRM.VisibleIndex = 3;
            // 
            // colFyt
            // 
            this.colFyt.FieldName = "Fyt";
            this.colFyt.Name = "colFyt";
            this.colFyt.Visible = true;
            this.colFyt.VisibleIndex = 4;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.nnnBindingNavigator);
            this.layoutControl1.Controls.Add(this.nnnGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(569, 114, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(764, 312);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 280);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 20);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(764, 312);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.nnnGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(744, 234);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.nnnBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(744, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 268);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(744, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // NnnXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 312);
            this.Controls.Add(this.layoutControl1);
            this.Name = "NnnXF";
            this.Text = "Ne [NntXF]";
            this.Load += new System.EventHandler(this.NntXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nnnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nnnBindingNavigator)).EndInit();
            this.nnnBindingNavigator.ResumeLayout(false);
            this.nnnBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnnGridControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private System.Windows.Forms.BindingSource nnnBindingSource;
        private System.Windows.Forms.BindingNavigator nnnBindingNavigator;
        private DevExpress.XtraGrid.GridControl nnnGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colKd;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colBRM;
        private DevExpress.XtraGrid.Columns.GridColumn colFyt;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uretenDepartmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem relationsToolStripMenuItem;
        private DataSetNe dataSetNe;
    }
}