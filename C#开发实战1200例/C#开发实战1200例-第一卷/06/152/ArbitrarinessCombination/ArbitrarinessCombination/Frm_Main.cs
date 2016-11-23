using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ArbitrarinessCombination
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string[] a =new string[6]{ "0", "1", "2", "3", "4", "5" };//定义数组
        int num = 6;//定义最大的个数
        int nIdx = 0, nSidx = 0;

        public void SetArbitrariness(int n, ArrayList List)
        {
            ArrayList SList = new ArrayList(a);//实例化ArrayList类
            SList.Clear();//清空ArrayList
            try
            {
                if (n >= 1)//如果大于等于1
                {
                    if (List.Count == 0)//如果List为空
                    {
                        for (nIdx = 0; nIdx <= num - 1; nIdx++)//添加单位数
                            SList.Add(a[nIdx]);
                    }
                    else
                    {
                        //添加多位数
                        for (nIdx = 0; nIdx <= num - 1; nIdx++)
                            for (nSidx = 0; nSidx <= List.Count - 1; nSidx++)
                                if (List[nSidx].ToString().IndexOf(a[nIdx]) == -1)//如查当前的值没有添加
                                    SList.Add(a[nIdx] + List[nSidx].ToString());//添加
                    }
                    SetArbitrariness(n - 1, SList);//递归该方法
                }
                if (SList.Count > 0)//如果有数值
                {
                    List.Clear();//清空List
                    for (int i = 0; i < SList.Count; i++)//添加单位数
                        List.Add(SList[i].ToString());
                }
            }
            catch
            {
                SList.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList List = new ArrayList(a);//实例化ArrayList类
            List.Clear();//清空ArrayList类
            listBox1.Items.Clear();//清空listBox1控件
            SetArbitrariness(Convert.ToInt32(textBox1.Text), List);//调用自定义方法
            //将不同的数值添加到listBox1控件上
            for (int i = 0; i < List.Count; i++)
                listBox1.Items.Add(List[i].ToString());
            listBox1.Items.Add("Total:" + listBox1.Items.Count.ToString());//显示一共执行了几行
        }
    }
}
