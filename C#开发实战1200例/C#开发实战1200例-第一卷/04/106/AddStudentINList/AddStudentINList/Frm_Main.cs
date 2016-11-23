using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AddStudentINList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ArrayList P_list_StudentInfo = new ArrayList();//实例化集合对象
            string[] P_str_Students, P_str_Info;//定义两个字符串数组，分别用来记录学生整体信息和分解后的信息
            string P_str_Student = "";//定义一个字符串变量，用来记录所有学生信息
            //向集合中添加学生信息
            P_list_StudentInfo.Add("小王 男 1980-01-01");
            P_list_StudentInfo.Add("小刘 女 1981-01-01");
            P_list_StudentInfo.Add("小赵 男 1990-01-01");
            P_list_StudentInfo.Add("小吕 男 1995-01-01");
            P_list_StudentInfo.Add("小梁 男 2000-01-01");
            foreach (string Pc_str_Student in P_list_StudentInfo)//遍历集合
            {
                P_str_Student += Pc_str_Student + ",";//记录所有学生信息
            }
            P_str_Students = P_str_Student.Split(',');//将学生信息存储在一个字符串数组中
            dgv_Info.Rows.Add(5);//为DataGridView控件添加5行
            for (int i = 0; i < P_str_Students.Length - 1; i++)//遍历存储学生整体信息的数组
            {
                P_str_Info = P_str_Students[i].Split(' ');//将学生整体信息进行分解
                dgv_Info.Rows[i].Cells[0].Value = P_str_Info[0];//显示学生姓名
                dgv_Info.Rows[i].Cells[1].Value = P_str_Info[1];//显示性别
                dgv_Info.Rows[i].Cells[2].Value = P_str_Info[2];//显示出生年月
            }
        }
    }
}
