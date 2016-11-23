using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace GetMemoryInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            InsertInfo("Win32_PhysicalMemory", ref listView1, true);//将内存信息显示在列表中
        }
        public void InsertInfo(string Key, ref ListView lst, bool DontInsertNull)
        {
            lst.Items.Clear();//清空ListView控件
            //创建ManagementObjectSearcher对象，使其查找参数Key的内容
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);
            try
            {
                //使用foreach语句遍历ManagementObjectSearcher对象查找的内容
                foreach (ManagementObject share in searcher.Get())
                {
                    ListViewGroup grp;//创建一个ListViewGroup对象
                    try
                    {
                        //设置组标题
                        grp = lst.Groups.Add(share["Name"].ToString(), share["Name"].ToString());
                    }
                    catch
                    {
                        grp = lst.Groups.Add(share.ToString(), share.ToString());
                    }
                    //如果没有查找到信息，则弹出提示
                    if (share.Properties.Count <= 0)
                    {
                        MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //遍历获取到的数据
                    foreach (PropertyData PC in share.Properties)
                    {
                        //将组添加到ListViewItem中
                        ListViewItem item = new ListViewItem(grp);
                        //设置每行的颜色
                        if (lst.Items.Count % 2 != 0)
                            item.BackColor = Color.White;
                        else
                            item.BackColor = Color.WhiteSmoke;
                        
                        item.Text = PC.Name;//设置项目标题
                        if (PC.Value != null && PC.Value.ToString() != "")//判断属性名称是否为空
                        {
                            switch (PC.Value.GetType().ToString())//获取属性名称
                            {
                                case "System.String[]"://如果是字符串数组类型
                                    string[] str = (string[])PC.Value;//存储属性名称
                                    string str2 = "";
                                    foreach (string st in str)
                                        str2 += st + " ";//拆分记录
                                    item.SubItems.Add(str2);//添加到ListView列表项中
                                    break;
                                case "System.UInt16[]"://如果是整型数组类型
                                    ushort[] shortData = (ushort[])PC.Value;//存储属性名称
                                    string tstr2 = "";
                                    foreach (ushort st in shortData)
                                        tstr2 += st.ToString() + " ";//拆分记录
                                    item.SubItems.Add(tstr2);//添加到ListView列表项中
                                    break;
                                default:
                                    item.SubItems.Add(PC.Value.ToString());//直接添加到ListView列表项中
                                    break;
                            }
                        }
                        else
                        {
                            //如果没有信息则添加“没有信息”的提示
                            if (!DontInsertNull)
                                item.SubItems.Add("没有信息");
                            else
                                continue;
                        }
                        lst.Items.Add(item);//将内容添加到ListView控件中
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
