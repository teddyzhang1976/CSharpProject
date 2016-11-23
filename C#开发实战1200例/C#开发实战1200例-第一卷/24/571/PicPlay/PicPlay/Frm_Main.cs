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
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public bool Pflag;
        int flag = 0;
        FileSystemInfo[] fsinfo;
        ArrayList al = new ArrayList();
        int MM = 0;
        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbShowType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                al.Clear();
                listBox1.Items.Clear();
                txtPicPath.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(txtPicPath.Text);
                fsinfo = di.GetFileSystemInfos();
                for (int i = 0; i < fsinfo.Length; i++)
                {
                    string filename = fsinfo[i].ToString();
                    string filetype = filename.Substring(filename.LastIndexOf(".") + 1, filename.Length - filename.LastIndexOf(".") - 1);
                    filetype = filetype.ToLower();
                    if (filetype == "jpeg" || filetype == "jpg" || filetype == "png" || filetype == "gif" || filetype == "bmp")
                    {
                        listBox1.Items.Add(fsinfo[i].ToString());
                        al.Add(fsinfo[i].ToString());
                        flag++;
                    }
                }
                listBox1.SetSelected(0,true);
                listBox1.Focus();
                tssltotel.Text = "共有"+flag+"张图片";
                Pflag = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string picpath = txtPicPath.Text + "\\" + listBox1.SelectedItem.ToString();
            tsslPath.Text ="|当前第"+Convert.ToString(listBox1.SelectedIndex+1)+"张图片|图片位置："+ picpath;
            pictureBox1.Image = Image.FromFile(picpath);
            MM = listBox1.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            txtPicPath.Text = "";
            tssltotel.Text = "";
            tsslPath.Text = "";
            pictureBox1.Image = null;
            Pflag = false;
            timer1.Stop();
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Pflag)
            {
                if (txtTime.Text != "")
                {
                    if (cbbShowType.SelectedIndex == 1)
                    {
                        timer1.Interval = int.Parse(txtTime.Text.Trim());
                        timer1.Start();
                        button5.Enabled = false;
                    }
                    else
                    {
                        Frm_Browser frm2 = new Frm_Browser();
                        frm2.fsi = al;
                        frm2.picPath = txtPicPath.Text.Trim();
                        frm2.mytimer = int.Parse(txtTime.Text.Trim());
                        frm2.ShowDialog();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MM < listBox1.Items.Count)
            {
                if (txtPicPath.Text.Trim().Length == 3)
                {
                    pictureBox1.Image = Image.FromFile(txtPicPath.Text.Trim() + listBox1.Items[MM].ToString());
                    listBox1.SetSelected(MM, true);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(txtPicPath.Text.Trim() + "\\" + listBox1.Items[MM].ToString());
                    listBox1.SetSelected(MM, true);
                }
            }
            MM++;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTime.Text != "")
            {
                if (txtTime.Text.Trim().Substring(0, 1) == "0")
                {
                    txtTime.Text = txtTime.Text.Substring(1, txtTime.Text.Length - 1);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button5.Enabled = true;
        }
    }
}
