using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            int P_int_temp;//定义整型变量
            if (int.TryParse(txt_value.Text, out P_int_temp))//为变量赋值
            {
                lb_result.Text = //输出计算结果
                    "计算结果为：" + Get(P_int_temp).ToString();
            }
            else
            {
                MessageBox.Show(//提示输入正确数值
                    "请输入正确的数值！","提示！");
            }
        }

        /// <summary>
        /// 递归算法
        /// </summary>
        /// <param name="i">参与计算的数值</param>
        /// <returns>计算结果</returns>
        int Get(int i)
        {
            if (i <= 0)							//判断数值是否小于0
                return 0;						//返回数值0
            else if (i >= 0 && i <= 2)			//判断位数是否大于等于0并且小于等于2
                return 1;						//返回数值1
            else								//如果不满足上述条件执行下面语句
                return Get(i - 1) + Get(i - 2);	//返回指定位数前两位数的和
        }
    }
}
