namespace Chapter_2_CSharp
{
    partial class TableDetails
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
            this.ColDataType = new System.Windows.Forms.Label();
            this.ColColumnName = new System.Windows.Forms.Label();
            this.LabelColumns = new System.Windows.Forms.Label();
            this.TableName = new System.Windows.Forms.Label();
            this.LabelTableName = new System.Windows.Forms.Label();
            this.ActClose = new System.Windows.Forms.Button();
            this.AllColumns = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ColDataType
            // 
            this.ColDataType.AutoSize = true;
            this.ColDataType.Location = new System.Drawing.Point(297, 40);
            this.ColDataType.Name = "ColDataType";
            this.ColDataType.Size = new System.Drawing.Size(57, 13);
            this.ColDataType.TabIndex = 4;
            this.ColDataType.Text = "Data Type";
            // 
            // ColColumnName
            // 
            this.ColColumnName.AutoSize = true;
            this.ColColumnName.Location = new System.Drawing.Point(121, 40);
            this.ColColumnName.Name = "ColColumnName";
            this.ColColumnName.Size = new System.Drawing.Size(73, 13);
            this.ColColumnName.TabIndex = 3;
            this.ColColumnName.Text = "Column Name";
            // 
            // LabelColumns
            // 
            this.LabelColumns.AutoSize = true;
            this.LabelColumns.Location = new System.Drawing.Point(9, 56);
            this.LabelColumns.Name = "LabelColumns";
            this.LabelColumns.Size = new System.Drawing.Size(50, 13);
            this.LabelColumns.TabIndex = 2;
            this.LabelColumns.Text = "Columns:";
            // 
            // TableName
            // 
            this.TableName.AutoSize = true;
            this.TableName.Location = new System.Drawing.Point(89, 9);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(70, 13);
            this.TableName.TabIndex = 1;
            this.TableName.Text = "Not Available";
            this.TableName.UseMnemonic = false;
            // 
            // LabelTableName
            // 
            this.LabelTableName.AutoSize = true;
            this.LabelTableName.Location = new System.Drawing.Point(9, 9);
            this.LabelTableName.Name = "LabelTableName";
            this.LabelTableName.Size = new System.Drawing.Size(68, 13);
            this.LabelTableName.TabIndex = 0;
            this.LabelTableName.Text = "Table Name:";
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(438, 200);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 6;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // AllColumns
            // 
            this.AllColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AllColumns.FormattingEnabled = true;
            this.AllColumns.Location = new System.Drawing.Point(89, 56);
            this.AllColumns.Name = "AllColumns";
            this.AllColumns.Size = new System.Drawing.Size(424, 134);
            this.AllColumns.TabIndex = 5;
            this.AllColumns.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.AllColumns_DrawItem);
            // 
            // TableDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 233);
            this.ControlBox = false;
            this.Controls.Add(this.ColDataType);
            this.Controls.Add(this.ColColumnName);
            this.Controls.Add(this.LabelColumns);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.LabelTableName);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.AllColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TableDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 2 - Table Details";
            this.Load += new System.EventHandler(this.TableDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label ColDataType;
        internal System.Windows.Forms.Label ColColumnName;
        internal System.Windows.Forms.Label LabelColumns;
        internal System.Windows.Forms.Label TableName;
        internal System.Windows.Forms.Label LabelTableName;
        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.ListBox AllColumns;
    }
}