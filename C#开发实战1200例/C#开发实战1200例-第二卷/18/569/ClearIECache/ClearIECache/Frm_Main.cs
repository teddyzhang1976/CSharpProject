using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClearIECache
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);//获取IE缓存文件存储路径
                DirectoryInfo mDi = new DirectoryInfo(dir);//创建DirectoryInfo对象
                mDi.Delete(true);//删除所有缓存文件
                mDi.Create();//创建IE缓存文件夹
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
