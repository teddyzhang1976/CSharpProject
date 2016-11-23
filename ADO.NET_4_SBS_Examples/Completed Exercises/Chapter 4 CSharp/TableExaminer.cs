// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 4 - Visual Basic Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_4_CSharp
{
    public partial class TableExaminer : Form
    {
        public TableExaminer()
        {
            InitializeComponent();
        }

        private void TableExaminer_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            String[] supportedTypes = new string[]
                {"Boolean", "Byte", "Char", "DateTime", "Decimal", "Double",
                "Int16", "Int32", "Int64", "SByte", "Single", "String",
                "TimeSpan", "UInt16", "UInt32", "UInt64"};

            // ----- Display the sample data.
            BaseTableDisplay.DataSource = BuildSampleTable();

            // ----- Fill in the list of data types for the custom columns.
            foreach (string scanType in supportedTypes)
            {
                ColumnType1.Items.Add(scanType);
                ColumnType2.Items.Add(scanType);
                ColumnType3.Items.Add(scanType);
            }
            ColumnType1.SelectedIndex = 0;
            ColumnType2.SelectedIndex = 0;
            ColumnType3.SelectedIndex = 0;
        }

        private DataTable BuildSampleTable()
        {
            // ------ Create a sample table to display in the application.
            DataTable theTable = new DataTable("SampleTable");
            theTable.Columns.Add("ID", typeof(long));
            theTable.Columns.Add("StudentName", typeof(string));
            theTable.Columns.Add("GradeYear", typeof(int));
            theTable.Columns.Add("ScoreTrimester1", typeof(decimal));
            theTable.Columns.Add("ScoreTrimester2", typeof(decimal));
            theTable.Columns.Add("ScoreTrimester3", typeof(decimal));

            // ----- Create a primary key for the table.
            theTable.PrimaryKey = new DataColumn[] {theTable.Columns["ID"]};

            theTable.Rows.Add(new Object[] {3429L, "Abercrombie, Kim", 12, 4m, 3.9m, 4m});
            theTable.Rows.Add(new Object[] {2352L, "Hamlin, Jay", 10, 2.5m, 1.85m, 1.7m});
            theTable.Rows.Add(new Object[] {6843L, "Jacobsen, Lola", 10, 2.67m, 2.9m, 3.2m});
            theTable.Rows.Add(new Object[] {4810L, "Price, Jeff", 11, 3m, 3m, 3.4m});

            return theTable;
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void ActPrimaryKey_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Perform a primary key lookup.
            long usePrimaryKey;
            DataRow result = null;
            DataTable workTable;
            DataTable displayTable;

            // ----- The primary key is required, and must be an integral value.
            if ((IsNumeric(PrimaryKey.Text.Trim()) == false) ||
                    (PrimaryKey.Text.IndexOf(".") >= 0))
            {
                MessageBox.Show("The Primary Key must be a valid integer.");
                PrimaryKey.Focus();
                return;
            }

            // ----- Convert supplied key to long, checking for overflow.
            try
            {
                usePrimaryKey = long.Parse(PrimaryKey.Text);
            }
            catch
            {
                MessageBox.Show("The Primary Key must be a valid integer.");
                PrimaryKey.Focus();
                return;
            }

            // ----- Get a copy of the table for the lookup.
            workTable = BuildSampleTable();

            // ----- Perform the lookup.
            try
            {
                result = workTable.Rows.Find(usePrimaryKey);
            }
            catch (MissingPrimaryKeyException)
            {
                MessageBox.Show("The table does not have a defined primary key.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Primary key lookup failed with the following error: " +
                    ex.Message);
                return;
            }

            // ----- Check for no match.
            if (result == null)
            {
                MessageBox.Show("The supplied key matched no rows.");
                PrimaryKey.Focus();
                return;
            }

            // ----- Display the results. The results panel requires a DataTable,
            //       so build a new table that includes only the matching row.
            displayTable = workTable.Clone();
            displayTable.ImportRow(result);
            (new ResultsViewer()).ShowResults(displayTable);
        }

        private void ActCriteria_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Perform a criteria lookup, with sorting.
            DataTable workTable;
            DataTable displayTable;
            DataRow[] results = null;

            // ----- Either a filter or a sorting list is required.
            if ((CriteriaFilter.Text.Trim().Length == 0) &&
                    (CriteriaSorting.Text.Trim().Length == 0))
            {
                MessageBox.Show("You must provide either a filter or a sorting list.");
                return;
            }

            // ----- Build a local table to perform the filter/sort.
            workTable = BuildSampleTable();
            workTable.CaseSensitive = BeCaseSensitive.Checked;

            // ----- Apply the filter and sorting list.
            try
            {
                results = workTable.Select(CriteriaFilter.Text, CriteriaSorting.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The filter failed with the following error: " +
                    ex.Message);
                return;
            }

            // ----- Display the results. The results panel requires a DataTable,
            //       so build a new table that includes only the matching rows.
            displayTable = workTable.Clone();
            foreach (DataRow scanResult in results)
            {
                displayTable.ImportRow(scanResult);
            }
            (new ResultsViewer()).ShowResults(displayTable);
        }

        private void ActExpression_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add expression columns to the sample table.
            DataTable workTable;
            int counter;
            int numAdded;
            TextBox nameField;
            ComboBox typeField;
            TextBox expressionField;

            // ----- Build a table for the new columns.
            workTable = BuildSampleTable();
            workTable.CaseSensitive = BeCaseSensitive.Checked;

            // ----- Scan each of the three expression columns.
            numAdded = 0;
            for (counter = 1; counter <= 3; ++counter)
            {
                // ----- Locate the correct controls.
                nameField = (TextBox)ByExpressionColumns.Controls["ColumnName" +
                    counter.ToString()];
                typeField = (ComboBox)ByExpressionColumns.Controls["ColumnType" +
                    counter.ToString()];
                expressionField = (TextBox)ByExpressionColumns.Controls["ColumnExpression" +
                    counter.ToString()];

                // ----- Ignore unused columns.
                if ((nameField.Text.Trim().Length == 0) &&
                    (expressionField.Text.Trim().Length == 0)) continue;

                // ----- Warn on missing data.
                if (nameField.Text.Trim().Length == 0)
                {
                    MessageBox.Show("A name is missing for column #" +
                        counter.ToString() + ".");
                    nameField.Focus();
                    return;
                }
                if (expressionField.Text.Trim().Length == 0)
                {
                    MessageBox.Show("An expression is missing for column #" +
                        counter.ToString() + ".");
                    expressionField.Focus();
                    return;
                }

                // ----- Add the expression column.
                try
                {
                    workTable.Columns.Add(nameField.Text.Trim(),
                        Type.GetType("System." + typeField.SelectedItem.ToString()),
                        expressionField.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred when adding expression column " +
                        counter.ToString() + ": " + ex.Message);
                    return;
                }
                numAdded += 1;
            }

            // ----- If no columns added, don't bother.
            if (numAdded == 0)
            {
                MessageBox.Show("You must add at least one expression column");
                return;
            }

            // ----- Show the results.
            (new ResultsViewer()).ShowResults(workTable);
        }

        private bool IsNumeric(string baseString)
        {
            // ----- Do a quick test for a valid decimal string.
            decimal result;

            if ((baseString == null) || (baseString.Trim().Length == 0))
                return false;
            return decimal.TryParse(baseString, out result);
        }
    }
}
