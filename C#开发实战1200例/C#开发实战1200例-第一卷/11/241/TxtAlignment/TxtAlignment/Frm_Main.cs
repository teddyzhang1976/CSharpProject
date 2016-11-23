using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//需引用命名空间Using System.IO

namespace TxtAlignment
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string temp = "tomorrow.RTF";//保存文件的路径
        private void TxtAlignment_Load(object sender,EventArgs e)
        {
            if(File.Exists(temp))//当在指定路径下存在该文件时
            {
                this.richTextBox1.LoadFile(temp,RichTextBoxStreamType.RichText);//从指定的位置加载RTF文件
                unfold.Enabled = false;//设定“打开”按钮为不可用状态
            }
            hold.Enabled = false;//设定“保存”按钮为不可用状态
        }

        private void unfold_Click(object sender,EventArgs e)
        {
            OpenFileDialog TxTOpenDialog = new OpenFileDialog();//声明一个用于打开文件对话框的对象
            TxTOpenDialog.Filter = "RTF文件(*.RTF)|*.RTF";//定义打开文件对话框的过滤参数
            if(TxTOpenDialog.ShowDialog() == DialogResult.OK)//当在打开对话框中单击“打开”按钮时
            {
                temp = TxTOpenDialog.FileName;//保存打开文件的路径
                this.richTextBox1.LoadFile(TxTOpenDialog.FileName,RichTextBoxStreamType.RichText);//从指定的位置加载RTF文件
                hold.Enabled = false;//设置“保存”按钮为不可用状态
                unfold.Enabled = false; //设置“打开”按钮为不可用状态
                MessageBox.Show("读取成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出读取成功时的提示信息
            }
        }

        private void hold_Click(object sender,EventArgs e)
        {
            ConserveMeasure(temp);//在指定路径下保存文件
        }

        private void richTextBox1_TextChanged(object sender,EventArgs e)
        {
            hold.Enabled = true;//
            if(this.richTextBox1.Text == "" || this.richTextBox1.Text == null)//
            {
                unfold.Enabled = true;//
            }
        }

        private void ConserveMeasure(string path)
        {
            SaveFileDialog TxTSaveDialog = new SaveFileDialog();//定义一个用于保存文件的保存对话框
            TxTSaveDialog.Filter = "RTF文件（*.RTF)|*.RTF";//设置保存文件的过滤参数
            if(File.Exists(path))//当在指定路径下存在该路径时
            {
                this.richTextBox1.SaveFile(path,RichTextBoxStreamType.RichText);//保存指定文件到指定位置
                MessageBox.Show("保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出保存成功的提示信息
                this.richTextBox1.Clear();//清空RichTextBox控件中的所有内容
                hold.Enabled = false;//设置“保存”按钮为不可用状态
            }
            else
            {
                if(TxTSaveDialog.ShowDialog() == DialogResult.OK)//当在保存对话框中单击“保存”按钮时
                {
                    this.richTextBox1.SaveFile(TxTSaveDialog.FileName,RichTextBoxStreamType.RichText);//保存文件到指定的位置
                    MessageBox.Show("保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出保存成功的提示信息
                    this.richTextBox1.Clear();//清空RichTextBox控件中的所有内容
                    hold.Enabled = false;//设定“保存”按钮为不可用状态
                }
            }
        }

        private void justifyCenter_Click(object sender,EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;//设置选定的文本为居中对齐
        }

        private void justifyLeft_Click(object sender,EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;//设置选定的文本为左对齐
        }

        private void justifyRight_Click(object sender,EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;//设置选定的文本为右对齐
        }
    }
}
