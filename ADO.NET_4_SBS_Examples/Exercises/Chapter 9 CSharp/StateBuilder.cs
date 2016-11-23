// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 9 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_9_CSharp
{
    public partial class StateBuilder : Form
    {
        private long ActiveStateID = -1L;

        public StateBuilder()
        {
            InitializeComponent();
        }

        private void RefreshEverything()
        {
            // ----- Refresh most of the fields on the three main tabs.
            string sqlText;
            SqlConnection linkToDB;
            SqlDataReader stateReader;

            // ----- Initialize.
            ActiveStateID = -1L;

            // ----- Open a database connection.
            linkToDB = General.OpenConnection();
            if (linkToDB == null) return;

            // ----- See if a custom state already exists.

            // ----- Adjust the display.
            if (ActiveStateID == -1L)
            {
                // ----- Set up the display for a new entry.
                AddName.Enabled = true;
                AddAbbreviation.Enabled = true;
                ActAdd.Enabled = true;

                EditID.Text = "N/A";
                EditName.Clear();
                EditAbbreviation.Clear();
                EditName.Enabled = false;
                EditAbbreviation.Enabled = false;
                ActEdit.Enabled = false;

                DeleteID.Text = "N/A";
                DeleteName.Text = "N/A";
                DeleteAbbreviation.Text = "N/A";
                ActDelete.Enabled = false;
            }
            else
            {
                // ----- Set up the display for an existing item.
                AddName.Enabled = false;
                AddAbbreviation.Enabled = false;
                ActAdd.Enabled = false;

                EditID.Text = ActiveStateID.ToString();
                EditName.Text = AddName.Text;
                EditAbbreviation.Text = AddAbbreviation.Text;
                EditName.Enabled = true;
                EditAbbreviation.Enabled = true;
                ActEdit.Enabled = true;

                DeleteID.Text = ActiveStateID.ToString();
                DeleteName.Text = AddName.Text;
                DeleteAbbreviation.Text = AddAbbreviation.Text;
                ActDelete.Enabled = true;
            }

            // ----- Refresh the SQL statement previews.
            RefreshAddPreview();
            RefreshEditPreview();
            RefreshDeletePreview();
        }

        private void RefreshAddPreview()
        {
            // ----- Show the processing string.
            if (ActiveStateID == -1L)
                AddSQL.Text = GenerateAddSQL();
            else
                AddSQL.Text = "Custom state already exists.";
        }

        private void RefreshEditPreview()
        {
            // ----- Show the processing string.
            if (ActiveStateID == -1L)
                EditSQL.Text = "No custom state available.";
            else
                EditSQL.Text = GenerateEditSQL();
        }

        private void RefreshDeletePreview()
        {
            // ----- Show the processing string.
            if (ActiveStateID == -1L)
                DeleteSQL.Text = "No custom state available.";
            else
                DeleteSQL.Text = GenerateDeleteSQL();
        }

        private string GenerateAddSQL()
        {
            // ----- Build the SQL string that will add a state record.
            if (ActiveStateID == -1L)
                return "INSERT INTO StateRegion (FullName, Abbreviation, " +
                    "RegionType) OUTPUT INSERTED.ID VALUES (" +
                    General.DBText(AddName.Text.Trim()) + ", " +
                    General.DBText(AddAbbreviation.Text.Trim()) + ", 99)";
            else
                return "";
        }

        private string GenerateEditSQL()
		{
			// ----- Build the SQL string that will modify a state record.
			if (ActiveStateID == -1L)
				return "";
			else
				return "UPDATE StateRegion " +
                    "SET FullName = " + General.DBText(EditName.Text.Trim()) +
                    ", Abbreviation = " + General.DBText(EditAbbreviation.Text.Trim()) +
					" WHERE ID = " + ActiveStateID;
		}

        private string GenerateDeleteSQL()
		{
			// ----- Build the SQL string that will delete a state record.
			if (ActiveStateID == -1L)
				return "";
			else
				return "DELETE FROM StateRegion WHERE ID = " + ActiveStateID;
		}

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void AddFields_TextChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Refresh the preview.
            AddSQL.Text = GenerateAddSQL();
        }

        private void EditFields_TextChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Refresh the preview.
            EditSQL.Text = GenerateEditSQL();
        }

        private void ActAdd_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add the custom state.
            SqlConnection linkToDB;
            object result;

            // ----- Ignore if there is already a state.
            if (ActiveStateID != -1L) return;

            // ----- The state name is required.
            if (AddName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a state name.");
                return;
            }

            // ----- The state abbreviaion is required.
            if (AddAbbreviation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a state abbreviation.");
                return;
            }

            // ----- Access the database.
            linkToDB = General.OpenConnection();
            if (linkToDB == null) return;

            // ----- Remove the record.
            result = General.ExecuteSQLReturn(GenerateAddSQL(), linkToDB);
            linkToDB.Close();
            if (DBNull.Value.Equals(result) == true) return;
            MessageBox.Show("Added new state with ID " + result.ToString() + ".");

            // ------ Refresh the display.
            RefreshEverything();
            ActionTabs.SelectedTab = TabEdit;
        }

        private void ActEdit_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Modify the custom state.
            SqlConnection linkToDB;

            // ----- Ignore if there is nothing to modify.
            if (ActiveStateID == -1L) return;

            // ----- The state name is required.
            if (EditName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a state name.");
                return;
            }

            // ----- The state abbreviaion is required.
            if (EditAbbreviation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a state abbreviation.");
                return;
            }

            // ----- Access the database.
            linkToDB = General.OpenConnection();
            if (linkToDB == null) return;

            // ----- Modify the record.
            General.ExecuteSQL(GenerateEditSQL(), linkToDB);
            linkToDB.Close();
            MessageBox.Show("Modified the state record.");

            // ------ Refresh the display.
            RefreshEverything();
        }

        private void ActDelete_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Delete the custom state.
            SqlConnection linkToDB;

            // ----- Ignore if there is nothing to delete.
            if (ActiveStateID == -1L) return;

            // ----- Access the database.
            linkToDB = General.OpenConnection();
            if (linkToDB == null) return;

            // ----- Remove the record.
            General.ExecuteSQL(GenerateDeleteSQL(), linkToDB);
            linkToDB.Close();
            MessageBox.Show("Deleted the state record.");

            // ------ Refresh the display.
            RefreshEverything();
            ActionTabs.SelectedTab = TabAdd;
        }

        private void StateBuilder_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            RefreshEverything();
            if (ActiveStateID != -1L) ActionTabs.SelectedTab = TabEdit;
        }
    }
}
