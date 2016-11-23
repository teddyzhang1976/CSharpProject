using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region  将MenuStrip控件中的信息添加到TreeView控件中
        /// <summary>
        /// 将MenuStrip控件中的首行命令项添加到TreeView控件中
        /// </summary>
        /// <param treeV="TreeView">TreeView控件</param>
        /// <param MenuS="MenuStrip">MenuStrip控件</param>
        public void GetMenu(TreeView treeV, MenuStrip MenuS)
        {
            bool Var_Bool = true;
            for (int i = 0; i < MenuS.Items.Count; i++) //遍历MenuStrip组件中的一级菜单项
            {
                //将一级菜单项的名称添加到TreeView组件的根节点中，并设置当前节点的子节点newNode1
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);
                if (MenuS.Items[i].Enabled == false)//判断当前项是否为可用
                {
                    newNode1.ForeColor = Color.Silver;//改变树节点的字体颜色为不可用色
                    Var_Bool = false;
                }
                else
                {
                    newNode1.ForeColor = Color.Black;//改变树节点的字体颜色为可用色
                    Var_Bool = true;
                }
                newNode1.Tag = 0;//标识，有子项的命令项
                //将当前菜单项的所有相关信息存入到ToolStripDropDownItem对象中
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                GetCavernMenu(newNode1, newmenu, Var_Bool);//添加多层命令项
            }
        }

        /// <summary>
        /// 将MenuStrip控件中的多层命今项添加到TreeView控件中
        /// </summary>
        /// <param newNodeA="TreeNode">TreeNode对象</param>
        /// <param newmenuA="ToolStripDropDownItem">ToolStripDropDownItem对象</param>
        /// <param BL="bool">标识（是否可用）</param>
        public void GetCavernMenu(TreeNode newNodeA, ToolStripDropDownItem newmenuA, bool BL)
        {
            bool Var_Bool = true;
            if (newmenuA.HasDropDownItems && newmenuA.DropDownItems.Count > 0)
                for (int j = 0; j < newmenuA.DropDownItems.Count; j++)    //遍历二级菜单项
                {
                    //将二级菜单名称添加到TreeView组件的子节点newNode1中，并设置当前节点的子节点newNode2
                    TreeNode newNodeB = newNodeA.Nodes.Add(newmenuA.DropDownItems[j].Text);
                    Var_Bool = true;
                    if (BL == false)//判断当前命令项的上一级命令是否可用
                    {
                        newNodeB.ForeColor = Color.Silver;//设置当前命令项的字体颜色为不可用色
                        newNodeB.Tag = 0;//标识，不显示相应的窗体
                        Var_Bool = false;
                    }
                    else
                    {
                        if (newmenuA.DropDownItems[j].Enabled == false)//判断当前命令项是否为可用
                        {
                            newNodeB.ForeColor = Color.Silver;//设置当前命令项的字体颜色为不可用色
                            newNodeB.Tag = 0;//标识，不显示相应的窗体
                            Var_Bool = false;
                        }
                        else
                        {
                            newNodeA.ForeColor = Color.Black;//设置当前命令项的字体颜色为可用色
                            newNodeB.Tag = int.Parse(newmenuA.DropDownItems[j].Tag.ToString());//标识，显示相应的窗体
                        }
                    }
                    //将当前菜单项的所有相关信息存入到ToolStripDropDownItem对象中
                    ToolStripDropDownItem newmenuB = (ToolStripDropDownItem)newmenuA.DropDownItems[j];
                    if (newmenuB.HasDropDownItems && newmenuA.DropDownItems.Count > 0)//如果当前命令项有子项
                    {
                        newNodeB.Tag = 0;//标识，有子项的命令项
                        GetCavernMenu(newNodeB, newmenuB, Var_Bool);//调用递归方法
                    }
                }
        }
        #endregion

        #region  打开MenuStrip控件或TreeView控件相应的窗体
        /// <summary>
        /// 打开MenuStrip控件或TreeView控件相应的窗体
        /// </summary>
        /// <param n="int">标识</param>
        /// <param FName="string">名称</param>
        public void frm_show(int n, string FName)
        {
            switch (n)//通过标识调用各子窗体
            {
                case 0: break;
                case 1:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 2:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 3:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 4:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 5:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 6:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 7:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 8:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 9:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 10:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 11:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 12:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 13:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 14:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 15:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 16:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 17:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 18:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 19:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 21:
                    {
                        //打开记事本
                        System.Diagnostics.Process.Start("notepad.exe");
                        break;
                    }
                case 22:
                    {
                        //打开计算器
                        System.Diagnostics.Process.Start("calc.exe");
                        break;
                    }
                case 23:
                    {
                        //打开WORD文档
                        System.Diagnostics.Process.Start("WINWORD.EXE");
                        break;
                    }
                case 24:
                    {
                        //打开EXCEL文件
                        System.Diagnostics.Process.Start("EXCEL.EXE");
                        break;
                    }
                case 25:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 26:
                    {
                        if (MessageBox.Show("确认退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            Application.Exit();//关闭当前工程
                        break;
                    }
                case 27:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 28:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 29:
                    {
                        Form2 fp = new Form2();//实例化一个窗体
                        fp.Text = FName;//设置窗体的名称
                        fp.ShowDialog();//用模试对话框打开窗体
                        fp.Dispose();//释放窗体的所有资原
                        break;
                    }
                case 30:
                    {
                        //打开帮助对话框
                        MessageBox.Show("\t你可以到明日科技网站\t\n\n\t  得到你想知道的\n\t    谢谢使用！！");
                        break;
                    }
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMenu(treeView1, menuStrip1);//将menuStrip1控件中的信息添加到treeView1控件中
        }

        private void ToolStrip_1_Click(object sender, EventArgs e)
        {
            frm_show(//打开MenuStrip控件或TreeView控件相应的窗体
                Convert.ToInt16(((ToolStripMenuItem)sender).Tag.ToString()), ((ToolStripMenuItem)sender).Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frm_show(//打开MenuStrip控件或TreeView控件相应的窗体
                Convert.ToInt16(((ToolStripButton)sender).Tag.ToString()), ((ToolStripButton)sender).Text);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            frm_show(//打开MenuStrip控件或TreeView控件相应的窗体
                Convert.ToInt16(e.Node.Tag.ToString()), e.Node.Text);
        }
    }
}
