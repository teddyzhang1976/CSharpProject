using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace SetPrintRange
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局对象及变量
        int intPage = 0;//总页数
        int intRows = 30;//每页行数
        int EndRows = 0;//最后一页行数
        int currentpageindex = 1;//当前打印页
        Pen myPen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 9);//字体
        Brush myBrush = new SolidBrush(Color.Black);//画刷
        int PrintPageHeight = 1169;//打印的默认高度
        int PrintPageWidth = 827;//打印的默认宽度
        int topmargin = 60; //顶边距 
        int rowgap = 32;//行高 
        int leftmargin = 50;//左边距 
        int rightmargin = 50;//右边距
        int buttommargin = 80;//底边距 
        int columnWidth1 = 57;//第一列宽度
        int columnWidth2 = 335;//第二列宽度
        int page = 0;//打印指定的页
        ArrayList list = new ArrayList();//记录打印范围
        int m = 0;//定义打印范围的索引值
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(//创建数据库连接对象
@"Data Source=(local)\EXPRESS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter sqlda = new SqlDataAdapter(//创建数据适配器
                @"select 学生姓名,性别,家庭住址 from tb_Student
union
select 学生姓名,convert(varchar,年龄),家庭住址 from tb_Student
union
select 学生姓名,convert(varchar,出生年月),家庭住址 from tb_Student
union
select 学生姓名,所在学院,家庭住址 from tb_Student", sqlcon);
            DataSet myds = new DataSet();//创建数据集
            sqlda.Fill(myds);//填充数据集
            dgv_Message.DataSource = myds.Tables[0];//设置数据源
            EndRows = (dgv_Message.Rows.Count - 2) % intRows;//去掉标题和最后一行的空行
            if (EndRows > 0)
                intPage = Convert.ToInt32(//计算页数
                    (dgv_Message.Rows.Count - 2) / intRows) + 1;
            else
                intPage = Convert.ToInt32(//计算页数
                    (dgv_Message.Rows.Count - 2) / intRows);
            label1.Text = "共有" +//显示页数
                (dgv_Message.Rows.Count - 2) + "条数据  共" + intPage + "页";
        }

        //标识全部打印
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_All.Checked)
                txt_Range.Enabled = false;
        }

        //标识打印指定页
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Range.Checked)
            {
                txt_Range.Enabled = true;
                txt_Range.Focus();
            }
        }

        //打印
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rb_Range.Checked)
                {
                    if (txt_Range.Text == "")
                    {
                        MessageBox.Show("请指定要打印的页码！",//弹出消息对话框
                            "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;//退出事件
                    }
                    else if (txt_Range.Text.IndexOf(",") == -1)
                    {
                        if (txt_Range.Text.IndexOf("-") != -1)
                        {
                            string[] strSubPages = txt_Range.Text.Split('-');//分割字符串
                            int intStart = Convert.ToInt32(strSubPages[0].ToString());//得到开始页码
                            int intEnd = Convert.ToInt32(strSubPages[1].ToString());//得到结束页码
                            for (int j = intStart; j <= intEnd; j++)
                                list.Add(j);//记录页码
                            list.Sort();//排序
                        }
                        else
                        {
                            list.Add(int.Parse(txt_Range.Text));//记录页码
                        }
                    }
                    else
                    {
                        string[] strPages = txt_Range.Text.Split(',');//分割字符串
                        for (int i = 0; i < strPages.Length; i++)
                        {
                            int intStart = Convert.ToInt32(strPages[0].ToString());//得到开始页码
                            int intEnd = Convert.ToInt32(strPages[1].ToString());//得到结束页码
                                for (int j = intStart; j <= intEnd; j++)
                                    list.Add(j);//记录页码
                            list.Sort();//对list集合中的元素排序
                        }
                    }
                }
                printPreviewDialog1.ShowDialog();//弹出打印预览对话框
            }
            catch (Exception ex)//捕获异常
            {
                MessageBox.Show(ex.Message, "提示");//弹出消息对话框
            }
        }

        //对打印文档进行设置
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dgv_Message.Rows.Count > 0)
            {
                PrintPageWidth = e.PageBounds.Width;//获取打印线张的宽度
                PrintPageHeight = e.PageBounds.Height;//获取打印线张的高度

                #region 绘制边框线
                e.Graphics.DrawLine(myPen, leftmargin, topmargin,//绘制边框线
                    PrintPageWidth - leftmargin - rightmargin, topmargin);
                e.Graphics.DrawLine(myPen, leftmargin, topmargin,//绘制边框线
                    leftmargin, PrintPageHeight - topmargin - buttommargin);//绘制边框线
                e.Graphics.DrawLine(myPen, leftmargin, PrintPageHeight -
                    topmargin - buttommargin, PrintPageWidth - leftmargin - //绘制边框线
                    rightmargin, PrintPageHeight - topmargin - buttommargin);
                e.Graphics.DrawLine(myPen, PrintPageWidth - leftmargin - rightmargin,//绘制边框线
                    topmargin, PrintPageWidth - leftmargin - rightmargin,
                    PrintPageHeight - topmargin - buttommargin);
                #endregion

                #region 打印全部
                if (rb_All.Checked)
                {
                    int intPrintRows = currentpageindex * intRows;//每页最后一个记录的索引
                    int j = 0;
                    for (int i = 0 + (intPrintRows - 30); i < intPrintRows; i++)
                    {
                        if (i <= dgv_Message.Rows.Count - 2)
                        {
                            e.Graphics.DrawString(dgv_Message.Rows[i].Cells[0].Value.ToString(),//绘制字符串
                                myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                            e.Graphics.DrawString(dgv_Message.Rows[i].Cells[1].Value.ToString(),//绘制字符串
                                myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                            e.Graphics.DrawString(dgv_Message.Rows[i].Cells[2].Value.ToString(),//绘制字符串
                                myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5, 
                                topmargin + j * rowgap + 5);
                            e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1,//绘制线条
                                PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                            e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin + j * rowgap,//绘制线条
                                leftmargin + columnWidth1, PrintPageHeight - topmargin - buttommargin);
                            e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2,//绘制线条
                                topmargin + j * rowgap, leftmargin + columnWidth1 + columnWidth2,
                                PrintPageHeight - topmargin - buttommargin);
                            e.Graphics.DrawString("共 " + intPage + " 页   第 " +//绘制字符串
                                currentpageindex + " 页", myFont, myBrush, PrintPageWidth - 200,
                                (int)(PrintPageHeight - buttommargin / 2));
                            j++;
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
                }
                #endregion

                else
                {
                    #region 打印指定的一页
                    if (page != 0)
                    {
                        if (page <= intPage)
                        {
                            int intPrintRows = page * intRows;
                            int j = 0;
                            for (int i = 0 + (intPrintRows - 30); i < intPrintRows; i++)
                            {
                                if (i <= dgv_Message.Rows.Count - 2)
                                {
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[0].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[1].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[2].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1,//绘制线条
                                        PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                                    e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin + j * rowgap,//绘制线条
                                        leftmargin + columnWidth1, PrintPageHeight - topmargin - buttommargin);
                                    e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2, topmargin +//绘制线条
                                        j * rowgap, leftmargin + columnWidth1 + columnWidth2, PrintPageHeight - topmargin - buttommargin);
                                    e.Graphics.DrawString("共 " + intPage + " 页   第 " + page + " 页", myFont,//绘制字符串
                                        myBrush, PrintPageWidth - 500, (int)(PrintPageHeight - buttommargin / 2));
                                    j++;
                                }
                            }
                        }
                        page = 0;
                    }
                    #endregion

                    #region 打印指定的多页
                    else
                    {
                        if (m < list.Count)
                        {
                            int startPage = Convert.ToInt32(list[m].ToString());
                            int intPrintRows = startPage * intRows;
                            int j = 0;
                            for (int i = 0 + (intPrintRows - 30); i < intPrintRows; i++)
                            {
                                if (i <= dgv_Message.Rows.Count - 2)
                                {
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[0].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[1].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawString(dgv_Message.Rows[i].Cells[2].Value.ToString(),//绘制字符串
                                        myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5, topmargin + j * rowgap + 5);
                                    e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1,//绘制线条
                                        PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                                    e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin + j * rowgap,//绘制线条
                                        leftmargin + columnWidth1, PrintPageHeight - topmargin - buttommargin);
                                    e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2,//绘制线条
                                        topmargin + j * rowgap, leftmargin + columnWidth1 + columnWidth2,
                                        PrintPageHeight - topmargin - buttommargin);
                                    e.Graphics.DrawString("共 " + intPage + " 页   第 " + startPage + " 页",//绘制字符串
                                        myFont, myBrush, PrintPageWidth - 200, (int)(PrintPageHeight - buttommargin / 2));
                                    j++;
                                }
                            }
                            m++;//下一页的页码
                            if (startPage < Convert.ToInt32(list[list.Count - 1].ToString()))//如果当前页不是最后一页
                            {
                                e.HasMorePages = true;//打印副页
                            }
                            else
                            {
                                e.HasMorePages = false;//不打印副页
                                startPage = Convert.ToInt32(list[0].ToString());//当前打印的页编号设为设置的第一页
                            }
                        }
                    }
                    #endregion
                }
            }
        }
    }
}
