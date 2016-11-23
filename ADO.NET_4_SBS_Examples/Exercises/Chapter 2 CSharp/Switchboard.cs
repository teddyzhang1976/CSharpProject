// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 2 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_2_CSharp
{
    public partial class Switchboard : Form
    {
        public Switchboard()
        {
            InitializeComponent();
        }

        private void ActNoColumns_Click(object sender, EventArgs e)
        {
            // ----- Show a table with no columns.
            DataTable theTable;

            theTable = GetNoColumnTable();
            if (theTable == null) return;
            ShowTable(theTable);
        }

        private void ActColumns_Click(object sender, EventArgs e)
        {
            // ----- Show a table with data columns.
            DataTable theTable;

            theTable = GetColumnTable();
            if (theTable == null) return;
            ShowTable(theTable);
        }

        private void ActDesigner_Click(object sender, EventArgs e)
        {
            // ----- Show a table created in the Dataset Designer.
            DataTable theTable;

            theTable = GetDesignerTable();
            if (theTable == null) return;
            ShowTable(theTable);
        }

        private DataTable GetNoColumnTable()
        {
            // ----- Return a table that has no columns.

        }

        private DataTable GetColumnTable()
        {
            return null;
        }

        private DataTable GetDesignerTable()
        {
            return null;
        }

        private void ShowTable(DataTable whichTable)
        {
            // ----- Show the design of a table through the detail form.
            if (whichTable == null) return;
            (new TableDetails()).ShowTable(whichTable);
        }
    }
}
