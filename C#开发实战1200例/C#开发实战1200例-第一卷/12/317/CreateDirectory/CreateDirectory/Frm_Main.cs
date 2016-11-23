using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;

namespace CreateDirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public void getFilter(string strPath, string strName)
        {
            string virtualDirName = strName;//虚拟目录名称
            string physicalPath = strPath;//虚拟目实际路径
            this.directoryEntry1.Path = "IIS://localhost/W3SVC/1/ROOT";//获取设置文件的路径
            this.directoryEntry1.Children.Add(virtualDirName, directoryEntry1.SchemaClassName);
            //对新创建的节点进行操作了
            //设置虚拟目录指向的物理路径
            directoryEntry1.Properties["Path"][0] = physicalPath;
            directoryEntry1.Invoke("AppCreate", true);//设置读取权限
            directoryEntry1.Properties["AccessRead"][0] = false;//设置读取权限
            directoryEntry1.Properties["ContentIndexed"][0] = true; ;
            directoryEntry1.Properties["DefaultDoc"][0] = "index.asp,Default.aspx"; //设置默认文档,多值情况下中间用逗号分割
            directoryEntry1.Properties["AppFriendlyName"][0] = virtualDirName;//应用程序名称
            directoryEntry1.Properties["AccessScript"][0] = true;//执行权限
            directoryEntry1.Properties["DontLog"][0] = true;
            directoryEntry1.Properties["AuthFlags"][0] = 0;//设置目录的安全性，0表示不允许匿名访问，1为允许，3为基本身份验证，7为windows继承身份验证
            directoryEntry1.Properties["AuthFlags"][0] = 1;
            directoryEntry1.CommitChanges();//将目录保存到IIS中
        }
        //打开文件路径
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        //设置
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath.ToString() != "" && textBox2.Text != "")
            {
                getFilter(folderBrowserDialog1.SelectedPath, textBox2.Text.TrimEnd());
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("请选择虚拟目录的物理路径或输入虚拟目录名称", "信息提示");
            }
        }
    }
}