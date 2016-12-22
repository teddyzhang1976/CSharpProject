namespace FilePropertiesAndMovement
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxNewPath = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCopyTo = new System.Windows.Forms.Button();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLastAccessTime = new System.Windows.Forms.TextBox();
            this.textBoxLastWriteTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCreationTime = new System.Windows.Forms.TextBox();
            this.textBoxFileSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDisplay = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBoxNewPath);
            this.groupBox5.Controls.Add(this.buttonDelete);
            this.groupBox5.Controls.Add(this.buttonCopyTo);
            this.groupBox5.Controls.Add(this.buttonMoveTo);
            this.groupBox5.Location = new System.Drawing.Point(8, 368);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(480, 88);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Move, Delete or Copy File";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "New Location";
            // 
            // textBoxNewPath
            // 
            this.textBoxNewPath.Location = new System.Drawing.Point(88, 56);
            this.textBoxNewPath.Name = "textBoxNewPath";
            this.textBoxNewPath.Size = new System.Drawing.Size(384, 20);
            this.textBoxNewPath.TabIndex = 5;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(168, 16);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // buttonCopyTo
            // 
            this.buttonCopyTo.Location = new System.Drawing.Point(88, 16);
            this.buttonCopyTo.Name = "buttonCopyTo";
            this.buttonCopyTo.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyTo.TabIndex = 1;
            this.buttonCopyTo.Text = "Copy To";
            this.buttonCopyTo.Click += new System.EventHandler(this.OnCopyButtonClick);
            // 
            // buttonMoveTo
            // 
            this.buttonMoveTo.Location = new System.Drawing.Point(8, 16);
            this.buttonMoveTo.Name = "buttonMoveTo";
            this.buttonMoveTo.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveTo.TabIndex = 0;
            this.buttonMoveTo.Text = "Move To";
            this.buttonMoveTo.Click += new System.EventHandler(this.OnMoveButtonClick);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Creation time";
            // 
            // textBoxLastAccessTime
            // 
            this.textBoxLastAccessTime.Enabled = false;
            this.textBoxLastAccessTime.Location = new System.Drawing.Point(232, 112);
            this.textBoxLastAccessTime.Name = "textBoxLastAccessTime";
            this.textBoxLastAccessTime.Size = new System.Drawing.Size(184, 20);
            this.textBoxLastAccessTime.TabIndex = 1;
            // 
            // textBoxLastWriteTime
            // 
            this.textBoxLastWriteTime.Enabled = false;
            this.textBoxLastWriteTime.Location = new System.Drawing.Point(16, 112);
            this.textBoxLastWriteTime.Name = "textBoxLastWriteTime";
            this.textBoxLastWriteTime.Size = new System.Drawing.Size(184, 20);
            this.textBoxLastWriteTime.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Last modification time";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Enter name of folder to be examined and click Display";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(240, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Last access time";
            // 
            // textBoxCreationTime
            // 
            this.textBoxCreationTime.Enabled = false;
            this.textBoxCreationTime.Location = new System.Drawing.Point(232, 72);
            this.textBoxCreationTime.Name = "textBoxCreationTime";
            this.textBoxCreationTime.Size = new System.Drawing.Size(184, 20);
            this.textBoxCreationTime.TabIndex = 15;
            // 
            // textBoxFileSize
            // 
            this.textBoxFileSize.Enabled = false;
            this.textBoxFileSize.Location = new System.Drawing.Point(24, 288);
            this.textBoxFileSize.Name = "textBoxFileSize";
            this.textBoxFileSize.Size = new System.Drawing.Size(184, 20);
            this.textBoxFileSize.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "File Size";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(252, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Folders";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Files";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "File name";
            // 
            // buttonDisplay
            // 
            this.buttonDisplay.Location = new System.Drawing.Point(428, 25);
            this.buttonDisplay.Name = "buttonDisplay";
            this.buttonDisplay.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplay.TabIndex = 35;
            this.buttonDisplay.Text = "Display";
            this.buttonDisplay.Click += new System.EventHandler(this.OnDisplayButtonClick);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Enabled = false;
            this.textBoxFolder.Location = new System.Drawing.Point(8, 24);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(384, 20);
            this.textBoxFolder.TabIndex = 2;
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(404, 73);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(72, 24);
            this.buttonUp.TabIndex = 34;
            this.buttonUp.Text = "Up";
            this.buttonUp.Click += new System.EventHandler(this.OnUpButtonClick);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 25);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(408, 20);
            this.textBoxInput.TabIndex = 31;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Enabled = false;
            this.textBoxFileName.Location = new System.Drawing.Point(80, 240);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(400, 20);
            this.textBoxFileName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLastAccessTime);
            this.groupBox2.Controls.Add(this.textBoxCreationTime);
            this.groupBox2.Controls.Add(this.textBoxLastWriteTime);
            this.groupBox2.Location = new System.Drawing.Point(8, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 144);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details of Selected File";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Location = new System.Drawing.Point(12, 121);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(240, 134);
            this.listBoxFiles.TabIndex = 28;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.OnListBoxFilesSelected);
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.Location = new System.Drawing.Point(260, 121);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(240, 134);
            this.listBoxFolders.TabIndex = 30;
            this.listBoxFolders.SelectedIndexChanged += new System.EventHandler(this.OnListBoxFoldersSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFileSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxFileName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxFolder);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(4, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 464);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contents of folder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDisplay);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "FilePropertiesAndMovement Sample";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxNewPath;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCopyTo;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLastAccessTime;
        private System.Windows.Forms.TextBox textBoxLastWriteTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCreationTime;
        private System.Windows.Forms.TextBox textBoxFileSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDisplay;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.GroupBox groupBox1;




    }
}

