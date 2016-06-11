namespace WordDocEditTimer
{
    partial class TimerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public TimerRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.toggleDisplayButton = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.pauseCheckBox = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabHome";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabHome";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.toggleDisplayButton);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.pauseCheckBox);
            this.group1.Label = "Timer Controls";
            this.group1.Name = "group1";
            this.group1.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.group1_DialogLauncherClick);
            // 
            // toggleDisplayButton
            // 
            this.toggleDisplayButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleDisplayButton.Label = "Toggle Timer Display";
            this.toggleDisplayButton.Name = "toggleDisplayButton";
            this.toggleDisplayButton.OfficeImageId = "StartAfterPrevious";
            this.toggleDisplayButton.ShowImage = true;
            this.toggleDisplayButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleDisplayButton_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // pauseCheckBox
            // 
            this.pauseCheckBox.Label = "Timer paused";
            this.pauseCheckBox.Name = "pauseCheckBox";
            this.pauseCheckBox.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.pauseCheckBox_Click);
            // 
            // TimerRibbon
            // 
            this.Name = "TimerRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.TimerRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonButton toggleDisplayButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox pauseCheckBox;

    }

    partial class ThisRibbonCollection
    {
        internal TimerRibbon TimerRibbon
        {
            get { return this.GetRibbon<TimerRibbon>(); }
        }
    }
}
