using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private OpenFileDialog G_OpenFileDialog = //声明打开文件对话框字段并赋值
            new OpenFileDialog();
        private SaveFileDialog G_SaveFileDialog = //声明保存文件对话框字段并赋值
            new SaveFileDialog();

        private void btn_Open_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void 打开RTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog.Filter = "text.rtf|*.rtf*";//筛选文件信息
            if (this.G_OpenFileDialog.ShowDialog() == DialogResult.OK)//判断是否打开文件
            {
                rtbox_Display.LoadFile(//载入rtf文件
                    G_OpenFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void 保存成TXT文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbox_Display.Text != "")//判断控件中是否有文本内容
            {
                G_SaveFileDialog.DefaultExt = "*.txt";//设置文件默认扩展名
                G_SaveFileDialog.Filter = "Txt Files|*.txt";//筛选文件信息
                if (this.G_SaveFileDialog.ShowDialog() == DialogResult.OK)//判断是否确认保存文件
                {
                    rtbox_Display.SaveFile(//保存文件
                        this.G_SaveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("保存成功", "信息提示",//弹出消息对话框
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请打开文件", "信息提示", //弹出消息对话框
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
