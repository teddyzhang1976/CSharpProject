// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 6 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Chapter_6_CSharp
{
    public partial class DataViews : Form
    {
        private DataTable SampleData;

        public DataViews()
        {
            InitializeComponent();
        }

        private void DataViews_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.

            // ----- Add the sample data to the form.
            SampleData = GetOriginalTable();
            OriginalRecords.DataSource = SampleData;

            // ----- Show the list of columns.
            IncludedColumns.Items.Clear();
            foreach (DataColumn scanColumn in SampleData.Columns)
                IncludedColumns.Items.Add(scanColumn.ColumnName);
            IncludedColumns.SelectedIndex = 0;
            RefreshColumnButtons();
        }

        private void ActExtract_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Create a new table based on the original.
            DataView interimView;
            DataTable generatedTable = null;

            // ----- At least one column is required.
            if (IncludedColumns.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please include at least one column.");
                IncludedColumns.Focus();
                return;
            }

            // ----- Clear the previous results.
            NewRecords.DataSource = null;

            // ----- Build a view that will generate the new table.
            interimView = new DataView(SampleData);

            // ----- Apply the optional filter.
            try
            {
                if (FilterExpression.Text.Trim().Length > 0)
                    interimView.RowFilter = FilterExpression.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not apply the filter: " + ex.Message);
                return;
            }

            // ----- Generate the new table.
            try
            {
                generatedTable = interimView.ToTable(true,
                    IncludedColumns.CheckedItems.Cast<string>().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not build the new table: " + ex.Message);
                return;
            }

            // ----- Display the results.
            NewRecords.DataSource = generatedTable;
        }

        private void ActMoveUp_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Move the selected column up one position.
            Object content;
            bool selection;
            int startIndex;

            // ----- Identify the base item to move.
            startIndex = IncludedColumns.SelectedIndex;
            if (startIndex <= 0) return;

            // ----- Move the content.
            content = IncludedColumns.Items[startIndex];
            IncludedColumns.Items[startIndex] = IncludedColumns.Items[startIndex - 1];
            IncludedColumns.Items[startIndex - 1] = content;

            // ----- Move the inclusion marker.
            selection = IncludedColumns.GetItemChecked(startIndex);
            IncludedColumns.SetItemChecked(startIndex,
                IncludedColumns.GetItemChecked(startIndex - 1));
            IncludedColumns.SetItemChecked(startIndex - 1, selection);

            // ----- Move to the new position.
            IncludedColumns.SelectedIndex = startIndex - 1;
        }

        private void ActMoveDown_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Move the selected column down one position.
            Object content;
            bool selection;
            int startIndex;

            // ----- Identify the base item to move.
            startIndex = IncludedColumns.SelectedIndex;
            if (startIndex == -1) return;
            if (startIndex == (IncludedColumns.Items.Count - 1)) return;

            // ----- Move the content.
            content = IncludedColumns.Items[startIndex];
            IncludedColumns.Items[startIndex] = IncludedColumns.Items[startIndex + 1];
            IncludedColumns.Items[startIndex + 1] = content;

            // ----- Move the inclusion marker.
            selection = IncludedColumns.GetItemChecked(startIndex);
            IncludedColumns.SetItemChecked(startIndex,
                IncludedColumns.GetItemChecked(startIndex + 1));
            IncludedColumns.SetItemChecked(startIndex + 1, selection);

            // ----- Move to the new position.
            IncludedColumns.SelectedIndex = startIndex + 1;
        }

        private void IncludedColumns_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the right buttons.
            RefreshColumnButtons();
        }

        private DataTable GetOriginalTable()
        {
            // ----- Build a sample original table.
            string[] sourceLines;
            string[] lineFields;
            DataRow oneRow;
            DataTable result = new DataTable("Parent");

            // ----- Add the column definitions.
            result.Columns.Add("ID", typeof(string));
            result.Columns.Add("StateName", typeof(string));
            result.Columns.Add("AreaSqMiles", typeof(int));
            result.Columns.Add("Statehood", typeof(DateTime));
            result.Columns.Add("Capital", typeof(string));

            // ----- Get access to the table's source data.
            Assembly thisProgram = Assembly.GetExecutingAssembly();
            System.IO.Stream incoming = thisProgram.GetManifestResourceStream("Chapter_6_CSharp.States.csv");
            System.IO.StreamReader tableContent = new System.IO.StreamReader(incoming);

            // ----- Add some sample data. The "States" resource has the
            //       following comma-delimited fields:
            //         ID (a.k.a., State Abbreviation)
            //         State Name
            //         Area in Square Miles
            //         Date of Statehood (optional)
            //         Capital (optional)
            sourceLines = tableContent.ReadToEnd().Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string oneLine in sourceLines)
            {
                // ----- Add a table row.
                lineFields = oneLine.Split(',');
                oneRow = result.NewRow();
                oneRow["ID"] = lineFields[0];
                oneRow["StateName"] = lineFields[1];
                oneRow["AreaSqMiles"] = int.Parse(lineFields[2]);
                if (lineFields[3].Length > 0) oneRow["Statehood"] = DateTime.Parse(lineFields[3]);
                if (lineFields[4].Length > 0) oneRow["Capital"] = lineFields[4];
                result.Rows.Add(oneRow);
            }

            // ----- Finished.
            tableContent.Dispose();
            incoming.Dispose();
            return result;
        }

        private void RefreshColumnButtons()
        {
            // ----- Enable the movement buttons as needed.
            ActMoveUp.Enabled = (IncludedColumns.SelectedIndex > 0);
            ActMoveDown.Enabled = (IncludedColumns.SelectedIndex >= 0) &&
                (IncludedColumns.SelectedIndex < (IncludedColumns.Items.Count - 1));
        }
    }
}
