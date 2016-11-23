using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemLock
{
    public partial class Frm_UnLock : Form
    {
        public Frm_UnLock()
        {
            InitializeComponent();
        }
        public int x;//鼠标活动区域的X坐标
        public int y;//鼠标活动区域的Y坐标
        public string infos;//挂机界面显示的信息
        public string pwd;//解锁密码
        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;//设置停靠在最前端
            this.Location = new Point(x, y);//设置窗体位置
            lblinfo.Text = infos;//显示挂机信息
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Trim() == pwd)//判断输入的密码是否正确
            {
                Application.Exit();//如果正确则退出挂机界面
            }
            else//否则
            {
                lblinfo.Text = "输入解锁密码错误，请重新输入！";//提示错误信息
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TopMost = false;//取消停靠最前的设置
            this.Close();//关闭窗体
        }
    }
}
