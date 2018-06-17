namespace RestClientWinForm
{
    partial class MainXF
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
            this.AHPbutton = new System.Windows.Forms.Button();
            this.AFBbutton = new System.Windows.Forms.Button();
            this.persistentRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.AfbTurRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xgtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.DvzRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ahpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AHPrepositoryItemSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.AfbTurRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvzRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AHPrepositoryItemSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // AHPbutton
            // 
            this.AHPbutton.Location = new System.Drawing.Point(22, 12);
            this.AHPbutton.Name = "AHPbutton";
            this.AHPbutton.Size = new System.Drawing.Size(75, 23);
            this.AHPbutton.TabIndex = 0;
            this.AHPbutton.Text = "AHP";
            this.AHPbutton.UseVisualStyleBackColor = true;
            this.AHPbutton.Click += new System.EventHandler(this.AHPbutton_Click);
            // 
            // AFBbutton
            // 
            this.AFBbutton.Location = new System.Drawing.Point(22, 55);
            this.AFBbutton.Name = "AFBbutton";
            this.AFBbutton.Size = new System.Drawing.Size(75, 23);
            this.AFBbutton.TabIndex = 1;
            this.AFBbutton.Text = "AFB";
            this.AFBbutton.UseVisualStyleBackColor = true;
            this.AFBbutton.Click += new System.EventHandler(this.AFBbutton_Click);
            // 
            // persistentRepository
            // 
            this.persistentRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.AfbTurRepositoryItemLookUpEdit,
            this.DvzRepositoryItemLookUpEdit,
            this.AHPrepositoryItemSearchLookUpEdit});
            // 
            // AfbTurRepositoryItemLookUpEdit
            // 
            this.AfbTurRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AfbTurRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kd", "Kd", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowPk", "Row Pk", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.AfbTurRepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.AfbTurRepositoryItemLookUpEdit.DisplayMember = "Kd";
            this.AfbTurRepositoryItemLookUpEdit.Name = "AfbTurRepositoryItemLookUpEdit";
            this.AfbTurRepositoryItemLookUpEdit.ValueMember = "RowPk";
            // 
            // xgtBindingSource
            // 
            this.xgtBindingSource.DataMember = "XGT";
            this.xgtBindingSource.DataSource = this.mainDataSet;
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DvzRepositoryItemLookUpEdit
            // 
            this.DvzRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DvzRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kd", "Kd", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowPk", "Row Pk", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.DvzRepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.DvzRepositoryItemLookUpEdit.DisplayMember = "Kd";
            this.DvzRepositoryItemLookUpEdit.Name = "DvzRepositoryItemLookUpEdit";
            this.DvzRepositoryItemLookUpEdit.ValueMember = "RowPk";
            // 
            // ahpBindingSource
            // 
            this.ahpBindingSource.DataMember = "AHP";
            this.ahpBindingSource.DataSource = this.mainDataSet;
            // 
            // AHPrepositoryItemSearchLookUpEdit
            // 
            this.AHPrepositoryItemSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AHPrepositoryItemSearchLookUpEdit.DataSource = this.ahpBindingSource;
            this.AHPrepositoryItemSearchLookUpEdit.DisplayMember = "Ad";
            this.AHPrepositoryItemSearchLookUpEdit.Name = "AHPrepositoryItemSearchLookUpEdit";
            this.AHPrepositoryItemSearchLookUpEdit.ValueMember = "RowPk";
            this.AHPrepositoryItemSearchLookUpEdit.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // MainXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AFBbutton);
            this.Controls.Add(this.AHPbutton);
            this.Name = "MainXF";
            this.Text = "MainXF";
            ((System.ComponentModel.ISupportInitialize)(this.AfbTurRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DvzRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AHPrepositoryItemSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MainDataSet mainDataSet;
        private System.Windows.Forms.Button AHPbutton;
        private System.Windows.Forms.Button AFBbutton;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AfbTurRepositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource xgtBindingSource;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit DvzRepositoryItemLookUpEdit;
        public DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository;
        public DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit AHPrepositoryItemSearchLookUpEdit;
        private System.Windows.Forms.BindingSource ahpBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}