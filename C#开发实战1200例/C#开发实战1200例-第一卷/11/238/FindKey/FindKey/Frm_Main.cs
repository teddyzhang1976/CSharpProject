using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//需引用命名空间Using System.IO

namespace FindKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void KeyWordsPlotRed_Load(object sender,EventArgs e)
        {
            richTextBox1.ReadOnly = true;//设置文本为只读格式
            string filePath = "test.txt";//设置打开文件的路径
            if(File.Exists(filePath)) //当存在该文件时
            {
                FetchFile(filePath);//在RichTextBox控件中显示指定路径下的文件
            }
            plotRed.Enabled = false;//设置“描红”按钮为不可用状态
            keyWord.Focus();//使焦点位于文本框中
        }
        private void FetchFile(string path)
        {
            StreamReader UTF_8Reader = new StreamReader(path,Encoding.Default);//实现一个 TextReader，使其以一种特定的编码从字节流中读取字符。
            richTextBox1.Text = UTF_8Reader.ReadToEnd();//在RichTextBox控件中显示从字节流中读取的字符
        }

        private void unfold_Click(object sender,EventArgs e)
        {
            OpenFileDialog UTF_8File = new OpenFileDialog();//表示一个通用对话框，用户可以使用此对话框来指定一个或多个要打开的文件的文件名。
            UTF_8File.Filter = "TXT文件（*.TXT）|*.TXT";//设置打开对话框的打开过滤参数
            if(UTF_8File.ShowDialog() == DialogResult.OK)//当在打开对话框中点击“打开”按钮时
            {
                richTextBox1.LoadFile(UTF_8File.FileName,RichTextBoxStreamType.PlainText);//从指定的位置加载TxT文件
                MessageBox.Show("读取成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出读取成共的信息提示
                unfold.Enabled = false;//设置“打开”按钮为不可用状态
            }
        }

        private int flag = 0;//定义一个int型的标识符
        private void plotRed_Click(object sender,EventArgs e)
        {
            if((flag = richTextBox1.Text.IndexOf(keyWord.Text,flag)) == -1)//当文件中不存在要搜索的关键字时
            {
                MessageBox.Show("没有要查找的结果","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出对应的信息提示
                keyWord.Clear();//清空文本框中的内容
                flag = 0;//重新为flag赋值
            }
            else//当在文件中存在对应的关键字时
            {
                richTextBox1.Select(flag,keyWord.Text.Length);//在RichTextBox控件中搜索关键字
                flag = flag + keyWord.Text.Length;//递增标识查询关键字的初始长度
                richTextBox1.SelectionColor = Color.Red;//设定关键字为红色
            }
        }

        private void keyWord_TextChanged(object sender,EventArgs e)
        {
            if(keyWord.Text == "" || keyWord.Text == null)//当文本框中不存在内容或者内容为空时
            {
                plotRed.Enabled = false;//设定“描红”按钮为不可用状态
            }
            else//当文本框中存在内容时
            {
                plotRed.Enabled = true;//设定“描红”按钮为可用状态
            }
        }   
    }
}
