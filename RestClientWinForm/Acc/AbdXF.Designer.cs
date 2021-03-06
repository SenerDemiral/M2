﻿namespace RestClientWinForm
{
    partial class AbdXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbdXF));
            this.abdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAcc = new RestClientWinForm.DataSetAcc();
            this.abdBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abdGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colABM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFyt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMik = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DVTrepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xdkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dataSetGnl = new RestClientWinForm.DataSetGnl();
            ((System.ComponentModel.ISupportInitialize)(this.abdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abdBindingNavigator)).BeginInit();
            this.abdBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abdGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVTrepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdkBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGnl)).BeginInit();
            this.SuspendLayout();
            // 
            // abdBindingSource
            // 
            this.abdBindingSource.DataMember = "ABD";
            this.abdBindingSource.DataSource = this.dataSetAcc;
            // 
            // dataSetAcc
            // 
            this.dataSetAcc.DataSetName = "DataSetAcc";
            this.dataSetAcc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // abdBindingNavigator
            // 
            this.abdBindingNavigator.AddNewItem = null;
            this.abdBindingNavigator.AutoSize = false;
            this.abdBindingNavigator.BindingSource = this.abdBindingSource;
            this.abdBindingNavigator.CountItem = null;
            this.abdBindingNavigator.DeleteItem = null;
            this.abdBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.abdBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton});
            this.abdBindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.abdBindingNavigator.MoveFirstItem = null;
            this.abdBindingNavigator.MoveLastItem = null;
            this.abdBindingNavigator.MoveNextItem = null;
            this.abdBindingNavigator.MovePreviousItem = null;
            this.abdBindingNavigator.Name = "abdBindingNavigator";
            this.abdBindingNavigator.PositionItem = null;
            this.abdBindingNavigator.Size = new System.Drawing.Size(665, 30);
            this.abdBindingNavigator.TabIndex = 0;
            this.abdBindingNavigator.Text = "bindingNavigator1";
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
            // abdGridControl
            // 
            this.abdGridControl.DataSource = this.abdBindingSource;
            this.abdGridControl.Location = new System.Drawing.Point(12, 46);
            this.abdGridControl.MainView = this.gridView1;
            this.abdGridControl.Name = "abdGridControl";
            this.abdGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.DVTrepositoryItemLookUpEdit});
            this.abdGridControl.Size = new System.Drawing.Size(665, 244);
            this.abdGridControl.TabIndex = 2;
            this.abdGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.abdGridControl.Click += new System.EventHandler(this.abdGridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colABM,
            this.colNNT,
            this.colAHP,
            this.colDVT,
            this.colFyt,
            this.colMik,
            this.colKur,
            this.colKDY});
            this.gridView1.GridControl = this.abdGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 0;
            // 
            // colABM
            // 
            this.colABM.FieldName = "ABM";
            this.colABM.Name = "colABM";
            this.colABM.Visible = true;
            this.colABM.VisibleIndex = 1;
            // 
            // colNNT
            // 
            this.colNNT.FieldName = "NNT";
            this.colNNT.Name = "colNNT";
            this.colNNT.Visible = true;
            this.colNNT.VisibleIndex = 2;
            // 
            // colAHP
            // 
            this.colAHP.FieldName = "AHP";
            this.colAHP.Name = "colAHP";
            this.colAHP.Visible = true;
            this.colAHP.VisibleIndex = 3;
            // 
            // colDVT
            // 
            this.colDVT.FieldName = "DVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.Visible = true;
            this.colDVT.VisibleIndex = 4;
            // 
            // colFyt
            // 
            this.colFyt.FieldName = "Fyt";
            this.colFyt.Name = "colFyt";
            this.colFyt.Visible = true;
            this.colFyt.VisibleIndex = 5;
            // 
            // colMik
            // 
            this.colMik.FieldName = "Mik";
            this.colMik.Name = "colMik";
            this.colMik.Visible = true;
            this.colMik.VisibleIndex = 6;
            // 
            // colKur
            // 
            this.colKur.FieldName = "Kur";
            this.colKur.Name = "colKur";
            this.colKur.Visible = true;
            this.colKur.VisibleIndex = 7;
            // 
            // colKDY
            // 
            this.colKDY.FieldName = "KDY";
            this.colKDY.Name = "colKDY";
            this.colKDY.Visible = true;
            this.colKDY.VisibleIndex = 8;
            // 
            // DVTrepositoryItemLookUpEdit
            // 
            this.DVTrepositoryItemLookUpEdit.AutoHeight = false;
            this.DVTrepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DVTrepositoryItemLookUpEdit.DataSource = this.xdkBindingSource;
            this.DVTrepositoryItemLookUpEdit.DisplayMember = "Dvz";
            this.DVTrepositoryItemLookUpEdit.Name = "DVTrepositoryItemLookUpEdit";
            this.DVTrepositoryItemLookUpEdit.ValueMember = "DVT";
            this.DVTrepositoryItemLookUpEdit.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.DVTrepositoryItemLookUpEdit_Closed);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(12, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(665, 20);
            this.statusStrip1.TabIndex = 3;
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
            this.layoutControl1.Controls.Add(this.abdBindingNavigator);
            this.layoutControl1.Controls.Add(this.abdGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(689, 326);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(689, 326);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.abdGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(669, 248);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.abdBindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(669, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.statusStrip1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 282);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(669, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // dataSetGnl
            // 
            this.dataSetGnl.DataSetName = "DataSetGnl";
            this.dataSetGnl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AbdXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 326);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AbdXF";
            this.Text = "Fatura Detayları [AbdXF]";
            ((System.ComponentModel.ISupportInitialize)(this.abdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abdBindingNavigator)).EndInit();
            this.abdBindingNavigator.ResumeLayout(false);
            this.abdBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abdGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVTrepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdkBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGnl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource abdBindingSource;
        private System.Windows.Forms.BindingNavigator abdBindingNavigator;
        private DevExpress.XtraGrid.GridControl abdGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colABM;
        private DevExpress.XtraGrid.Columns.GridColumn colNNT;
        private DevExpress.XtraGrid.Columns.GridColumn colAHP;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colFyt;
        private DevExpress.XtraGrid.Columns.GridColumn colMik;
        private DevExpress.XtraGrid.Columns.GridColumn colKur;
        private DevExpress.XtraGrid.Columns.GridColumn colKDY;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit DVTrepositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource xdkBindingSource;
        private DataSetAcc dataSetAcc;
        private DataSetGnl dataSetGnl;
    }
}