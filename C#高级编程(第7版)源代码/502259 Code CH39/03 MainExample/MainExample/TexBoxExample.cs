using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainExample.Properties;

namespace MainExample
{
    public partial class TexBoxExample : Form
    {
        public TexBoxExample()
        {
            InitializeComponent();

            this.richTextBox1.Rtf = Resources.Hello;
        }
    }
}
