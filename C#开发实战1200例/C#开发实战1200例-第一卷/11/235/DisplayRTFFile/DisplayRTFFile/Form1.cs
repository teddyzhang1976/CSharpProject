using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DisplayRTFFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string fileName = ""; //该变量用来保存文件的内容
        private OpenFileDialog G_OpenFileDialog = //定义打开文件对话框字段并赋值
            new OpenFileDialog();
        private SaveFileDialog G_SaveFileDialog = //定义保存文件对话框字段并赋值
            new SaveFileDialog();

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//停用保存功能
                DropDownItems["保存ToolStripMenuItem"].Enabled = false;
            G_OpenFileDialog.Filter = "RTF文件(*.RTF)|*.RTF";//设置打开文件的过滤参数
            if (G_OpenFileDialog.ShowDialog() == DialogResult.OK && G_OpenFileDialog.FileName.Length > 0)//当打开的文件内容不为空且点击“打开”按钮时
            {
                fileName = G_OpenFileDialog.FileName;//保存打开文件的文件名
                this.richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);//从指定位置加载RTF文件
            }
        }

        private void 清空ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();//清空RichTextBox控件中的内容
            richTextBox1.Focus();//时RichTextBox控件获得焦点
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileName))//如果存在该文件
            {
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichNoOleObjs);//在指定路径下保存
                MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//弹出保存成功的提示信息
                richTextBox1.Clear();//清空RichTextBox控件中的内容
            }
            else//当不存在该文件时
            {
                G_SaveFileDialog.Filter = "RTF文件(*.RTF)|*.RTF";//设置保存文件的保存格式
                if (G_SaveFileDialog.ShowDialog() == DialogResult.OK && G_SaveFileDialog.FileName.Length > 0)//当保存文件的文件名存在且点击的是“保存”按钮时
                {
                    richTextBox1.SaveFile(G_SaveFileDialog.FileName + ".RTF");//在指定位置下保存RTF文件
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出应用程序
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")//当RichTextBox控件中存在内容时
            {
                ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//启用保存功能
                    DropDownItems["保存ToolStripMenuItem"].Enabled = true;
            }
            else//当RichTextBox控件中不存在内容时
            {
                ((ToolStripMenuItem)Menu_Main.Items["文件ToolStripMenuItem"]).//停用保存功能
                    DropDownItems["保存ToolStripMenuItem"].Enabled = false;
            }
        }
    }
}
