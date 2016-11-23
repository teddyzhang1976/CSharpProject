using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CreatePDFDocument
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //该变量保存PDF的文档名
        public static string filePath = "";

        //创建PDF文档
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); 				//给出文件保存信息，确定保存位置
            saveFileDialog.Filter = "PDF文件（*.PDF）|*.PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                //开始创建PDF文档，首先声明一个Document对象
                Document document = new Document();
                //使用指定的路径和创建模式初始化文件流对象
                PdfWriter.getInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();										//打开文档
                BaseFont baseFont = BaseFont.createFont(@"c:\windows\fonts\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20); 	//设置文档字体样式
                document.Add(new Paragraph(richTextBox1.Text, font)); 			//添加内容至PDF文档中
                document.Close();										//关闭文档
                MessageBox.Show("祝贺你，文档创建成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
