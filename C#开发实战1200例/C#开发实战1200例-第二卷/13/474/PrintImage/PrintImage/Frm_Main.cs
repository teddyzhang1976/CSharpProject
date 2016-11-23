using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoPrint
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap("image.jpg");//创建位图对象
                e.Graphics.DrawImage(//绘制图像
                    bitmap, 150, 240, 500, 700);
            }
            catch (Exception ee)//捕获异常
            {
                MessageBox.Show(ee.Message);//弹出消息对话框
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = this.printDocument1;//设置预览文档
                printPreviewDialog1.ShowDialog();//弹出预览文档对话框
                printDocument1.Print();//打印文档
            }
            catch { }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            printPreviewControl1.Document = printDocument1;//设置要预览的文档
        }
    }
}