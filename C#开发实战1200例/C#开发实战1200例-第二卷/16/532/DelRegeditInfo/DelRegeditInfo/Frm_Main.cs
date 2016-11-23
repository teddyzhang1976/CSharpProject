using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace DelRegeditInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine; //创建RegistryKey类的实例，获取“HKEY_LOCAL_MACHINE”基项
            //使用OpenSubKey方法打开HKEY_LOCAL_MACHINE\HARDWARE子项
            RegistryKey rkHardware = rkLocalMachine.OpenSubKey("HARDWARE", true);
            //使用CreateSubKey方法创建名为ZHD的子项
            RegistryKey rkChild = rkHardware.CreateSubKey("MR");
            rkChild.SetValue("mrkj", "明日科技");//在子项“MR”下创建一个键/值对
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine;//获取“HKEY_LOCAL_MACHINE”基项
            RegistryKey rkHardware = rkLocalMachine.OpenSubKey("HARDWARE", true);//获取该基项下的HARDWARE子项
            string[] strSubKeyNames = rkHardware.GetSubKeyNames();//获取HARDWARE子项的所有子项
            foreach (string strItem  in strSubKeyNames)//遍历数组
            {
                if (strItem == textBox1.Text.Trim())//判断是否存在要被删除的子项
                {
                    rkHardware.DeleteSubKeyTree(strItem);//删除指定的子项
                    MessageBox.Show("删除子项"+strItem+"成功！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("请输入键名称！");
                return;
            }
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            RegistryKey rkMR = rkLocalMachine.CreateSubKey("HARDWARE\\MR");//打开现有的子项以进行读写操作
            string[] strValueNames = rkMR.GetValueNames();//获取MR子项的所有键值对的键名称
            foreach (string strItem in strValueNames)//遍历数组
            {
                if (strItem == textBox2.Text.Trim())//判断是否存在要删除的键值对的键名称
                {
                    rkMR.DeleteValue(strItem);//删除指定键名称的键值对
                    MessageBox.Show("删除键名称为" + strItem + "的键值对！");
                }
            }
        }
    }
}