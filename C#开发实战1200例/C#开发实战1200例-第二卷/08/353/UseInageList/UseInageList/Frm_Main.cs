using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace UseImageList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();//创建数据表对象

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr;//创建数据行变量
            dr = dt.NewRow();//得到数据行对象
            dr["userName"] = this.txt_UserName.Text;//设置内容
            dt.Rows.Add(dr);//添回数据行
            Method(dt);//显示数据表中内容
        }

        /// <summary>
        /// 显示数据表中内容
        /// </summary>
        /// <param name="dt">数据表对象</param>
        private void Method(DataTable dt)
        {
            lv_Person.Items.Clear();//清空控件中所有数据项
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (j % 2 == 0)
                {
                    lv_Person.Items.Add(//添加数据项和图像
                        dt.Rows[j][0].ToString(), 0);
                }
                else
                {
                    lv_Person.Items.Add(//添加数据项和图像
                        dt.Rows[j][0].ToString(), 1);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lv_Person.View = View.LargeIcon;//设置显示方式
            lv_Person.LargeImageList = imageList1;//设置ImageList属性
            DataColumn column = new DataColumn();//创建数据列对象
            column.DataType =//设置数据类型
                System.Type.GetType("System.String");
            column.ColumnName = "userName";//设置列名称
            dt.Columns.Add(column);//添加数据列
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }
    }
}