using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace PrintEmptyCertificate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        Brush myBrush = new SolidBrush(Color.Black);
        Pen mypen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 10);
        #endregion

        //设置打印内容
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int printWidth = e.PageBounds.Width;//得到打印区域宽度
            int printHeight = e.PageBounds.Height;//得到打印区域高度
            e.Graphics.DrawRectangle(mypen, 344, 236, 480, 355);//绘制矩形边框
            e.Graphics.DrawRectangle(mypen, 374, 266, 193, 295);//绘制矩形边框
            e.Graphics.DrawRectangle(mypen, 601, 266, 193, 295);//绘制矩形边框
            //填充左侧内容
            e.Graphics.DrawLine(mypen, 404, 301, 404, 561);//绘制第一列网格线
            e.Graphics.DrawLine(mypen, 476, 301, 476, 396);//绘制第二列网格线
            e.Graphics.DrawLine(mypen, 374, 301, 567, 301);//绘制第一行网格线
            e.Graphics.DrawLine(mypen, 374, 333, 476, 333);//绘制第二行网格线
            e.Graphics.DrawLine(mypen, 374, 366, 476, 366);//绘制第三行网格线
            e.Graphics.DrawLine(mypen, 374, 396, 567, 396);//绘制第四行网格线
            e.Graphics.DrawLine(mypen, 374, 426, 567, 426);//绘制第五行网格线
            e.Graphics.DrawLine(mypen, 374, 460, 567, 460);//绘制第六行网格线
            e.Graphics.DrawLine(mypen, 374, 495, 567, 495);//绘制第七行网格线
            e.Graphics.DrawLine(mypen, 374, 530, 567, 530);//绘制第八行网格线
            e.Graphics.DrawString("吉林**大学", new Font("宋体",//绘制文本内容
                16, FontStyle.Bold), myBrush, 415, 270);
            e.Graphics.DrawString("姓名", myFont, myBrush, 375, 310);//绘制文本内容
            e.Graphics.DrawString("性别", myFont, myBrush, 375, 342);//绘制文本内容
            e.Graphics.DrawString("出生", new Font("宋体", 8), myBrush, 377, 371);//绘制文本内容
            e.Graphics.DrawString("年月", new Font("宋体", 8), myBrush, 377, 384);//绘制文本内容
            e.Graphics.DrawString("籍贯", myFont, myBrush, 375, 405);//绘制文本内容
            e.Graphics.DrawString("学号", myFont, myBrush, 375, 435);//绘制文本内容
            e.Graphics.DrawString("入学", new Font("宋体", 8), myBrush, 377, 465);//绘制文本内容
            e.Graphics.DrawString("日期", new Font("宋体", 8), myBrush, 377, 478);//绘制文本内容
            e.Graphics.DrawString("专业", myFont, myBrush, 375, 504);//绘制文本内容
            e.Graphics.DrawString("发证", new Font("宋体", 8), myBrush, 377, 535);//绘制文本内容
            e.Graphics.DrawString("日期", new Font("宋体", 8), myBrush, 377, 548);//绘制文本内容
            //填充右侧内容
            e.Graphics.DrawLine(mypen, 632, 266, 632, 561);//绘制第一列网格线
            e.Graphics.DrawLine(mypen, 713, 266, 713, 561);//绘制第二列网格线
            e.Graphics.DrawLine(mypen, 601, 306, 794, 306);//绘制第一行网格线
            e.Graphics.DrawLine(mypen, 601, 391, 794, 391);//绘制第二行网格线
            e.Graphics.DrawLine(mypen, 601, 476, 794, 476);//绘制第三行网格线
            e.Graphics.DrawString("年级", myFont, myBrush, 602, 276);//绘制文本内容
            e.Graphics.DrawString("学   期", myFont, myBrush, 646, 276);//绘制文本内容
            e.Graphics.DrawString("注   册", myFont, myBrush, 727, 276);//绘制文本内容
            e.Graphics.DrawString("一", myFont, myBrush, 607, 341);//绘制文本内容
            e.Graphics.DrawString("二", myFont, myBrush, 607, 426);//绘制文本内容
            e.Graphics.DrawString("三", myFont, myBrush, 607, 511);//绘制文本内容
            e.Graphics.DrawLine(mypen, 632, 348, 794, 348);//分割第一学期
            e.Graphics.DrawLine(mypen, 632, 433, 794, 433);//分割第二学期
            e.Graphics.DrawLine(mypen, 632, 518, 794, 518);//分割第三学期
            e.Graphics.DrawString("第一学期", myFont, myBrush, 642, 320);//绘制文本内容
            e.Graphics.DrawString("第二学期", myFont, myBrush, 642, 362);//绘制文本内容
            e.Graphics.DrawString("第三学期", myFont, myBrush, 642, 404);//绘制文本内容
            e.Graphics.DrawString("第四学期", myFont, myBrush, 642, 446);//绘制文本内容
            e.Graphics.DrawString("第五学期", myFont, myBrush, 642, 488);//绘制文本内容
            e.Graphics.DrawString("第六学期", myFont, myBrush, 642, 530);//绘制文本内容
        }

        //打印
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;//设置要预览的文档
            pageSetupDialog1.Document = printDocument1;//设置要进行页面设置的文档
            pageSetupDialog1.PageSettings.Landscape = true;//设置横向打印还是纵向打印
            printPreviewDialog1.ShowDialog();//显示打印预览窗体
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape=true;
            printPreviewControl1.Document = printDocument1;
        }
    }
}
