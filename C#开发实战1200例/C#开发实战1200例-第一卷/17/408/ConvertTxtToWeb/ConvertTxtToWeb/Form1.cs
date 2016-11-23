using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConvertTxtToWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strContent = "明日科技有限公司是一家以计算机软件技术为核心的高科技企业，多年来始终致力于行业管理软件开发、数字化出版物制作、计算机网络系统综合应用以及行业电子商务网站开发领域，涉及生产、管理、控制、仓储、物流、营销、服务等行业。公司拥有软件开发和项目实施方面的资深专家和学习型技术团队，多年来积累了丰富的技术文档和学习资料，公司的开发团队不仅是开拓进取的技术实践者，更致力于成为技术的普及和传播者。";
                string strCompany = "吉林省明日科技有限公司";
                string strWeb = "www.mingrisoft.com";
                string strFileName = "公司网页.htm";
                richTextBox1.Clear();
                richTextBox1.AppendText("<HTML>");
                richTextBox1.AppendText("<HEAD>");
                richTextBox1.AppendText("<TITLE>");
                richTextBox1.AppendText(strCompany);
                richTextBox1.AppendText("</TITLE>");
                richTextBox1.AppendText("</HEAD>");
                richTextBox1.AppendText("<BODY BGCOLOR='TAN'>");
                richTextBox1.AppendText("<CENTER>");
                richTextBox1.AppendText("<H2>" + strCompany + "</H2>");
                String strHyper = "<H4><A HREF='" + strWeb + "'>欢迎访问明日科技公司网站：";
                richTextBox1.AppendText(strHyper + strWeb + "</A></H4>");
                richTextBox1.AppendText("</CENTER>");
                richTextBox1.AppendText(strContent);
                richTextBox1.AppendText("</BODY>");
                richTextBox1.AppendText("</HTML>");
                richTextBox1.SaveFile(strFileName, RichTextBoxStreamType.PlainText);
                System.Diagnostics.Process.Start(strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
