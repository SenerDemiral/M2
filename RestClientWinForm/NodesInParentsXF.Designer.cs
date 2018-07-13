namespace RestClientWinForm
{
    partial class NodesInParentsXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodesInParentsXF));
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.nodesInParentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nodesInParentsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.nodesInParentsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nodesInParentsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingNavigator)).BeginInit();
            this.nodesInParentsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nodesInParentsBindingSource
            // 
            this.nodesInParentsBindingSource.DataMember = "NodesInParents";
            this.nodesInParentsBindingSource.DataSource = this.mainDataSet;
            // 
            // nodesInParentsBindingNavigator
            // 
            this.nodesInParentsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.nodesInParentsBindingNavigator.BindingSource = this.nodesInParentsBindingSource;
            this.nodesInParentsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.nodesInParentsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.nodesInParentsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.nodesInParentsBindingNavigatorSaveItem});
            this.nodesInParentsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.nodesInParentsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nodesInParentsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nodesInParentsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nodesInParentsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nodesInParentsBindingNavigator.Name = "nodesInParentsBindingNavigator";
            this.nodesInParentsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.nodesInParentsBindingNavigator.Size = new System.Drawing.Size(720, 25);
            this.nodesInParentsBindingNavigator.TabIndex = 0;
            this.nodesInParentsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // nodesInParentsBindingNavigatorSaveItem
            // 
            this.nodesInParentsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nodesInParentsBindingNavigatorSaveItem.Enabled = false;
            this.nodesInParentsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("nodesInParentsBindingNavigatorSaveItem.Image")));
            this.nodesInParentsBindingNavigatorSaveItem.Name = "nodesInParentsBindingNavigatorSaveItem";
            this.nodesInParentsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.nodesInParentsBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // nodesInParentsGridControl
            // 
            this.nodesInParentsGridControl.DataSource = this.nodesInParentsBindingSource;
            this.nodesInParentsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesInParentsGridControl.Location = new System.Drawing.Point(0, 25);
            this.nodesInParentsGridControl.MainView = this.gridView1;
            this.nodesInParentsGridControl.Name = "nodesInParentsGridControl";
            this.nodesInParentsGridControl.Size = new System.Drawing.Size(720, 427);
            this.nodesInParentsGridControl.TabIndex = 1;
            this.nodesInParentsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKNo,
            this.colPNo,
            this.colKAd,
            this.colPAd,
            this.colM});
            this.gridView1.GridControl = this.nodesInParentsGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colKNo
            // 
            this.colKNo.FieldName = "KNo";
            this.colKNo.Name = "colKNo";
            this.colKNo.Visible = true;
            this.colKNo.VisibleIndex = 0;
            // 
            // colPNo
            // 
            this.colPNo.FieldName = "PNo";
            this.colPNo.Name = "colPNo";
            this.colPNo.Visible = true;
            this.colPNo.VisibleIndex = 1;
            // 
            // colKAd
            // 
            this.colKAd.FieldName = "KAd";
            this.colKAd.Name = "colKAd";
            this.colKAd.Visible = true;
            this.colKAd.VisibleIndex = 2;
            // 
            // colPAd
            // 
            this.colPAd.FieldName = "PAd";
            this.colPAd.Name = "colPAd";
            this.colPAd.Visible = true;
            this.colPAd.VisibleIndex = 3;
            // 
            // colM
            // 
            this.colM.DisplayFormat.FormatString = "n";
            this.colM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colM.FieldName = "M";
            this.colM.Name = "colM";
            this.colM.Visible = true;
            this.colM.VisibleIndex = 4;
            // 
            // NodesInParentsXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 452);
            this.Controls.Add(this.nodesInParentsGridControl);
            this.Controls.Add(this.nodesInParentsBindingNavigator);
            this.Name = "NodesInParentsXF";
            this.Text = "NodesInParentsXF";
            this.Load += new System.EventHandler(this.NodesInParentsXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingNavigator)).EndInit();
            this.nodesInParentsBindingNavigator.ResumeLayout(false);
            this.nodesInParentsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource nodesInParentsBindingSource;
        private System.Windows.Forms.BindingNavigator nodesInParentsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton nodesInParentsBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl nodesInParentsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colKNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPNo;
        private DevExpress.XtraGrid.Columns.GridColumn colKAd;
        private DevExpress.XtraGrid.Columns.GridColumn colPAd;
        private DevExpress.XtraGrid.Columns.GridColumn colM;
    }
}