using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SetMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        public extern static int SwapMouseButton(int bSwap);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int pvParam, uint fWinIni);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int GetSystemMetrics(int nIndes);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        public extern static int SetDoubleClickTime(int wCount);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public extern static int GetDoubleClickTime();

        const int SM_SWAPBUTTON = 23;//如左右鼠标键已经交换，则为TRUE
        const int SPI_SETMOUSE = 4;//设置鼠标的移动速度
        const int SPI_GETMOUSESPEED = 112;//检索当前鼠标速度
        const uint SPIF_UPDATEINIFILE = 0x0001;//更新win.ini和（或）注册表中的用户配置文件
        const uint SPIF_SENDWININICHANGE = 0x0002;//该消息告诉应用程序已经改变了用户配置设置
        int aMouseinfo=0;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GetSystemMetrics(SM_SWAPBUTTON) == 0)//如果鼠标的左右键没有切换
            {
                pictureBox1.Image = null;//清空图片
                pictureBox1.Image = Properties.Resources.鼠标左键;//显示图片
                checkBox1.Checked = false;//设置复选框为不选中状态
            }
            else//如果鼠标左右切换
            {
                pictureBox1.Image = null;//清空图片
                pictureBox1.Image = Properties.Resources.鼠标右键;//显示图片
                checkBox1.Checked = true;//设置复选框为选中状态
            }
            int tem_n = 0;
            switch (Convert.ToInt32(DoubleClickTime_Get()))//获取鼠标的双击速度
            {
                case 900: tem_n = 0; break;
                case 830: tem_n = 1; break;
                case 760: tem_n = 2; break;
                case 690: tem_n = 3; break;
                case 620: tem_n = 4; break;
                case 550: tem_n = 5; break;
                case 480: tem_n = 6; break;
                case 410: tem_n = 7; break;
                case 340: tem_n = 8; break;
                case 270: tem_n = 9; break;
                case 200: tem_n = 10; break;
            }
            trackBar1.Value = tem_n;//显示鼠标的双击速度
            SystemParametersInfo(SPI_GETMOUSESPEED, 0, ref aMouseinfo, 0);//获取当前鼠标的移动速度
            trackBar2.Value = aMouseinfo;//显示当前鼠标的移动速度
        }

        public string DoubleClickTime_Get()
        {
            return GetDoubleClickTime().ToString();//获取鼠标的双击速度
        }

        public void DoubleClickTime_Set(int MouseDoubleClickTime)
        {
            SetDoubleClickTime(MouseDoubleClickTime);//设置获取鼠标的双击速度
        }

        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (((CheckBox)sender).Checked == true)//如果为选中状态
            {
                pictureBox1.Image = null;//清空图片
                pictureBox1.Image = Properties.Resources.鼠标右键;//显示图片
                SwapMouseButton(1);//切换鼠标左右键
            }
            else//如果不为选中状态
            {
                if (((CheckBox)sender).Checked == false)
                {
                    pictureBox1.Image = null;//清空图片
                    pictureBox1.Image = Properties.Resources.鼠标左键;//显示图片
                    SwapMouseButton(0);//恢复，设置左键为主键
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int tem_n = 0;
            switch (((TrackBar)sender).Value)//记录鼠标的双击速度
            {
                case 0: tem_n = 900; break;
                case 1: tem_n = 830; break;
                case 2: tem_n = 760; break;
                case 3: tem_n = 690; break;
                case 4: tem_n = 620; break;
                case 5: tem_n = 550; break;
                case 6: tem_n = 480; break;
                case 7: tem_n = 410; break;
                case 8: tem_n = 340; break;
                case 9: tem_n = 270; break;
                case 10: tem_n = 200; break;
            }
            DoubleClickTime_Set(tem_n);//设置鼠标的双击的速度
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            aMouseinfo = trackBar2.Value;//记录鼠标的移动速度

            SystemParametersInfo(SPI_SETMOUSE, 0, ref aMouseinfo, SPIF_UPDATEINIFILE);//设置鼠标的移动速度
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
