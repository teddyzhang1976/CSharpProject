using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCtrlStyle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ImageList = imageList1;//设置控件的ImageList属性为imageList1
            //第一个选项卡的图标是imageList1中索引为0的图标
            tabPage1.ImageIndex = 0;
            tabPage1.Text = "C#编程词典——全能版";//设置第一个选项卡标题
            //第二个选项卡的图标是imageList1中索引为0的图标
            tabPage2.ImageIndex = 0;
            tabPage2.Text = "C#编程词典——珍藏版";//设置第二个选项卡标题
            //将控件的Appearance属性设置为Buttons，使选项卡具有三维按钮的外观
            tabControl1.Appearance = TabAppearance.Buttons;
        }
    }
}