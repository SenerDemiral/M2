namespace RestClientWinForm
{
    partial class AfdXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AfdXF));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.accDataSet = new RestClientWinForm.AccDataSet();
            this.afdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.afdBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.afdGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjAFB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjAHP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjDvz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DvzRepositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xdkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.colKur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutTL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingNavigator)).BeginInit();
            this.afdBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afdGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvzRepositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
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
            // afdBindingSource
            // 
            this.afdBindingSource.DataMember = "AFD";
            this.afdBindingSource.DataSource = this.accDataSet;
            // 
            // afdBindingNavigator
            // 
            this.afdBindingNavigator.AddNewItem = null;
            this.afdBindingNavigator.AutoSize = false;
            this.afdBindingNavigator.BindingSource = this.afdBindingSource;
            this.afdBindingNavigator.CountItem = null;
            this.afdBindingNavigator.DeleteItem = null;
            this.afdBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.afdBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton});
            this.afdBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.afdBindingNavigator.MoveFirstItem = null;
            this.afdBindingNavigator.MoveLastItem = null;
            this.afdBindingNavigator.MoveNextItem = null;
            this.afdBindingNavigator.MovePreviousItem = null;
            this.afdBindingNavigator.Name = "afdBindingNavigator";
            this.afdBindingNavigator.PositionItem = null;
            this.afdBindingNavigator.Size = new System.Drawing.Size(774, 30);
            this.afdBindingNavigator.TabIndex = 0;
            this.afdBindingNavigator.Text = "bindingNavigator1";
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
            // afdGridControl
            // 
            this.afdGridControl.Location = new System.Drawing.Point(12, 46);
            this.afdGridControl.MainView = this.gridView1;
            this.afdGridControl.Name = "afdGridControl";
            this.afdGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.DvzRepositoryItemLookUpEdit1});
            this.afdGridControl.Size = new System.Drawing.Size(774, 322);
            this.afdGridControl.TabIndex = 0;
            this.afdGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowPk,
            this.colObjAFB,
            this.colObjAHP,
            this.colInfo,
            this.colTut,
            this.colObjDvz,
            this.colKur,
            this.colTutTL});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colTut;
            gridFormatRule1.Name = "FormatAlc";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.MediumVioletRed;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = 0D;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.afdGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRowPk, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView1_CustomDrawFooterCell);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.HiddenEditor += new System.EventHandler(this.gridView1_HiddenEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colRowPk
            // 
            this.colRowPk.Caption = "AFD#";
            this.colRowPk.FieldName = "RowPk";
            this.colRowPk.Name = "colRowPk";
            this.colRowPk.OptionsColumn.ReadOnly = true;
            this.colRowPk.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowPk", "{0}")});
            this.colRowPk.Visible = true;
            this.colRowPk.VisibleIndex = 0;
            this.colRowPk.Width = 65;
            // 
            // colObjAFB
            // 
            this.colObjAFB.Caption = "AFB#";
            this.colObjAFB.FieldName = "ObjAFB";
            this.colObjAFB.Name = "colObjAFB";
            this.colObjAFB.OptionsColumn.ReadOnly = true;
            this.colObjAFB.Visible = true;
            this.colObjAFB.VisibleIndex = 1;
            this.colObjAFB.Width = 59;
            // 
            // colObjAHP
            // 
            this.colObjAHP.Caption = "Hesap";
            this.colObjAHP.FieldName = "ObjAHP";
            this.colObjAHP.Name = "colObjAHP";
            this.colObjAHP.Visible = true;
            this.colObjAHP.VisibleIndex = 2;
            this.colObjAHP.Width = 139;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 7;
            this.colInfo.Width = 212;
            // 
            // colTut
            // 
            this.colTut.AppearanceHeader.Options.UseTextOptions = true;
            this.colTut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTut.DisplayFormat.FormatString = "n";
            this.colTut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTut.FieldName = "Tut";
            this.colTut.MinWidth = 80;
            this.colTut.Name = "colTut";
            this.colTut.Visible = true;
            this.colTut.VisibleIndex = 3;
            this.colTut.Width = 80;
            // 
            // colObjDvz
            // 
            this.colObjDvz.Caption = "Dvz";
            this.colObjDvz.ColumnEdit = this.DvzRepositoryItemLookUpEdit1;
            this.colObjDvz.FieldName = "ObjDvz";
            this.colObjDvz.Name = "colObjDvz";
            this.colObjDvz.Visible = true;
            this.colObjDvz.VisibleIndex = 4;
            this.colObjDvz.Width = 45;
            // 
            // DvzRepositoryItemLookUpEdit1
            // 
            this.DvzRepositoryItemLookUpEdit1.AutoHeight = false;
            this.DvzRepositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DvzRepositoryItemLookUpEdit1.DataSource = this.xdkBindingSource;
            this.DvzRepositoryItemLookUpEdit1.DisplayMember = "Dvz";
            this.DvzRepositoryItemLookUpEdit1.Name = "DvzRepositoryItemLookUpEdit1";
            this.DvzRepositoryItemLookUpEdit1.ValueMember = "ObjDvz";
            this.DvzRepositoryItemLookUpEdit1.EditValueChanged += new System.EventHandler(this.DvzRepositoryItemLookUpEdit1_EditValueChanged);
            // 
            // xdkBindingSource
            // 
            this.xdkBindingSource.DataMember = "XDK";
            this.xdkBindingSource.DataSource = this.mainDataSet;
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colKur
            // 
            this.colKur.AppearanceHeader.Options.UseTextOptions = true;
            this.colKur.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKur.DisplayFormat.FormatString = "n4";
            this.colKur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKur.FieldName = "Kur";
            this.colKur.Name = "colKur";
            this.colKur.Visible = true;
            this.colKur.VisibleIndex = 5;
            this.colKur.Width = 50;
            // 
            // colTutTL
            // 
            this.colTutTL.AppearanceHeader.Options.UseTextOptions = true;
            this.colTutTL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTutTL.DisplayFormat.FormatString = "#,##.00 B;#,##.00 A; ";
            this.colTutTL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTutTL.FieldName = "TutTL";
            this.colTutTL.MinWidth = 100;
            this.colTutTL.Name = "colTutTL";
            this.colTutTL.OptionsColumn.ReadOnly = true;
            this.colTutTL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TutTL", "{0:#,##.00 B;#,##.00 A;B=A}")});
            this.colTutTL.Visible = true;
            this.colTutTL.VisibleIndex = 6;
            this.colTutTL.Width = 106;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 372);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 20);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.statusStrip1);
            this.layoutControl1.Controls.Add(this.afdBindingNavigator);
            this.layoutControl1.Controls.Add(this.afdGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(798, 404);
            this.layoutControl1.TabIndex = 3;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(798, 404);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.afdGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(778, 326);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.afdBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(778, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 360);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(778, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // AfdXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 404);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AfdXF";
            this.Text = "Muhasebe Fiş Detayları [AfdXF]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AfdXF_FormClosing);
            this.Load += new System.EventHandler(this.AfdXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingNavigator)).EndInit();
            this.afdBindingNavigator.ResumeLayout(false);
            this.afdBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afdGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvzRepositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccDataSet accDataSet;
        private System.Windows.Forms.BindingSource afdBindingSource;
        private System.Windows.Forms.BindingNavigator afdBindingNavigator;
        private DevExpress.XtraGrid.GridControl afdGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private DevExpress.XtraGrid.Columns.GridColumn colRowPk;
        private DevExpress.XtraGrid.Columns.GridColumn colObjAFB;
        private DevExpress.XtraGrid.Columns.GridColumn colObjAHP;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colTut;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn colObjDvz;
        private DevExpress.XtraGrid.Columns.GridColumn colKur;
        private DevExpress.XtraGrid.Columns.GridColumn colTutTL;
        private MainDataSet mainDataSet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit DvzRepositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource xdkBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}