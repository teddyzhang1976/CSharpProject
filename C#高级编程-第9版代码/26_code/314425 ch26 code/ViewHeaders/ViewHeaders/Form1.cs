using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewHeaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebRequest wrq = WebRequest.Create("http://www.wrox.com");
            WebResponse wrs = wrq.GetResponse();
            WebHeaderCollection whc = wrs.Headers;
            for (int i = 0; i < whc.Count; i++)
            {
                listBox1.Items.Add(string.Format("Header {0}: {1}", whc.GetKey(i), whc[i]));
            }
        }
    }
}
