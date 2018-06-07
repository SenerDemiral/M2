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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldInt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDbl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDcm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFldDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHspNoG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowPkG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coObjPG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colHspNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNoT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAdT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRowPkT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colObjPT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.altHesapEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.dataTable1,
            this.dataTable2});
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
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.dataTable2.TableName = "AHP";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "HspNo";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "No";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Ad";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "RowPk";
            this.dataColumn10.DataType = typeof(ulong);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "ObjP";
            this.dataColumn11.DataType = typeof(ulong);
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
            this.gridControl1.Location = new System.Drawing.Point(0, 484);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 140);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "AHP Fill";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.DataMember = "AHP";
            this.gridControl2.DataSource = this.dataSet1;
            this.gridControl2.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl2_EmbeddedNavigator_ButtonClick);
            this.gridControl2.Location = new System.Drawing.Point(12, 83);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(776, 178);
            this.gridControl2.TabIndex = 5;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHspNoG,
            this.colNoG,
            this.colAdG,
            this.colRowPkG,
            this.coObjPG});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            // 
            // colHspNoG
            // 
            this.colHspNoG.Caption = "HspNo";
            this.colHspNoG.FieldName = "HspNo";
            this.colHspNoG.Name = "colHspNoG";
            this.colHspNoG.Visible = true;
            this.colHspNoG.VisibleIndex = 0;
            // 
            // colNoG
            // 
            this.colNoG.FieldName = "No";
            this.colNoG.Name = "colNoG";
            this.colNoG.Visible = true;
            this.colNoG.VisibleIndex = 1;
            // 
            // colAdG
            // 
            this.colAdG.FieldName = "Ad";
            this.colAdG.Name = "colAdG";
            this.colAdG.Visible = true;
            this.colAdG.VisibleIndex = 2;
            // 
            // colRowPkG
            // 
            this.colRowPkG.Caption = "RowPk";
            this.colRowPkG.DisplayFormat.FormatString = "n0";
            this.colRowPkG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRowPkG.FieldName = "RowPk";
            this.colRowPkG.Name = "colRowPkG";
            this.colRowPkG.Visible = true;
            this.colRowPkG.VisibleIndex = 3;
            // 
            // coObjPG
            // 
            this.coObjPG.FieldName = "ObjP";
            this.coObjPG.Name = "coObjPG";
            this.coObjPG.Visible = true;
            this.coObjPG.VisibleIndex = 4;
            // 
            // treeList1
            // 
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colHspNoT,
            this.colNoT,
            this.colAdT,
            this.colRowPkT,
            this.colObjPT});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataMember = "AHP";
            this.treeList1.DataSource = this.dataSet1;
            this.treeList1.KeyFieldName = "RowPk";
            this.treeList1.Location = new System.Drawing.Point(12, 278);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeList1.OptionsFind.AllowFindPanel = true;
            this.treeList1.OptionsFind.FindFilterColumns = "HspNo;Ad";
            this.treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.ParentFieldName = "ObjP";
            this.treeList1.Size = new System.Drawing.Size(641, 200);
            this.treeList1.TabIndex = 6;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Wide;
            // 
            // colHspNoT
            // 
            this.colHspNoT.FieldName = "HspNo";
            this.colHspNoT.Name = "colHspNoT";
            this.colHspNoT.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colHspNoT.Visible = true;
            this.colHspNoT.VisibleIndex = 0;
            this.colHspNoT.Width = 125;
            // 
            // colNoT
            // 
            this.colNoT.FieldName = "No";
            this.colNoT.Name = "colNoT";
            this.colNoT.Visible = true;
            this.colNoT.VisibleIndex = 1;
            this.colNoT.Width = 125;
            // 
            // colAdT
            // 
            this.colAdT.FieldName = "Ad";
            this.colAdT.Name = "colAdT";
            this.colAdT.Visible = true;
            this.colAdT.VisibleIndex = 2;
            this.colAdT.Width = 125;
            // 
            // colRowPkT
            // 
            this.colRowPkT.FieldName = "RowPk";
            this.colRowPkT.Name = "colRowPkT";
            this.colRowPkT.Visible = true;
            this.colRowPkT.VisibleIndex = 3;
            this.colRowPkT.Width = 124;
            // 
            // colObjPT
            // 
            this.colObjPT.FieldName = "ObjP";
            this.colObjPT.Name = "colObjPT";
            this.colObjPT.Visible = true;
            this.colObjPT.VisibleIndex = 4;
            this.colObjPT.Width = 124;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altHesapEkleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // altHesapEkleToolStripMenuItem
            // 
            this.altHesapEkleToolStripMenuItem.Name = "altHesapEkleToolStripMenuItem";
            this.altHesapEkleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.altHesapEkleToolStripMenuItem.Text = "Alt Hesap Ekle";
            this.altHesapEkleToolStripMenuItem.Click += new System.EventHandler(this.altHesapEkleToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(107, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "AHP Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 625);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button3;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colHspNoG;
        private DevExpress.XtraGrid.Columns.GridColumn colNoG;
        private DevExpress.XtraGrid.Columns.GridColumn colAdG;
        private DevExpress.XtraGrid.Columns.GridColumn colRowPkG;
        private System.Data.DataColumn dataColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn coObjPG;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem altHesapEkleToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHspNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNoT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAdT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRowPkT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colObjPT;
        private System.Windows.Forms.Button button4;
    }
}

