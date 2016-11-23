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
    public partial class FlightDetail : Form
    {
        public FlightDetail()
        {
            InitializeComponent();
        }

        public bool EditDetail(ref DataRow flightRow)
        {
            // ----- Fill in the existing details.
            if (DBNull.Value.Equals(flightRow["ID"]) == false)
                FlightID.Value = (int)flightRow["ID"];
            if (DBNull.Value.Equals(flightRow["Region"]) == false)
                RegionName.Text = (string)flightRow["Region"];
            if (DBNull.Value.Equals(flightRow["FlightsPerWeek"]) == false)
                FlightsPerWeek.Value = (int)flightRow["FlightsPerWeek"];

            // ----- Prompt the user for the changes.
            if (this.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    flightRow.BeginEdit();
                    flightRow["ID"] = FlightID.Value;
                    flightRow["Region"] = RegionName.Text.Trim();
                    flightRow["FlightsPerWeek"] = FlightsPerWeek.Value;
                    flightRow.EndEdit();
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
            // ----- The region name is required.
            if (RegionName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please provide a region name.");
                RegionName.Focus();
                return;
            }

            // ----- Success.
            this.DialogResult = DialogResult.OK;
        }
    }
}
