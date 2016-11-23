namespace Chapter_15_CSharp
{
    partial class EntityQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityQuery));
            this.LabelResults = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPredefined = new System.Windows.Forms.TabPage();
            this.ActNavigationProperty = new System.Windows.Forms.Button();
            this.ActSimpleRetrieval = new System.Windows.Forms.Button();
            this.ActSingleEntity = new System.Windows.Forms.Button();
            this.ActDataTable = new System.Windows.Forms.Button();
            this.ActAnonymousType = new System.Windows.Forms.Button();
            this.TabCustom = new System.Windows.Forms.TabPage();
            this.CustomQuery = new System.Windows.Forms.TextBox();
            this.ActProcess = new System.Windows.Forms.Button();
            this.TabModel = new System.Windows.Forms.TabPage();
            this.ModelImage = new System.Windows.Forms.PictureBox();
            this.DisplayResults = new System.Windows.Forms.DataGridView();
            this.TabControl1.SuspendLayout();
            this.TabPredefined.SuspendLayout();
            this.TabCustom.SuspendLayout();
            this.TabModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResults)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelResults
            // 
            this.LabelResults.AutoSize = true;
            this.LabelResults.Location = new System.Drawing.Point(8, 280);
            this.LabelResults.Name = "LabelResults";
            this.LabelResults.Size = new System.Drawing.Size(42, 13);
            this.LabelResults.TabIndex = 1;
            this.LabelResults.Text = "Results";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPredefined);
            this.TabControl1.Controls.Add(this.TabCustom);
            this.TabControl1.Controls.Add(this.TabModel);
            this.TabControl1.Location = new System.Drawing.Point(8, 8);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(464, 256);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPredefined
            // 
            this.TabPredefined.Controls.Add(this.ActNavigationProperty);
            this.TabPredefined.Controls.Add(this.ActSimpleRetrieval);
            this.TabPredefined.Controls.Add(this.ActSingleEntity);
            this.TabPredefined.Controls.Add(this.ActDataTable);
            this.TabPredefined.Controls.Add(this.ActAnonymousType);
            this.TabPredefined.Location = new System.Drawing.Point(4, 22);
            this.TabPredefined.Name = "TabPredefined";
            this.TabPredefined.Padding = new System.Windows.Forms.Padding(3);
            this.TabPredefined.Size = new System.Drawing.Size(456, 230);
            this.TabPredefined.TabIndex = 0;
            this.TabPredefined.Text = "Predefined Queries";
            this.TabPredefined.UseVisualStyleBackColor = true;
            // 
            // ActNavigationProperty
            // 
            this.ActNavigationProperty.Location = new System.Drawing.Point(8, 80);
            this.ActNavigationProperty.Name = "ActNavigationProperty";
            this.ActNavigationProperty.Size = new System.Drawing.Size(160, 23);
            this.ActNavigationProperty.TabIndex = 2;
            this.ActNavigationProperty.Text = "Navigation Property";
            this.ActNavigationProperty.UseVisualStyleBackColor = true;
            this.ActNavigationProperty.Click += new System.EventHandler(this.ActNavigationProperty_Click);
            // 
            // ActSimpleRetrieval
            // 
            this.ActSimpleRetrieval.Location = new System.Drawing.Point(8, 16);
            this.ActSimpleRetrieval.Name = "ActSimpleRetrieval";
            this.ActSimpleRetrieval.Size = new System.Drawing.Size(160, 23);
            this.ActSimpleRetrieval.TabIndex = 0;
            this.ActSimpleRetrieval.Text = "Simple Retrieval";
            this.ActSimpleRetrieval.UseVisualStyleBackColor = true;
            this.ActSimpleRetrieval.Click += new System.EventHandler(this.ActSimpleRetrieval_Click);
            // 
            // ActSingleEntity
            // 
            this.ActSingleEntity.Location = new System.Drawing.Point(8, 48);
            this.ActSingleEntity.Name = "ActSingleEntity";
            this.ActSingleEntity.Size = new System.Drawing.Size(160, 23);
            this.ActSingleEntity.TabIndex = 1;
            this.ActSingleEntity.Text = "Single Entity";
            this.ActSingleEntity.UseVisualStyleBackColor = true;
            this.ActSingleEntity.Click += new System.EventHandler(this.ActSingleEntity_Click);
            // 
            // ActDataTable
            // 
            this.ActDataTable.Location = new System.Drawing.Point(176, 48);
            this.ActDataTable.Name = "ActDataTable";
            this.ActDataTable.Size = new System.Drawing.Size(160, 23);
            this.ActDataTable.TabIndex = 4;
            this.ActDataTable.Text = "Data Table";
            this.ActDataTable.UseVisualStyleBackColor = true;
            this.ActDataTable.Click += new System.EventHandler(this.ActDataTable_Click);
            // 
            // ActAnonymousType
            // 
            this.ActAnonymousType.Location = new System.Drawing.Point(176, 16);
            this.ActAnonymousType.Name = "ActAnonymousType";
            this.ActAnonymousType.Size = new System.Drawing.Size(160, 23);
            this.ActAnonymousType.TabIndex = 3;
            this.ActAnonymousType.Text = "Anonymous Type";
            this.ActAnonymousType.UseVisualStyleBackColor = true;
            this.ActAnonymousType.Click += new System.EventHandler(this.ActAnonymousType_Click);
            // 
            // TabCustom
            // 
            this.TabCustom.Controls.Add(this.CustomQuery);
            this.TabCustom.Controls.Add(this.ActProcess);
            this.TabCustom.Location = new System.Drawing.Point(4, 22);
            this.TabCustom.Name = "TabCustom";
            this.TabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.TabCustom.Size = new System.Drawing.Size(456, 230);
            this.TabCustom.TabIndex = 1;
            this.TabCustom.Text = "Custom Queries";
            this.TabCustom.UseVisualStyleBackColor = true;
            // 
            // CustomQuery
            // 
            this.CustomQuery.Location = new System.Drawing.Point(8, 8);
            this.CustomQuery.Multiline = true;
            this.CustomQuery.Name = "CustomQuery";
            this.CustomQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CustomQuery.Size = new System.Drawing.Size(432, 176);
            this.CustomQuery.TabIndex = 0;
            // 
            // ActProcess
            // 
            this.ActProcess.Location = new System.Drawing.Point(368, 192);
            this.ActProcess.Name = "ActProcess";
            this.ActProcess.Size = new System.Drawing.Size(75, 23);
            this.ActProcess.TabIndex = 1;
            this.ActProcess.Text = "Process";
            this.ActProcess.UseVisualStyleBackColor = true;
            this.ActProcess.Click += new System.EventHandler(this.ActProcess_Click);
            // 
            // TabModel
            // 
            this.TabModel.Controls.Add(this.ModelImage);
            this.TabModel.Location = new System.Drawing.Point(4, 22);
            this.TabModel.Name = "TabModel";
            this.TabModel.Size = new System.Drawing.Size(456, 230);
            this.TabModel.TabIndex = 2;
            this.TabModel.Text = "Entity Model";
            this.TabModel.UseVisualStyleBackColor = true;
            // 
            // ModelImage
            // 
            this.ModelImage.BackColor = System.Drawing.Color.White;
            this.ModelImage.Image = ((System.Drawing.Image)(resources.GetObject("ModelImage.Image")));
            this.ModelImage.Location = new System.Drawing.Point(0, 0);
            this.ModelImage.Name = "ModelImage";
            this.ModelImage.Padding = new System.Windows.Forms.Padding(10);
            this.ModelImage.Size = new System.Drawing.Size(456, 232);
            this.ModelImage.TabIndex = 0;
            this.ModelImage.TabStop = false;
            // 
            // DisplayResults
            // 
            this.DisplayResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DisplayResults.Location = new System.Drawing.Point(8, 296);
            this.DisplayResults.Name = "DisplayResults";
            this.DisplayResults.Size = new System.Drawing.Size(464, 160);
            this.DisplayResults.TabIndex = 2;
            // 
            // EntityQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 470);
            this.Controls.Add(this.LabelResults);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.DisplayResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EntityQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 15 - Entity Query";
            this.TabControl1.ResumeLayout(false);
            this.TabPredefined.ResumeLayout(false);
            this.TabCustom.ResumeLayout(false);
            this.TabCustom.PerformLayout();
            this.TabModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModelImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelResults;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPredefined;
        internal System.Windows.Forms.Button ActNavigationProperty;
        internal System.Windows.Forms.Button ActSimpleRetrieval;
        internal System.Windows.Forms.Button ActSingleEntity;
        internal System.Windows.Forms.Button ActDataTable;
        internal System.Windows.Forms.Button ActAnonymousType;
        internal System.Windows.Forms.TabPage TabCustom;
        internal System.Windows.Forms.TextBox CustomQuery;
        internal System.Windows.Forms.Button ActProcess;
        internal System.Windows.Forms.TabPage TabModel;
        internal System.Windows.Forms.PictureBox ModelImage;
        internal System.Windows.Forms.DataGridView DisplayResults;
    }
}

