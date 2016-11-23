using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                lb_Name.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 0, 0);
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                txt_Name.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 60, 0);
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                lb_Department.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 0, 20);
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                txt_Department.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 60, 20);
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                lb_Job.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 0, 40);
            e.Graphics.DrawString(//使用DrawString方法绘制字符串
                txt_Job.Text, new Font("宋体", 10, FontStyle.Regular), Brushes.Black, 60, 40);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();//弹出打印选项对话框
            printPreviewDialog1.Document = this.printDocument1;//设置要预览的文档
            printPreviewDialog1.ShowDialog();//弹出打印预览对话框
        }
    }
}