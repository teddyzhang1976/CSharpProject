using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AvertFormDie
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(//创建线程对象
                () =>//定义匿名方法
                {
                    Invoke(
                        (MethodInvoker)(() =>//定义匿名方法
                        {
                            MessageBox.Show("在线程中使用匿名方法防止窗体“假死”!");
                        }));
                });
            th.IsBackground = true;//设置线程后台执行
            th.Start();//开启线程
        }
    }
}
