namespace Chapter_7_CSharp
{
    partial class Serialization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelResults = new System.Windows.Forms.Label();
            this.LabelMappingType = new System.Windows.Forms.Label();
            this.ColumnMappingType = new System.Windows.Forms.ComboBox();
            this.SerializedResults = new System.Windows.Forms.TextBox();
            this.LabelColumnMapping = new System.Windows.Forms.Label();
            this.SelectColumn = new System.Windows.Forms.ComboBox();
            this.LabelPrefix = new System.Windows.Forms.Label();
            this.TablePrefix = new System.Windows.Forms.TextBox();
            this.LabelNamespace = new System.Windows.Forms.Label();
            this.TableNamespace = new System.Windows.Forms.TextBox();
            this.NestChildRecords = new System.Windows.Forms.CheckBox();
            this.LabelWriteMode = new System.Windows.Forms.Label();
            this.LabelChildTable = new System.Windows.Forms.Label();
            this.ChildContent = new System.Windows.Forms.DataGridView();
            this.ParentContent = new System.Windows.Forms.DataGridView();
            this.OutputWriteMode = new System.Windows.Forms.ComboBox();
            this.ActGenerate = new System.Windows.Forms.Button();
            this.LabelParentTable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChildContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentContent)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelResults
            // 
            this.LabelResults.AutoSize = true;
            this.LabelResults.Location = new System.Drawing.Point(224, 104);
            this.LabelResults.Name = "LabelResults";
            this.LabelResults.Size = new System.Drawing.Size(45, 13);
            this.LabelResults.TabIndex = 16;
            this.LabelResults.Text = "Results:";
            // 
            // LabelMappingType
            // 
            this.LabelMappingType.AutoSize = true;
            this.LabelMappingType.Location = new System.Drawing.Point(478, 58);
            this.LabelMappingType.Name = "LabelMappingType";
            this.LabelMappingType.Size = new System.Drawing.Size(45, 13);
            this.LabelMappingType.TabIndex = 13;
            this.LabelMappingType.Text = "...map...";
            // 
            // ColumnMappingType
            // 
            this.ColumnMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnMappingType.FormattingEnabled = true;
            this.ColumnMappingType.Location = new System.Drawing.Point(528, 56);
            this.ColumnMappingType.Name = "ColumnMappingType";
            this.ColumnMappingType.Size = new System.Drawing.Size(120, 21);
            this.ColumnMappingType.TabIndex = 14;
            this.ColumnMappingType.SelectedIndexChanged += new System.EventHandler(this.ColumnMappingType_SelectedIndexChanged);
            // 
            // SerializedResults
            // 
            this.SerializedResults.Location = new System.Drawing.Point(224, 120);
            this.SerializedResults.Multiline = true;
            this.SerializedResults.Name = "SerializedResults";
            this.SerializedResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SerializedResults.Size = new System.Drawing.Size(424, 176);
            this.SerializedResults.TabIndex = 17;
            // 
            // LabelColumnMapping
            // 
            this.LabelColumnMapping.AutoSize = true;
            this.LabelColumnMapping.Location = new System.Drawing.Point(224, 58);
            this.LabelColumnMapping.Name = "LabelColumnMapping";
            this.LabelColumnMapping.Size = new System.Drawing.Size(72, 13);
            this.LabelColumnMapping.TabIndex = 11;
            this.LabelColumnMapping.Text = "Mapping for...";
            // 
            // SelectColumn
            // 
            this.SelectColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectColumn.FormattingEnabled = true;
            this.SelectColumn.Location = new System.Drawing.Point(320, 56);
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.Size = new System.Drawing.Size(152, 21);
            this.SelectColumn.TabIndex = 12;
            this.SelectColumn.SelectedIndexChanged += new System.EventHandler(this.SelectColumn_SelectedIndexChanged);
            // 
            // LabelPrefix
            // 
            this.LabelPrefix.AutoSize = true;
            this.LabelPrefix.Location = new System.Drawing.Point(480, 10);
            this.LabelPrefix.Name = "LabelPrefix";
            this.LabelPrefix.Size = new System.Drawing.Size(36, 13);
            this.LabelPrefix.TabIndex = 6;
            this.LabelPrefix.Text = "Prefix:";
            // 
            // TablePrefix
            // 
            this.TablePrefix.Location = new System.Drawing.Point(528, 8);
            this.TablePrefix.Name = "TablePrefix";
            this.TablePrefix.Size = new System.Drawing.Size(120, 20);
            this.TablePrefix.TabIndex = 7;
            this.TablePrefix.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelNamespace
            // 
            this.LabelNamespace.AutoSize = true;
            this.LabelNamespace.Location = new System.Drawing.Point(224, 10);
            this.LabelNamespace.Name = "LabelNamespace";
            this.LabelNamespace.Size = new System.Drawing.Size(92, 13);
            this.LabelNamespace.TabIndex = 4;
            this.LabelNamespace.Text = "XML Namespace:";
            // 
            // TableNamespace
            // 
            this.TableNamespace.Location = new System.Drawing.Point(320, 8);
            this.TableNamespace.Name = "TableNamespace";
            this.TableNamespace.Size = new System.Drawing.Size(152, 20);
            this.TableNamespace.TabIndex = 5;
            this.TableNamespace.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // NestChildRecords
            // 
            this.NestChildRecords.AutoSize = true;
            this.NestChildRecords.Location = new System.Drawing.Point(528, 32);
            this.NestChildRecords.Name = "NestChildRecords";
            this.NestChildRecords.Size = new System.Drawing.Size(111, 17);
            this.NestChildRecords.TabIndex = 10;
            this.NestChildRecords.Text = "Nest child records";
            this.NestChildRecords.UseVisualStyleBackColor = true;
            // 
            // LabelWriteMode
            // 
            this.LabelWriteMode.AutoSize = true;
            this.LabelWriteMode.Location = new System.Drawing.Point(224, 34);
            this.LabelWriteMode.Name = "LabelWriteMode";
            this.LabelWriteMode.Size = new System.Drawing.Size(90, 13);
            this.LabelWriteMode.TabIndex = 8;
            this.LabelWriteMode.Text = "XML Write Mode:";
            // 
            // LabelChildTable
            // 
            this.LabelChildTable.AutoSize = true;
            this.LabelChildTable.Location = new System.Drawing.Point(8, 160);
            this.LabelChildTable.Name = "LabelChildTable";
            this.LabelChildTable.Size = new System.Drawing.Size(30, 13);
            this.LabelChildTable.TabIndex = 2;
            this.LabelChildTable.Text = "Child";
            // 
            // ChildContent
            // 
            this.ChildContent.AllowUserToAddRows = false;
            this.ChildContent.AllowUserToDeleteRows = false;
            this.ChildContent.AllowUserToOrderColumns = true;
            this.ChildContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ChildContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ChildContent.DefaultCellStyle = dataGridViewCellStyle6;
            this.ChildContent.Location = new System.Drawing.Point(8, 176);
            this.ChildContent.MultiSelect = false;
            this.ChildContent.Name = "ChildContent";
            this.ChildContent.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChildContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ChildContent.RowHeadersVisible = false;
            this.ChildContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChildContent.Size = new System.Drawing.Size(208, 120);
            this.ChildContent.TabIndex = 3;
            // 
            // ParentContent
            // 
            this.ParentContent.AllowUserToAddRows = false;
            this.ParentContent.AllowUserToDeleteRows = false;
            this.ParentContent.AllowUserToOrderColumns = true;
            this.ParentContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParentContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ParentContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParentContent.DefaultCellStyle = dataGridViewCellStyle9;
            this.ParentContent.Location = new System.Drawing.Point(8, 24);
            this.ParentContent.MultiSelect = false;
            this.ParentContent.Name = "ParentContent";
            this.ParentContent.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParentContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ParentContent.RowHeadersVisible = false;
            this.ParentContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParentContent.Size = new System.Drawing.Size(208, 120);
            this.ParentContent.TabIndex = 1;
            // 
            // OutputWriteMode
            // 
            this.OutputWriteMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputWriteMode.FormattingEnabled = true;
            this.OutputWriteMode.Location = new System.Drawing.Point(320, 32);
            this.OutputWriteMode.Name = "OutputWriteMode";
            this.OutputWriteMode.Size = new System.Drawing.Size(152, 21);
            this.OutputWriteMode.TabIndex = 9;
            // 
            // ActGenerate
            // 
            this.ActGenerate.Location = new System.Drawing.Point(576, 88);
            this.ActGenerate.Name = "ActGenerate";
            this.ActGenerate.Size = new System.Drawing.Size(75, 23);
            this.ActGenerate.TabIndex = 15;
            this.ActGenerate.Text = "Generate";
            this.ActGenerate.UseVisualStyleBackColor = true;
            this.ActGenerate.Click += new System.EventHandler(this.ActGenerate_Click);
            // 
            // LabelParentTable
            // 
            this.LabelParentTable.AutoSize = true;
            this.LabelParentTable.Location = new System.Drawing.Point(8, 8);
            this.LabelParentTable.Name = "LabelParentTable";
            this.LabelParentTable.Size = new System.Drawing.Size(38, 13);
            this.LabelParentTable.TabIndex = 0;
            this.LabelParentTable.Text = "Parent";
            // 
            // Serialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 306);
            this.Controls.Add(this.LabelResults);
            this.Controls.Add(this.LabelMappingType);
            this.Controls.Add(this.ColumnMappingType);
            this.Controls.Add(this.SerializedResults);
            this.Controls.Add(this.LabelColumnMapping);
            this.Controls.Add(this.SelectColumn);
            this.Controls.Add(this.LabelPrefix);
            this.Controls.Add(this.TablePrefix);
            this.Controls.Add(this.LabelNamespace);
            this.Controls.Add(this.TableNamespace);
            this.Controls.Add(this.NestChildRecords);
            this.Controls.Add(this.LabelWriteMode);
            this.Controls.Add(this.LabelChildTable);
            this.Controls.Add(this.ChildContent);
            this.Controls.Add(this.ParentContent);
            this.Controls.Add(this.OutputWriteMode);
            this.Controls.Add(this.ActGenerate);
            this.Controls.Add(this.LabelParentTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Serialization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 7 - Serialization";
            this.Load += new System.EventHandler(this.Serialization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChildContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelResults;
        internal System.Windows.Forms.Label LabelMappingType;
        internal System.Windows.Forms.ComboBox ColumnMappingType;
        internal System.Windows.Forms.TextBox SerializedResults;
        internal System.Windows.Forms.Label LabelColumnMapping;
        internal System.Windows.Forms.ComboBox SelectColumn;
        internal System.Windows.Forms.Label LabelPrefix;
        internal System.Windows.Forms.TextBox TablePrefix;
        internal System.Windows.Forms.Label LabelNamespace;
        internal System.Windows.Forms.TextBox TableNamespace;
        internal System.Windows.Forms.CheckBox NestChildRecords;
        internal System.Windows.Forms.Label LabelWriteMode;
        internal System.Windows.Forms.Label LabelChildTable;
        internal System.Windows.Forms.DataGridView ChildContent;
        internal System.Windows.Forms.DataGridView ParentContent;
        internal System.Windows.Forms.ComboBox OutputWriteMode;
        internal System.Windows.Forms.Button ActGenerate;
        internal System.Windows.Forms.Label LabelParentTable;
    }
}

