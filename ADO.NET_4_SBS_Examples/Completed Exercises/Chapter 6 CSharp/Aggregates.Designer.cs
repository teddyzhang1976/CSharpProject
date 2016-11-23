namespace Chapter_6_CSharp
{
    partial class Aggregates
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
            this.LabelChildType = new System.Windows.Forms.Label();
            this.ChildDataType = new System.Windows.Forms.ComboBox();
            this.LabelParentType = new System.Windows.Forms.Label();
            this.ParentDataType = new System.Windows.Forms.ComboBox();
            this.ChildExpression = new System.Windows.Forms.TextBox();
            this.LabelChildExpression = new System.Windows.Forms.Label();
            this.ChildName = new System.Windows.Forms.TextBox();
            this.LabelChildName = new System.Windows.Forms.Label();
            this.ActChildColumn = new System.Windows.Forms.Button();
            this.ParentExpression = new System.Windows.Forms.TextBox();
            this.LabelParentExpression = new System.Windows.Forms.Label();
            this.ActReset = new System.Windows.Forms.Button();
            this.ActClose = new System.Windows.Forms.Button();
            this.ActCompute = new System.Windows.Forms.Button();
            this.LabelCloseParen = new System.Windows.Forms.Label();
            this.LabelOpenParen = new System.Windows.Forms.Label();
            this.ComputeColumn = new System.Windows.Forms.ComboBox();
            this.LabelCompute = new System.Windows.Forms.Label();
            this.ParentName = new System.Windows.Forms.TextBox();
            this.LabelParentName = new System.Windows.Forms.Label();
            this.ChildRecords = new System.Windows.Forms.DataGridView();
            this.LabelChild = new System.Windows.Forms.Label();
            this.ParentRecords = new System.Windows.Forms.DataGridView();
            this.ComputeFunction = new System.Windows.Forms.ComboBox();
            this.ActParentColumn = new System.Windows.Forms.Button();
            this.LabelParent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChildRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelChildType
            // 
            this.LabelChildType.AutoSize = true;
            this.LabelChildType.Location = new System.Drawing.Point(320, 298);
            this.LabelChildType.Name = "LabelChildType";
            this.LabelChildType.Size = new System.Drawing.Size(60, 13);
            this.LabelChildType.TabIndex = 13;
            this.LabelChildType.Text = "Data Type:";
            // 
            // ChildDataType
            // 
            this.ChildDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChildDataType.FormattingEnabled = true;
            this.ChildDataType.Location = new System.Drawing.Point(384, 296);
            this.ChildDataType.Name = "ChildDataType";
            this.ChildDataType.Size = new System.Drawing.Size(112, 21);
            this.ChildDataType.TabIndex = 14;
            // 
            // LabelParentType
            // 
            this.LabelParentType.AutoSize = true;
            this.LabelParentType.Location = new System.Drawing.Point(320, 122);
            this.LabelParentType.Name = "LabelParentType";
            this.LabelParentType.Size = new System.Drawing.Size(60, 13);
            this.LabelParentType.TabIndex = 4;
            this.LabelParentType.Text = "Data Type:";
            // 
            // ParentDataType
            // 
            this.ParentDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentDataType.FormattingEnabled = true;
            this.ParentDataType.Location = new System.Drawing.Point(384, 120);
            this.ParentDataType.Name = "ParentDataType";
            this.ParentDataType.Size = new System.Drawing.Size(112, 21);
            this.ParentDataType.TabIndex = 5;
            // 
            // ChildExpression
            // 
            this.ChildExpression.Location = new System.Drawing.Point(152, 320);
            this.ChildExpression.Name = "ChildExpression";
            this.ChildExpression.Size = new System.Drawing.Size(344, 20);
            this.ChildExpression.TabIndex = 17;
            this.ChildExpression.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelChildExpression
            // 
            this.LabelChildExpression.AutoSize = true;
            this.LabelChildExpression.Location = new System.Drawing.Point(72, 322);
            this.LabelChildExpression.Name = "LabelChildExpression";
            this.LabelChildExpression.Size = new System.Drawing.Size(61, 13);
            this.LabelChildExpression.TabIndex = 16;
            this.LabelChildExpression.Text = "Expression:";
            // 
            // ChildName
            // 
            this.ChildName.Location = new System.Drawing.Point(152, 296);
            this.ChildName.Name = "ChildName";
            this.ChildName.Size = new System.Drawing.Size(160, 20);
            this.ChildName.TabIndex = 12;
            this.ChildName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelChildName
            // 
            this.LabelChildName.AutoSize = true;
            this.LabelChildName.Location = new System.Drawing.Point(72, 298);
            this.LabelChildName.Name = "LabelChildName";
            this.LabelChildName.Size = new System.Drawing.Size(76, 13);
            this.LabelChildName.TabIndex = 11;
            this.LabelChildName.Text = "Column Name:";
            // 
            // ActChildColumn
            // 
            this.ActChildColumn.Location = new System.Drawing.Point(501, 295);
            this.ActChildColumn.Name = "ActChildColumn";
            this.ActChildColumn.Size = new System.Drawing.Size(75, 23);
            this.ActChildColumn.TabIndex = 15;
            this.ActChildColumn.Text = "Add";
            this.ActChildColumn.UseVisualStyleBackColor = true;
            this.ActChildColumn.Click += new System.EventHandler(this.ActChildColumn_Click);
            // 
            // ParentExpression
            // 
            this.ParentExpression.Location = new System.Drawing.Point(152, 144);
            this.ParentExpression.Name = "ParentExpression";
            this.ParentExpression.Size = new System.Drawing.Size(344, 20);
            this.ParentExpression.TabIndex = 8;
            this.ParentExpression.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelParentExpression
            // 
            this.LabelParentExpression.AutoSize = true;
            this.LabelParentExpression.Location = new System.Drawing.Point(72, 146);
            this.LabelParentExpression.Name = "LabelParentExpression";
            this.LabelParentExpression.Size = new System.Drawing.Size(61, 13);
            this.LabelParentExpression.TabIndex = 7;
            this.LabelParentExpression.Text = "Expression:";
            // 
            // ActReset
            // 
            this.ActReset.Location = new System.Drawing.Point(421, 384);
            this.ActReset.Name = "ActReset";
            this.ActReset.Size = new System.Drawing.Size(75, 23);
            this.ActReset.TabIndex = 24;
            this.ActReset.Text = "Reset";
            this.ActReset.UseVisualStyleBackColor = true;
            this.ActReset.Click += new System.EventHandler(this.ActReset_Click);
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(501, 384);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 25;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // ActCompute
            // 
            this.ActCompute.Location = new System.Drawing.Point(501, 352);
            this.ActCompute.Name = "ActCompute";
            this.ActCompute.Size = new System.Drawing.Size(75, 23);
            this.ActCompute.TabIndex = 23;
            this.ActCompute.Text = "Compute";
            this.ActCompute.UseVisualStyleBackColor = true;
            this.ActCompute.Click += new System.EventHandler(this.ActCompute_Click);
            // 
            // LabelCloseParen
            // 
            this.LabelCloseParen.AutoSize = true;
            this.LabelCloseParen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCloseParen.Location = new System.Drawing.Point(484, 354);
            this.LabelCloseParen.Name = "LabelCloseParen";
            this.LabelCloseParen.Size = new System.Drawing.Size(13, 16);
            this.LabelCloseParen.TabIndex = 22;
            this.LabelCloseParen.Text = ")";
            // 
            // LabelOpenParen
            // 
            this.LabelOpenParen.AutoSize = true;
            this.LabelOpenParen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOpenParen.Location = new System.Drawing.Point(168, 354);
            this.LabelOpenParen.Name = "LabelOpenParen";
            this.LabelOpenParen.Size = new System.Drawing.Size(13, 16);
            this.LabelOpenParen.TabIndex = 20;
            this.LabelOpenParen.Text = "(";
            // 
            // ComputeColumn
            // 
            this.ComputeColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComputeColumn.FormattingEnabled = true;
            this.ComputeColumn.Location = new System.Drawing.Point(184, 352);
            this.ComputeColumn.Name = "ComputeColumn";
            this.ComputeColumn.Size = new System.Drawing.Size(296, 21);
            this.ComputeColumn.TabIndex = 21;
            // 
            // LabelCompute
            // 
            this.LabelCompute.AutoSize = true;
            this.LabelCompute.Location = new System.Drawing.Point(8, 354);
            this.LabelCompute.Name = "LabelCompute";
            this.LabelCompute.Size = new System.Drawing.Size(52, 13);
            this.LabelCompute.TabIndex = 18;
            this.LabelCompute.Text = "C&ompute:";
            // 
            // ParentName
            // 
            this.ParentName.Location = new System.Drawing.Point(152, 120);
            this.ParentName.Name = "ParentName";
            this.ParentName.Size = new System.Drawing.Size(160, 20);
            this.ParentName.TabIndex = 3;
            this.ParentName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelParentName
            // 
            this.LabelParentName.AutoSize = true;
            this.LabelParentName.Location = new System.Drawing.Point(72, 122);
            this.LabelParentName.Name = "LabelParentName";
            this.LabelParentName.Size = new System.Drawing.Size(76, 13);
            this.LabelParentName.TabIndex = 2;
            this.LabelParentName.Text = "Column Name:";
            // 
            // ChildRecords
            // 
            this.ChildRecords.AllowUserToAddRows = false;
            this.ChildRecords.AllowUserToDeleteRows = false;
            this.ChildRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ChildRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildRecords.Location = new System.Drawing.Point(72, 176);
            this.ChildRecords.Name = "ChildRecords";
            this.ChildRecords.ReadOnly = true;
            this.ChildRecords.RowHeadersVisible = false;
            this.ChildRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ChildRecords.Size = new System.Drawing.Size(504, 112);
            this.ChildRecords.TabIndex = 10;
            // 
            // LabelChild
            // 
            this.LabelChild.AutoSize = true;
            this.LabelChild.Location = new System.Drawing.Point(8, 178);
            this.LabelChild.Name = "LabelChild";
            this.LabelChild.Size = new System.Drawing.Size(33, 13);
            this.LabelChild.TabIndex = 9;
            this.LabelChild.Text = "&Child:";
            // 
            // ParentRecords
            // 
            this.ParentRecords.AllowUserToAddRows = false;
            this.ParentRecords.AllowUserToDeleteRows = false;
            this.ParentRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ParentRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParentRecords.Location = new System.Drawing.Point(72, 8);
            this.ParentRecords.Name = "ParentRecords";
            this.ParentRecords.ReadOnly = true;
            this.ParentRecords.RowHeadersVisible = false;
            this.ParentRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ParentRecords.Size = new System.Drawing.Size(504, 104);
            this.ParentRecords.TabIndex = 1;
            // 
            // ComputeFunction
            // 
            this.ComputeFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComputeFunction.FormattingEnabled = true;
            this.ComputeFunction.Location = new System.Drawing.Point(64, 352);
            this.ComputeFunction.Name = "ComputeFunction";
            this.ComputeFunction.Size = new System.Drawing.Size(96, 21);
            this.ComputeFunction.TabIndex = 19;
            // 
            // ActParentColumn
            // 
            this.ActParentColumn.Location = new System.Drawing.Point(501, 119);
            this.ActParentColumn.Name = "ActParentColumn";
            this.ActParentColumn.Size = new System.Drawing.Size(75, 23);
            this.ActParentColumn.TabIndex = 6;
            this.ActParentColumn.Text = "Add";
            this.ActParentColumn.UseVisualStyleBackColor = true;
            this.ActParentColumn.Click += new System.EventHandler(this.ActParentColumn_Click);
            // 
            // LabelParent
            // 
            this.LabelParent.AutoSize = true;
            this.LabelParent.Location = new System.Drawing.Point(8, 10);
            this.LabelParent.Name = "LabelParent";
            this.LabelParent.Size = new System.Drawing.Size(41, 13);
            this.LabelParent.TabIndex = 0;
            this.LabelParent.Text = "&Parent:";
            // 
            // Aggregates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(586, 416);
            this.ControlBox = false;
            this.Controls.Add(this.LabelChildType);
            this.Controls.Add(this.ChildDataType);
            this.Controls.Add(this.LabelParentType);
            this.Controls.Add(this.ParentDataType);
            this.Controls.Add(this.ChildExpression);
            this.Controls.Add(this.LabelChildExpression);
            this.Controls.Add(this.ChildName);
            this.Controls.Add(this.LabelChildName);
            this.Controls.Add(this.ActChildColumn);
            this.Controls.Add(this.ParentExpression);
            this.Controls.Add(this.LabelParentExpression);
            this.Controls.Add(this.ActReset);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.ActCompute);
            this.Controls.Add(this.LabelCloseParen);
            this.Controls.Add(this.LabelOpenParen);
            this.Controls.Add(this.ComputeColumn);
            this.Controls.Add(this.LabelCompute);
            this.Controls.Add(this.ParentName);
            this.Controls.Add(this.LabelParentName);
            this.Controls.Add(this.ChildRecords);
            this.Controls.Add(this.LabelChild);
            this.Controls.Add(this.ParentRecords);
            this.Controls.Add(this.ComputeFunction);
            this.Controls.Add(this.ActParentColumn);
            this.Controls.Add(this.LabelParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Aggregates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 6 - Aggregates";
            this.Load += new System.EventHandler(this.Aggregates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChildRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelChildType;
        internal System.Windows.Forms.ComboBox ChildDataType;
        internal System.Windows.Forms.Label LabelParentType;
        internal System.Windows.Forms.ComboBox ParentDataType;
        internal System.Windows.Forms.TextBox ChildExpression;
        internal System.Windows.Forms.Label LabelChildExpression;
        internal System.Windows.Forms.TextBox ChildName;
        internal System.Windows.Forms.Label LabelChildName;
        internal System.Windows.Forms.Button ActChildColumn;
        internal System.Windows.Forms.TextBox ParentExpression;
        internal System.Windows.Forms.Label LabelParentExpression;
        internal System.Windows.Forms.Button ActReset;
        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.Button ActCompute;
        internal System.Windows.Forms.Label LabelCloseParen;
        internal System.Windows.Forms.Label LabelOpenParen;
        internal System.Windows.Forms.ComboBox ComputeColumn;
        internal System.Windows.Forms.Label LabelCompute;
        internal System.Windows.Forms.TextBox ParentName;
        internal System.Windows.Forms.Label LabelParentName;
        internal System.Windows.Forms.DataGridView ChildRecords;
        internal System.Windows.Forms.Label LabelChild;
        internal System.Windows.Forms.DataGridView ParentRecords;
        internal System.Windows.Forms.ComboBox ComputeFunction;
        internal System.Windows.Forms.Button ActParentColumn;
        internal System.Windows.Forms.Label LabelParent;
    }
}