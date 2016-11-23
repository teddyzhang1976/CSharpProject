using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetProgramFilesPath
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);//获取Program Files路径
            textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//获取桌面目录路径
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);//获取开始菜单路径
            textBox4.Text = Environment.GetFolderPath(Environment.SpecialFolder.Programs);//获取用户程序组路径
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.Templates);//获取文档模板路径
            textBox6.Text = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);//获取收藏夹路径
            textBox7.Text = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);//获取共享组件路径
            textBox8.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);//获我的图片取路径
            textBox9.Text = Environment.GetFolderPath(Environment.SpecialFolder.History);//获取Internet历史记录路径
            textBox10.Text = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);//获取Internet临时文件路径
        }
    }
}