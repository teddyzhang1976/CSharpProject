using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace WriteRegedit
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
            rkHardware.CreateSubKey("ZHD");
            TreeNode tn1 = new TreeNode("我的电脑");//创建TreeView控件的根节点
            TreeNode tn2 = new TreeNode("HKEY_LOCAL_MACHINE");//创建TreeView控件的二级节点
            TreeNode tn3 = new TreeNode("HARDWARE");//创建TreeView控件的三级节点
            TreeNode tn4 = new TreeNode("ZHD");//创建TreeView控件的四级节点

            tn3.Nodes.Add(tn4);//把四级节点填入三级节点
            tn2.Nodes.Add(tn3);//把三级节点填入二级节点
            tn1.Nodes.Add(tn2);//把二级节点填入一级节点
            treeView1.Nodes.Add(tn1);//向树形控件添加一级节点
            treeView1.ExpandAll();//展开树形控件
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rkLocalMachine = Registry.LocalMachine; //创建RegistryKey类的实例，获取“HKEY_LOCAL_MACHINE”基项
                RegistryKey rkChild = rkLocalMachine.OpenSubKey("HARDWARE\\ZHD", true);//检索新添加的子项
                rkChild.SetValue(txtKey.Text.Trim(), txtValue.Text.Trim());//给“ZHD”子项的添加一个新的键/值对
                MessageBox.Show("向注册表中写入信息成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}