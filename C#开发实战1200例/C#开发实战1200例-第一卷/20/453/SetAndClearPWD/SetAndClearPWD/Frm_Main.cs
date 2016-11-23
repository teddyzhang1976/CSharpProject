using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace SetAndClearPWD
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openFileDialog1.Title = "选择Excel文件";//设置打开对话框标题
            openFileDialog1.Multiselect = false;//设置打开对话框中只能单选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Path.Text=openFileDialog1.FileName;//在文本框中显示Excel文件内容
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            object missing = Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook=excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //记录用户输入的密码
            string P_str_password = excel.Application.InputBox("输入密码：",missing, missing, missing, missing, missing, missing, missing).ToString();
            //记录用户输入的确认密码
            string P_str_confirmPassword = excel.Application.InputBox("确认密码：", missing, missing, missing, missing, missing, missing, missing).ToString();
            if (P_str_password != P_str_confirmPassword)//判断密码与确认密码是否一致
            {
                MessageBox.Show("输入的密码不一致！");
            }
            else 
            {
                workbook.Password = P_str_password;//设置Excel密码
                MessageBox.Show("密码设置成功！");
            }
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            object missing = Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            workbook.Password = "";//设置Excel密码为空
            MessageBox.Show("密码清除成功！");
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
        }
    }
}
