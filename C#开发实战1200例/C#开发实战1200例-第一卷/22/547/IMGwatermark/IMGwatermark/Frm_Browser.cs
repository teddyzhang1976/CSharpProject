using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMGwatermark
{
    public partial class Frm_Browser : Form
    {
        public Frm_Browser()
        {
            InitializeComponent();
        }
        public Image ig = null;
        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ig;
        }
    }
}
