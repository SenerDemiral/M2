namespace RestClientWinForm
{
    partial class AfbXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AfbXF));
            this.accDataSet = new RestClientWinForm.AccDataSet();
            this.afbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.afbBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.afbGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAoK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrcTop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlcTop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afbBindingNavigator)).BeginInit();
            this.afbBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afbGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accDataSet
            // 
            this.accDataSet.DataSetName = "AccDataSet";
            this.accDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // afbBindingSource
            // 
            this.afbBindingSource.DataMember = "AFB";
            this.afbBindingSource.DataSource = this.accDataSet;
            // 
            // afbBindingNavigator
            // 
            this.afbBindingNavigator.AddNewItem = null;
            this.afbBindingNavigator.CountItem = null;
            this.afbBindingNavigator.DeleteItem = null;
            this.afbBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton});
            this.afbBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.afbBindingNavigator.MoveFirstItem = null;
            this.afbBindingNavigator.MoveLastItem = null;
            this.afbBindingNavigator.MoveNextItem = null;
            this.afbBindingNavigator.MovePreviousItem = null;
            this.afbBindingNavigator.Name = "afbBindingNavigator";
            this.afbBindingNavigator.PositionItem = null;
            this.afbBindingNavigator.Size = new System.Drawing.Size(708, 25);
            this.afbBindingNavigator.TabIndex = 0;
            this.afbBindingNavigator.Text = "bindingNavigator1";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // revertToolStripButton
            // 
            this.revertToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.revertToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("revertToolStripButton.Image")));
            this.revertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revertToolStripButton.Name = "revertToolStripButton";
            this.revertToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.revertToolStripButton.Text = "toolStripButton6";
            this.revertToolStripButton.Click += new System.EventHandler(this.revertToolStripButton_Click);
            // 
            // afbGridControl
            // 
            this.afbGridControl.DataSource = this.afbBindingSource;
            this.afbGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afbGridControl.Location = new System.Drawing.Point(0, 25);
            this.afbGridControl.MainView = this.gridView1;
            this.afbGridControl.Name = "afbGridControl";
            this.afbGridControl.Size = new System.Drawing.Size(708, 270);
            this.afbGridControl.TabIndex = 1;
            this.afbGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowPk,
            this.colTrh,
            this.colObjTur,
            this.colAoK,
            this.colInfo,
            this.colBrcTop,
            this.colAlcTop});
            this.gridView1.GridControl = this.afbGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colRowPk
            // 
            this.colRowPk.FieldName = "RowPk";
            this.colRowPk.Name = "colRowPk";
            this.colRowPk.OptionsColumn.ReadOnly = true;
            this.colRowPk.Visible = true;
            this.colRowPk.VisibleIndex = 0;
            this.colRowPk.Width = 98;
            // 
            // colTrh
            // 
            this.colTrh.FieldName = "Trh";
            this.colTrh.Name = "colTrh";
            this.colTrh.Visible = true;
            this.colTrh.VisibleIndex = 1;
            this.colTrh.Width = 98;
            // 
            // colObjTur
            // 
            this.colObjTur.Caption = "Tür";
            this.colObjTur.FieldName = "ObjTur";
            this.colObjTur.Name = "colObjTur";
            this.colObjTur.Visible = true;
            this.colObjTur.VisibleIndex = 2;
            this.colObjTur.Width = 98;
            // 
            // colAoK
            // 
            this.colAoK.Caption = "A/K";
            this.colAoK.FieldName = "AoK";
            this.colAoK.Name = "colAoK";
            this.colAoK.OptionsColumn.ReadOnly = true;
            this.colAoK.Visible = true;
            this.colAoK.VisibleIndex = 3;
            this.colAoK.Width = 38;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 4;
            this.colInfo.Width = 117;
            // 
            // colBrcTop
            // 
            this.colBrcTop.FieldName = "BrcTop";
            this.colBrcTop.Name = "colBrcTop";
            this.colBrcTop.Visible = true;
            this.colBrcTop.VisibleIndex = 5;
            this.colBrcTop.Width = 117;
            // 
            // colAlcTop
            // 
            this.colAlcTop.FieldName = "AlcTop";
            this.colAlcTop.Name = "colAlcTop";
            this.colAlcTop.Visible = true;
            this.colAlcTop.VisibleIndex = 6;
            this.colAlcTop.Width = 124;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 273);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(708, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // AfbXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 295);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.afbGridControl);
            this.Controls.Add(this.afbBindingNavigator);
            this.Name = "AfbXF";
            this.Text = "Muhasebe Fişleri [AfbXF]";
            this.Load += new System.EventHandler(this.AfbXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afbBindingNavigator)).EndInit();
            this.afbBindingNavigator.ResumeLayout(false);
            this.afbBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afbGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccDataSet accDataSet;
        private System.Windows.Forms.BindingSource afbBindingSource;
        private System.Windows.Forms.BindingNavigator afbBindingNavigator;
        private DevExpress.XtraGrid.GridControl afbGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowPk;
        private DevExpress.XtraGrid.Columns.GridColumn colTrh;
        private DevExpress.XtraGrid.Columns.GridColumn colObjTur;
        private DevExpress.XtraGrid.Columns.GridColumn colAoK;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colBrcTop;
        private DevExpress.XtraGrid.Columns.GridColumn colAlcTop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
    }
}