using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoundCalculator
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        private static extern Int32 mciSendString(String lpstrCommand, String lpstrReturnString, Int32 uReturnLength, Int32 hwndCallback);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string[] VoxPath = new string[24];

        string tem_Value = "";
        string tem_FileName = "";
        Int32 n = 0;

        public void GetVox()
        { 
            StringBuilder temp = new StringBuilder(255);
            if (System.IO.File.Exists(Application.StartupPath + "\\Tem_File.ini") == true)
            {
                for (int i = 0; i < VoxPath.Length; i++)
                {
                    GetPrivateProfileString("Vox", i.ToString(), "数据读取错误。", temp, 255, Application.StartupPath + "\\Tem_File.ini");
                    VoxPath[i] = temp.ToString();
                }
            }
        }
        public void sound(string FileName)
        {
            if (FileName == null)//如果文件为空
                return;//退出操作
            if (FileName.IndexOf(" ") == -1)//如果路径中没有空格
            {
                if (tem_FileName.Length!=0)//如果有播放的文件
                    mciSendString("close " + tem_FileName, null, 0, 0);//关闭当前文件的播放
                n=mciSendString("open " + FileName , null, 0 , 0);//打开要播放的文件
                n=mciSendString("play " + FileName, null, 0, 0);//播放当前文件
                tem_FileName = FileName;//记录播放文件的路径
            }
        }

        private void pict_Back_Click(object sender, EventArgs e)
        {
            tem_Value = ((PictureBox)sender).AccessibleName;//获取当前按钮的标识
            switch (tem_Value)
            {
                case "0": num(tem_Value); sound(VoxPath[0]); break;//实现按钮的语音功能
                case "1": num(tem_Value); sound(VoxPath[1]); break;
                case "2": num(tem_Value); sound(VoxPath[2]); break;
                case "3": num(tem_Value); sound(VoxPath[3]); break;
                case "4": num(tem_Value); sound(VoxPath[4]); break;
                case "5": num(tem_Value); sound(VoxPath[5]); break;
                case "6": num(tem_Value); sound(VoxPath[6]); break;
                case "7": num(tem_Value); sound(VoxPath[7]); break;
                case "8": num(tem_Value); sound(VoxPath[8]); break;
                case "9": num(tem_Value); sound(VoxPath[9]); break;
                case "+": js(tem_Value); sound(VoxPath[10]); break;
                case "-": js(tem_Value); sound(VoxPath[11]); break;
                case "*": js(tem_Value); sound(VoxPath[12]); break;
                case "/": js(tem_Value); sound(VoxPath[13]); break;
                case "=": js(tem_Value); sound(VoxPath[14]); break;
                case "C": Aclose(); sound(VoxPath[15]); break;
                case "CE": ce(); sound(VoxPath[16]); break;
                case "Back": backspace(); sound(VoxPath[17]); break;
                case "%": bai(); sound(VoxPath[18]); break;
                case "X": ji(); sound(VoxPath[19]); break;
                case ".": dian(); sound(VoxPath[20]); break;
                case "+-":
                    {
                        zf();
                        if (Convert.ToInt32(textBox1.Text) > 0)//如果当前为正数
                            sound(VoxPath[21]);//实现正数发音
                        else
                            sound(VoxPath[22]);//实现负数发音
                        break;
                    }
                case "Sqrt": kfang(); sound(VoxPath[23]); break;
            }
            textBox1.Select(textBox1.Text.Length, 0);
        }

        bool isnum = false;
        double n1 = 0;
        string fu = "";
        double zong = 0;
        bool isdian = false;
        public void num(string n)
        {
            if (isnum == true)
            {
                if (textBox1.Text == "0.") { textBox1.Text = textBox1.Text + n; }
                else { textBox1.Text = n; }
                isnum = false;
            }
            else
            {
                if (textBox1.Text == "0") { textBox1.Text = n; }
                else
                {
                    textBox1.Text = textBox1.Text + n;
                }
            }
            n1 = Convert.ToDouble(textBox1.Text);
        }

        public void dian()
        {
            bool isfirst = isfloor();
            if ((isnum == true) || (textBox1.Text == "0")) { textBox1.Text = "0."; }
            if ((isdian == false) && (isfirst == true))
            {
                textBox1.Text = "0.";
            }
            else if (isdian == false)
            {
                if (Convert.ToDouble(textBox1.Text) == 0) { textBox1.Text = "0."; }
                else if (isfirst == true) { textBox1.Text = textBox1.Text; }
                else { textBox1.Text = textBox1.Text + "."; }
                isdian = true;
            }
        }
        public bool isfloor()
        {
            var int1 = Convert.ToDouble(textBox1.Text);
            var int2 = Math.Floor(int1);
            if (int1 > int2) { return true; }
            else { return false; }
        }
        public void ce()
        {
            zong = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "0";
            isnum = true;
            isdian = false;
        }
        public void Aclose()
        {
            isdian = isnum = false;
            ce();
            fu = tem_base = "";
            zong = n1 = 0;
        }
        public bool isxiao(double n)
        {
            double int1 = Convert.ToSingle(n);
            double int2 = Math.Floor(int1);
            if (int1 > int2) { return true; }
            else { return false; }
        }
        string tem_base;
        public void js(string s)
        {
            double lin = Convert.ToSingle(n1);
            if ((s == "=") && (fu == "="))
            {
                if ((tem_base == "+") || (tem_base == "-") || (tem_base == "*") || (tem_base == "/"))
                {
                    zong = eval(zong , tem_base , lin);
                    if (isxiao(zong) == true) { textBox1.Text = Math.Round(zong, 4).ToString(); }
                    else { textBox1.Text = zong.ToString(); }
                }
            }
            else if ((fu == "=") && (s == ("*") || s == ("/") || s == ("+") || s == ("-")))
            {
                if (isxiao(zong) == true) { textBox1.Text = Math.Round(zong, 4).ToString(); }
                else { textBox1.Text = zong.ToString(); }
                tem_base = fu;
                fu = s;
            }
            else
            {
                if (isnum && fu != "=")
                {
                    if ("+" == fu)
                        zong = eval(zong , fu , lin);
                    else if ("-" == fu)
                        zong = eval(zong , fu , lin);
                    else if ("/" == fu)
                        zong = eval(zong , fu , lin);
                    else if ("*" == fu)
                        zong = eval(zong , fu , lin);
                    else if ("" == fu)
                        zong = lin;
                    if (isxiao(zong) == true) { textBox1.Text = Math.Round(zong, 4).ToString(); }
                    else { textBox1.Text = zong.ToString(); }
                    tem_base = fu;
                    fu = s;
                }
                else
                {
                    if ("+" == fu)
                        zong += lin;
                    else if ("-" == fu)
                        zong = zong - lin;
                    else if ("/" == fu)
                        zong /= lin;
                    else if ("*" == fu)
                        zong *= lin;
                    else
                        zong = lin;
                    if (isxiao(zong) == true) { textBox1.Text = Math.Round(zong, 4).ToString(); }
                    else { textBox1.Text = zong.ToString(); }
                    tem_base = fu;
                    fu = s;
                }
            }
            isnum = true;
        }
        public void bai()
        {
            textBox1.Text = ((Convert.ToDouble(textBox1.Text) / 100) * Convert.ToDouble(zong)).ToString();
            isdian = false;
        }
        public void kfang()
        {
            if (textBox1.Text != "0" || textBox1.Text != "")
            {
                textBox1.Text = Math.Sqrt(Convert.ToDouble(textBox1.Text)).ToString();
                isnum = true;
                isdian = false;
            }
        }
        public void zf()
        {
            double pp = Convert.ToDouble(textBox1.Text);
            if (pp > 0) { textBox1.Text = "-" + pp; }
            if (pp < 0) { textBox1.Text = Math.Abs(pp).ToString(); }
        }
        public void ji()
        {
            double pp = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Convert.ToDouble(1 / pp).ToString();
            isnum = true;
            isdian = false;
        }
        public void backspace()
        {
            var bstr = textBox1.Text;
            if (bstr != "0")
            {
                string isabs = (Math.Abs(Convert.ToDouble(bstr)).ToString());
                if ((bstr.Length == 1) || (isabs.Length == 1))
                {
                    textBox1.Text = "0";
                    isdian = false;
                }
                else { textBox1.Text = bstr.Substring(0, bstr.Length - 1); }
            }
        }

        public double eval(double n1, string sign, double n2)
        {
            switch (sign)
            {
                case "-": return n1 - n2;
                case "+": return n1 + n2;
                case "*": return n1 * n2;
                case "/": return n1 / n2;
            }
            return 0;
        }

        private void ToolS_Vox_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
            {
                case 0:
                    {
                        Frm_Set Frm_2 = new Frm_Set();
                        if (Frm_2.ShowDialog() == DialogResult.OK)
                        {
                            GetVox();
                        }
                        break;
                    }
                case 1: Close(); break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetVox();
        }

        private void pict_Back_MouseEnter(object sender, EventArgs e)
        {
            SetButton(sender, false);
        }


        private void pict_Back_MouseLeave(object sender, EventArgs e)
        {
            SetButton(sender, true);
        }

        public void SetButton(object sender, bool b)//b为false时变色
        {
            ((PictureBox)sender).Image = null;
            tem_Value = ((PictureBox)sender).AccessibleName;
            switch (tem_Value)
            {
                case "0":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._0;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._0_1;
                    break;
                case "1":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._1;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._1_1;
                    break;
                case "2":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._2;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._2_1;
                    break;
                case "3":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._3;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._3_1;
                    break;
                case "4":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._4;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._4_1;
                    break;
                case "5":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._5;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._5_1;
                    break;
                case "6":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._6;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._6_1;
                    break;
                case "7":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._7;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._7_1;
                    break;
                case "8":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._8;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._8_1;
                    break;
                case "9":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources._9;
                    else
                        ((PictureBox)sender).Image = Properties.Resources._9_1;
                    break;
                case "+":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Add;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Add1;
                    break;
                case "-":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Decr;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Decr1;
                    break;
                case "*":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Ride;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Ride1;
                    break;
                case "/":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Remove;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Remove1;
                    break;
                case "=":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Amound;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Amound1;
                    break;
                case "C":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.c;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.c1;
                    break;
                case "CE":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.ce;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.ce1;
                    break;
                case "Back":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.back;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.back1;
                    break;
                case "%":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Hund;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Humd1;
                    break;
                case "X":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Deno;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Deno1;
                    break;
                case ".":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Dot;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Dot1;
                    break;
                case "+-":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.Bear;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.Bear1;
                    break;
                case "Sqrt":
                    if (b)
                        ((PictureBox)sender).Image = Properties.Resources.sqrt;
                    else
                        ((PictureBox)sender).Image = Properties.Resources.sqrt1;
                    break;
            }
        }

    }
}
