using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.MatchCollection matches =//使用正则表达式查找重复出现单词的集合
                System.Text.RegularExpressions.Regex.Matches(label1.Text,
                @"\b(?<word>\w+)\s+(\k<word>)\b", System.Text.
                RegularExpressions.RegexOptions.Compiled | System.Text.
                RegularExpressions.RegexOptions.IgnoreCase);
            if (matches.Count != 0)//如果集合中有内容
            {
                foreach (System.Text.RegularExpressions.Match//遍历集合
                    match in matches)
                {
                    string word = match.Groups["word"].Value;//获取重复出现的单词
                    MessageBox.Show(word.ToString(), "英文单词");//弹出消息对话框
                }
            }
            else { MessageBox.Show("没有重复的单词"); }//弹出消息对话框
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =//创建字符串对象
                "The the quick brown fox  fox jumped over the lazy dog dog.";
        }
    }
}