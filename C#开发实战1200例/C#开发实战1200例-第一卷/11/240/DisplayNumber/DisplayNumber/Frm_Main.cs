using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//引用与输入输出流有关的命名空间

namespace DisplayNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private static string temp = "tomorrow.RTF";//用来保存RTF文件的路径
        private RichTextBoxEx richTextBox1 = new RichTextBoxEx();//声明一个自定义类的实例
        private void DisplayNumber_Load(object sender,EventArgs e)
        {
            this.richTextBox1.Parent = this.groupBox1;//设置自定义类的父容器
            this.groupBox1.Controls.Add(this.richTextBox1);//向指定的父容器中添加控件
            if(File.Exists(temp))//当存在该RTF文件时
            {
                this.richTextBox1.LoadFile(temp,RichTextBoxStreamType.RichText);//将该文件显示在RichTextBox控件中
            }
            richTextBox1.SelectionBullet = true;//设置RichTextBox控件标识项目符号的值为true
        }

        private void programNumeration_Click(object sender,EventArgs e)
        {
            if(richTextBox1.SelectionBullet)//当RichTextBox控件标识项目符号的值为true时
            {
                richTextBox1.SelectionBullet = false;//设置RichTextBox控件标识项目符号的值为false
            }
            else //当RichTextBox控件标识项目符号的值为false时
            {
                richTextBox1.SelectionBullet = true;//设置RichTextBox控件标识项目符号的值为true
            }
        }

        private void unfold_Click(object sender,EventArgs e)
        {
            OpenFileDialog TxTOpenDialog = new OpenFileDialog();//声明一个打开文件对话框的对象
            TxTOpenDialog.Filter = "RTF文件(*.RTF)|*.RTF";//设置打开文件的格式
            if(TxTOpenDialog.ShowDialog() == DialogResult.OK)//当单击“打开”按钮时
            {
                temp = TxTOpenDialog.FileName;//保存打开文件的路径
                this.richTextBox1.LoadFile(TxTOpenDialog.FileName,RichTextBoxStreamType.RichText);//在RichTextBox控件中打开文件
                MessageBox.Show("读取成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出读取成功的信息提示
            }
        }

        private void hold_Click(object sender,EventArgs e)
        {
            SaveFileDialog TxTSaveDialog = new SaveFileDialog();//声明一个保存文件对话框对象
            TxTSaveDialog.Filter = "RTF文件（*.RTF)|*.RTF";//设置保存文件的格式
            if(File.Exists(temp))//当在指定路径下存在该文件时
            {
                this.richTextBox1.SaveFile(temp,RichTextBoxStreamType.RichText);//在指定路径下保存该文件
                MessageBox.Show("保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出保存成功的信息提示
                this.richTextBox1.Clear();//清空RichTextBox控件中的原有内容
            }
            else//当在指定路径下不存在该文件时
            {
                if(TxTSaveDialog.ShowDialog() == DialogResult.OK)//当单击“保存”按钮时
                {
                    this.richTextBox1.SaveFile(TxTSaveDialog.FileName,RichTextBoxStreamType.RichText);//以指定的格式保存该文件
                    MessageBox.Show("保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出保存成功的信息提示
                    this.richTextBox1.Clear();//清空RichTextBox控件中的原有内容
                }
            }
        }

        private void figuresNumeration_Click(object sender,EventArgs e)
        {
            richTextBox1.BulletType = RichTextBoxEx.AdvRichTextBulletType.Number;//设置文件的项目编号属性
        }
    }
}
