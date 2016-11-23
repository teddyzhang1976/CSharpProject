using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagesPrint
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局对象及变量
        int intPage = 0;//总页数
        int intRows = 0;//每页行数
        int EndRows = 0;//最后一页行数
        int currentpageindex = 1;//当前打印页
        Pen myPen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 9);//字体
        Brush myBrush = new SolidBrush(Color.Black);//画刷
        int PrintPageHeight = 1169;//打印的默认高度
        int PrintPageWidth = 827;//打印的默认宽度
        int topmargin = 60; //顶边距 
        int rowgap = 0;//行高 
        int leftmargin = 50;//左边距 
        int rightmargin = 50;//右边距
        int buttommargin = 80;//底边距 
        int columnWidth1 = 57;//第一列宽度
        int columnWidth2 = 335;//第二列宽度
        #endregion

        //初始化数据
        private void Form1_Load(object sender, EventArgs e)
        {
            intRows = Convert.ToInt32(textBox1.Text);
            SqlConnection sqlcon = new SqlConnection(
@"Data Source=(local)\EXPRESS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter sqlda = new SqlDataAdapter("select 学生姓名,所学专业,家庭住址 from tb_Student", sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            dataGridView1.DataSource = myds.Tables[0];
            //设置每列的宽度
            dataGridView1.Columns[0].Width = 57;
            dataGridView1.Columns[1].Width = 260;
            dataGridView1.Columns[2].Width = 280;
            EndRows = (dataGridView1.Rows.Count - 2) % intRows;//去掉标题和最后一行的空行
            if (EndRows > 0)
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows) + 1;
            else
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows);
            label2.Text = "总页数：" + intPage + "页";
        }

        //设置分页
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyChar == 13)
                {
                    intRows = Convert.ToInt32(textBox1.Text);
                    EndRows = (dataGridView1.Rows.Count - 2) % intRows;//去掉标题和最后一行的空行
                    if (EndRows > 0)
                        intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows) + 1;
                    else
                        intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows);
                    label2.Text = "总页数：" + intPage + "页";
                }
            }
        }

        //打印
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        //退出当前应用程序
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //设置打印内容
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                PrintPageWidth = e.PageBounds.Width;//获取打印线张的宽度
                PrintPageHeight = e.PageBounds.Height;//获取打印线张的高度
                e.Graphics.DrawLine(myPen, leftmargin, topmargin,//绘制边框线
                    PrintPageWidth - leftmargin - rightmargin, topmargin);
                e.Graphics.DrawLine(myPen, leftmargin, topmargin,//绘制边框线
                    leftmargin, PrintPageHeight - topmargin - buttommargin);
                e.Graphics.DrawLine(myPen, leftmargin, PrintPageHeight//绘制边框线
                    - topmargin - buttommargin, PrintPageWidth - leftmargin 
                    - rightmargin, PrintPageHeight - topmargin - buttommargin);
                e.Graphics.DrawLine(myPen, PrintPageWidth - leftmargin//绘制边框线
                    - rightmargin, topmargin, PrintPageWidth - leftmargin
                    - rightmargin, PrintPageHeight - topmargin - buttommargin);
                #region 打印
                int intPrintRows = currentpageindex * intRows;//当前页最后一条记录的索引
                rowgap = Convert.ToInt32((PrintPageHeight - topmargin//计算行高度
                    - buttommargin - 5 * intRows) / intRows)+3;
                int j = 0;//记录正在打印的行数
                for (int i = 0 + (intPrintRows - intRows); i < intPrintRows; i++)
                {
                    if (i <= dataGridView1.Rows.Count - 2)
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(),//绘制字符串信息
                            myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(),//绘制字符串信息
                            myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(),//绘制字符串信息
                            myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5,
                            topmargin + j * rowgap + 5);
                        e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1,//绘制线条
                            PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                        e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin +//绘制线条
                            j * rowgap, leftmargin + columnWidth1, PrintPageHeight -
                            topmargin - buttommargin);
                        e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2,//绘制线条
                            topmargin + j * rowgap, leftmargin + columnWidth1 + columnWidth2,
                            PrintPageHeight - topmargin - buttommargin);
                        e.Graphics.DrawString("共 " + intPage + " 页   第 " + currentpageindex//绘制页码
                            + " 页", myFont, myBrush, PrintPageWidth - 200, (int)(PrintPageHeight
                            - buttommargin / 2));
                        j++;//记数器
                    }
                }
                currentpageindex++;//下一页的页码
                if (currentpageindex <= intPage)//如果当前页不是最后一页
                {
                    e.HasMorePages = true;//打印副页
                }
                else
                {
                    e.HasMorePages = false;//不打印副页
                    currentpageindex = 1;//当前打印的页编号设为1
                }
                #endregion
            }
        }
    }
}
