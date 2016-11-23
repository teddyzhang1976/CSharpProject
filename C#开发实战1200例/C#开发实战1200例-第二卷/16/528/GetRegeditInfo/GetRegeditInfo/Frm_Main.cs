using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace GetRegeditInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TVRegedit.Nodes.Clear();//清除所有树节点
            RegistryKey rkConfig = Registry.CurrentConfig;//通过读取“HKEY_CURRENT_CONFIG”基项创建RegistryKey类的对象
            TreeNode tConfig = new TreeNode("HKEY_CURRENT_CONFIG");//创建标签为“HKEY_CURRENT_CONFIG”的树节点
            foreach (string si in rkConfig.GetSubKeyNames())//遍历“HKEY_CURRENT_CONFIG”基项下的子项
            {
                tConfig.Nodes.Add(si.ToString());//向当前树节点添加新的子节点，子节点名称为对应子项的名称。
            }
            this.TVRegedit.Nodes.Add(tConfig);//向TreeView控件添加节点
        }

       
    }
}