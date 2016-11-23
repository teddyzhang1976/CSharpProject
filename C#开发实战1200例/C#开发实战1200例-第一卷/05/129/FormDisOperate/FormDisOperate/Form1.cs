using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormDisOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void FormOperate<T>()
        {
            Form2 Frm_2 = new Form2();//实例化Form2窗体对象
            Frm_2.ShowDialog();//以对话框形式显示Form2窗体
        }

        public void FormOperate<T>(string strError)
        {
            MessageBoxIcon messIcon = MessageBoxIcon.Error;//实例化提示框中显示图标对象
            MessageBox.Show(strError, "提示", MessageBoxButtons.OK, messIcon);//显示错误提示框
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOperate<object>();//调用FormOperate方法的第一种重载形式对窗体操作
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOperate<object>("数据库连接失败。");//调用FormOperate方法的第二种重载形式对窗体操作
        }

    }
}
