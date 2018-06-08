namespace RestClientWinForm
{
    partial class AhpEditXF
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.aHPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accDataSet = new RestClientWinForm.AccDataSet();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.NoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.AdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForAd = new DevExpress.XtraLayout.LayoutControlItem();
            this.ObjPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForObjP = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForObjP)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(367, 410);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // aHPBindingSource
            // 
            this.aHPBindingSource.DataMember = "AHP";
            this.aHPBindingSource.DataSource = this.accDataSet;
            // 
            // accDataSet
            // 
            this.accDataSet.DataSetName = "AccDataSet";
            this.accDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(367, 410);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.NoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ObjPTextEdit);
            this.dataLayoutControl1.DataSource = this.aHPBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(343, 386);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(347, 390);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(343, 386);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNo,
            this.ItemForAd,
            this.ItemForObjP});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(323, 366);
            // 
            // NoTextEdit
            // 
            this.NoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.aHPBindingSource, "No", true));
            this.NoTextEdit.Location = new System.Drawing.Point(42, 12);
            this.NoTextEdit.Name = "NoTextEdit";
            this.NoTextEdit.Size = new System.Drawing.Size(289, 20);
            this.NoTextEdit.StyleController = this.dataLayoutControl1;
            this.NoTextEdit.TabIndex = 4;
            // 
            // ItemForNo
            // 
            this.ItemForNo.Control = this.NoTextEdit;
            this.ItemForNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForNo.Name = "ItemForNo";
            this.ItemForNo.Size = new System.Drawing.Size(323, 24);
            this.ItemForNo.Text = "No";
            this.ItemForNo.TextSize = new System.Drawing.Size(26, 13);
            // 
            // AdTextEdit
            // 
            this.AdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.aHPBindingSource, "Ad", true));
            this.AdTextEdit.Location = new System.Drawing.Point(42, 36);
            this.AdTextEdit.Name = "AdTextEdit";
            this.AdTextEdit.Size = new System.Drawing.Size(289, 20);
            this.AdTextEdit.StyleController = this.dataLayoutControl1;
            this.AdTextEdit.TabIndex = 5;
            // 
            // ItemForAd
            // 
            this.ItemForAd.Control = this.AdTextEdit;
            this.ItemForAd.Location = new System.Drawing.Point(0, 24);
            this.ItemForAd.Name = "ItemForAd";
            this.ItemForAd.Size = new System.Drawing.Size(323, 24);
            this.ItemForAd.Text = "Ad";
            this.ItemForAd.TextSize = new System.Drawing.Size(26, 13);
            // 
            // ObjPTextEdit
            // 
            this.ObjPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.aHPBindingSource, "ObjP", true));
            this.ObjPTextEdit.Location = new System.Drawing.Point(42, 60);
            this.ObjPTextEdit.Name = "ObjPTextEdit";
            this.ObjPTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ObjPTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ObjPTextEdit.Properties.Mask.EditMask = "N0";
            this.ObjPTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ObjPTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ObjPTextEdit.Size = new System.Drawing.Size(289, 20);
            this.ObjPTextEdit.StyleController = this.dataLayoutControl1;
            this.ObjPTextEdit.TabIndex = 6;
            // 
            // ItemForObjP
            // 
            this.ItemForObjP.Control = this.ObjPTextEdit;
            this.ItemForObjP.Location = new System.Drawing.Point(0, 48);
            this.ItemForObjP.Name = "ItemForObjP";
            this.ItemForObjP.Size = new System.Drawing.Size(323, 318);
            this.ItemForObjP.Text = "Obj P";
            this.ItemForObjP.TextSize = new System.Drawing.Size(26, 13);
            // 
            // AhpEditXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 410);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AhpEditXF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AhpEditXF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AhpEditXF_FormClosing);
            this.Load += new System.EventHandler(this.AhpEditXF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aHPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForObjP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource aHPBindingSource;
        private AccDataSet accDataSet;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit NoTextEdit;
        private DevExpress.XtraEditors.TextEdit AdTextEdit;
        private DevExpress.XtraEditors.TextEdit ObjPTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAd;
        private DevExpress.XtraLayout.LayoutControlItem ItemForObjP;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}