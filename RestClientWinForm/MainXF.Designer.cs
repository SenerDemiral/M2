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
            this.colIsW = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.AHPbutton = new System.Windows.Forms.Button();
            this.AFBbutton = new System.Windows.Forms.Button();
            this.persistentRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.AfbTurRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xgtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDataSet = new RestClientWinForm.MainDataSet();
            this.DVTrepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DateRepositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.AHPrepositoryItemTreeListLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit();
            this.ahpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemTreeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.colHspNoAd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBrc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAlc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.KkkTurRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.AbbTurRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.XDKbutton = new System.Windows.Forms.Button();
            this.KFTbutton = new System.Windows.Forms.Button();
            this.UYHbutton = new System.Windows.Forms.Button();
            this.ABBbutton = new System.Windows.Forms.Button();
            this.NeUpButton = new System.Windows.Forms.Button();
            this.NeDownButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AfbTurRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVTrepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRepositoryItemDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRepositoryItemDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AHPrepositoryItemTreeListLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KkkTurRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbbTurRepositoryItemLookUpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // colIsW
            // 
            this.colIsW.FieldName = "IsW";
            this.colIsW.Name = "colIsW";
            this.colIsW.Visible = true;
            this.colIsW.VisibleIndex = 1;
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
            this.DVTrepositoryItemLookUpEdit,
            this.DateRepositoryItemDateEdit,
            this.AHPrepositoryItemTreeListLookUpEdit,
            this.KkkTurRepositoryItemLookUpEdit,
            this.AbbTurRepositoryItemLookUpEdit});
            // 
            // AfbTurRepositoryItemLookUpEdit
            // 
            this.AfbTurRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AfbTurRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kd", "Kd", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowKey", "RowKey", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.AfbTurRepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.AfbTurRepositoryItemLookUpEdit.DisplayMember = "Kd";
            this.AfbTurRepositoryItemLookUpEdit.Name = "AfbTurRepositoryItemLookUpEdit";
            this.AfbTurRepositoryItemLookUpEdit.ValueMember = "RowKey";
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
            // DVTrepositoryItemLookUpEdit
            // 
            this.DVTrepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DVTrepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kd", "Kd", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowKey", "RowKey", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.DVTrepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.DVTrepositoryItemLookUpEdit.DisplayMember = "Kd";
            this.DVTrepositoryItemLookUpEdit.Name = "DVTrepositoryItemLookUpEdit";
            this.DVTrepositoryItemLookUpEdit.ValueMember = "RowKey";
            // 
            // DateRepositoryItemDateEdit
            // 
            this.DateRepositoryItemDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateRepositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateRepositoryItemDateEdit.Name = "DateRepositoryItemDateEdit";
            this.DateRepositoryItemDateEdit.ShowWeekNumbers = true;
            this.DateRepositoryItemDateEdit.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            // 
            // AHPrepositoryItemTreeListLookUpEdit
            // 
            this.AHPrepositoryItemTreeListLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.AHPrepositoryItemTreeListLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AHPrepositoryItemTreeListLookUpEdit.DataSource = this.ahpBindingSource;
            this.AHPrepositoryItemTreeListLookUpEdit.DisplayMember = "HspNoAd";
            this.AHPrepositoryItemTreeListLookUpEdit.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.AHPrepositoryItemTreeListLookUpEdit.ImmediatePopup = true;
            this.AHPrepositoryItemTreeListLookUpEdit.Name = "AHPrepositoryItemTreeListLookUpEdit";
            this.AHPrepositoryItemTreeListLookUpEdit.NullValuePrompt = "Hesap girin";
            this.AHPrepositoryItemTreeListLookUpEdit.NullValuePromptShowForEmptyValue = true;
            this.AHPrepositoryItemTreeListLookUpEdit.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.AHPrepositoryItemTreeListLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.AHPrepositoryItemTreeListLookUpEdit.TreeList = this.repositoryItemTreeListLookUpEdit1TreeList;
            this.AHPrepositoryItemTreeListLookUpEdit.ValueMember = "RowKey";
            this.AHPrepositoryItemTreeListLookUpEdit.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.AHPrepositoryItemTreeListLookUpEdit_QueryCloseUp);
            this.AHPrepositoryItemTreeListLookUpEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.AHPrepositoryItemTreeListLookUpEdit_CloseUp);
            // 
            // ahpBindingSource
            // 
            this.ahpBindingSource.DataMember = "AHP";
            this.ahpBindingSource.DataSource = this.mainDataSet;
            // 
            // repositoryItemTreeListLookUpEdit1TreeList
            // 
            this.repositoryItemTreeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colHspNoAd,
            this.colIsW,
            this.colBrc,
            this.colAlc});
            this.repositoryItemTreeListLookUpEdit1TreeList.DataSource = this.ahpBindingSource;
            this.repositoryItemTreeListLookUpEdit1TreeList.KeyFieldName = "RowKey";
            this.repositoryItemTreeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.repositoryItemTreeListLookUpEdit1TreeList.Name = "repositoryItemTreeListLookUpEdit1TreeList";
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsBehavior.ExpandNodesOnFiltering = true;
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsFind.AllowFindPanel = true;
            this.repositoryItemTreeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.repositoryItemTreeListLookUpEdit1TreeList.ParentFieldName = "P";
            this.repositoryItemTreeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.repositoryItemTreeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // colHspNoAd
            // 
            this.colHspNoAd.FieldName = "HspNoAd";
            this.colHspNoAd.Name = "colHspNoAd";
            this.colHspNoAd.Visible = true;
            this.colHspNoAd.VisibleIndex = 0;
            // 
            // colBrc
            // 
            this.colBrc.FieldName = "Brc";
            this.colBrc.Format.FormatString = "n";
            this.colBrc.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBrc.Name = "colBrc";
            this.colBrc.Visible = true;
            this.colBrc.VisibleIndex = 2;
            // 
            // colAlc
            // 
            this.colAlc.FieldName = "Alc";
            this.colAlc.Format.FormatString = "n";
            this.colAlc.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAlc.Name = "colAlc";
            this.colAlc.Visible = true;
            this.colAlc.VisibleIndex = 3;
            // 
            // KkkTurRepositoryItemLookUpEdit
            // 
            this.KkkTurRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KkkTurRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kd", "Kd", 22, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RowKey", "RowKey", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.KkkTurRepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.KkkTurRepositoryItemLookUpEdit.DisplayMember = "Ad";
            this.KkkTurRepositoryItemLookUpEdit.Name = "KkkTurRepositoryItemLookUpEdit";
            this.KkkTurRepositoryItemLookUpEdit.ValueMember = "RowKey";
            // 
            // AbbTurRepositoryItemLookUpEdit
            // 
            this.AbbTurRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AbbTurRepositoryItemLookUpEdit.DataSource = this.xgtBindingSource;
            this.AbbTurRepositoryItemLookUpEdit.DisplayMember = "Ad";
            this.AbbTurRepositoryItemLookUpEdit.Name = "AbbTurRepositoryItemLookUpEdit";
            this.AbbTurRepositoryItemLookUpEdit.ValueMember = "RowKey";
            // 
            // XDKbutton
            // 
            this.XDKbutton.Location = new System.Drawing.Point(22, 97);
            this.XDKbutton.Name = "XDKbutton";
            this.XDKbutton.Size = new System.Drawing.Size(75, 23);
            this.XDKbutton.TabIndex = 2;
            this.XDKbutton.Text = "XDK";
            this.XDKbutton.UseVisualStyleBackColor = true;
            this.XDKbutton.Click += new System.EventHandler(this.XDKbutton_Click);
            // 
            // KFTbutton
            // 
            this.KFTbutton.Location = new System.Drawing.Point(22, 142);
            this.KFTbutton.Name = "KFTbutton";
            this.KFTbutton.Size = new System.Drawing.Size(75, 23);
            this.KFTbutton.TabIndex = 3;
            this.KFTbutton.Text = "KFT";
            this.KFTbutton.UseVisualStyleBackColor = true;
            this.KFTbutton.Click += new System.EventHandler(this.KFTbutton_Click);
            // 
            // UYHbutton
            // 
            this.UYHbutton.Location = new System.Drawing.Point(22, 181);
            this.UYHbutton.Name = "UYHbutton";
            this.UYHbutton.Size = new System.Drawing.Size(75, 23);
            this.UYHbutton.TabIndex = 4;
            this.UYHbutton.Text = "UYH";
            this.UYHbutton.UseVisualStyleBackColor = true;
            this.UYHbutton.Click += new System.EventHandler(this.UYHbutton_Click);
            // 
            // ABBbutton
            // 
            this.ABBbutton.Location = new System.Drawing.Point(122, 55);
            this.ABBbutton.Name = "ABBbutton";
            this.ABBbutton.Size = new System.Drawing.Size(75, 23);
            this.ABBbutton.TabIndex = 5;
            this.ABBbutton.Text = "ABB";
            this.ABBbutton.UseVisualStyleBackColor = true;
            this.ABBbutton.Click += new System.EventHandler(this.ABBbutton_Click);
            // 
            // NeUpButton
            // 
            this.NeUpButton.Location = new System.Drawing.Point(22, 210);
            this.NeUpButton.Name = "NeUpButton";
            this.NeUpButton.Size = new System.Drawing.Size(75, 23);
            this.NeUpButton.TabIndex = 6;
            this.NeUpButton.Text = "NeUp";
            this.NeUpButton.UseVisualStyleBackColor = true;
            this.NeUpButton.Click += new System.EventHandler(this.NeUpButton_Click);
            // 
            // NeDownButton
            // 
            this.NeDownButton.Location = new System.Drawing.Point(113, 210);
            this.NeDownButton.Name = "NeDownButton";
            this.NeDownButton.Size = new System.Drawing.Size(75, 23);
            this.NeDownButton.TabIndex = 7;
            this.NeDownButton.Text = "NeDown";
            this.NeDownButton.UseVisualStyleBackColor = true;
            this.NeDownButton.Click += new System.EventHandler(this.NeDownButton_Click);
            // 
            // MainXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.NeDownButton);
            this.Controls.Add(this.NeUpButton);
            this.Controls.Add(this.ABBbutton);
            this.Controls.Add(this.UYHbutton);
            this.Controls.Add(this.KFTbutton);
            this.Controls.Add(this.XDKbutton);
            this.Controls.Add(this.AFBbutton);
            this.Controls.Add(this.AHPbutton);
            this.Name = "MainXF";
            this.Text = "MainXF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainXF_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.AfbTurRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVTrepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRepositoryItemDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRepositoryItemDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AHPrepositoryItemTreeListLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KkkTurRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbbTurRepositoryItemLookUpEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AHPbutton;
        private System.Windows.Forms.Button AFBbutton;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AfbTurRepositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource xgtBindingSource;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit DVTrepositoryItemLookUpEdit;
        public DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository;
        private System.Windows.Forms.BindingSource ahpBindingSource;
        private System.Windows.Forms.Button XDKbutton;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit DateRepositoryItemDateEdit;
        public DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit AHPrepositoryItemTreeListLookUpEdit;
        private DevExpress.XtraTreeList.TreeList repositoryItemTreeListLookUpEdit1TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsW;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBrc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAlc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHspNoAd;
        private System.Windows.Forms.Button KFTbutton;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit KkkTurRepositoryItemLookUpEdit;
        public MainDataSet mainDataSet;
        private System.Windows.Forms.Button UYHbutton;
        private System.Windows.Forms.Button ABBbutton;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AbbTurRepositoryItemLookUpEdit;
        private System.Windows.Forms.Button NeUpButton;
        private System.Windows.Forms.Button NeDownButton;
    }
}