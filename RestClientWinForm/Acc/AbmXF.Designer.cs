namespace RestClientWinForm
{
    partial class AbmXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmXF));
            this.abmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAcc = new RestClientWinForm.DataSetAcc();
            this.abmBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abmGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colABK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.faturaDetayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.abmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abmBindingNavigator)).BeginInit();
            this.abmBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // abmBindingSource
            // 
            this.abmBindingSource.DataMember = "ABM";
            this.abmBindingSource.DataSource = this.dataSetAcc;
            // 
            // dataSetAcc
            // 
            this.dataSetAcc.DataSetName = "DataSetAcc";
            this.dataSetAcc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // abmBindingNavigator
            // 
            this.abmBindingNavigator.AddNewItem = null;
            this.abmBindingNavigator.AutoSize = false;
            this.abmBindingNavigator.BindingSource = this.abmBindingSource;
            this.abmBindingNavigator.CountItem = null;
            this.abmBindingNavigator.DeleteItem = null;
            this.abmBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.abmBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton,
            this.editToolStripButton});
            this.abmBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.abmBindingNavigator.MoveFirstItem = null;
            this.abmBindingNavigator.MoveLastItem = null;
            this.abmBindingNavigator.MoveNextItem = null;
            this.abmBindingNavigator.MovePreviousItem = null;
            this.abmBindingNavigator.Name = "abmBindingNavigator";
            this.abmBindingNavigator.PositionItem = null;
            this.abmBindingNavigator.Size = new System.Drawing.Size(825, 30);
            this.abmBindingNavigator.TabIndex = 0;
            this.abmBindingNavigator.Text = "bindingNavigator1";
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
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
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
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 27);
            this.editToolStripButton.Text = "toolStripButton1";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // abmGridControl
            // 
            this.abmGridControl.DataSource = this.abmBindingSource;
            this.abmGridControl.Location = new System.Drawing.Point(12, 46);
            this.abmGridControl.MainView = this.gridView1;
            this.abmGridControl.Name = "abmGridControl";
            this.abmGridControl.Size = new System.Drawing.Size(825, 241);
            this.abmGridControl.TabIndex = 2;
            this.abmGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.abmGridControl.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.abmGridControl_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colDrm,
            this.colTrh,
            this.colABK,
            this.colKFT,
            this.colBA,
            this.colDVT,
            this.colKur,
            this.colInfo,
            this.colTut,
            this.colKd,
            this.colAd});
            this.gridView1.GridControl = this.abmGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 1;
            // 
            // colDrm
            // 
            this.colDrm.FieldName = "Drm";
            this.colDrm.Name = "colDrm";
            this.colDrm.Visible = true;
            this.colDrm.VisibleIndex = 2;
            // 
            // colTrh
            // 
            this.colTrh.FieldName = "Trh";
            this.colTrh.Name = "colTrh";
            this.colTrh.Visible = true;
            this.colTrh.VisibleIndex = 3;
            // 
            // colABK
            // 
            this.colABK.Caption = "Tür";
            this.colABK.FieldName = "ABK";
            this.colABK.Name = "colABK";
            this.colABK.Visible = true;
            this.colABK.VisibleIndex = 4;
            // 
            // colKFT
            // 
            this.colKFT.Caption = "Firma KFT";
            this.colKFT.FieldName = "KFT";
            this.colKFT.Name = "colKFT";
            this.colKFT.Visible = true;
            this.colKFT.VisibleIndex = 5;
            this.colKFT.Width = 78;
            // 
            // colBA
            // 
            this.colBA.FieldName = "BA";
            this.colBA.Name = "colBA";
            this.colBA.Visible = true;
            this.colBA.VisibleIndex = 6;
            // 
            // colDVT
            // 
            this.colDVT.Caption = "Dvz DVT";
            this.colDVT.FieldName = "DVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.Visible = true;
            this.colDVT.VisibleIndex = 7;
            this.colDVT.Width = 88;
            // 
            // colKur
            // 
            this.colKur.FieldName = "Kur";
            this.colKur.Name = "colKur";
            this.colKur.Visible = true;
            this.colKur.VisibleIndex = 8;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 10;
            // 
            // colTut
            // 
            this.colTut.FieldName = "Tut";
            this.colTut.Name = "colTut";
            this.colTut.Visible = true;
            this.colTut.VisibleIndex = 9;
            // 
            // colKd
            // 
            this.colKd.FieldName = "Kd";
            this.colKd.Name = "colKd";
            this.colKd.Visible = true;
            this.colKd.VisibleIndex = 11;
            // 
            // colAd
            // 
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 12;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.abmBindingNavigator);
            this.layoutControl1.Controls.Add(this.abmGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(849, 323);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 20);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(849, 323);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.abmGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(829, 245);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.abmBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(829, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 279);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(829, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faturaDetayToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 26);
            // 
            // faturaDetayToolStripMenuItem
            // 
            this.faturaDetayToolStripMenuItem.Name = "faturaDetayToolStripMenuItem";
            this.faturaDetayToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.faturaDetayToolStripMenuItem.Text = "Fatura Detay";
            this.faturaDetayToolStripMenuItem.Click += new System.EventHandler(this.faturaDetayToolStripMenuItem_Click);
            // 
            // AbmXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 323);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AbmXF";
            this.Text = "Faturalar [AbmXF]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbmXF_FormClosing);
            this.Load += new System.EventHandler(this.AbmXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.abmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abmBindingNavigator)).EndInit();
            this.abmBindingNavigator.ResumeLayout(false);
            this.abmBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource abmBindingSource;
        private System.Windows.Forms.BindingNavigator abmBindingNavigator;
        private DevExpress.XtraGrid.GridControl abmGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colDrm;
        private DevExpress.XtraGrid.Columns.GridColumn colTrh;
        private DevExpress.XtraGrid.Columns.GridColumn colABK;
        private DevExpress.XtraGrid.Columns.GridColumn colKFT;
        private DevExpress.XtraGrid.Columns.GridColumn colBA;
        private DevExpress.XtraGrid.Columns.GridColumn colKur;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colTut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem faturaDetayToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colKd;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DataSetAcc dataSetAcc;
    }
}