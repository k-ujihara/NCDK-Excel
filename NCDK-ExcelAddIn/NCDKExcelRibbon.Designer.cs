namespace NCDK_ExcelAddIn
{
    partial class NCDKExcelRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NCDKExcelRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabNCDK = this.Factory.CreateRibbonTab();
            this.groupGeneral = this.Factory.CreateRibbonGroup();
            this.buttonImportSDF = this.Factory.CreateRibbonButton();
            this.buttonGeneratePicture = this.Factory.CreateRibbonButton();
            this.tabNCDK.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNCDK
            // 
            this.tabNCDK.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabNCDK.Groups.Add(this.groupGeneral);
            this.tabNCDK.Label = "TabAddIns";
            this.tabNCDK.Name = "tabNCDK";
            // 
            // groupGeneral
            // 
            this.groupGeneral.Items.Add(this.buttonImportSDF);
            this.groupGeneral.Items.Add(this.buttonGeneratePicture);
            this.groupGeneral.Label = "NCDK";
            this.groupGeneral.Name = "groupGeneral";
            // 
            // buttonImportSDF
            // 
            this.buttonImportSDF.Label = "Import SDF";
            this.buttonImportSDF.Name = "buttonImportSDF";
            this.buttonImportSDF.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonImportSDF_Click);
            // 
            // buttonGeneratePicture
            // 
            this.buttonGeneratePicture.Label = "Generate Picture";
            this.buttonGeneratePicture.Name = "buttonGeneratePicture";
            this.buttonGeneratePicture.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonGeneratePicture_Click);
            // 
            // NCDKExcelRibbon
            // 
            this.Name = "NCDKExcelRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabNCDK);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.NCDKExcelRibbon_Load);
            this.tabNCDK.ResumeLayout(false);
            this.tabNCDK.PerformLayout();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabNCDK;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupGeneral;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonImportSDF;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonGeneratePicture;
    }

    partial class ThisRibbonCollection
    {
        internal NCDKExcelRibbon NCDKExcelRibbon
        {
            get { return this.GetRibbon<NCDKExcelRibbon>(); }
        }
    }
}
