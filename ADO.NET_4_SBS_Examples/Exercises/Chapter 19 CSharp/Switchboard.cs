// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 19 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_19_CSharp
{
    public partial class Switchboard : Form
    {
        public Switchboard()
        {
            InitializeComponent();
        }

        private void ActOrderViewer_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Display the order viewer.
            (new OrderViewer()).ShowDialog();
        }

        private void ActStatesYear_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Display the recent state viewer.
            (new StatesByYear()).ShowDialog();
        }
    }
}
