// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 5 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_5_CSharp
{
    public partial class FlightInfo : Form
    {
        private DataSet SampleDataSet;

        public FlightInfo()
        {
            InitializeComponent();
        }

        private void FlightInfo_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Fill in the update and delete rule lists.
            UpdateRule.Items.Add(System.Data.Rule.None);
            UpdateRule.Items.Add(System.Data.Rule.Cascade);
            UpdateRule.Items.Add(System.Data.Rule.SetNull);
            UpdateRule.Items.Add(System.Data.Rule.SetDefault);
            UpdateRule.SelectedIndex = 0;

            DeleteRule.Items.Add(System.Data.Rule.None);
            DeleteRule.Items.Add(System.Data.Rule.Cascade);
            DeleteRule.Items.Add(System.Data.Rule.SetNull);
            DeleteRule.Items.Add(System.Data.Rule.SetDefault);
            DeleteRule.SelectedIndex = 0;

            // ----- Create the sample data.
            ActResetAll.PerformClick();
        }

        private DataTable BuildFlightTable()
        {
            // ----- Create a sample table of flights.
            DataTable result;
            DataColumn keyColumn;

            // ----- Design the table structure.
            result = new DataTable("Flight");
            keyColumn = result.Columns.Add("ID", typeof(int));
            result.Columns.Add("Region", typeof(string));
            result.Columns.Add("FlightsPerWeek", typeof(int));
            result.PrimaryKey = new DataColumn[] {keyColumn};

            // ----- Add some sample data.
            result.Rows.Add(new Object[] {834, "Northwest", 5});
            result.Rows.Add(new Object[] {223, "South", 3});
            result.Rows.Add(new Object[] {225, "South", 5});

            return result;
        }

        private DataTable BuildLegTable()
        {
            // ----- Create a sample table of flight legs.
            DataTable result;
            DataColumn keyColumn;

            // ----- Design the table structure.
            result = new DataTable("Leg");
            keyColumn = result.Columns.Add("ID", typeof(int));
            keyColumn.AutoIncrement = true;
            result.Columns.Add("FlightID", typeof(int));
            result.Columns.Add("StartCity", typeof(string));
            result.Columns.Add("EndCity", typeof(string));
            result.Columns.Add("Distance", typeof(int));
            result.PrimaryKey = new DataColumn[] {keyColumn};

            // ----- Add some sample data.
            result.Rows.Add(new Object[] {1, 834, "Portland (PDX)", "Seattle (SEA)", 129});
            result.Rows.Add(new Object[] {2, 834, "Seattle (SEA)", "Missoula (MSO)", 416});
            result.Rows.Add(new Object[] {3, 223, "Dallas (DFW)", "Albuquerque (ABQ)", 567});
            result.Rows.Add(new Object[] {4, 223, "Albuquerque (ABQ)", "Phoenix (PHX)", 328});
            result.Rows.Add(new Object[] {5, 223, "Phoenix (PHX)", "Los Angeles (LAX)", 369});
            result.Rows.Add(new Object[] {6, 225, "Los Angeles (LAX)", "Phoenix (PHX)", 369});
            result.Rows.Add(new Object[] {7, 225, "Phoenix (PHX)", "Albuquerque (ABQ)", 328});
            result.Rows.Add(new Object[] {8, 225, "Albuquerque (ABQ)", "Dallas (DFW)", 567});

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

            // ----- Build the relationship between the tables.

            // ----- Set the constraints as selected by the user.
            RefreshConstraints();
            result.EnforceConstraints = EnforceConstraints.Checked;

            return result;
        }

        private void RefreshConstraints()
        {
            // ----- Set the delete and update rules for the table relationship.
            ForeignKeyConstraint linkConstraint;

            // ----- Ignore if there is no constraint.
            if (SampleDataSet == null) return;
            if (SampleDataSet.Relations.Count == 0) return;
            linkConstraint = SampleDataSet.Relations[0].ChildKeyConstraint;
            if (linkConstraint == null) return;

            // ----- Alter its cascade rules.

        }

        private void ActResetAll_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Clear any previous data.
            FlightView.DataSource = null;
            LegView.DataSource = null;
            ActFlightEdit.Enabled = false;
            ActFlightDelete.Enabled = false;
            ActLegEdit.Enabled = false;
            ActLegDelete.Enabled = false;

            // ----- Start a fresh data set for testing.
            SampleDataSet = BuildSampleDataSet();
            RefreshConstraints();
            FlightView.DataSource = SampleDataSet.Tables["Flight"];
            LegView.DataSource = SampleDataSet.Tables["Leg"];
        }

        private void EnforceConstraints_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Toggle constraint enforcement.
            if (SampleDataSet != null)
                SampleDataSet.EnforceConstraints = EnforceConstraints.Checked;
        }

        private void FlightView_SelectionChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable buttons if needed.
            ActFlightEdit.Enabled = (FlightView.SelectedRows.Count > 0);
            ActFlightDelete.Enabled = (FlightView.SelectedRows.Count > 0);
        }

        private void LegView_SelectionChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable buttons if needed.
            ActLegEdit.Enabled = (LegView.SelectedRows.Count > 0);
            ActLegDelete.Enabled = (LegView.SelectedRows.Count > 0);
        }

        private void UpdateRule_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Set the constraints as selected by the user.
            RefreshConstraints();
        }

        private void DeleteRule_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Set the constraints as selected by the user.
            RefreshConstraints();
        }

        private void ActFlightAdd_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new flight record.
            DataTable flightTable;
            DataRow flightRow;

            // ----- Create a new placeholder.
            flightTable = SampleDataSet.Tables["Flight"];
            if (flightTable == null) return;
            flightRow = flightTable.NewRow();

            // ----- Prompt the user.
            if ((new FlightDetail()).EditDetail(ref flightRow) == false) return;

            // ----- Add the row to the table.
            try
            {
                flightTable.Rows.Add(flightRow);
                flightTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add new row: " + ex.Message);
            }
        }

        private void ActFlightEdit_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Edit an existing flight record.
            DataTable flightTable;
            DataRowView flightRowManaged;
            DataRow flightRow;

            // ----- Locate the existing row.
            flightTable = SampleDataSet.Tables["Flight"];
            if (flightTable == null) return;
            if (FlightView.SelectedRows.Count == 0) return;
            flightRowManaged = (DataRowView)FlightView.SelectedRows[0].DataBoundItem;
            flightRow = flightRowManaged.Row;

            // ----- Prompt the user.
            if ((new FlightDetail()).EditDetail(ref flightRow) == false) return;

            // ----- Update the row in the table.
            try
            {
                flightTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not edit the row: " + ex.Message);
            }
        }

        private void ActFlightDelete_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new flight record.
            DataTable flightTable;
            DataRowView flightRowManaged;
            DataRow flightRow;

            // ----- Locate the existing row.
            flightTable = SampleDataSet.Tables["Flight"];
            if (flightTable == null) return;
            if (FlightView.SelectedRows.Count == 0) return;
            flightRowManaged = (DataRowView)FlightView.SelectedRows[0].DataBoundItem;
            flightRow = flightRowManaged.Row;

            // ----- Prompt the user.
            if (MessageBox.Show("Really delete the selected flight?",
                    "Chapter 5", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // ----- Update the row in the table.
            try
            {
                flightRow.Delete();
                flightTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete the row: " + ex.Message);
            }
        }

        private void ActLegAdd_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new leg record.
            DataTable legTable;
            DataRow legRow;
            DataRowView flightRowManaged;
            DataRow flightRow;
            string flightID;

            // ----- Create a new placeholder.
            legTable = SampleDataSet.Tables["Leg"];
            if (legTable == null) return;
            legRow = legTable.NewRow();

            // ----- Get the selected flight ID.
            flightID = "";
            if (FlightView.SelectedRows.Count > 0)
            {
                flightRowManaged = (DataRowView)FlightView.SelectedRows[0].DataBoundItem;
                flightRow = flightRowManaged.Row;
                flightID = ((int)flightRow["ID"]).ToString();
            }

            // ----- Prompt the user.
            if ((new LegDetail()).EditDetail(ref legRow, flightID) == false) return;

            // ----- Add the row to the table.
            try
            {
                legTable.Rows.Add(legRow);
                legTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add new row: " + ex.Message);
            }
        }

        private void ActLegEdit_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Edit an existing leg record.
            DataTable legTable;
            DataRowView legRowManaged;
            DataRow legRow;
            DataRowView flightRowManaged;
            DataRow flightRow;
            string flightID;

            // ----- Locate the existing row.
            legTable = SampleDataSet.Tables["Leg"];
            if (legTable == null) return;
            if (LegView.SelectedRows.Count == 0) return;
            legRowManaged = (DataRowView)LegView.SelectedRows[0].DataBoundItem;
            legRow = legRowManaged.Row;

            // ----- Get the selected flight ID.
            flightID = "";
            if (FlightView.SelectedRows.Count > 0)
            {
                flightRowManaged = (DataRowView)FlightView.SelectedRows[0].DataBoundItem;
                flightRow = flightRowManaged.Row;
                flightID = ((int)flightRow["ID"]).ToString();
            }

            // ----- Prompt the user.
            if ((new LegDetail()).EditDetail(ref legRow, flightID) == false) return;

            // ----- Update the row in the table.
            try
            {
                legTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not edit the row: " + ex.Message);
            }
        }

        private void ActLegDelete_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new leg record.
            DataTable legTable;
            DataRowView legRowManaged;
            DataRow legRow;

            // ----- Locate the existing row.
            legTable = SampleDataSet.Tables["Leg"];
            if (legTable == null) return;
            if (LegView.SelectedRows.Count == 0) return;
            legRowManaged = (DataRowView)LegView.SelectedRows[0].DataBoundItem;
            legRow = legRowManaged.Row;

            // ----- Prompt the user.
            if (MessageBox.Show("Really delete the selected leg?",
                    "Chapter 5", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // ----- Update the row in the table.
            try
            {
                legRow.Delete();
                legTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete the row: " + ex.Message);
            }
        }
    }
}
