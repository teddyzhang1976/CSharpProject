using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicViewDesk
{
    public partial class Frm_Set : Form
    {
        public Frm_Set()
        {
            InitializeComponent();
        }
        string path;
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            string[] scrs = System.IO.Directory.GetFiles(Environment.SystemDirectory.ToString(),"*.scr");
            comboBox2.Items.AddRange(scrs);
            comboBox2.SelectedIndex = 0;

            path = Application.StartupPath.ToString();
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += @"\Setup.ini";

            txtMusicPath.Text = baseClass.IniReadValue("setup", "musicpath", path);
            txtPath.Text = baseClass.IniReadValue("setup", "picpath", path);
            comboBox1.Text = baseClass.IniReadValue("setup", "pictime", path);
            comboBox2.Text = baseClass.IniReadValue("setup", "screen", path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Length > 2)
            {
                if (comboBox1.Text.Trim().Substring(0, 1) == "0")
                {
                    comboBox1.Text = comboBox1.Text.Trim().Substring(1);
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMusicPath.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(comboBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || txtMusicPath.Text.Trim() == "" || txtPath.Text.Trim() == "")
            {
                MessageBox.Show("请将设置信息填写完整！");
            }
            else
            {
                string picTime = comboBox1.Text.Trim();
                string picPath = txtPath.Text.Trim();
                string MusicPath = txtMusicPath.Text.Trim();
                string screenPath = comboBox2.Text.Trim();

                baseClass.IniWriteValue("setup", "pictime", picTime, path);
                baseClass.IniWriteValue("setup", "picpath", picPath, path);
                baseClass.IniWriteValue("setup", "musicpath", MusicPath, path);
                baseClass.IniWriteValue("setup", "screen", screenPath, path);

                if (MessageBox.Show("设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
