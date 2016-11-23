using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace BootStrapBeatitude
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(); 	//初始化一个表示一系列相互连接的直线和曲线的类
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)); 	//初始化一个矩形操作区域
            gp.AddEllipse(rect); 				//向当前指定的路径下添加一个椭圆
            this.Region = new Region(gp); 		//设置与此控件关联的窗口区域
            this.label3.Text = DateTime.Now.ToShortDateString();	//在label3控件中显示当前的日期
            this.label5.Text = DateTime.Now.ToShortTimeString(); 	//在label5中显示当前的时间
            GraphicsPath gpstirng = new GraphicsPath(); 			//初始化一个表示一系列相互连接的直线和曲线的类
            FontFamily family = new FontFamily("宋体");			//初始化一个字体样式类
            int fontStyle = (int)FontStyle.Italic; 		//设置字体的样式类型
            int emSize = 25; 					//初始化一个emSize变量
            Point origin = new Point(0, 0); 		//初始化一个有序实数对的实例
            StringFormat format = StringFormat.GenericDefault; 	//实例化一个包含文本布局信息的对象
            gpstirng.AddString("开开心心每一天", family, fontStyle, emSize, origin, format); 	//向指定的路径添加字符串
            this.button1.Region = new Region(gpstirng); 			//设置与button1控件关联的窗口区域
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\RUN").SetValue("MyAngel", Application.StartupPath + "\\Ex05_13.exe", RegistryValueKind.String); 		//打开注册表中的现有项并设置其中的键值类型
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}