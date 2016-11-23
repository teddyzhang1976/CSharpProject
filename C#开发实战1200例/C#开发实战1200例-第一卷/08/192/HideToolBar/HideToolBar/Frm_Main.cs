using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HideToolBar
{
    public partial class Frm_Main : Form
    {
        #region 声明本程序中用到的API函数
        //获取当前鼠标下可视化控件的函数
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        //获取指定句柄的父级函数
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        //获取屏幕的大小
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        #endregion

        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 运行本程序需要声明的变量
        private IntPtr CurrentHandle;//记录鼠标当前状态下控件的句柄
        private int WindowFlag;//标记是否对窗体进行拉伸操作 
        private int intOriHeight;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            intOriHeight = this.Height;
            this.DesktopLocation = new Point(794, 0);   //为当前窗体定位
            JudgeWinMouPosition.Enabled = true;      //计时器JudgeWinMouPosition开始工作
            listView1.Clear();
            listView1.LargeImageList = imageList1;
            listView1.Items.Add("小猪", "小猪", 0);
            listView1.Items.Add("小狗", "小狗", 1);
            listView1.Items.Add("娇娇", "娇娇", 2);
        }

        
        public int OriHeight
        {
            get { return intOriHeight; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button1.Dock = DockStyle.Top;
            button2.Dock = DockStyle.Bottom;
            button3.Dock = DockStyle.Bottom;
            button3.SendToBack();
            listView1.BringToFront();
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("小猪", "小猪", 0);
            listView1.Items.Add("小狗", "小狗", 1);
            listView1.Items.Add("娇娇", "娇娇", 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
           
            button2.Dock = DockStyle.Top;
            
            button1.Dock = DockStyle.Top;
            button1.SendToBack();

            button3.Dock = DockStyle.Bottom;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("北风", "北风", 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;

            button3.Dock = DockStyle.Top;//设置button3按钮绑定到窗体的上边缘

            button2.Dock = DockStyle.Top;//设置button2按钮绑定到窗体的上边缘
            button2.SendToBack();           //保证button2在button3的后面

            button1.Dock = DockStyle.Top;
            button1.SendToBack();//保证button1在button2的后面
            

            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("冰雨", "冰雨", 5);
        }

        private void JudgeWinMouPosition_Tick(object sender, EventArgs e)
        {
            if (this.Top < 3)                       //当本窗体距屏幕的上边距小于3px时
            {
                if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))//当鼠标在该窗体上时
                {
                    WindowFlag = 1;                //设定当前的窗体状态
                    HideWindow.Enabled = false;     //设定计时器HideWindow为不可用状态
                    this.Top = 0;                 //设定窗体上边缘与容器工作区上边缘之间的距离
                }
                else                              //当鼠标没在窗体上时
                {
                    WindowFlag = 1;                //设定当前的窗体状态
                    HideWindow.Enabled = true;      //启动计时器HideWindow

                }
            }                                     //当本窗体距屏幕的上边距大于3px时
            else
            {
                //当本窗体在屏幕的最左端或者最右端、最下端时
                if (this.Left < 3 || (this.Left + this.Width) > (GetSystemMetrics(0) - 3) || (this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                {
                    if (this.Left < 3)              //当窗体处于屏幕左侧时
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))    //当鼠标在该窗体上时
                        {
                            this.Height = Screen.AllScreens[0].Bounds.Height - 40;
                            this.Top = 3;
                            WindowFlag = 2;        //设定当前的窗体状态
                            HideWindow.Enabled = false;//设定计时器HideWindow为不可用状态
                            this.Left = 0;         //设定窗体的左边缘与容器工作区的左边缘之间的距离
                        }
                        else                      //当鼠标没在该窗体上时
                        {
                            WindowFlag = 2;        //设定当前的窗体状态
                            HideWindow.Enabled = true;//设定计时器HideWindow为可用状态
                           
                        }
                    }
                    if ((this.Left + this.Width) > (GetSystemMetrics(0) - 3)) //当窗体处于屏幕的最右侧时
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))//当鼠标处于窗体上时
                        {
                            this.Height = Screen.AllScreens[0].Bounds.Height - 40;
                            this.Top = 3;
                            WindowFlag = 3;        //设定当前的窗体状态
                            HideWindow.Enabled = false; //设定计时器HideWindow为不可用状态
                            this.Left = GetSystemMetrics(0) - this.Width;//设定该窗体与容器工作区左边缘之间的距离
                        }
                        else                          //当鼠标离开窗体时
                        {
                            WindowFlag = 3;            //设定当前的窗体状态
                            HideWindow.Enabled = true;  //设定计时器HideWindow为可用状态
                        }
                    }
                    //当窗体距屏幕最下端的距离小于3px时
                    if ((this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y)) //当鼠标在该窗体上时
                        {
                            WindowFlag = 4;           //设定当前的窗体状态
                            HideWindow.Enabled = false;//设定计时器HideWindow为不可用状态
                            this.Top = Screen.AllScreens[0].Bounds.Height - this.Height;//设定该窗体与容器工作区上边缘之间的距离
                        }
                        else
                        {
                            if ((this.Left > this.Width + 3) && (GetSystemMetrics(0) - this.Right) > 3)
                            {
                                WindowFlag = 4;           //设定当前的窗体状态
                                HideWindow.Enabled = true; //设定计时器HideWindow为可用状态
                            }
                        }
                    }
                }
            }
        }

        private void HideWindow_Tick(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(WindowFlag.ToString())) //判断当前窗体处于那个状态
            {
                case 1:             //当窗体处于最上端时   
                    if (this.Top < 3)   //当窗体与容器工作区的上边缘的距离小于5px时
                        this.Top = -(this.Height - 2);  //设定当前窗体距容器工作区上边缘的值
                    break;
                case 2:              //当窗体处于最左端时
                    if (this.Left < 3)//当窗体与容器工作区的左边缘的距离小于5px时
                        this.Left = -(this.Width - 2); //设定当前窗体据容器工作区左边缘的值
                    break;
                case 3:             //当窗体处于最右端时
                    if ((this.Left + this.Width) > (GetSystemMetrics(0) - 3) )  //当窗体与容器工作区的右边缘的距离小于5px时
                        this.Left = GetSystemMetrics(0) - 2;    //设定当前窗体距容器工作区左边缘的值
                    break;
                case 4:             //当窗体处于最低端时
                    if (this.Bottom > Screen.AllScreens[0].Bounds.Height - 3 )//当窗体与容器工作区的下边缘的距离小于5px时
                        this.Top = Screen.AllScreens[0].Bounds.Height - 5;   //设定当前窗体距容器工作区上边缘之间的距离
                    break;
            }
        }

        #region 获取鼠标当前状态下控件的句柄
        /// <summary>
        /// 获取鼠标当前状态下控件的句柄
        /// </summary>
        /// <param name="x">当前鼠标的X坐标</param>
        /// <param name="y">当前鼠标的Y坐标</param>
        /// <returns></returns>
        public IntPtr MouseNowPosition(int x, int y)
        {
            IntPtr OriginalHandle;//声明保存原始句柄的变量
            OriginalHandle = ((IntPtr)WindowFromPoint(x, y));//获取包含鼠标原始位置的窗口的句柄
            CurrentHandle = OriginalHandle;//设置当前句柄
            while (OriginalHandle != ((IntPtr)0))//循环判断鼠标是否移动
            {
                CurrentHandle = OriginalHandle;//记录当前的句柄
                OriginalHandle = GetParent(CurrentHandle);//更新原始句柄
            }
            return CurrentHandle;  //返回当前的句柄
        }
        #endregion

        //当窗体离开左右隐藏区域时，窗体回复原有高度
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.Left > 3 && this.Right < (GetSystemMetrics(0) - 3))
            {
                if (this.Height == Screen.AllScreens[0].Bounds.Height - 40)
                {
                    this.Height = OriHeight;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            listView1.Height = this.Height - button3.Height * 3 - 30;
        }
    }
}