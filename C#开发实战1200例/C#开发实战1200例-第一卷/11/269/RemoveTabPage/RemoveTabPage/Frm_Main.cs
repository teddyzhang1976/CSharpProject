using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveTabPage
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
        //移除选项卡
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)//判断是否选择了要移除的选项卡
            {
                MessageBox.Show("请选择要移除的选项卡");//如果没有选择，弹出提示
            }
            else
            {
                //使用TabControl控件的TabPages属性的Remove方法移除指定的选项卡
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }
    }
}
