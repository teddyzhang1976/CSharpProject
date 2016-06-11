using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainExample
{
    public partial class PanelExample : Form
    {
        public PanelExample()
        {
            InitializeComponent();

            // Add in some controls
            for (int i = 0; i < 20; i++)
            {
                Button b = new Button();
                b.Text = string.Format("Button{0}", i);
                this.flowLayoutPanel1.Controls.Add(b);
            }

        }
    }
}
