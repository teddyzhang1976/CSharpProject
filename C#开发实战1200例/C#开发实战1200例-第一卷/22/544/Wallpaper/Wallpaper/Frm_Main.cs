using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Wallpaper
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.
StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + @"\Image\";			//获取图片的所在路径
            DirectoryInfo DInfo = new DirectoryInfo(strPath);					//实例化DirectoryInfo类
            FileInfo[] FInfo = DInfo.GetFiles();								//获取当前文件夹下的所有文件
            Random rand = new Random();								//实例化Random类
            int i = rand.Next(FInfo.Length);								//获取随机数
            RegistryKey myRKey = Registry.CurrentUser; 						//获取册注表中的基表
            myRKey = myRKey.OpenSubKey("Control Panel\\Desktop", true);		//检索指定的子项
            //通过调用RegistryKey对象的SetValue方法随机设置桌面壁纸
            myRKey.SetValue("WallPaper", strPath + FInfo[i].Name);
            myRKey.SetValue("TitleWallPaper", "2");
            myRKey.Close();
            MessageBox.Show("桌面壁纸已经更改！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}