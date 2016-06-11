namespace RibbonImageSource
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
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
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl8 = this.Factory.CreateRibbonDropDownItem();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button8 = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.button10 = this.Factory.CreateRibbonButton();
            this.button9 = this.Factory.CreateRibbonButton();
            this.button11 = this.Factory.CreateRibbonButton();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.button7 = this.Factory.CreateRibbonButton();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.button6 = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.splitButton1 = this.Factory.CreateRibbonSplitButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.menu3 = this.Factory.CreateRibbonMenu();
            this.button12 = this.Factory.CreateRibbonButton();
            this.button13 = this.Factory.CreateRibbonButton();
            this.dropDown1 = this.Factory.CreateRibbonDropDown();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.checkBox1 = this.Factory.CreateRibbonCheckBox();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.separator5 = this.Factory.CreateRibbonSeparator();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.gallery1 = this.Factory.CreateRibbonGallery();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button8);
            this.group1.Items.Add(this.separator4);
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Items.Add(this.menu1);
            this.group1.Items.Add(this.separator3);
            this.group1.Items.Add(this.splitButton1);
            this.group1.Items.Add(this.dropDown1);
            this.group1.Items.Add(this.checkBox1);
            this.group1.Items.Add(this.editBox1);
            this.group1.Items.Add(this.separator5);
            this.group1.Items.Add(this.label1);
            this.group1.Items.Add(this.gallery1);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // button8
            // 
            this.button8.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button8.Label = "Large Button";
            this.button8.Name = "button8";
            this.button8.ShowImage = true;
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.button10);
            this.buttonGroup1.Items.Add(this.button9);
            this.buttonGroup1.Items.Add(this.button11);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // button10
            // 
            this.button10.Label = "button10";
            this.button10.Name = "button10";
            this.button10.OfficeImageId = "_1";
            this.button10.ShowImage = true;
            this.button10.ShowLabel = false;
            // 
            // button9
            // 
            this.button9.Label = "button9";
            this.button9.Name = "button9";
            this.button9.OfficeImageId = "_2";
            this.button9.ShowImage = true;
            this.button9.ShowLabel = false;
            // 
            // button11
            // 
            this.button11.Label = "button11";
            this.button11.Name = "button11";
            this.button11.OfficeImageId = "_3";
            this.button11.ShowImage = true;
            this.button11.ShowLabel = false;
            // 
            // menu1
            // 
            this.menu1.Items.Add(this.button7);
            this.menu1.Items.Add(this.menu2);
            this.menu1.Items.Add(this.button6);
            this.menu1.Label = "My Menu";
            this.menu1.Name = "menu1";
            // 
            // button7
            // 
            this.button7.Label = "button7";
            this.button7.Name = "button7";
            this.button7.ShowImage = true;
            // 
            // menu2
            // 
            this.menu2.Label = "menu2";
            this.menu2.Name = "menu2";
            this.menu2.ShowImage = true;
            // 
            // button6
            // 
            this.button6.Label = "button6";
            this.button6.Name = "button6";
            this.button6.ShowImage = true;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // splitButton1
            // 
            this.splitButton1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton1.Items.Add(this.button1);
            this.splitButton1.Items.Add(this.menu3);
            this.splitButton1.Label = "Split Button";
            this.splitButton1.Name = "splitButton1";
            // 
            // button1
            // 
            this.button1.Label = "Button on menu";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            // 
            // menu3
            // 
            this.menu3.Items.Add(this.button12);
            this.menu3.Items.Add(this.button13);
            this.menu3.Label = "Submenu";
            this.menu3.Name = "menu3";
            this.menu3.ShowImage = true;
            // 
            // button12
            // 
            this.button12.Label = "A button";
            this.button12.Name = "button12";
            this.button12.ShowImage = true;
            // 
            // button13
            // 
            this.button13.Label = "Another Button";
            this.button13.Name = "button13";
            this.button13.ShowImage = true;
            // 
            // dropDown1
            // 
            this.dropDown1.Buttons.Add(this.button2);
            this.dropDown1.Buttons.Add(this.button3);
            this.dropDown1.Buttons.Add(this.button4);
            this.dropDown1.Buttons.Add(this.button5);
            ribbonDropDownItemImpl5.Label = "Item0";
            ribbonDropDownItemImpl6.Label = "Item1";
            this.dropDown1.Items.Add(ribbonDropDownItemImpl5);
            this.dropDown1.Items.Add(ribbonDropDownItemImpl6);
            this.dropDown1.Label = "A drop down";
            this.dropDown1.Name = "dropDown1";
            // 
            // button2
            // 
            this.button2.Label = "button2";
            this.button2.Name = "button2";
            // 
            // button3
            // 
            this.button3.Label = "button3";
            this.button3.Name = "button3";
            // 
            // button4
            // 
            this.button4.Label = "button4";
            this.button4.Name = "button4";
            // 
            // button5
            // 
            this.button5.Label = "button5";
            this.button5.Name = "button5";
            // 
            // checkBox1
            // 
            this.checkBox1.Label = "Check Box";
            this.checkBox1.Name = "checkBox1";
            // 
            // editBox1
            // 
            this.editBox1.Label = "Edit Box";
            this.editBox1.Name = "editBox1";
            this.editBox1.Text = null;
            // 
            // separator5
            // 
            this.separator5.Name = "separator5";
            // 
            // label1
            // 
            this.label1.Label = "A label";
            this.label1.Name = "label1";
            // 
            // gallery1
            // 
            ribbonDropDownItemImpl7.Label = "Item0";
            ribbonDropDownItemImpl8.Label = "Item1";
            this.gallery1.Items.Add(ribbonDropDownItemImpl7);
            this.gallery1.Items.Add(ribbonDropDownItemImpl8);
            this.gallery1.Label = "Gallery";
            this.gallery1.Name = "gallery1";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // toggleButton2
            // 
            this.toggleButton2.Label = "toggleButton2";
            this.toggleButton2.Name = "toggleButton2";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown dropDown1;
        private Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        private Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        private Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        private Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button10;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button9;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button11;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button12;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button13;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator5;
        internal Microsoft.Office.Tools.Ribbon.RibbonGallery gallery1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;

    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
