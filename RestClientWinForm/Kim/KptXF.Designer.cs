namespace RestClientWinForm
{
    partial class KptXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KptXF));
            this.kptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetKim = new RestClientWinForm.DataSetKim();
            this.kptBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.kptGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.haberlesmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colYtkAlsNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYtkStsNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYtkTrnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YtkNoRepositoryItemImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptBindingNavigator)).BeginInit();
            this.kptBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kptGridControl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YtkNoRepositoryItemImageComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kptBindingSource
            // 
            this.kptBindingSource.DataMember = "KPT";
            this.kptBindingSource.DataSource = this.dataSetKim;
            // 
            // dataSetKim
            // 
            this.dataSetKim.DataSetName = "DataSetKim";
            this.dataSetKim.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kptBindingNavigator
            // 
            this.kptBindingNavigator.AddNewItem = null;
            this.kptBindingNavigator.AutoSize = false;
            this.kptBindingNavigator.BindingSource = this.kptBindingSource;
            this.kptBindingNavigator.CountItem = null;
            this.kptBindingNavigator.DeleteItem = null;
            this.kptBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.kptBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton,
            this.editToolStripButton});
            this.kptBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.kptBindingNavigator.MoveFirstItem = null;
            this.kptBindingNavigator.MoveLastItem = null;
            this.kptBindingNavigator.MoveNextItem = null;
            this.kptBindingNavigator.MovePreviousItem = null;
            this.kptBindingNavigator.Name = "kptBindingNavigator";
            this.kptBindingNavigator.PositionItem = null;
            this.kptBindingNavigator.Size = new System.Drawing.Size(720, 30);
            this.kptBindingNavigator.TabIndex = 0;
            this.kptBindingNavigator.Text = "bindingNavigator1";
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
            // kptGridControl
            // 
            this.kptGridControl.ContextMenuStrip = this.contextMenuStrip1;
            this.kptGridControl.DataSource = this.kptBindingSource;
            this.kptGridControl.Location = new System.Drawing.Point(12, 46);
            this.kptGridControl.MainView = this.gridView1;
            this.kptGridControl.Name = "kptGridControl";
            this.kptGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.YtkNoRepositoryItemImageComboBox});
            this.kptGridControl.Size = new System.Drawing.Size(720, 232);
            this.kptGridControl.TabIndex = 0;
            this.kptGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.haberlesmeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // haberlesmeToolStripMenuItem
            // 
            this.haberlesmeToolStripMenuItem.Name = "haberlesmeToolStripMenuItem";
            this.haberlesmeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.haberlesmeToolStripMenuItem.Text = "Haberlesme";
            this.haberlesmeToolStripMenuItem.Click += new System.EventHandler(this.haberlesmeToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKFT,
            this.colRowKey,
            this.colKd,
            this.colAd,
            this.colInfo,
            this.colYtkAlsNo,
            this.colYtkStsNo,
            this.colYtkTrnNo});
            this.gridView1.GridControl = this.kptGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colKFT
            // 
            this.colKFT.FieldName = "KFT";
            this.colKFT.Name = "colKFT";
            this.colKFT.OptionsColumn.ReadOnly = true;
            this.colKFT.Visible = true;
            this.colKFT.VisibleIndex = 0;
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.OptionsColumn.FixedWidth = true;
            this.colRowKey.OptionsColumn.ReadOnly = true;
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 1;
            this.colRowKey.Width = 100;
            // 
            // colKd
            // 
            this.colKd.FieldName = "Kd";
            this.colKd.Name = "colKd";
            this.colKd.Visible = true;
            this.colKd.VisibleIndex = 2;
            this.colKd.Width = 120;
            // 
            // colAd
            // 
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 3;
            this.colAd.Width = 482;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 4;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.kptBindingNavigator);
            this.layoutControl1.Controls.Add(this.kptGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(744, 314);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(720, 20);
            this.statusStrip1.TabIndex = 3;
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
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(744, 314);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.kptGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(724, 236);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.kptBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(724, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 270);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(724, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // colYtkAlsNo
            // 
            this.colYtkAlsNo.Caption = "YtkAlş";
            this.colYtkAlsNo.ColumnEdit = this.YtkNoRepositoryItemImageComboBox;
            this.colYtkAlsNo.FieldName = "YtkAlsNo";
            this.colYtkAlsNo.Name = "colYtkAlsNo";
            this.colYtkAlsNo.Visible = true;
            this.colYtkAlsNo.VisibleIndex = 5;
            // 
            // colYtkStsNo
            // 
            this.colYtkStsNo.Caption = "YtkStş";
            this.colYtkStsNo.ColumnEdit = this.YtkNoRepositoryItemImageComboBox;
            this.colYtkStsNo.FieldName = "YtkStsNo";
            this.colYtkStsNo.Name = "colYtkStsNo";
            this.colYtkStsNo.Visible = true;
            this.colYtkStsNo.VisibleIndex = 6;
            // 
            // colYtkTrnNo
            // 
            this.colYtkTrnNo.Caption = "YtkTrn";
            this.colYtkTrnNo.ColumnEdit = this.YtkNoRepositoryItemImageComboBox;
            this.colYtkTrnNo.FieldName = "YtkTrnNo";
            this.colYtkTrnNo.Name = "colYtkTrnNo";
            this.colYtkTrnNo.Visible = true;
            this.colYtkTrnNo.VisibleIndex = 7;
            // 
            // YtkNoRepositoryItemImageComboBox
            // 
            this.YtkNoRepositoryItemImageComboBox.AutoHeight = false;
            this.YtkNoRepositoryItemImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.YtkNoRepositoryItemImageComboBox.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yetkisiz", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1.Onay", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2.Onay", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3.Onay", 3, -1)});
            this.YtkNoRepositoryItemImageComboBox.Name = "YtkNoRepositoryItemImageComboBox";
            // 
            // KptXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 314);
            this.Controls.Add(this.layoutControl1);
            this.Name = "KptXF";
            this.Text = "Personel [KptXF]";
            this.Load += new System.EventHandler(this.KptXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kptBindingNavigator)).EndInit();
            this.kptBindingNavigator.ResumeLayout(false);
            this.kptBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kptGridControl)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.YtkNoRepositoryItemImageComboBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource kptBindingSource;
        private System.Windows.Forms.BindingNavigator kptBindingNavigator;
        private DevExpress.XtraGrid.GridControl kptGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colKd;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem haberlesmeToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DataSetKim dataSetKim;
        private DevExpress.XtraGrid.Columns.GridColumn colKFT;
        private DevExpress.XtraGrid.Columns.GridColumn colYtkAlsNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox YtkNoRepositoryItemImageComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn colYtkStsNo;
        private DevExpress.XtraGrid.Columns.GridColumn colYtkTrnNo;
    }
}