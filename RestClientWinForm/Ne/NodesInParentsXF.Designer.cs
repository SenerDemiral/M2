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
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.nodesInParentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nodesInParentsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldKNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldKAd1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPAd1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldM1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.dataSetNe = new RestClientWinForm.DataSetNe();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).BeginInit();
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
            this.nodesInParentsBindingSource.DataSource = this.dataSetNe;
            // 
            // nodesInParentsGridControl
            // 
            this.nodesInParentsGridControl.DataSource = this.nodesInParentsBindingSource;
            this.nodesInParentsGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.nodesInParentsGridControl.Location = new System.Drawing.Point(0, 0);
            this.nodesInParentsGridControl.MainView = this.gridView1;
            this.nodesInParentsGridControl.Name = "nodesInParentsGridControl";
            this.nodesInParentsGridControl.Size = new System.Drawing.Size(720, 246);
            this.nodesInParentsGridControl.TabIndex = 1;
            this.nodesInParentsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Red;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKNo,
            this.colPNo,
            this.colKAd,
            this.colPAd,
            this.colM});
            this.gridView1.GridControl = this.nodesInParentsGridControl;
            this.gridView1.GroupFormat = "{1} {2}";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // colKNo
            // 
            this.colKNo.FieldName = "KNo";
            this.colKNo.Name = "colKNo";
            // 
            // colPNo
            // 
            this.colPNo.FieldName = "PNo";
            this.colPNo.Name = "colPNo";
            // 
            // colKAd
            // 
            this.colKAd.Caption = "- HamMadde / + YarıMamül";
            this.colKAd.FieldName = "KAd";
            this.colKAd.Name = "colKAd";
            this.colKAd.Visible = true;
            this.colKAd.VisibleIndex = 0;
            // 
            // colPAd
            // 
            this.colPAd.Caption = "* Mamül / + YarıMamül";
            this.colPAd.FieldName = "PAd";
            this.colPAd.Name = "colPAd";
            this.colPAd.Visible = true;
            this.colPAd.VisibleIndex = 1;
            // 
            // colM
            // 
            this.colM.DisplayFormat.FormatString = "n";
            this.colM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colM.FieldName = "M";
            this.colM.Name = "colM";
            this.colM.Visible = true;
            this.colM.VisibleIndex = 2;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.nodesInParentsBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldKNo1,
            this.fieldPNo1,
            this.fieldKAd1,
            this.fieldPAd1,
            this.fieldM1});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 246);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(720, 206);
            this.pivotGridControl1.TabIndex = 2;
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
            this.fieldKAd1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldKAd1.AreaIndex = 0;
            this.fieldKAd1.Caption = "+ YarıMamül / - HamMadde";
            this.fieldKAd1.FieldName = "KAd";
            this.fieldKAd1.Name = "fieldKAd1";
            // 
            // fieldPAd1
            // 
            this.fieldPAd1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPAd1.AreaIndex = 0;
            this.fieldPAd1.Caption = "* Mamül / + YarıMamül";
            this.fieldPAd1.FieldName = "PAd";
            this.fieldPAd1.Name = "fieldPAd1";
            this.fieldPAd1.Width = 168;
            // 
            // fieldM1
            // 
            this.fieldM1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldM1.AreaIndex = 0;
            this.fieldM1.Caption = "Miktar";
            this.fieldM1.CellFormat.FormatString = "G";
            this.fieldM1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldM1.FieldName = "M";
            this.fieldM1.Name = "fieldM1";
            // 
            // dataSetNe
            // 
            this.dataSetNe.DataSetName = "DataSetNe";
            this.dataSetNe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NodesInParentsXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 452);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.nodesInParentsGridControl);
            this.Name = "NodesInParentsXF";
            this.Text = "NodesInParentsXF";
            this.Load += new System.EventHandler(this.NodesInParentsXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodesInParentsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetNe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource nodesInParentsBindingSource;
        private DevExpress.XtraGrid.GridControl nodesInParentsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colKNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPNo;
        private DevExpress.XtraGrid.Columns.GridColumn colKAd;
        private DevExpress.XtraGrid.Columns.GridColumn colPAd;
        private DevExpress.XtraGrid.Columns.GridColumn colM;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldKNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldKAd1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPAd1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldM1;
        private DataSetNe dataSetNe;
    }
}