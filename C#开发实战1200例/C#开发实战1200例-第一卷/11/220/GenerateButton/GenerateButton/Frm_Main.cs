using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenerateButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Random G_Random = new Random();

        private void Frm_Main_MouseClick(object sender, MouseEventArgs e)
        {
            Button bt = new Button()//创建按钮对象
            {
                Text = "动态生成按钮",//设置按钮的文本信息
                ForeColor = Color.FromArgb(//设置按钮的前景颜色
                G_Random.Next(0, 255),
                G_Random.Next(0, 255),
                G_Random.Next(0, 255)),
                AutoSize = true,//设置按钮自动调整大小
                Location = e.Location//设置按钮位置
            };
            Controls.Add(bt);//将按钮加入控件集合
        }
    }
}
