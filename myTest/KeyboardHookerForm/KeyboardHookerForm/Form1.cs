using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardHookerForm
{
    public partial class Form1 : Form
    {
        private KeyboardHook k_hook;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            k_hook = new KeyboardHook();

            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//全局按键事件
            k_hook.MouseDown += k_hook_MouseDown;//全局点击事件

            k_hook.Start();//安装键盘钩子
            this.ShowInTaskbar = false;
            this.Opacity = 0;

        }

        void k_hook_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text= "鼠标激发";
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {


            //判断按下的键（Alt + A）

            if (e.KeyValue == (int)Keys.A && (int)Control.ModifierKeys == (int)Keys.Alt)
            {

                System.Windows.Forms.MessageBox.Show("按下了指定快捷键组合");

            }

        }
    }
}
