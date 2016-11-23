namespace Chapter_6_CSharp
{
    partial class DataViews
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
            this.ActMoveDown = new System.Windows.Forms.Button();
            this.ActMoveUp = new System.Windows.Forms.Button();
            this.IncludedColumns = new System.Windows.Forms.CheckedListBox();
            this.LabelColumns = new System.Windows.Forms.Label();
            this.FilterExpression = new System.Windows.Forms.TextBox();
            this.LabelFilter = new System.Windows.Forms.Label();
            this.ActClose = new System.Windows.Forms.Button();
            this.NewRecords = new System.Windows.Forms.DataGridView();
            this.LabelNew = new System.Windows.Forms.Label();
            this.OriginalRecords = new System.Windows.Forms.DataGridView();
            this.ActExtract = new System.Windows.Forms.Button();
            this.LabelOriginal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NewRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // ActMoveDown
            // 
            this.ActMoveDown.Enabled = false;
            this.ActMoveDown.Location = new System.Drawing.Point(485, 152);
            this.ActMoveDown.Name = "ActMoveDown";
            this.ActMoveDown.Size = new System.Drawing.Size(75, 23);
            this.ActMoveDown.TabIndex = 5;
            this.ActMoveDown.Text = "Move &Down";
            this.ActMoveDown.UseVisualStyleBackColor = true;
            this.ActMoveDown.Click += new System.EventHandler(this.ActMoveDown_Click);
            // 
            // ActMoveUp
            // 
            this.ActMoveUp.Enabled = false;
            this.ActMoveUp.Location = new System.Drawing.Point(485, 120);
            this.ActMoveUp.Name = "ActMoveUp";
            this.ActMoveUp.Size = new System.Drawing.Size(75, 23);
            this.ActMoveUp.TabIndex = 4;
            this.ActMoveUp.Text = "Move &Up";
            this.ActMoveUp.UseVisualStyleBackColor = true;
            this.ActMoveUp.Click += new System.EventHandler(this.ActMoveUp_Click);
            // 
            // IncludedColumns
            // 
            this.IncludedColumns.FormattingEnabled = true;
            this.IncludedColumns.Location = new System.Drawing.Point(133, 120);
            this.IncludedColumns.Name = "IncludedColumns";
            this.IncludedColumns.Size = new System.Drawing.Size(344, 94);
            this.IncludedColumns.TabIndex = 3;
            this.IncludedColumns.SelectedIndexChanged += new System.EventHandler(this.IncludedColumns_SelectedIndexChanged);
            // 
            // LabelColumns
            // 
            this.LabelColumns.AutoSize = true;
            this.LabelColumns.Location = new System.Drawing.Point(77, 120);
            this.LabelColumns.Name = "LabelColumns";
            this.LabelColumns.Size = new System.Drawing.Size(50, 13);
            this.LabelColumns.TabIndex = 2;
            this.LabelColumns.Text = "&Columns:";
            // 
            // FilterExpression
            // 
            this.FilterExpression.Location = new System.Drawing.Point(133, 224);
            this.FilterExpression.Name = "FilterExpression";
            this.FilterExpression.Size = new System.Drawing.Size(344, 20);
            this.FilterExpression.TabIndex = 7;
            // 
            // LabelFilter
            // 
            this.LabelFilter.AutoSize = true;
            this.LabelFilter.Location = new System.Drawing.Point(77, 224);
            this.LabelFilter.Name = "LabelFilter";
            this.LabelFilter.Size = new System.Drawing.Size(32, 13);
            this.LabelFilter.TabIndex = 6;
            this.LabelFilter.Text = "&Filter:";
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(485, 384);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 11;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // NewRecords
            // 
            this.NewRecords.AllowUserToAddRows = false;
            this.NewRecords.AllowUserToDeleteRows = false;
            this.NewRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.NewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewRecords.Location = new System.Drawing.Point(56, 256);
            this.NewRecords.Name = "NewRecords";
            this.NewRecords.ReadOnly = true;
            this.NewRecords.RowHeadersVisible = false;
            this.NewRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.NewRecords.Size = new System.Drawing.Size(504, 112);
            this.NewRecords.TabIndex = 10;
            // 
            // LabelNew
            // 
            this.LabelNew.AutoSize = true;
            this.LabelNew.Location = new System.Drawing.Point(8, 258);
            this.LabelNew.Name = "LabelNew";
            this.LabelNew.Size = new System.Drawing.Size(32, 13);
            this.LabelNew.TabIndex = 9;
            this.LabelNew.Text = "New:";
            // 
            // OriginalRecords
            // 
            this.OriginalRecords.AllowUserToAddRows = false;
            this.OriginalRecords.AllowUserToDeleteRows = false;
            this.OriginalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OriginalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OriginalRecords.Location = new System.Drawing.Point(56, 8);
            this.OriginalRecords.Name = "OriginalRecords";
            this.OriginalRecords.ReadOnly = true;
            this.OriginalRecords.RowHeadersVisible = false;
            this.OriginalRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OriginalRecords.Size = new System.Drawing.Size(504, 104);
            this.OriginalRecords.TabIndex = 1;
            // 
            // ActExtract
            // 
            this.ActExtract.Location = new System.Drawing.Point(485, 224);
            this.ActExtract.Name = "ActExtract";
            this.ActExtract.Size = new System.Drawing.Size(75, 23);
            this.ActExtract.TabIndex = 8;
            this.ActExtract.Text = "E&xtract";
            this.ActExtract.UseVisualStyleBackColor = true;
            this.ActExtract.Click += new System.EventHandler(this.ActExtract_Click);
            // 
            // LabelOriginal
            // 
            this.LabelOriginal.AutoSize = true;
            this.LabelOriginal.Location = new System.Drawing.Point(8, 10);
            this.LabelOriginal.Name = "LabelOriginal";
            this.LabelOriginal.Size = new System.Drawing.Size(45, 13);
            this.LabelOriginal.TabIndex = 0;
            this.LabelOriginal.Text = "Original:";
            // 
            // DataViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(570, 417);
            this.ControlBox = false;
            this.Controls.Add(this.ActMoveDown);
            this.Controls.Add(this.ActMoveUp);
            this.Controls.Add(this.IncludedColumns);
            this.Controls.Add(this.LabelColumns);
            this.Controls.Add(this.FilterExpression);
            this.Controls.Add(this.LabelFilter);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.NewRecords);
            this.Controls.Add(this.LabelNew);
            this.Controls.Add(this.OriginalRecords);
            this.Controls.Add(this.ActExtract);
            this.Controls.Add(this.LabelOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataViews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 6 - Data Views";
            this.Load += new System.EventHandler(this.DataViews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ActMoveDown;
        internal System.Windows.Forms.Button ActMoveUp;
        internal System.Windows.Forms.CheckedListBox IncludedColumns;
        internal System.Windows.Forms.Label LabelColumns;
        internal System.Windows.Forms.TextBox FilterExpression;
        internal System.Windows.Forms.Label LabelFilter;
        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.DataGridView NewRecords;
        internal System.Windows.Forms.Label LabelNew;
        internal System.Windows.Forms.DataGridView OriginalRecords;
        internal System.Windows.Forms.Button ActExtract;
        internal System.Windows.Forms.Label LabelOriginal;
    }
}