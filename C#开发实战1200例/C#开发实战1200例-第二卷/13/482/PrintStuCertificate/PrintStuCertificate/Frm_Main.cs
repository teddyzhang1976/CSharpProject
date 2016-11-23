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

namespace PrintStuCertificate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strID = "";
        string strName = "";
        string strSex = "";
        string strBirthday = "   年  月";
        string strNPlace = "";
        string strRXSJ = "    年  月  日";
        string strZY = "";
        string strFZRQ = "    年  月  日";
        Image imgPhoto = null;
        ArrayList lists = new ArrayList();
        int currentPage = 1;
        Brush myBrush = new SolidBrush(Color.Black);
        Pen mypen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 10);
        #endregion

        //窗体加载时显示所有学生信息
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindInfo("","").Tables[0];
        }

        //设置打印内容
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 记录的打印的学生信息
            if (lists.Count > 0)
            {
                DataSet myds = BindInfo("编号",//获得数据集对象
                    dataGridView1.Rows[Convert.ToInt32(lists[currentPage - 1])].
                    Cells[0].Value.ToString());
                strID = dataGridView1.Rows[Convert.ToInt32(//获得学生编号
                    lists[currentPage - 1])].Cells[0].Value.ToString();
                strName = myds.Tables[0].Rows[0][1].ToString();//获得学生姓名
                strSex = myds.Tables[0].Rows[0][2].ToString();//获得学生性别
                DateTime dt = Convert.ToDateTime(//获得系统时间
                    myds.Tables[0].Rows[0][3].ToString());
                strBirthday = dt.Year + "年" + dt.Month + "月";//获得生日信息
                strNPlace = myds.Tables[0].Rows[0][4].ToString();//获得籍贯信息
                strRXSJ = Convert.ToDateTime(myds.Tables[0].//获得入学时间
                    Rows[0][5].ToString()).ToLongDateString();
                strZY = myds.Tables[0].Rows[0][6].ToString();//获得专业信息
                strFZRQ = DateTime.Now.ToLongDateString();//获得当前系统时间
                MemoryStream memoryImage =//创建内存流对象
                    new MemoryStream((byte[])myds.Tables[0].Rows[0][7]);
                imgPhoto = Image.FromStream(memoryImage);//获得图像对象
            }
            #endregion
            int printWidth = e.PageBounds.Width;//获取打印区域宽度
            int printHeight = e.PageBounds.Height;//获取打印区域高度
            //绘制矩形边框
            e.Graphics.DrawRectangle(mypen, 344, 236, 480, 355);
            e.Graphics.DrawRectangle(mypen, 374, 266, 193, 295);
            e.Graphics.DrawRectangle(mypen, 601, 266, 193, 295);
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
            e.Graphics.DrawString("吉林**大学", new Font("宋体", 16,//绘制文本内容
                FontStyle.Bold), myBrush, 415, 270);
            e.Graphics.DrawString("姓名", myFont, myBrush, 375, 310);//绘制文本内容
            e.Graphics.DrawString(strName, myFont, myBrush, 405, 310);//绘制文本内容
            e.Graphics.DrawString("性别", myFont, myBrush, 375, 342);//绘制文本内容
            e.Graphics.DrawString(strSex, myFont, myBrush, 405, 342);//绘制文本内容
            e.Graphics.DrawString("出生", new Font("宋体", 8), myBrush, 377, 371);//绘制文本内容
            e.Graphics.DrawString("年月", new Font("宋体", 8), myBrush, 377, 384);//绘制文本内容
            e.Graphics.DrawString(strBirthday, myFont, myBrush, 405, 375);//绘制文本内容
            e.Graphics.DrawString("籍贯", myFont, myBrush, 375, 405);//绘制文本内容
            e.Graphics.DrawString(strNPlace, myFont, myBrush, 405, 405);//绘制文本内容
            e.Graphics.DrawString("学号", myFont, myBrush, 375, 435);//绘制文本内容
            e.Graphics.DrawString(strID, myFont, myBrush, 405, 435);//绘制文本内容
            e.Graphics.DrawString("入学", new Font("宋体", 8), myBrush, 377, 465);//绘制文本内容
            e.Graphics.DrawString("日期", new Font("宋体", 8), myBrush, 377, 478);//绘制文本内容
            e.Graphics.DrawString(strRXSJ, myFont, myBrush, 405, 469);//绘制文本内容
            e.Graphics.DrawString("专业", myFont, myBrush, 375, 504);//绘制文本内容
            e.Graphics.DrawString(strZY, myFont, myBrush, 405, 504);//绘制文本内容
            e.Graphics.DrawString("发证", new Font("宋体", 8), myBrush, 377, 535);//绘制文本内容
            e.Graphics.DrawString("日期", new Font("宋体", 8), myBrush, 377, 548);//绘制文本内容
            e.Graphics.DrawString(strFZRQ, myFont, myBrush, 405, 539);//绘制文本内容
            if (imgPhoto != null)
                e.Graphics.DrawImage(imgPhoto, 479, 303, 86, 93);//绘制照片
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
            currentPage++;//下一页的页码
            if (currentPage <= lists.Count)//如果当前页不是最后一页
            {
                e.HasMorePages = true;//打印副页
            }
            else
            {
                e.HasMorePages = false;//不打印副页
                currentPage = 1;//当前打印的页编号设为1
            }
        }

        //打印
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                    lists.Add(row.Index);
            }
            lists.Sort();
            pageSetupDialog1.PageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        #region 获取学生信息
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="str">查找条件</param>
        /// <param name="strKeyWord">查找关键字</param>
        /// <returns>DataSet数据集</returns>
        private DataSet BindInfo(string str,string strKeyWord)
        {
            string strCon = @"Data Source=LVSHUANG\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
            SqlConnection sqlcon = new SqlConnection(strCon);
            string strSql = "";
            if (str == "编号")
                strSql = @"select ID as 学生编号,Name as 姓名,Sex as 性别,
Birthday as 出生年月,NPlace as 籍贯,RXSJ as 入学时间,ZHUANYE as 专业,
Photo as 员工照片 from tb_StudentInfo where ID='" + strKeyWord + "'";
            else
                strSql = @"select ID as 学生编号,Name as 姓名,Sex as 性别,
Birthday as 出生年月,NPlace as 籍贯,RXSJ as 入学时间,ZHUANYE as 专业,
Photo as 员工照片 from tb_StudentInfo";
            SqlDataAdapter sqlda = new SqlDataAdapter(strSql, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            return myds;
        }
        #endregion
    }
}
