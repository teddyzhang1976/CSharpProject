using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LookupNear
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static int[] a = new int[21] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//定义数组
        public string LOCATE(int[] XX, int N, int X)//N数值的个数，M查找的数值
        {
            int tem_n;//定义变量
            int jl, ju, jm;
            jl=0;
            ju=N + 1;
            //利用二分查找法进行查询
            rebound://goto语句
            if (ju - jl > 1)//如果没有遍历完
            {
                jm = (ju + jl) / 2;//获取中间的位置
                if (XX[N] > XX[1] == X > XX[jm])//利用二分查找进行判断
                    jl = jm;
                else
                    ju = jm;
                goto rebound;
            }
            tem_n = jl;//获取近似值的位置
            if (X - XX[tem_n] > (XX[tem_n + 1] - N))//判断左右那个更接近
                tem_n = jl + 1;
            return "a[" + tem_n.ToString() + "]:" + XX[tem_n].ToString();//返回近似值
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string str1 = "";
            int n1 = 20;
            for (int i = 0; i <= n1; i++)
            {
                a[i] = i * 2 + i - 2;
                str1 = str1 + a[i].ToString() + ",";
            }
            listBox1.Items.Add("一维数组 a :");
            listBox1.Items.Add(str1.Trim());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("查找的近似值为：");
            listBox1.Items.Add(LOCATE(a, 20, Convert.ToInt32(textBox1.Text)));
        }
    }
}
