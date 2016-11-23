// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 7 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Chapter_7_CSharp
{
    public partial class Serialization : Form
    {
        private DataSet SampleDataSet;

        public Serialization()
        {
            InitializeComponent();
        }

        private DataTable BuildParentTable()
        {
            // ----- Create a sample parent table.
            DataTable result;
            DataColumn keyColumn;

            // ----- Design the table structure.
            result = new DataTable("Customer");
            keyColumn = result.Columns.Add("ID", typeof(int));
            result.Columns.Add("BusinessName", typeof(string));
            result.Columns.Add("AnnualFee", typeof(decimal));
            result.Columns.Add("ContractDate", typeof(DateTime));
            result.PrimaryKey = new DataColumn[] {keyColumn};

            // ----- Add some sample data.
            result.Rows.Add(new Object[] {1, "City Power & Light",
                500m, DateTime.Parse("6/1/2008")});
            result.Rows.Add(new Object[] {2, "Lucerne Publishing",
                300m, DateTime.Parse("1/1/2008")});
            result.Rows.Add(new Object[] {3, "Southridge Video",
                350m, DateTime.Parse("2/15/2010")});

            return result;
        }

        private DataTable BuildChildTable()
        {
            // ----- Create a sample child table.
            DataTable result;
            DataColumn keyColumn;

            // ----- Design the table structure.
            result = new DataTable("Order");
            keyColumn = result.Columns.Add("ID", typeof(int));
            keyColumn.AutoIncrement = true;
            result.Columns.Add("CustomerID", typeof(int));
            result.Columns.Add("OrderDate", typeof(DateTime));
            result.Columns.Add("Subtotal", typeof(decimal));
            result.Columns.Add("TaxRate", typeof(decimal));
            result.Columns.Add("Total", typeof(decimal),
                "Subtotal * (1 + TaxRate)");
            result.PrimaryKey = new DataColumn[] {keyColumn};

            // ----- Add some sample data.
            result.Rows.Add(new Object[] {801, 1, DateTime.Parse("3/23/2010"), 342.94m, 0.0875m});
            result.Rows.Add(new Object[] {802, 3, DateTime.Parse("3/23/2010"), 100m, 0.0925m});
            result.Rows.Add(new Object[] {803, 3, DateTime.Parse("3/24/2010"), 59.99m, 0.0925m});
            result.Rows.Add(new Object[] {804, 1, DateTime.Parse("3/25/2010"), 342.94m, 0.0875m});
            result.Rows.Add(new Object[] { 805, 2, DateTime.Parse("4/2/2010"), 180.08m, 0.0875m});

            return result;
        }

        private DataSet BuildSampleDataSet()
        {
            // ----- Build a sample data set of flight information.
            DataSet result;
            DataTable parentTable;
            DataTable childTable;
            DataRelation tableLink;

            // ----- Add the two tables to the data set.
            result = new DataSet("SerializeSample");
            parentTable = BuildParentTable();
            childTable = BuildChildTable();
            result.Tables.Add(parentTable);
            result.Tables.Add(childTable);

            // ----- Build the relationship between the tables.
            tableLink = new DataRelation("CustomerOrder", parentTable.Columns["ID"],
                childTable.Columns["CustomerID"], true);
            result.Relations.Add(tableLink);

            return result;
        }

        private DataColumn GetMappingColumn()
        {
            // ----- Locate the column from the SelectColumn field.
            string[] nameParts;
            DataTable whichTable;

            // ----- Identify the selected column.
            if (SelectColumn.SelectedIndex == -1) return null;
            nameParts = ((string)SelectColumn.SelectedItem).Split('.');
            if (nameParts[0] == "Parent")
                whichTable = SampleDataSet.Tables["Customer"];
            else
                whichTable = SampleDataSet.Tables["Order"];
            return whichTable.Columns[nameParts[1]];
        }

        private void Serialization_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            DataTable parentTable;
            DataTable childTable;

            // ----- Prepare the core sample data.
            SampleDataSet = BuildSampleDataSet();
            parentTable = SampleDataSet.Tables["Customer"];
            ParentContent.DataSource = parentTable;
            childTable = SampleDataSet.Tables["Order"];
            ChildContent.DataSource = childTable;

            // ----- Fill in the XML Write Mode options.
            OutputWriteMode.Items.Add(XmlWriteMode.WriteSchema);
            OutputWriteMode.Items.Add(XmlWriteMode.IgnoreSchema);
            OutputWriteMode.Items.Add(XmlWriteMode.DiffGram);
            OutputWriteMode.SelectedIndex = 0;

            // ----- Fill in the types of column mapping.
            ColumnMappingType.Items.Add(MappingType.Element);
            ColumnMappingType.Items.Add(MappingType.Attribute);
            ColumnMappingType.Items.Add(MappingType.SimpleContent);
            ColumnMappingType.Items.Add(MappingType.Hidden);

            // ----- Fill in the list of columns.
            foreach (DataColumn scanColumn in parentTable.Columns)
                SelectColumn.Items.Add("Parent." + scanColumn.ColumnName);
            foreach (DataColumn scanColumn in childTable.Columns)
                SelectColumn.Items.Add("Child." + scanColumn.ColumnName);
            SelectColumn.SelectedIndex = 0;
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void ActGenerate_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Generate the XML content using the settings.
            MemoryStream holdBuffer;
            Char[] charArray;
            UTF8Encoding decoder;

            // ----- Set the XML namespace.
            SampleDataSet.Tables["Customer"].Namespace = TableNamespace.Text.Trim();
            SampleDataSet.Tables["Customer"].Prefix = TablePrefix.Text.Trim();
            SampleDataSet.Tables["Order"].Namespace = TableNamespace.Text.Trim();
            SampleDataSet.Tables["Order"].Prefix = TablePrefix.Text.Trim();

            // ----- Indicate the relationship type.
            SampleDataSet.Relations[0].Nested = NestChildRecords.Checked;

            // ----- Clear any existing results.
            SerializedResults.Clear();

            // ----- Build a memory stream to hold the results.
            holdBuffer = new MemoryStream(8192);
            SampleDataSet.WriteXml(holdBuffer, (XmlWriteMode)OutputWriteMode.SelectedItem);

            // ----- Convert it to something displayable.
            decoder = new UTF8Encoding();
            holdBuffer.Seek(0, SeekOrigin.Begin);
            charArray = new Char[decoder.GetCharCount(holdBuffer.ToArray()) - 1];
            decoder.GetDecoder().GetChars(holdBuffer.ToArray(), 0, charArray.Length, charArray, 0);
            SerializedResults.Text = new string(charArray);
        }

        private void SelectColumn_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Display the mapping for the selected column.
            DataColumn whichColumn;

            // ----- Identify the selected column.
            whichColumn = GetMappingColumn();
            if (whichColumn == null) return;

            // ----- Set the option field to the current setting.
            ColumnMappingType.SelectedIndex =
                ColumnMappingType.Items.IndexOf(whichColumn.ColumnMapping);
        }

        private void ColumnMappingType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Display the mapping for the selected column.
            DataColumn whichColumn;
            MappingType newType;

            // ----- Identify the selected column.
            whichColumn = GetMappingColumn();
            if (whichColumn == null) return;
            if (ColumnMappingType.SelectedIndex == -1) return;

            // ----- Use the new setting to modify the column.
            newType = (MappingType)ColumnMappingType.SelectedItem;
            if (newType != whichColumn.ColumnMapping)
                whichColumn.ColumnMapping = newType;
        }
    }
}
