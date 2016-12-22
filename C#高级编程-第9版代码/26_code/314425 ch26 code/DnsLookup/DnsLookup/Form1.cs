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

namespace DnsLookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(textBox1.Text);
            foreach (IPAddress ip in ipHost.AddressList)
            {
                string ipaddress = ip.AddressFamily.ToString();
                listBox1.Items.Add(ipaddress);
                listBox1.Items.Add(" " + ip.ToString());
            }
            textBox2.Text = ipHost.HostName;
        }
    }
}
