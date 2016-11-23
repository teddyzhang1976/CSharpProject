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
    public partial class Aggregates : Form
    {
        public Aggregates()
        {
            InitializeComponent();
        }

        private DataSet ExampleData;

        private void Aggregates_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Fill in the list of compute functions.
            ComputeFunction.Items.Clear();
            ComputeFunction.Items.AddRange(
                "Sum,Avg,Min,Max,Count,StDev,Var".Split(new Char[] { ',' }));
            ComputeFunction.SelectedIndex = 0;

            // ----- Fill in the data type choices.
            ParentDataType.Items.Clear();
            ParentDataType.Items.AddRange(
                ("Boolean,Byte,Char,DateTime,Decimal,Double,Int16,Int32," +
                "Int64,SByte,Single,String,TimeSpan,UInt16,UInt32,UInt64").Split(
                new Char[] { ',' }));
            ParentDataType.SelectedIndex = 0;

            ChildDataType.Items.Clear();
            ChildDataType.Items.AddRange(
                ("Boolean,Byte,Char,DateTime,Decimal,Double,Int16,Int32," +
                "Int64,SByte,Single,String,TimeSpan,UInt16,UInt32,UInt64").Split(
                new Char[] { ',' }));
            ChildDataType.SelectedIndex = 0;

            // ----- Fill in the tables with default data.
            ResetDataTables();

            // ----- Update the compute feature's view of columns.
            RefreshComputeColumns();
        }

        private void ActParentColumn_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Check for valid data.
            if (ParentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a column name.");
                ParentName.Focus();
                return;
            }
            if (ParentExpression.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide an expression.");
                ParentExpression.Focus();
                return;
            }

            // ----- Add the new column.
            try
            {
                ExampleData.Tables["Parent"].Columns.Add(ParentName.Text.Trim(),
                    Type.GetType("System." + ParentDataType.SelectedItem.ToString()),
                    ParentExpression.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the column: " + ex.Message);
                return;
            }

            // ----- Refresh the columns used for quick computing.
            RefreshComputeColumns();

            // ----- Reset for another column.
            ParentName.Clear();
            ParentDataType.SelectedIndex = 0;
            ParentExpression.Clear();
        }

        private void ActChildColumn_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Check for valid data.
            if (ChildName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a column name.");
                ChildName.Focus();
                return;
            }
            if (ChildExpression.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide an expression.");
                ChildExpression.Focus();
                return;
            }

            // ----- Add the new column.
            try
            {
                ExampleData.Tables["Child"].Columns.Add(ChildName.Text.Trim(),
                    Type.GetType("System." + ChildDataType.SelectedItem.ToString()),
                    ChildExpression.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the column: " + ex.Message);
                return;
            }

            // ----- Refresh the columns used for quick computing.
            RefreshComputeColumns();

            // ----- Reset for another column.
            ChildName.Clear();
            ChildDataType.SelectedIndex = 0;
            ChildExpression.Clear();
        }

        private void ActCompute_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Run a quick computation against a table column.
            bool isParent;
            string columnName;
            int delimIndex;
            string expression;
            Object result;
            DataTable whichTable;

            // ----- Get the selection components.
            columnName = ComputeColumn.SelectedItem.ToString();
            delimIndex = columnName.IndexOf(".");
            isParent = (columnName.Substring(0, delimIndex) == "Parent");
            columnName = columnName.Substring(delimIndex + 1);

            // ----- Build the expression.

            // ----- Get the table that will process the expression.
            if (isParent == true)
                whichTable = ExampleData.Tables["Parent"];
            else
                whichTable = ExampleData.Tables["Child"];

            // ----- Process the expression.

            // ----- Display the results.

        }

        private void ActReset_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Start over with fresh data.
            ResetDataTables();
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private DataTable GetParentTable()
        {
            // ----- Build a sample parent table.
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
            sourceLines = tableContent.ReadToEnd().Split(new string[] {"\r\n"},
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

        private DataTable GetChildTable()
        {
            // ----- Build a sample child table.
            string[] sourceLines;
            string[] lineFields;
            DataRow oneRow;
            DataTable result = new DataTable("Child");

            // ----- Add the column definitions.
            result.Columns.Add("ParentID", typeof(string));
            result.Columns.Add("CountyName", typeof(string));
            result.Columns.Add("Population2009", typeof(int));
            result.Columns.Add("Births2009", typeof(int));
            result.Columns.Add("Deaths2009", typeof(int));

            // ----- Get access to the table's source data.
            Assembly thisProgram = Assembly.GetExecutingAssembly();
            System.IO.Stream incoming = thisProgram.GetManifestResourceStream("Chapter_6_CSharp.Counties.csv");
            System.IO.StreamReader tableContent = new System.IO.StreamReader(incoming);

            // ----- Add some sample data. The "Counties" resource has the
            //       following comma-delimited fields:
            //         Parent ID (a.k.a., State Abbreviation)
            //         County Name
            //         2009 Population Estimation
            //         2009 Births
            //         2009 Deaths
            //       Demographic information is from the US Census Bureau.
            sourceLines = tableContent.ReadToEnd().Split(new string[] {"\r\n"},
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string oneLine in sourceLines)
            {
                // ----- Add a table row.
                lineFields = oneLine.Split(',');
                oneRow = result.NewRow();
                oneRow["ParentID"] = lineFields[0];
                oneRow["CountyName"] = lineFields[1];
                oneRow["Population2009"] = int.Parse(lineFields[2]);
                oneRow["Births2009"] = int.Parse(lineFields[3]);
                oneRow["Deaths2009"] = int.Parse(lineFields[4]);
                result.Rows.Add(oneRow);
            }

            // ----- Finished.
            tableContent.Dispose();
            incoming.Dispose();
            return result;
        }

        private void ResetDataTables()
        {
            // ----- Reset the table data used by the sample form.
            DataTable parentTable;
            DataTable childTable;

            // ----- Clear the existing data.
            ChildRecords.DataSource = null;
            ParentRecords.DataSource = null;
            ExampleData = new DataSet();

            // ----- Add the tables and relationships.
            parentTable = GetParentTable();
            childTable = GetChildTable();
            ExampleData.Tables.Add(parentTable);
            ExampleData.Tables.Add(childTable);
            ExampleData.Relations.Add(parentTable.Columns["ID"],
                childTable.Columns["ParentID"]);

            // ----- Add the tables to the display.
            ParentRecords.DataSource = parentTable;
            ChildRecords.DataSource = childTable;
        }

        private void RefreshComputeColumns()
        {
            // ----- Build a list of available columns from both parent and child.

            // ----- Clear any existing definitions.
            ComputeColumn.Items.Clear();

            // ----- Add the parent columns.
            foreach (DataColumn scanColumn in ExampleData.Tables["Parent"].Columns)
                ComputeColumn.Items.Add("Parent." + scanColumn.ColumnName);

            // ----- Add the child columns.
            foreach (DataColumn scanColumn in ExampleData.Tables["Child"].Columns)
                ComputeColumn.Items.Add("Child." + scanColumn.ColumnName);

            // ----- Finished.
            ComputeColumn.SelectedIndex = 0;
        }
    }
}
