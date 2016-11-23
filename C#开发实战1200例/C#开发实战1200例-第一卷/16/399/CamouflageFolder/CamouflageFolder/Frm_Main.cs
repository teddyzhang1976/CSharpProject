using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace CamouflageFolder
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private string GetFolType()
        {
            int Tid = comboBox1.SelectedIndex;							//获取选择项索引
            switch (Tid)												//根据索引设置Windows文件标识符
            {
                case 0: return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";	//我的电脑的Windows文件标识符
                case 1: return @"{450D8FBA-AD25-11D0-98A8-0800361B1103}";	//我的文档Windows文件标识符
                case 2: return @"{992CFFA0-F557-101A-88EC-00DD010CCC48}";	//拨号网络Windows文件标识符
                case 3: return @"{21EC2020-3AEA-1069-A2DD-08002B30309D}";	//控制面板Windows文件标识符
                case 4: return @"{D6277990-4C6A-11CF-8D87-00AA0060F5BF}";	//计划任务Windows文件标识符
                case 5: return @"{2227A280-3AEA-1069-A2DE-08002B30309D}";	//打印机Windows文件标识符
                case 6: return @"{208D2C60-3AEA-1069-A2D7-08002B30309D}";	//网络邻居Windows文件标识符
                case 7: return @"{645FF040-5081-101B-9F08-00AA002F954E}";		//回收站Windows文件标识符
                case 8: return @"{85BBD920-42A0-1069-A2E4-08002B30309D}";	//公文包Windows文件标识符
                case 9: return @"{BD84B380-8CA2-1069-AB1D-08000948F534}";	//字体Windows文件标识符
                case 10: return @"{BDEADF00-C265-11d0-BCED-00A0C90AB50F}";	//Web 文件夹Windows文件标识符
            }
            //如果都不符合则返回我的电脑Windows文件标识符
            return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.Length >= 4)
                {
                    txtFolPath.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("不能对盘符进行伪装", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 11)
            {
                txtID.ReadOnly = false;
                txtID.Text = "";
            }
            else
            {
                txtID.ReadOnly = true;
                txtID.Text = GetFolType();
            }

        }

        private void Camouflage(string str)									//用于创建desktop.ini文件
        {
            StreamWriter sw = File.CreateText(txtFolPath.Text.Trim() + @"\desktop.ini");	//用desktop.ini文件创建StreamWriter实例
            sw.WriteLine(@"[.ShellClassInfo]");							//写入“[.ShellClassInfo]”
            sw.WriteLine("CLSID=" + str);								//写入Windows文件标识符
            sw.Close();												//关闭对象
            //设置desktop.ini文件为隐藏
            File.SetAttributes(txtFolPath.Text.Trim() + @"\desktop.ini", FileAttributes.Hidden);
            File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);		//设置文件夹属性为系统属性
            //弹出提示
            MessageBox.Show("伪装成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtFolPath.Text == "")									//如果没选择文件
            {
                //弹出提示信息
                MessageBox.Show("请选择文件夹路径！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else													//否则
            {
                try
                {
                    if (txtID.ReadOnly == false)							//如果自定义Windows文件标识符
                    {
                        string str = txtID.Text.Trim();						//获取选择的Windows文件标识符
                        if (str.StartsWith("."))							//如果以“.”开头
                            str = str.Substring(1);							//则去掉“.”
                        if (!str.StartsWith("{") || str.Trim().Length != 38)			//如果不以“{”开头，并且长度错误
                        {
                            //弹出提示
                            MessageBox.Show("自定义类型错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else											//如果Windows文件标识符合法
                        {
                            Camouflage(str);							//调用Camouflage方法开始伪装
                        }
                    }
                    else											//如果选择预定的伪装方式
                    {
                        //则首先要通过GetFolType方法获取Windows文件标识符，然后使用Camouflage方法开始伪装
                        Camouflage(GetFolType());
                    }
                }
                catch
                {
                    MessageBox.Show("不要进行多次伪装！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolPath.Text == "")										//判断是否选择了需要还原伪装的文件夹
            {
                MessageBox.Show("请选择加密过的文件夹！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else													//如果选择了文件夹
            {
                try
                {
                    FileInfo fi = new FileInfo(txtFolPath.Text.Trim() + @"\desktop.ini");	//创建FileInfo实例
                    if (!fi.Exists)										//如果不存在desktop.ini文件说明没有被伪装
                    {
                        MessageBox.Show("该文件夹没有被伪装！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else											//否则
                    {
                        System.Threading.Thread.Sleep(1000);				//睡眠线程
                        File.Delete(txtFolPath.Text + @"\desktop.ini");			//删除文件夹下的desktop.ini文件
                        File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);//设置文件夹属性为系统属性
                        MessageBox.Show("还原成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("不要多次还原！");
                }
            }
        }
    }
}
