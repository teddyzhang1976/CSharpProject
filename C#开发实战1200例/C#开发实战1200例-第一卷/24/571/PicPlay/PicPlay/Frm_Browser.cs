using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace PicPlay
{
    public partial class Frm_Browser : Form
    {
        public Frm_Browser()
        {
            InitializeComponent();
        }
        public ArrayList fsi=new ArrayList();
        public int mytimer;
        public string picPath;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = mytimer;
            timer1.Start();
        }

        int MM = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MM <fsi.Count)
            {
                if (picPath.Length == 3)
                {
                    pictureBox2.Image = Image.FromFile(picPath +fsi[MM].ToString());
                }
                else
                {
                    pictureBox2.Image = Image.FromFile(picPath + "\\" + fsi[MM].ToString());
                }
            }
            MM++;
        }
    }
}
