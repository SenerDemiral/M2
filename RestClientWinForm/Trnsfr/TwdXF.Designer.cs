namespace RestClientWinForm
{
    partial class TwdXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwdXF));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.twdBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.twdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetTrnsfr = new RestClientWinForm.DataSetTrnsfr();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.twdGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twdBindingNavigator)).BeginInit();
            this.twdBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTrnsfr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twdGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.twdBindingNavigator);
            this.layoutControl1.Controls.Add(this.twdGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(949, 333);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 20);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // twdBindingNavigator
            // 
            this.twdBindingNavigator.AddNewItem = null;
            this.twdBindingNavigator.AutoSize = false;
            this.twdBindingNavigator.BindingSource = this.twdBindingSource;
            this.twdBindingNavigator.CountItem = null;
            this.twdBindingNavigator.DeleteItem = null;
            this.twdBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.twdBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton,
            this.editToolStripButton});
            this.twdBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.twdBindingNavigator.MoveFirstItem = null;
            this.twdBindingNavigator.MoveLastItem = null;
            this.twdBindingNavigator.MoveNextItem = null;
            this.twdBindingNavigator.MovePreviousItem = null;
            this.twdBindingNavigator.Name = "twdBindingNavigator";
            this.twdBindingNavigator.PositionItem = null;
            this.twdBindingNavigator.Size = new System.Drawing.Size(925, 30);
            this.twdBindingNavigator.TabIndex = 2;
            this.twdBindingNavigator.Text = "bindingNavigator1";
            // 
            // twdBindingSource
            // 
            this.twdBindingSource.DataMember = "TWD";
            this.twdBindingSource.DataSource = this.dataSetTrnsfr;
            // 
            // dataSetTrnsfr
            // 
            this.dataSetTrnsfr.DataSetName = "DataSetTrnsfr";
            this.dataSetTrnsfr.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.addToolStripButton.Text = "Add";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.saveToolStripButton.Text = "Save";
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
            // twdGridControl
            // 
            this.twdGridControl.DataSource = this.twdBindingSource;
            this.twdGridControl.Location = new System.Drawing.Point(12, 46);
            this.twdGridControl.MainView = this.gridView1;
            this.twdGridControl.Name = "twdGridControl";
            this.twdGridControl.Size = new System.Drawing.Size(925, 251);
            this.twdGridControl.TabIndex = 0;
            this.twdGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colTOM,
            this.colKd,
            this.colAd,
            this.colInfo});
            this.gridView1.GridControl = this.twdGridControl;
            this.gridView1.Name = "gridView1";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(949, 333);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.twdGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(929, 255);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.twdBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(929, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 289);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(929, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 0;
            // 
            // colTOM
            // 
            this.colTOM.FieldName = "TOM";
            this.colTOM.Name = "colTOM";
            this.colTOM.Visible = true;
            this.colTOM.VisibleIndex = 1;
            // 
            // colKd
            // 
            this.colKd.FieldName = "Kd";
            this.colKd.Name = "colKd";
            this.colKd.Visible = true;
            this.colKd.VisibleIndex = 2;
            // 
            // colAd
            // 
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 3;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 4;
            // 
            // TwdXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 333);
            this.Controls.Add(this.layoutControl1);
            this.Name = "TwdXF";
            this.Text = "TwdXF";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twdBindingNavigator)).EndInit();
            this.twdBindingNavigator.ResumeLayout(false);
            this.twdBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTrnsfr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twdGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DataSetTrnsfr dataSetTrnsfr;
        private System.Windows.Forms.BindingSource twdBindingSource;
        private System.Windows.Forms.BindingNavigator twdBindingNavigator;
        private DevExpress.XtraGrid.GridControl twdGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colTOM;
        private DevExpress.XtraGrid.Columns.GridColumn colKd;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
    }
}