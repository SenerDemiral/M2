namespace RestClientWinForm
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldInt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDbl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDcm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Fill";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "RowPk";
            this.dataColumn1.DataType = typeof(ulong);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "FldStr";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "FldInt";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "FldDbl";
            this.dataColumn4.DataType = typeof(double);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "FldDcm";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "FldDate";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Update (Ins/Upd/Del)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Table1";
            this.gridControl1.DataSource = this.dataSet1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 102);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 276);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRowPk,
            this.colFldStr,
            this.colFldInt,
            this.colFldDbl,
            this.colFldDcm,
            this.colFldDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colRowPk
            // 
            this.colRowPk.FieldName = "RowPk";
            this.colRowPk.Name = "colRowPk";
            this.colRowPk.OptionsColumn.ReadOnly = true;
            this.colRowPk.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowPk", "{0:n0}")});
            this.colRowPk.Visible = true;
            this.colRowPk.VisibleIndex = 0;
            // 
            // colFldStr
            // 
            this.colFldStr.FieldName = "FldStr";
            this.colFldStr.Name = "colFldStr";
            this.colFldStr.Visible = true;
            this.colFldStr.VisibleIndex = 1;
            // 
            // colFldInt
            // 
            this.colFldInt.FieldName = "FldInt";
            this.colFldInt.Name = "colFldInt";
            this.colFldInt.Visible = true;
            this.colFldInt.VisibleIndex = 2;
            // 
            // colFldDbl
            // 
            this.colFldDbl.FieldName = "FldDbl";
            this.colFldDbl.Name = "colFldDbl";
            this.colFldDbl.Visible = true;
            this.colFldDbl.VisibleIndex = 3;
            // 
            // colFldDcm
            // 
            this.colFldDcm.FieldName = "FldDcm";
            this.colFldDcm.Name = "colFldDcm";
            this.colFldDcm.Visible = true;
            this.colFldDcm.VisibleIndex = 4;
            // 
            // colFldDate
            // 
            this.colFldDate.FieldName = "FldDate";
            this.colFldDate.Name = "colFldDate";
            this.colFldDate.Visible = true;
            this.colFldDate.VisibleIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 378);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowPk;
        private DevExpress.XtraGrid.Columns.GridColumn colFldStr;
        private DevExpress.XtraGrid.Columns.GridColumn colFldInt;
        private DevExpress.XtraGrid.Columns.GridColumn colFldDbl;
        private DevExpress.XtraGrid.Columns.GridColumn colFldDcm;
        private DevExpress.XtraGrid.Columns.GridColumn colFldDate;
    }
}

