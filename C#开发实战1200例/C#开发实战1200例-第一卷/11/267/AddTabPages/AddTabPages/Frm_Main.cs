using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddTabPages
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.Normal;//设置选项卡的外观样式
        }
        //添加选项卡
        private void button1_Click(object sender, EventArgs e)
        {
            //声明一个字符串变量，用于生成新增选项卡的名称
            string Title = "新增选项卡 " + (tabControl1.TabCount + 1).ToString();
            TabPage MyTabPage = new TabPage(Title);//创建TabPage对象
            //使用TabControl控件的TabPages 属性的Add方法添加新的选项卡
            tabControl1.TabPages.Add(MyTabPage);
            MessageBox.Show("现有" + tabControl1.TabCount + "个选项卡");//获取选项卡个数
        }
    }
}
