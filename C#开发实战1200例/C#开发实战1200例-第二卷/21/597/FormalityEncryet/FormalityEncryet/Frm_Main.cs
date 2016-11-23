using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FormalityEncryet
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Hardware.HardwareInfo hd = new Hardware.HardwareInfo();

        private void Form1_Shown(object sender, EventArgs e)
        {
            hd.GetHardDisk(comboBox_Disk);
            comboBox_Disk.SelectedIndex = 0;
        }

        private void button_EXE_Click(object sender, EventArgs e)
        {
            string Sprass="";//加密字符串
            string Annex = "";//附加的高级条件
            if (textBox_File.Text == "")
            {
                MessageBox.Show("没有选择要加密的EXE文件。");
                return;
            }
            FileInfo SFInfo = new FileInfo(textBox_File.Text.Trim());
            if (SFInfo.Exists == false)
            {
                MessageBox.Show("选择的文件并不存在。");
                return;
            }
            if (SFInfo.Extension.ToUpper() != ".EXE")
            {
                MessageBox.Show("选择的加密文件并不是EXE文件。");
                return;
            }
            Sprass = hd.CreatePass(this.groupB_Encryption, this.comboBox_Disk);

            if (radio_Data.Checked == true)
            {
                Annex = "," + dateTimePicker1.Value.ToShortDateString() + "D";
            }
            if (radio_Month.Checked == true)
            {
                Annex = "," + ((int)nume_Month.Value).ToString() + "M";
            }
            if (radio_Day.Checked == true)
            {
                Annex = "," + ((int)numer_Day.Value).ToString() + "A";
            }
            if (radio_Count.Checked == true)
            {
                Annex = "," + ((int)numer_Count.Value).ToString() + "C";
            }

            if (Sprass.Trim() == "")
            {
                MessageBox.Show("无法生成加密码，请重新设置。");
                return;
            }
            hd.WriteEXE(Hardware.HardwareInfo.PFileDir, Sprass.Trim() + Annex.Trim());
            hd.CreateTXT(Sprass.Trim());
            MessageBox.Show("EXE文件加密成功。");
        }

        private void button_File_Click(object sender, EventArgs e)
        {
            string FileN = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_File.Text = openFileDialog1.FileName;
                Hardware.HardwareInfo.PFileDir = openFileDialog1.FileName; 
                FileInfo SFInfo = new FileInfo(textBox_File.Text.Trim());
                FileN = SFInfo.Name;
                Hardware.HardwareInfo.PFileN = FileN.Substring(0, FileN.Length - 4);
            }
        }

        //使单选按钮只能选择一个
        private void Stemma(RadioButton RadioB)
        {
            radio_Data.Checked = false;
            radio_Month.Checked = false;
            radio_Day.Checked = false;
            radio_Count.Checked = false;
            RadioB.Checked = true;
        }

        private void radio_Data_MouseUp(object sender, MouseEventArgs e)
        {
            Stemma((RadioButton)sender);
        }
    }
}