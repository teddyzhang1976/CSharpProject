using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemLock
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Point mouseOffset;//鼠标位置
        private bool isMouseDown = false;//表示鼠标是否按下
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();//窗体的关闭按钮
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Trim() == "" || txtPwd2.Text.Trim() == "")//判断是否输入密码
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (txtPwd2.Text.Trim() == txtPwd.Text.Trim())//如果两次密码输入一致
                {
                    Frm_Browser frm2 = new Frm_Browser();//实例化Frm_Browser窗体
                    frm2.s = this.Size;//传递窗体大小
                    frm2.x = this.Location.X;//传递窗体的X坐标
                    frm2.y = this.Location.Y;//传递窗体的Y坐标
                    frm2.infos = txtInfo.Text.Trim();//传递挂机信息
                    frm2.pwd = txtPwd2.Text.Trim();//传递解锁密码
                    this.Hide();//隐藏当前窗体
                    frm2.ShowDialog();//打开Frm_Browser窗体
                }
                else
                {
                    MessageBox.Show("两次密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
