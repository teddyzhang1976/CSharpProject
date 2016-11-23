namespace Chapter_4_CSharp
{
    partial class TableExaminer
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
            this.BeCaseSensitive = new System.Windows.Forms.CheckBox();
            this.TableActions = new System.Windows.Forms.TabControl();
            this.ByPrimaryKey = new System.Windows.Forms.TabPage();
            this.InfoPrimaryKey = new System.Windows.Forms.Label();
            this.PrimaryKey = new System.Windows.Forms.TextBox();
            this.LabelPrimaryKey = new System.Windows.Forms.Label();
            this.ActPrimaryKey = new System.Windows.Forms.Button();
            this.ByCriteria = new System.Windows.Forms.TabPage();
            this.InfoCriteriaSorting = new System.Windows.Forms.Label();
            this.CriteriaSorting = new System.Windows.Forms.TextBox();
            this.LabelSorting = new System.Windows.Forms.Label();
            this.InfoCriteriaFilter = new System.Windows.Forms.Label();
            this.InfoCriteria = new System.Windows.Forms.Label();
            this.CriteriaFilter = new System.Windows.Forms.TextBox();
            this.LabelFilter = new System.Windows.Forms.Label();
            this.ActCriteria = new System.Windows.Forms.Button();
            this.ByExpressionColumns = new System.Windows.Forms.TabPage();
            this.ColumnType3 = new System.Windows.Forms.ComboBox();
            this.ColumnType2 = new System.Windows.Forms.ComboBox();
            this.ColumnType1 = new System.Windows.Forms.ComboBox();
            this.LabelType = new System.Windows.Forms.Label();
            this.ColumnExpression3 = new System.Windows.Forms.TextBox();
            this.ColumnName3 = new System.Windows.Forms.TextBox();
            this.LabelCalculated3 = new System.Windows.Forms.Label();
            this.ColumnExpression2 = new System.Windows.Forms.TextBox();
            this.ColumnName2 = new System.Windows.Forms.TextBox();
            this.LabelCalculated2 = new System.Windows.Forms.Label();
            this.LabelExpression = new System.Windows.Forms.Label();
            this.ColumnExpression1 = new System.Windows.Forms.TextBox();
            this.LabelColumn = new System.Windows.Forms.Label();
            this.InfoCalculated = new System.Windows.Forms.Label();
            this.ColumnName1 = new System.Windows.Forms.TextBox();
            this.LabelCalculated1 = new System.Windows.Forms.Label();
            this.ActExpression = new System.Windows.Forms.Button();
            this.BaseTableDisplay = new System.Windows.Forms.DataGridView();
            this.TableActions.SuspendLayout();
            this.ByPrimaryKey.SuspendLayout();
            this.ByCriteria.SuspendLayout();
            this.ByExpressionColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseTableDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // BeCaseSensitive
            // 
            this.BeCaseSensitive.AutoSize = true;
            this.BeCaseSensitive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BeCaseSensitive.Location = new System.Drawing.Point(481, 182);
            this.BeCaseSensitive.Name = "BeCaseSensitive";
            this.BeCaseSensitive.Size = new System.Drawing.Size(207, 17);
            this.BeCaseSensitive.TabIndex = 1;
            this.BeCaseSensitive.Text = "Match te&xt in a case-sensitive manner.";
            this.BeCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // TableActions
            // 
            this.TableActions.Controls.Add(this.ByPrimaryKey);
            this.TableActions.Controls.Add(this.ByCriteria);
            this.TableActions.Controls.Add(this.ByExpressionColumns);
            this.TableActions.Location = new System.Drawing.Point(8, 192);
            this.TableActions.Name = "TableActions";
            this.TableActions.SelectedIndex = 0;
            this.TableActions.Size = new System.Drawing.Size(680, 160);
            this.TableActions.TabIndex = 2;
            // 
            // ByPrimaryKey
            // 
            this.ByPrimaryKey.Controls.Add(this.InfoPrimaryKey);
            this.ByPrimaryKey.Controls.Add(this.PrimaryKey);
            this.ByPrimaryKey.Controls.Add(this.LabelPrimaryKey);
            this.ByPrimaryKey.Controls.Add(this.ActPrimaryKey);
            this.ByPrimaryKey.Location = new System.Drawing.Point(4, 22);
            this.ByPrimaryKey.Name = "ByPrimaryKey";
            this.ByPrimaryKey.Padding = new System.Windows.Forms.Padding(3);
            this.ByPrimaryKey.Size = new System.Drawing.Size(672, 134);
            this.ByPrimaryKey.TabIndex = 0;
            this.ByPrimaryKey.Text = "Lookup by Primary Key";
            this.ByPrimaryKey.UseVisualStyleBackColor = true;
            // 
            // InfoPrimaryKey
            // 
            this.InfoPrimaryKey.AutoSize = true;
            this.InfoPrimaryKey.Location = new System.Drawing.Point(16, 16);
            this.InfoPrimaryKey.Name = "InfoPrimaryKey";
            this.InfoPrimaryKey.Size = new System.Drawing.Size(338, 13);
            this.InfoPrimaryKey.TabIndex = 0;
            this.InfoPrimaryKey.Text = "Enter a single primary key value, then click Lookup to view the results.";
            // 
            // PrimaryKey
            // 
            this.PrimaryKey.Location = new System.Drawing.Point(96, 40);
            this.PrimaryKey.MaxLength = 8;
            this.PrimaryKey.Name = "PrimaryKey";
            this.PrimaryKey.Size = new System.Drawing.Size(136, 20);
            this.PrimaryKey.TabIndex = 2;
            this.PrimaryKey.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelPrimaryKey
            // 
            this.LabelPrimaryKey.AutoSize = true;
            this.LabelPrimaryKey.Location = new System.Drawing.Point(16, 42);
            this.LabelPrimaryKey.Name = "LabelPrimaryKey";
            this.LabelPrimaryKey.Size = new System.Drawing.Size(65, 13);
            this.LabelPrimaryKey.TabIndex = 1;
            this.LabelPrimaryKey.Text = "&Primary Key:";
            // 
            // ActPrimaryKey
            // 
            this.ActPrimaryKey.Location = new System.Drawing.Point(240, 39);
            this.ActPrimaryKey.Name = "ActPrimaryKey";
            this.ActPrimaryKey.Size = new System.Drawing.Size(75, 23);
            this.ActPrimaryKey.TabIndex = 3;
            this.ActPrimaryKey.Text = "&Lookup...";
            this.ActPrimaryKey.UseVisualStyleBackColor = true;
            this.ActPrimaryKey.Click += new System.EventHandler(this.ActPrimaryKey_Click);
            // 
            // ByCriteria
            // 
            this.ByCriteria.Controls.Add(this.InfoCriteriaSorting);
            this.ByCriteria.Controls.Add(this.CriteriaSorting);
            this.ByCriteria.Controls.Add(this.LabelSorting);
            this.ByCriteria.Controls.Add(this.InfoCriteriaFilter);
            this.ByCriteria.Controls.Add(this.InfoCriteria);
            this.ByCriteria.Controls.Add(this.CriteriaFilter);
            this.ByCriteria.Controls.Add(this.LabelFilter);
            this.ByCriteria.Controls.Add(this.ActCriteria);
            this.ByCriteria.Location = new System.Drawing.Point(4, 22);
            this.ByCriteria.Name = "ByCriteria";
            this.ByCriteria.Padding = new System.Windows.Forms.Padding(3);
            this.ByCriteria.Size = new System.Drawing.Size(672, 134);
            this.ByCriteria.TabIndex = 1;
            this.ByCriteria.Text = "Lookup by Criteria";
            this.ByCriteria.UseVisualStyleBackColor = true;
            // 
            // InfoCriteriaSorting
            // 
            this.InfoCriteriaSorting.AutoSize = true;
            this.InfoCriteriaSorting.Location = new System.Drawing.Point(96, 112);
            this.InfoCriteriaSorting.Name = "InfoCriteriaSorting";
            this.InfoCriteriaSorting.Size = new System.Drawing.Size(358, 13);
            this.InfoCriteriaSorting.TabIndex = 6;
            this.InfoCriteriaSorting.Text = "Comma-delimited. \'ASC\' or \'DESC\' can be added to each column if desired.";
            // 
            // CriteriaSorting
            // 
            this.CriteriaSorting.Location = new System.Drawing.Point(96, 88);
            this.CriteriaSorting.Name = "CriteriaSorting";
            this.CriteriaSorting.Size = new System.Drawing.Size(480, 20);
            this.CriteriaSorting.TabIndex = 5;
            this.CriteriaSorting.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelSorting
            // 
            this.LabelSorting.AutoSize = true;
            this.LabelSorting.Location = new System.Drawing.Point(16, 90);
            this.LabelSorting.Name = "LabelSorting";
            this.LabelSorting.Size = new System.Drawing.Size(62, 13);
            this.LabelSorting.TabIndex = 4;
            this.LabelSorting.Text = "&Sorting List:";
            // 
            // InfoCriteriaFilter
            // 
            this.InfoCriteriaFilter.AutoSize = true;
            this.InfoCriteriaFilter.Location = new System.Drawing.Point(96, 64);
            this.InfoCriteriaFilter.Name = "InfoCriteriaFilter";
            this.InfoCriteriaFilter.Size = new System.Drawing.Size(430, 13);
            this.InfoCriteriaFilter.TabIndex = 3;
            this.InfoCriteriaFilter.Text = "Boolean expressions supported. Use square brackets around nonstandard column name" +
                "s.";
            // 
            // InfoCriteria
            // 
            this.InfoCriteria.AutoSize = true;
            this.InfoCriteria.Location = new System.Drawing.Point(16, 16);
            this.InfoCriteria.Name = "InfoCriteria";
            this.InfoCriteria.Size = new System.Drawing.Size(509, 13);
            this.InfoCriteria.TabIndex = 0;
            this.InfoCriteria.Text = "Using the column titles, provide a filtering criteria and a comma-delimited sorti" +
                "ng list. Both fields are optional.";
            // 
            // CriteriaFilter
            // 
            this.CriteriaFilter.Location = new System.Drawing.Point(96, 40);
            this.CriteriaFilter.Name = "CriteriaFilter";
            this.CriteriaFilter.Size = new System.Drawing.Size(480, 20);
            this.CriteriaFilter.TabIndex = 2;
            this.CriteriaFilter.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelFilter
            // 
            this.LabelFilter.AutoSize = true;
            this.LabelFilter.Location = new System.Drawing.Point(16, 42);
            this.LabelFilter.Name = "LabelFilter";
            this.LabelFilter.Size = new System.Drawing.Size(67, 13);
            this.LabelFilter.TabIndex = 1;
            this.LabelFilter.Text = "&Filter Criteria:";
            // 
            // ActCriteria
            // 
            this.ActCriteria.Location = new System.Drawing.Point(584, 39);
            this.ActCriteria.Name = "ActCriteria";
            this.ActCriteria.Size = new System.Drawing.Size(75, 23);
            this.ActCriteria.TabIndex = 7;
            this.ActCriteria.Text = "&Lookup...";
            this.ActCriteria.UseVisualStyleBackColor = true;
            this.ActCriteria.Click += new System.EventHandler(this.ActCriteria_Click);
            // 
            // ByExpressionColumns
            // 
            this.ByExpressionColumns.Controls.Add(this.ColumnType3);
            this.ByExpressionColumns.Controls.Add(this.ColumnType2);
            this.ByExpressionColumns.Controls.Add(this.ColumnType1);
            this.ByExpressionColumns.Controls.Add(this.LabelType);
            this.ByExpressionColumns.Controls.Add(this.ColumnExpression3);
            this.ByExpressionColumns.Controls.Add(this.ColumnName3);
            this.ByExpressionColumns.Controls.Add(this.LabelCalculated3);
            this.ByExpressionColumns.Controls.Add(this.ColumnExpression2);
            this.ByExpressionColumns.Controls.Add(this.ColumnName2);
            this.ByExpressionColumns.Controls.Add(this.LabelCalculated2);
            this.ByExpressionColumns.Controls.Add(this.LabelExpression);
            this.ByExpressionColumns.Controls.Add(this.ColumnExpression1);
            this.ByExpressionColumns.Controls.Add(this.LabelColumn);
            this.ByExpressionColumns.Controls.Add(this.InfoCalculated);
            this.ByExpressionColumns.Controls.Add(this.ColumnName1);
            this.ByExpressionColumns.Controls.Add(this.LabelCalculated1);
            this.ByExpressionColumns.Controls.Add(this.ActExpression);
            this.ByExpressionColumns.Location = new System.Drawing.Point(4, 22);
            this.ByExpressionColumns.Name = "ByExpressionColumns";
            this.ByExpressionColumns.Size = new System.Drawing.Size(672, 134);
            this.ByExpressionColumns.TabIndex = 2;
            this.ByExpressionColumns.Text = "Add Expression Columns";
            this.ByExpressionColumns.UseVisualStyleBackColor = true;
            // 
            // ColumnType3
            // 
            this.ColumnType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnType3.FormattingEnabled = true;
            this.ColumnType3.Location = new System.Drawing.Point(192, 104);
            this.ColumnType3.Name = "ColumnType3";
            this.ColumnType3.Size = new System.Drawing.Size(136, 21);
            this.ColumnType3.TabIndex = 14;
            // 
            // ColumnType2
            // 
            this.ColumnType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnType2.FormattingEnabled = true;
            this.ColumnType2.Location = new System.Drawing.Point(192, 80);
            this.ColumnType2.Name = "ColumnType2";
            this.ColumnType2.Size = new System.Drawing.Size(136, 21);
            this.ColumnType2.TabIndex = 10;
            // 
            // ColumnType1
            // 
            this.ColumnType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnType1.FormattingEnabled = true;
            this.ColumnType1.Location = new System.Drawing.Point(192, 56);
            this.ColumnType1.Name = "ColumnType1";
            this.ColumnType1.Size = new System.Drawing.Size(136, 21);
            this.ColumnType1.TabIndex = 6;
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(192, 40);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(31, 13);
            this.LabelType.TabIndex = 2;
            this.LabelType.Text = "Type";
            // 
            // ColumnExpression3
            // 
            this.ColumnExpression3.Location = new System.Drawing.Point(336, 104);
            this.ColumnExpression3.Name = "ColumnExpression3";
            this.ColumnExpression3.Size = new System.Drawing.Size(240, 20);
            this.ColumnExpression3.TabIndex = 15;
            this.ColumnExpression3.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ColumnName3
            // 
            this.ColumnName3.Location = new System.Drawing.Point(48, 104);
            this.ColumnName3.Name = "ColumnName3";
            this.ColumnName3.Size = new System.Drawing.Size(136, 20);
            this.ColumnName3.TabIndex = 13;
            this.ColumnName3.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelCalculated3
            // 
            this.LabelCalculated3.AutoSize = true;
            this.LabelCalculated3.Location = new System.Drawing.Point(16, 106);
            this.LabelCalculated3.Name = "LabelCalculated3";
            this.LabelCalculated3.Size = new System.Drawing.Size(23, 13);
            this.LabelCalculated3.TabIndex = 12;
            this.LabelCalculated3.Text = "#&3:";
            // 
            // ColumnExpression2
            // 
            this.ColumnExpression2.Location = new System.Drawing.Point(336, 80);
            this.ColumnExpression2.Name = "ColumnExpression2";
            this.ColumnExpression2.Size = new System.Drawing.Size(240, 20);
            this.ColumnExpression2.TabIndex = 11;
            this.ColumnExpression2.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ColumnName2
            // 
            this.ColumnName2.Location = new System.Drawing.Point(48, 80);
            this.ColumnName2.Name = "ColumnName2";
            this.ColumnName2.Size = new System.Drawing.Size(136, 20);
            this.ColumnName2.TabIndex = 9;
            this.ColumnName2.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelCalculated2
            // 
            this.LabelCalculated2.AutoSize = true;
            this.LabelCalculated2.Location = new System.Drawing.Point(16, 82);
            this.LabelCalculated2.Name = "LabelCalculated2";
            this.LabelCalculated2.Size = new System.Drawing.Size(23, 13);
            this.LabelCalculated2.TabIndex = 8;
            this.LabelCalculated2.Text = "#&2:";
            // 
            // LabelExpression
            // 
            this.LabelExpression.AutoSize = true;
            this.LabelExpression.Location = new System.Drawing.Point(336, 40);
            this.LabelExpression.Name = "LabelExpression";
            this.LabelExpression.Size = new System.Drawing.Size(58, 13);
            this.LabelExpression.TabIndex = 3;
            this.LabelExpression.Text = "Expression";
            // 
            // ColumnExpression1
            // 
            this.ColumnExpression1.Location = new System.Drawing.Point(336, 56);
            this.ColumnExpression1.Name = "ColumnExpression1";
            this.ColumnExpression1.Size = new System.Drawing.Size(240, 20);
            this.ColumnExpression1.TabIndex = 7;
            this.ColumnExpression1.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelColumn
            // 
            this.LabelColumn.AutoSize = true;
            this.LabelColumn.Location = new System.Drawing.Point(48, 40);
            this.LabelColumn.Name = "LabelColumn";
            this.LabelColumn.Size = new System.Drawing.Size(35, 13);
            this.LabelColumn.TabIndex = 1;
            this.LabelColumn.Text = "Name";
            // 
            // InfoCalculated
            // 
            this.InfoCalculated.AutoSize = true;
            this.InfoCalculated.Location = new System.Drawing.Point(16, 16);
            this.InfoCalculated.Name = "InfoCalculated";
            this.InfoCalculated.Size = new System.Drawing.Size(549, 13);
            this.InfoCalculated.TabIndex = 0;
            this.InfoCalculated.Text = "Enter up to three calculated expression columns. Name, Type, and Expression are r" +
                "equired for each added column.";
            // 
            // ColumnName1
            // 
            this.ColumnName1.Location = new System.Drawing.Point(48, 56);
            this.ColumnName1.Name = "ColumnName1";
            this.ColumnName1.Size = new System.Drawing.Size(136, 20);
            this.ColumnName1.TabIndex = 5;
            this.ColumnName1.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelCalculated1
            // 
            this.LabelCalculated1.AutoSize = true;
            this.LabelCalculated1.Location = new System.Drawing.Point(16, 58);
            this.LabelCalculated1.Name = "LabelCalculated1";
            this.LabelCalculated1.Size = new System.Drawing.Size(23, 13);
            this.LabelCalculated1.TabIndex = 4;
            this.LabelCalculated1.Text = "#&1:";
            // 
            // ActExpression
            // 
            this.ActExpression.Location = new System.Drawing.Point(584, 55);
            this.ActExpression.Name = "ActExpression";
            this.ActExpression.Size = new System.Drawing.Size(75, 23);
            this.ActExpression.TabIndex = 16;
            this.ActExpression.Text = "&Build...";
            this.ActExpression.UseVisualStyleBackColor = true;
            this.ActExpression.Click += new System.EventHandler(this.ActExpression_Click);
            // 
            // BaseTableDisplay
            // 
            this.BaseTableDisplay.AllowUserToAddRows = false;
            this.BaseTableDisplay.AllowUserToDeleteRows = false;
            this.BaseTableDisplay.AllowUserToOrderColumns = true;
            this.BaseTableDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.BaseTableDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaseTableDisplay.Location = new System.Drawing.Point(8, 8);
            this.BaseTableDisplay.MultiSelect = false;
            this.BaseTableDisplay.Name = "BaseTableDisplay";
            this.BaseTableDisplay.ReadOnly = true;
            this.BaseTableDisplay.RowHeadersVisible = false;
            this.BaseTableDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.BaseTableDisplay.Size = new System.Drawing.Size(680, 168);
            this.BaseTableDisplay.TabIndex = 0;
            // 
            // TableExaminer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 368);
            this.Controls.Add(this.BeCaseSensitive);
            this.Controls.Add(this.TableActions);
            this.Controls.Add(this.BaseTableDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TableExaminer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 4 - Table Examiner";
            this.Load += new System.EventHandler(this.TableExaminer_Load);
            this.TableActions.ResumeLayout(false);
            this.ByPrimaryKey.ResumeLayout(false);
            this.ByPrimaryKey.PerformLayout();
            this.ByCriteria.ResumeLayout(false);
            this.ByCriteria.PerformLayout();
            this.ByExpressionColumns.ResumeLayout(false);
            this.ByExpressionColumns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseTableDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox BeCaseSensitive;
        internal System.Windows.Forms.TabControl TableActions;
        internal System.Windows.Forms.TabPage ByPrimaryKey;
        internal System.Windows.Forms.Label InfoPrimaryKey;
        internal System.Windows.Forms.TextBox PrimaryKey;
        internal System.Windows.Forms.Label LabelPrimaryKey;
        internal System.Windows.Forms.Button ActPrimaryKey;
        internal System.Windows.Forms.TabPage ByCriteria;
        internal System.Windows.Forms.Label InfoCriteriaSorting;
        internal System.Windows.Forms.TextBox CriteriaSorting;
        internal System.Windows.Forms.Label LabelSorting;
        internal System.Windows.Forms.Label InfoCriteriaFilter;
        internal System.Windows.Forms.Label InfoCriteria;
        internal System.Windows.Forms.TextBox CriteriaFilter;
        internal System.Windows.Forms.Label LabelFilter;
        internal System.Windows.Forms.Button ActCriteria;
        internal System.Windows.Forms.TabPage ByExpressionColumns;
        internal System.Windows.Forms.ComboBox ColumnType3;
        internal System.Windows.Forms.ComboBox ColumnType2;
        internal System.Windows.Forms.ComboBox ColumnType1;
        internal System.Windows.Forms.Label LabelType;
        internal System.Windows.Forms.TextBox ColumnExpression3;
        internal System.Windows.Forms.TextBox ColumnName3;
        internal System.Windows.Forms.Label LabelCalculated3;
        internal System.Windows.Forms.TextBox ColumnExpression2;
        internal System.Windows.Forms.TextBox ColumnName2;
        internal System.Windows.Forms.Label LabelCalculated2;
        internal System.Windows.Forms.Label LabelExpression;
        internal System.Windows.Forms.TextBox ColumnExpression1;
        internal System.Windows.Forms.Label LabelColumn;
        internal System.Windows.Forms.Label InfoCalculated;
        internal System.Windows.Forms.TextBox ColumnName1;
        internal System.Windows.Forms.Label LabelCalculated1;
        internal System.Windows.Forms.Button ActExpression;
        internal System.Windows.Forms.DataGridView BaseTableDisplay;
    }
}

