namespace MainExample
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.controlSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExample = new System.Windows.Forms.ToolStripMenuItem();
            this.listExample = new System.Windows.Forms.ToolStripMenuItem();
            this.validationExample = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxExample = new System.Windows.Forms.ToolStripMenuItem();
            this.panelExample = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterExample = new System.Windows.Forms.ToolStripMenuItem();
            this.userControlExample = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetExample = new System.Windows.Forms.ToolStripMenuItem();
            this.arrayDataSourceExample = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTableExample = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewExample = new System.Windows.Forms.ToolStripMenuItem();
            this.genericListExample = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.controlSamplesToolStripMenuItem,
            this.dataSamplesToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(782, 26);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(46, 22);
            this.fileMenu.Text = "&File";
            // 
            // fileExit
            // 
            this.fileExit.Name = "fileExit";
            this.fileExit.Size = new System.Drawing.Size(103, 22);
            this.fileExit.Text = "E&xit";
            this.fileExit.Click += new System.EventHandler(this.fileExit_Click);
            // 
            // controlSamplesToolStripMenuItem
            // 
            this.controlSamplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExample,
            this.listExample,
            this.validationExample,
            this.textBoxExample,
            this.panelExample,
            this.splitterExample,
            this.userControlExample});
            this.controlSamplesToolStripMenuItem.Name = "controlSamplesToolStripMenuItem";
            this.controlSamplesToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.controlSamplesToolStripMenuItem.Text = "Control Samples";
            // 
            // buttonExample
            // 
            this.buttonExample.Name = "buttonExample";
            this.buttonExample.Size = new System.Drawing.Size(231, 22);
            this.buttonExample.Text = "Button Example";
            this.buttonExample.Click += new System.EventHandler(this.buttonExample_Click);
            // 
            // listExample
            // 
            this.listExample.Name = "listExample";
            this.listExample.Size = new System.Drawing.Size(231, 22);
            this.listExample.Text = "List Example";
            this.listExample.Click += new System.EventHandler(this.listExample_Click);
            // 
            // validationExample
            // 
            this.validationExample.Name = "validationExample";
            this.validationExample.Size = new System.Drawing.Size(231, 22);
            this.validationExample.Text = "ValidationExample";
            this.validationExample.Click += new System.EventHandler(this.validationExample_Click);
            // 
            // textBoxExample
            // 
            this.textBoxExample.Name = "textBoxExample";
            this.textBoxExample.Size = new System.Drawing.Size(231, 22);
            this.textBoxExample.Text = "Text Box Example";
            this.textBoxExample.Click += new System.EventHandler(this.textBoxExample_Click);
            // 
            // panelExample
            // 
            this.panelExample.Name = "panelExample";
            this.panelExample.Size = new System.Drawing.Size(231, 22);
            this.panelExample.Text = "Panel Example";
            this.panelExample.Click += new System.EventHandler(this.panelExample_Click);
            // 
            // splitterExample
            // 
            this.splitterExample.Name = "splitterExample";
            this.splitterExample.Size = new System.Drawing.Size(231, 22);
            this.splitterExample.Text = "Splitter Example";
            this.splitterExample.Click += new System.EventHandler(this.splitterExample_Click);
            // 
            // userControlExample
            // 
            this.userControlExample.Name = "userControlExample";
            this.userControlExample.Size = new System.Drawing.Size(231, 22);
            this.userControlExample.Text = "User Control Example";
            this.userControlExample.Click += new System.EventHandler(this.userControlExample_Click);
            // 
            // dataSamplesToolStripMenuItem
            // 
            this.dataSamplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSetExample,
            this.arrayDataSourceExample,
            this.dataTableExample,
            this.dataViewExample,
            this.genericListExample});
            this.dataSamplesToolStripMenuItem.Name = "dataSamplesToolStripMenuItem";
            this.dataSamplesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.dataSamplesToolStripMenuItem.Text = "Data Samples";
            // 
            // dataSetExample
            // 
            this.dataSetExample.Name = "dataSetExample";
            this.dataSetExample.Size = new System.Drawing.Size(263, 22);
            this.dataSetExample.Text = "DataSet Example";
            this.dataSetExample.Click += new System.EventHandler(this.dataSetExample_Click);
            // 
            // arrayDataSourceExample
            // 
            this.arrayDataSourceExample.Name = "arrayDataSourceExample";
            this.arrayDataSourceExample.Size = new System.Drawing.Size(263, 22);
            this.arrayDataSourceExample.Text = "Array data source Example";
            this.arrayDataSourceExample.Click += new System.EventHandler(this.arrayDataSourceExample_Click);
            // 
            // dataTableExample
            // 
            this.dataTableExample.Name = "dataTableExample";
            this.dataTableExample.Size = new System.Drawing.Size(263, 22);
            this.dataTableExample.Text = "Data Table Example";
            this.dataTableExample.Click += new System.EventHandler(this.dataTableSourceExample_Click);
            // 
            // dataViewExample
            // 
            this.dataViewExample.Name = "dataViewExample";
            this.dataViewExample.Size = new System.Drawing.Size(263, 22);
            this.dataViewExample.Text = "Data View Example";
            this.dataViewExample.Click += new System.EventHandler(this.dataViewExample_Click);
            // 
            // genericListExample
            // 
            this.genericListExample.Name = "genericListExample";
            this.genericListExample.Size = new System.Drawing.Size(263, 22);
            this.genericListExample.Text = "Generic List Example";
            this.genericListExample.Click += new System.EventHandler(this.genericListExample_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 555);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Pro C# 2010 Windows Forms";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExit;
        private System.Windows.Forms.ToolStripMenuItem controlSamplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSamplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonExample;
        private System.Windows.Forms.ToolStripMenuItem listExample;
        private System.Windows.Forms.ToolStripMenuItem validationExample;
        private System.Windows.Forms.ToolStripMenuItem textBoxExample;
        private System.Windows.Forms.ToolStripMenuItem panelExample;
        private System.Windows.Forms.ToolStripMenuItem splitterExample;
        private System.Windows.Forms.ToolStripMenuItem userControlExample;
        private System.Windows.Forms.ToolStripMenuItem dataSetExample;
        private System.Windows.Forms.ToolStripMenuItem arrayDataSourceExample;
        private System.Windows.Forms.ToolStripMenuItem dataTableExample;
        private System.Windows.Forms.ToolStripMenuItem dataViewExample;
        private System.Windows.Forms.ToolStripMenuItem genericListExample;
    }
}

