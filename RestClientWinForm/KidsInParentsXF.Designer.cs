namespace RestClientWinForm
{
    partial class KidsInParentsXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KidsInParentsXF));
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.kidsInParentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kidsInParentsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.kidsInParentsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.kidsInParentsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldKNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldKAd1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPAd1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldM1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsBindingNavigator)).BeginInit();
            this.kidsInParentsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kidsInParentsBindingSource
            // 
            this.kidsInParentsBindingSource.DataMember = "KidsInParents";
            this.kidsInParentsBindingSource.DataSource = this.mainDataSet;
            // 
            // kidsInParentsBindingNavigator
            // 
            this.kidsInParentsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.kidsInParentsBindingNavigator.BindingSource = this.kidsInParentsBindingSource;
            this.kidsInParentsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.kidsInParentsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.kidsInParentsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.kidsInParentsBindingNavigatorSaveItem});
            this.kidsInParentsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.kidsInParentsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.kidsInParentsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.kidsInParentsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.kidsInParentsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.kidsInParentsBindingNavigator.Name = "kidsInParentsBindingNavigator";
            this.kidsInParentsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.kidsInParentsBindingNavigator.Size = new System.Drawing.Size(574, 25);
            this.kidsInParentsBindingNavigator.TabIndex = 0;
            this.kidsInParentsBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // kidsInParentsBindingNavigatorSaveItem
            // 
            this.kidsInParentsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kidsInParentsBindingNavigatorSaveItem.Enabled = false;
            this.kidsInParentsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("kidsInParentsBindingNavigatorSaveItem.Image")));
            this.kidsInParentsBindingNavigatorSaveItem.Name = "kidsInParentsBindingNavigatorSaveItem";
            this.kidsInParentsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.kidsInParentsBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // kidsInParentsGridControl
            // 
            this.kidsInParentsGridControl.DataSource = this.kidsInParentsBindingSource;
            this.kidsInParentsGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.kidsInParentsGridControl.Location = new System.Drawing.Point(0, 25);
            this.kidsInParentsGridControl.MainView = this.gridView1;
            this.kidsInParentsGridControl.Name = "kidsInParentsGridControl";
            this.kidsInParentsGridControl.Size = new System.Drawing.Size(574, 265);
            this.kidsInParentsGridControl.TabIndex = 1;
            this.kidsInParentsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridView1.GridControl = this.kidsInParentsGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colKNo
            // 
            this.colKNo.FieldName = "KNo";
            this.colKNo.Name = "colKNo";
            this.colKNo.Visible = true;
            this.colKNo.VisibleIndex = 0;
            this.colKNo.Width = 76;
            // 
            // colPNo
            // 
            this.colPNo.FieldName = "PNo";
            this.colPNo.Name = "colPNo";
            this.colPNo.Visible = true;
            this.colPNo.VisibleIndex = 1;
            this.colPNo.Width = 70;
            // 
            // colKAd
            // 
            this.colKAd.FieldName = "KAd";
            this.colKAd.Name = "colKAd";
            this.colKAd.Visible = true;
            this.colKAd.VisibleIndex = 2;
            this.colKAd.Width = 135;
            // 
            // colPAd
            // 
            this.colPAd.FieldName = "PAd";
            this.colPAd.Name = "colPAd";
            this.colPAd.Visible = true;
            this.colPAd.VisibleIndex = 3;
            this.colPAd.Width = 135;
            // 
            // colM
            // 
            this.colM.DisplayFormat.FormatString = "n";
            this.colM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colM.FieldName = "M";
            this.colM.Name = "colM";
            this.colM.Visible = true;
            this.colM.VisibleIndex = 4;
            this.colM.Width = 140;
            // 
            // pivotGridControl2
            // 
            this.pivotGridControl2.DataSource = this.kidsInParentsBindingSource;
            this.pivotGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl2.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldKNo1,
            this.fieldPNo1,
            this.fieldKAd1,
            this.fieldPAd1,
            this.fieldM1});
            this.pivotGridControl2.Location = new System.Drawing.Point(0, 290);
            this.pivotGridControl2.Name = "pivotGridControl2";
            this.pivotGridControl2.Size = new System.Drawing.Size(574, 346);
            this.pivotGridControl2.TabIndex = 3;
            // 
            // fieldKNo1
            // 
            this.fieldKNo1.AreaIndex = 0;
            this.fieldKNo1.FieldName = "KNo";
            this.fieldKNo1.Name = "fieldKNo1";
            // 
            // fieldPNo1
            // 
            this.fieldPNo1.AreaIndex = 1;
            this.fieldPNo1.FieldName = "PNo";
            this.fieldPNo1.Name = "fieldPNo1";
            // 
            // fieldKAd1
            // 
            this.fieldKAd1.AreaIndex = 2;
            this.fieldKAd1.FieldName = "KAd";
            this.fieldKAd1.Name = "fieldKAd1";
            // 
            // fieldPAd1
            // 
            this.fieldPAd1.AreaIndex = 3;
            this.fieldPAd1.FieldName = "PAd";
            this.fieldPAd1.Name = "fieldPAd1";
            // 
            // fieldM1
            // 
            this.fieldM1.AreaIndex = 4;
            this.fieldM1.FieldName = "M";
            this.fieldM1.Name = "fieldM1";
            // 
            // KidsInParentsXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 636);
            this.Controls.Add(this.pivotGridControl2);
            this.Controls.Add(this.kidsInParentsGridControl);
            this.Controls.Add(this.kidsInParentsBindingNavigator);
            this.Name = "KidsInParentsXF";
            this.Text = "KidsInParentsXF";
            this.Load += new System.EventHandler(this.KidsInParentsXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsBindingNavigator)).EndInit();
            this.kidsInParentsBindingNavigator.ResumeLayout(false);
            this.kidsInParentsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kidsInParentsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource kidsInParentsBindingSource;
        private System.Windows.Forms.BindingNavigator kidsInParentsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton kidsInParentsBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl kidsInParentsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colKNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPNo;
        private DevExpress.XtraGrid.Columns.GridColumn colKAd;
        private DevExpress.XtraGrid.Columns.GridColumn colPAd;
        private DevExpress.XtraGrid.Columns.GridColumn colM;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl2;
        private DevExpress.XtraPivotGrid.PivotGridField fieldKNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldKAd1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPAd1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldM1;
    }
}