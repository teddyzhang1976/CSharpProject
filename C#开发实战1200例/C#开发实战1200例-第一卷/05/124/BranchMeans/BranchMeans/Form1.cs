using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BranchMeans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Value_1 = "";//记录计算之前的数
        public string Value_2 = "";//记录计算之后的数
        public string Kind = "";//记录算法
        string tem_Value = "";//记录当前输入的键值
        bool isnum = false;//判断输入的是计算的那个值
        bool isdian = false;//是否有小数点
        Account Acc = new Account();//实例化计算类

        //根据键值触发相应的功能
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            tem_Value = ((PictureBox)sender).Tag.ToString();//获取当前按钮的标识
            switch (tem_Value)
            {
                //输入数字键
                case "0": num(tem_Value); break;
                case "1": num(tem_Value); break;
                case "2": num(tem_Value); break;
                case "3": num(tem_Value); break;
                case "4": num(tem_Value); break;
                case "5": num(tem_Value); break;
                case "6": num(tem_Value); break;
                case "7": num(tem_Value); break;
                case "8": num(tem_Value); break;
                case "9": num(tem_Value); break;
                //输入计算键
                case "+":
                case "-":
                case "*":
                case "/": Kind = tem_Value; isnum = true; textBox1.Text = "0"; break;
                case "%":
                case "1/X":
                case "+-":
                case "Sqrt": fu(tem_Value); break;
                case ".": dian(); break;
                //计算结果
                case "=": js(tem_Value); break;
                //清除键
                case "C":
                    {
                        Value_1 = "";
                        Value_2 = "";
                        Kind = "";
                        textBox1.Text = "0";
                        break;
                    }
                case "CE": textBox1.Text = "0"; Value_1 = ""; break;
                case "Back": backspace(); break;
            }
        }

        /// <summary>
        /// 记录当前输入的数字键的值
        /// </summary>
        /// <param name="n">键值</param>
        public void num(string n)
        {
            if (isdian)
            {
                if (textBox1.Text == "0")
                    textBox1.Text = "0.";
                else
                    textBox1.Text += ".";
                isdian = false;
            }
            if (textBox1.Text == "0")
                textBox1.Text = "";
            if (isnum)//如果是计算之前的值
            {
                textBox1.Text += n;//累加输入值
                Value_2 = textBox1.Text;//显示在文本框中
            }
            else//计算之后的值
            {
                textBox1.Text += n;//累加输入值
                Value_1 = textBox1.Text;//显示在文本框中
            }
        }
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="n"></param>
        public void js(string n)
        {
            double tem_v = 0;//记录计算后的结果
            if (Value_1.Length <= 0 || Value_2.Length <= 0)//判断是否有计算的两个值
                return;
            if (Kind.Length > 0)//如果可以计算
            {
                switch (Kind)
                {
                    case "+": tem_v = Acc.Addition(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "-": tem_v = Acc.Subtration(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "*": tem_v = Acc.Multiplication(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                    case "/": tem_v = Acc.Division(Convert.ToDouble(Value_1), Convert.ToDouble(Value_2)); break;
                }
            }
            if (tem_v == Math.Ceiling(tem_v))//如果计算结果为整数
            {
                textBox1.Text = Convert.ToInt64(tem_v).ToString();//对结果进行取整
            }
            else
            {
                textBox1.Text = tem_v.ToString();//以双精度进行显示
            }
            Value_1 = textBox1.Text;//显示计算结果
            Value_2 = "";

        }

        /// <summary>
        /// 辅助计算
        /// </summary>
        /// <param name="n"></param>
        public void fu(string n)
        {
            double tem_v = 0;//记录计算结果
            switch (n)
            {
                case "%": tem_v = Acc.Par(Convert.ToDouble(textBox1.Text)); break;
                case "1/X": tem_v = Acc.Molecule(Convert.ToDouble(textBox1.Text)); break;
                case "+-": tem_v = Acc.Opposition(Convert.ToDouble(textBox1.Text)); break;
                case "Sqrt": tem_v = Acc.Evolution(Convert.ToDouble(textBox1.Text)); break;
            }
            if (tem_v == Math.Ceiling(tem_v))//如果计算结果为整数
            {
                textBox1.Text = Convert.ToInt64(tem_v).ToString();//对结果进行取整
            }
            else
            {
                textBox1.Text = tem_v.ToString();//以双精度进行显示
            }
            Value_1 = textBox1.Text;//显示计算结果
            Value_2 = "";
        }

        /// <summary>
        /// 删除输入的值
        /// </summary>
        public void backspace()
        {
            var bstr = textBox1.Text;//记录当前文本框中的值
            if (bstr != "0")//如果值不为零
            {
                string isabs = (Math.Abs(Convert.ToDouble(bstr)).ToString());//获取该值的绝对值
                if ((bstr.Length == 1) || (isabs.Length == 1))//如果当前文本框中只有一个数值
                {
                    textBox1.Text = "0";//将文本框清零
                }
                else { textBox1.Text = bstr.Substring(0, bstr.Length - 1); }//删除指定的值
                Value_1 = textBox1.Text;//显示删除后的结果
            }
        }

        public void dian()
        {
            if (textBox1.Text.IndexOf(".") == -1)
                isdian = true;
            else
                isdian = false;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
