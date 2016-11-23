using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace DynamicBindCrystalReport
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //显示所有学生信息
        private void Form1_Load(object sender, EventArgs e)
        {
            string P_str_sql =//创建公式字符串
                " {tb_StudentInfo.ID} like '*'";
            crystalReportViewer1.ReportSource =//将报表绑定到CrystalReportViewer控件
                CrystalReports("CrystalReport1.rpt", P_str_sql);
        }

        //按学生编号查询学生信息
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                string P_str_sql =//组合公式字符串
                    " {tb_StudentInfo.ID} like '" + toolStripTextBox1.Text.Trim() + "'";
                crystalReportViewer1.ReportSource =//将报表绑定到CrystalReportViewer控件
                    CrystalReports("CrystalReport1.rpt", P_str_sql);
            }
            else
                Form1_Load(sender, e);
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);//按回车键查询学生信息
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出应用程序
        }

        #region  绑定水晶报表
        /// <summary>
        /// 绑定水晶报表
        /// </summary>
        /// <param name="P_str_creportName">报表名称</param>
        /// <param name="P_str_sql">SQL语句</param>
        /// <returns>返回ReportDocument对象</returns>
        public ReportDocument CrystalReports(string P_str_creportName, string P_str_sql)
        {
            ReportDocument reportDocument = new ReportDocument();//创建ReportDocument对象
            string P_str_creportPath = Application.StartupPath.Substring(//得到报表路径信息
                0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            P_str_creportPath += "\\" + P_str_creportName;//添加报表名称
            reportDocument.Load(P_str_creportPath);//加载报表
            reportDocument.DataDefinition.RecordSelectionFormula = P_str_sql;//设置公式
            return reportDocument;//方法返回ReportDocument对象
        }
        #endregion
    }
}