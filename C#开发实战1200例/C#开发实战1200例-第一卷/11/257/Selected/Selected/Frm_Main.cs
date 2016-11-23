using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Selected
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void ckInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInfo.Checked == true)//判断是否选中基本档案
            {
                ckLinfo.Visible = true;//显示基本档案信息
                CheckAll(ckLinfo);//选中所有基本档案
            }
            else
            {
                ckLinfo.Visible = false;//隐藏基本档案信息
                CheckAllEsce(ckLinfo);//取消选中所有基本档案
            }
        }

        private void ckShop_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShop.Checked == true)//判断是否选中进货管理
            {
                cklShop.Visible = true;//显示进货管理信息
                CheckAll(cklShop);//选中所有进货管理
            }
            else
            {
                cklShop.Visible = false;//隐藏进货管理信息
                CheckAllEsce(cklShop);//取消选中所有进货管理
            }

        }

        private void ckSell_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSell.Checked == true)//判断是否选中销售管理
            {
                cklSell.Visible = true;//显示销售管理信息
                CheckAll(cklSell);//选中所有销售管理
            }
            else
            {
                cklSell.Visible = false;//隐藏销售管理信息
                CheckAllEsce(cklSell);//取消选中所有销售管理
            }
        }

        private void ckMange_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMange.Checked == true)//判断是否选中库存管理
            {
                cklMange.Visible = true;//显示库存管理
                CheckAll(cklMange);//选中所有库存管理
            }
            else
            {
                cklMange.Visible = false;//隐藏库存管理
                CheckAllEsce(cklMange);//取消选中所有库存管理
            }
        }
        /// <summary>
        /// 全部选中方法
        /// </summary>
        /// <param name="chckList">控件对象</param>
        public void CheckAll(CheckedListBox ckl)
        {
            for (int i = 0; i < ckl.Items.Count; i++)//遍历控件中的项并赋值
            { ckl.SetItemCheckState(i, CheckState.Checked); }
        }

        /// <summary>
        /// 全部取选中方法
        /// </summary>
        /// <param name="chckList">控件对象</param>
        public void CheckAllEsce(CheckedListBox ckl)
        {
            for (int i = 0; i < ckl.Items.Count; i++)//遍历控件中的项并赋值
            { ckl.SetItemCheckState(i, CheckState.Unchecked); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")//判断用户输入是否为空
                {
                    MessageBox.Show(//弹出消息对话框
                        "用户姓名不能为空", "提示");
                    return;
                }
                if (textBox2.Text == "")//判断密码输入是否为空
                {
                    MessageBox.Show(//弹出消息对话框
                        "用户密码", "提示");
                    return;
                }
                if (radMan.Checked == false && //判断用户性别输入是否为空
                    radWoman.Checked == false)
                {
                    MessageBox.Show(//弹出消息对话框
                        "请选择用户性别", "提示");
                    return;
                }
                if (ckInfo.Checked == false && ckMange.Checked == false && //判断是否选择权限
                    ckSell.Checked == false && ckShop.Checked == false)
                {
                    MessageBox.Show(//弹出消息对话框
                        "请任选一项用户权限", "提示");
                    return;
                }
                string strName = textBox1.Text.ToString();//得到用户名信息
                string strPassword = textBox2.Text;//得到密码信息
                string strPhon = textBox3.Text;//得到电话信息
                string srtEmail = textBox4.Text;//得到邮件地址信息
                string strAdress = textBox5.Text;//得到地址信息
                string strSex;//定义性别变量
                if (radWoman.Checked == true)//判断用户性别
                {
                    strSex = "女";//为性别变量赋值
                }
                else
                {
                    strSex = "男";//为性别变量赋值
                }

                string strCkNabge = "库存管理：" + "\n";//创建字符串对象
                string strCklsell = "销售管理：" + "\n";//创建字符串对象
                string strCklShop = "进货管理:" + "\n";//创建字符串对象
                string strCkl = "基本档案:" + "\n";//创建字符串对象
                if (ckLinfo.Visible == true)//判断基本档案中是否有选择项
                {

                    for (int i = 0; i < ckLinfo.CheckedItems.Count; i++)
                    {

                        strCkl += //添加输出信息
                            ckLinfo.CheckedItems[i].ToString() + "\n";
                    }
                }
                if (cklMange.Visible == true)//判断库存管理中是否有选择项
                {

                    for (int i = 0; i < cklMange.CheckedItems.Count; i++)
                    {
                        strCkNabge += //添加输出信息
                            cklMange.CheckedItems[i].ToString() + "\n";
                    }

                }
                if (cklSell.Visible == true)//判断销售管理中是否有选择项
                {

                    for (int i = 0; i < cklSell.CheckedItems.Count; i++)
                    {
                        strCklsell += //添加输出信息
                            cklSell.CheckedItems[i].ToString() + "\n";
                    }

                }
                if (cklShop.Visible == true)//判断进货管理中是否有选择项
                {
                    for (int i = 0; i < cklShop.CheckedItems.Count; i++)
                    {
                        strCklShop += //添加输出信息
                            cklShop.CheckedItems[i].ToString() + "\n";

                    }
                }
                MessageBox.Show(//弹出消息对话框，输出用户输入权限信息
                    "注册信息如下：" + "\n" + "姓名:" + strName + 
                    "\n" + "密码：" + strPassword + "\n" + "电话:"  +
                    strPhon + "\n" + "邮箱:" + srtEmail + "\n" + 
                    "地址:" + strAdress + "\n" + "性别：" + strSex + 
                    "\n" + "用户权限如下：" + "\n" + 
                    strCkl + strCkNabge + strCklsell + strCklShop, "信息确认");
            }
            catch (Exception ee)
            {
                MessageBox.Show(//弹出消息对话框
                    ee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radWoman.Checked = false;//取消选择性别女
            radMan.Checked = false;//取消选择性别男

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";//初始化控件
            textBox2.Text = "";//初始化控件
            textBox3.Text = "";//初始化控件
            textBox4.Text = "";//初始化控件
            textBox5.Text = "";//初始化控件
            radWoman.Checked = false;//初始化控件
            radMan.Checked = false;//初始化控件
            ckInfo.Checked = false;//初始化控件
            ckMange.Checked = false;//初始化控件
            ckSell.Checked = false;//初始化控件
            ckShop.Checked = false;//初始化控件
        }
    }
}