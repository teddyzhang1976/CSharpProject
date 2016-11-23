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
    public partial class LegDetail : Form
    {
        public LegDetail()
        {
            InitializeComponent();
        }

        public bool EditDetail(ref DataRow legRow, string trueFlightID)
        {
            // ----- Fill in the existing details.
            if (trueFlightID.Length > 0) ParentFlightID.Text = trueFlightID;
            if (DBNull.Value.Equals(legRow["FlightID"]) == false)
                FlightID.Value = (int)legRow["FlightID"];
            if (DBNull.Value.Equals(legRow["StartCity"]) == false)
                StartCity.Text = (string)legRow["StartCity"];
            if (DBNull.Value.Equals(legRow["EndCity"]) == false)
                EndCity.Text = (string)legRow["EndCity"];
            if (DBNull.Value.Equals(legRow["Distance"]) == false)
                FlightDistance.Value = (int)legRow["Distance"];

            // ----- Prompt the user for the changes.
            if (this.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    legRow.BeginEdit();
                    legRow["FlightID"] = FlightID.Value;
                    legRow["StartCity"] = StartCity.Text.Trim();
                    legRow["EndCity"] = EndCity.Text.Trim();
                    legRow["Distance"] = FlightDistance.Value;
                    legRow.EndEdit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Changes could not be saved: " + ex.Message);
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void ActOK_Click(System.Object sender, System.EventArgs e)
        {
            // ----- The start city is required.
            if (StartCity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a start city.");
                StartCity.Focus();
                return;
            }

            // ----- The end city is required.
            if (EndCity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide an end city.");
                EndCity.Focus();
                return;
            }

            // ----- The cities can't be the same.
            if (StartCity.Text.Trim().ToUpper() == EndCity.Text.Trim().ToUpper())
            {
                MessageBox.Show("The start and end cities must be different.");
                EndCity.Focus();
                return;
            }

            // ----- Success.
            this.DialogResult = DialogResult.OK;
        }
    }
}
