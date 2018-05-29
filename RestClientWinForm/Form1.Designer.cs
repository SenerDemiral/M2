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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rowPkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldIntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldDblDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldDcmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "RowPk"}, true)});
            this.dataTable1.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowPkDataGridViewTextBoxColumn,
            this.fldStrDataGridViewTextBoxColumn,
            this.fldIntDataGridViewTextBoxColumn,
            this.fldDblDataGridViewTextBoxColumn,
            this.fldDcmDataGridViewTextBoxColumn,
            this.fldDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Table1";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 338);
            this.dataGridView1.TabIndex = 1;
            // 
            // rowPkDataGridViewTextBoxColumn
            // 
            this.rowPkDataGridViewTextBoxColumn.DataPropertyName = "RowPk";
            this.rowPkDataGridViewTextBoxColumn.HeaderText = "RowPk";
            this.rowPkDataGridViewTextBoxColumn.Name = "rowPkDataGridViewTextBoxColumn";
            // 
            // fldStrDataGridViewTextBoxColumn
            // 
            this.fldStrDataGridViewTextBoxColumn.DataPropertyName = "FldStr";
            this.fldStrDataGridViewTextBoxColumn.HeaderText = "FldStr";
            this.fldStrDataGridViewTextBoxColumn.Name = "fldStrDataGridViewTextBoxColumn";
            // 
            // fldIntDataGridViewTextBoxColumn
            // 
            this.fldIntDataGridViewTextBoxColumn.DataPropertyName = "FldInt";
            this.fldIntDataGridViewTextBoxColumn.HeaderText = "FldInt";
            this.fldIntDataGridViewTextBoxColumn.Name = "fldIntDataGridViewTextBoxColumn";
            // 
            // fldDblDataGridViewTextBoxColumn
            // 
            this.fldDblDataGridViewTextBoxColumn.DataPropertyName = "FldDbl";
            this.fldDblDataGridViewTextBoxColumn.HeaderText = "FldDbl";
            this.fldDblDataGridViewTextBoxColumn.Name = "fldDblDataGridViewTextBoxColumn";
            // 
            // fldDcmDataGridViewTextBoxColumn
            // 
            this.fldDcmDataGridViewTextBoxColumn.DataPropertyName = "FldDcm";
            this.fldDcmDataGridViewTextBoxColumn.HeaderText = "FldDcm";
            this.fldDcmDataGridViewTextBoxColumn.Name = "fldDcmDataGridViewTextBoxColumn";
            // 
            // fldDateDataGridViewTextBoxColumn
            // 
            this.fldDateDataGridViewTextBoxColumn.DataPropertyName = "FldDate";
            this.fldDateDataGridViewTextBoxColumn.HeaderText = "FldDate";
            this.fldDateDataGridViewTextBoxColumn.Name = "fldDateDataGridViewTextBoxColumn";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowPkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldIntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldDblDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldDcmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldDateDataGridViewTextBoxColumn;
    }
}

