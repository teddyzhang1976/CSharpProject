using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 声明一个接口，用于定义Seak方法，而具体Speak方法功能的实现是在类中进行的
        /// </summary>
        interface ISelectLanguage
        {
            void Speak(string str);
        }

        /// <summary>
        /// 如果跟中国人对话，则说汉语
        /// </summary>
        class C_SpeakChinese : ISelectLanguage
        {
            public void Speak(string str)
            {
                MessageBox.Show("您对中国友人说：" + str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 如果跟美国人对话，则说英语
        /// </summary>
        class C_SpeakEnglish : ISelectLanguage
        {
            public void Speak(string str)
            {
                MessageBox.Show("您对美国友人说：" +str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public bool CheckChinese(string str)
        {
            bool flag = false;
            UnicodeEncoding a = new UnicodeEncoding();
            byte[] b = a.GetBytes(str);
            for(int i=0;i<b.Length;i++)
            {
                i++;
                if (b[i] != 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == "")
            {
                MessageBox.Show("不想跟友人说点什么吗？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)//与中国人对话
                {
                    if (CheckChinese(txtContent.Text))
                    {
                        ISelectLanguage Interface1 = new C_SpeakChinese();
                        Interface1.Speak(txtContent.Text);
                        
                    }
                    else
                    {
                        MessageBox.Show("请和中国友人说汉语？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else//与美国人对话
                {
                    if (CheckChinese(txtContent.Text))
                    {
                        MessageBox.Show("请和美国友人说英语？", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ISelectLanguage Interface1 = new C_SpeakEnglish();
                        Interface1.Speak(txtContent.Text);
                    }
                }
            }
        }
    }
}
