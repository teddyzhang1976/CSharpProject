using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FunctionQuery
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//创建数据上下文类的实例
            var query = from emp in dc.EmployeeInfo
                        select new
                        {
                            emp.Addr,
                            emp.Birthday,
                            emp.EMail,
                            emp.EmployeeCode,
                            emp.Handset,
                            emp.HelpCode,
                            emp.ID,
                            emp.IDCard,
                            emp.Name,
                            emp.OperateDate,
                            emp.Operator,
                            emp.Tel,
                            Sex = dc.F_GetSex(emp.Sex)//调用SQL Server中的函数显示中文的性别信息
                        };
            dataGridView1.DataSource = query.Take(5);//将查询结果集绑定到dataGridView1
        }
    }
}
