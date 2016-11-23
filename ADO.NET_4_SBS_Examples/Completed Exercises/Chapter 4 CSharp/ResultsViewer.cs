// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 4 - Visual Basic Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_4_CSharp
{
    public partial class ResultsViewer : Form
    {
        public ResultsViewer()
        {
            InitializeComponent();
        }

        public void ShowResults(Object displaySource)
        {
            try
            {
                ResultsDisplay.DataSource = displaySource;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not display the processed results with the following error: " +
                    ex.Message);
            }
        }
    }
}
