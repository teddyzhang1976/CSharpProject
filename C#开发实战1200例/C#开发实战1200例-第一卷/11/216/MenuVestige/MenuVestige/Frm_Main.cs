using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuVestige
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btn_One.Image = //设置按钮上的图像
                global::MenuVestige.Properties.Resources.picture;
            btn_Tow.ForeColor = Color.Red;//设置按钮前景色为红色
            btn_Three.FlatStyle = FlatStyle.Flat;//设置按钮以平面显示
            btn_Three.ForeColor = Color.Blue;//设置按钮前景色为蓝色
            btn_Four.ForeColor = Color.Green;//设置按钮前景色为绿色
            btn_Four.FlatStyle = FlatStyle.Popup;//得到焦点后按钮为三维样式
            btn_Five.FlatStyle = FlatStyle.Standard;//设置按钮以三维样式显示
            btn_six.FlatStyle = FlatStyle.System;//按钮外观由操作系统决定
            btn_six.Font = new Font("隶书", 20);//设置按钮文字字体
        }
    }
}
