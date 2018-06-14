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
            this.accDataSet = new RestClientWinForm.AccDataSet();
            this.afdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.afdBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.afdGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.revertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.colRowPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjAFB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObjAHP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingNavigator)).BeginInit();
            this.afdBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afdGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.afdBindingNavigator.BindingSource = this.afdBindingSource;
            this.afdBindingNavigator.CountItem = null;
            this.afdBindingNavigator.DeleteItem = null;
            this.afdBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.refreshToolStripButton,
            this.revertToolStripButton});
            this.afdBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.afdBindingNavigator.MoveFirstItem = null;
            this.afdBindingNavigator.MoveLastItem = null;
            this.afdBindingNavigator.MoveNextItem = null;
            this.afdBindingNavigator.MovePreviousItem = null;
            this.afdBindingNavigator.Name = "afdBindingNavigator";
            this.afdBindingNavigator.PositionItem = null;
            this.afdBindingNavigator.Size = new System.Drawing.Size(686, 25);
            this.afdBindingNavigator.TabIndex = 0;
            this.afdBindingNavigator.Text = "bindingNavigator1";
            // 
            // afdGridControl
            // 
            this.afdGridControl.DataSource = this.afdBindingSource;
            this.afdGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afdGridControl.Location = new System.Drawing.Point(0, 25);
            this.afdGridControl.MainView = this.gridView1;
            this.afdGridControl.Name = "afdGridControl";
            this.afdGridControl.Size = new System.Drawing.Size(686, 300);
            this.afdGridControl.TabIndex = 1;
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
            this.colTut});
            this.gridView1.GridControl = this.afdGridControl;
            this.gridView1.Name = "gridView1";
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
            // colRowPk
            // 
            this.colRowPk.FieldName = "RowPk";
            this.colRowPk.Name = "colRowPk";
            this.colRowPk.Visible = true;
            this.colRowPk.VisibleIndex = 0;
            // 
            // colObjAFB
            // 
            this.colObjAFB.FieldName = "ObjAFB";
            this.colObjAFB.Name = "colObjAFB";
            this.colObjAFB.Visible = true;
            this.colObjAFB.VisibleIndex = 1;
            // 
            // colObjAHP
            // 
            this.colObjAHP.FieldName = "ObjAHP";
            this.colObjAHP.Name = "colObjAHP";
            this.colObjAHP.Visible = true;
            this.colObjAHP.VisibleIndex = 2;
            // 
            // colInfo
            // 
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 3;
            // 
            // colTut
            // 
            this.colTut.FieldName = "Tut";
            this.colTut.Name = "colTut";
            this.colTut.Visible = true;
            this.colTut.VisibleIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 303);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // AfdXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 325);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.afdGridControl);
            this.Controls.Add(this.afdBindingNavigator);
            this.Name = "AfdXF";
            this.Text = "AfdXF";
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afdBindingNavigator)).EndInit();
            this.afdBindingNavigator.ResumeLayout(false);
            this.afdBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afdGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}