namespace RestClientWinForm
{
    partial class ToBrXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToBrXF));
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.brBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.brGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOthers = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brBindingNavigator)).BeginInit();
            this.brBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // brBindingSource
            // 
            this.brBindingSource.DataMember = "BR";
            this.brBindingSource.DataSource = this.mainDataSet;
            // 
            // brBindingNavigator
            // 
            this.brBindingNavigator.AddNewItem = null;
            this.brBindingNavigator.BindingSource = this.brBindingSource;
            this.brBindingNavigator.CountItem = null;
            this.brBindingNavigator.DeleteItem = null;
            this.brBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton,
            this.editToolStripButton});
            this.brBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.brBindingNavigator.MoveFirstItem = null;
            this.brBindingNavigator.MoveLastItem = null;
            this.brBindingNavigator.MoveNextItem = null;
            this.brBindingNavigator.MovePreviousItem = null;
            this.brBindingNavigator.Name = "brBindingNavigator";
            this.brBindingNavigator.PositionItem = null;
            this.brBindingNavigator.Size = new System.Drawing.Size(485, 25);
            this.brBindingNavigator.TabIndex = 0;
            this.brBindingNavigator.Text = "bindingNavigator1";
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
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "Refresh";
            // 
            // revertToolStripButton
            // 
            this.revertToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.revertToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("revertToolStripButton.Image")));
            this.revertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revertToolStripButton.Name = "revertToolStripButton";
            this.revertToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.revertToolStripButton.Text = "toolStripButton6";
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "toolStripButton1";
            // 
            // brGridControl
            // 
            this.brGridControl.DataSource = this.brBindingSource;
            this.brGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brGridControl.Location = new System.Drawing.Point(0, 25);
            this.brGridControl.MainView = this.gridView1;
            this.brGridControl.Name = "brGridControl";
            this.brGridControl.Size = new System.Drawing.Size(485, 280);
            this.brGridControl.TabIndex = 1;
            this.brGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowKey,
            this.colP,
            this.colC,
            this.colOthers});
            this.gridView1.GridControl = this.brGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colRowKey
            // 
            this.colRowKey.FieldName = "RowKey";
            this.colRowKey.Name = "colRowKey";
            this.colRowKey.OptionsColumn.AllowEdit = false;
            this.colRowKey.OptionsColumn.AllowFocus = false;
            this.colRowKey.OptionsColumn.FixedWidth = true;
            this.colRowKey.Visible = true;
            this.colRowKey.VisibleIndex = 0;
            // 
            // colP
            // 
            this.colP.FieldName = "P";
            this.colP.Name = "colP";
            this.colP.Visible = true;
            this.colP.VisibleIndex = 1;
            // 
            // colC
            // 
            this.colC.FieldName = "C";
            this.colC.Name = "colC";
            this.colC.Visible = true;
            this.colC.VisibleIndex = 2;
            // 
            // colOthers
            // 
            this.colOthers.FieldName = "Others";
            this.colOthers.Name = "colOthers";
            this.colOthers.Visible = true;
            this.colOthers.VisibleIndex = 3;
            // 
            // ToBrXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 305);
            this.Controls.Add(this.brGridControl);
            this.Controls.Add(this.brBindingNavigator);
            this.Name = "ToBrXF";
            this.Text = "ToBrXF";
            this.Load += new System.EventHandler(this.ToBrXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brBindingNavigator)).EndInit();
            this.brBindingNavigator.ResumeLayout(false);
            this.brBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource brBindingSource;
        private System.Windows.Forms.BindingNavigator brBindingNavigator;
        private DevExpress.XtraGrid.GridControl brGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowKey;
        private DevExpress.XtraGrid.Columns.GridColumn colP;
        private DevExpress.XtraGrid.Columns.GridColumn colC;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton revertToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private DevExpress.XtraGrid.Columns.GridColumn colOthers;
    }
}