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

namespace Chapter_6_CSharp
{
    public partial class Switchboard : Form
    {
        public Switchboard()
        {
            InitializeComponent();
        }

        private void ActAggregate_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Show the aggregates example.
            (new Aggregates()).ShowDialog();
        }

        private void ActDataView_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Show the data views example.
            (new DataViews()).ShowDialog();
        }
    }
}
