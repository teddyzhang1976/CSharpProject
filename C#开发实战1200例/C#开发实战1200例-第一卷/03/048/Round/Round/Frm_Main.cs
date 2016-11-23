using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Round
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            double P_dbl_d1, P_dbl_d2;//定义两个double类型变量
            if (double.TryParse(txt_add1.Text, out P_dbl_d1) &&//判断输入信息是否正确
                double.TryParse(txt_add2.Text, out P_dbl_d2))
            {
                txt_add3.Text = //得到四舍五入后的值
                    Round(P_dbl_d1 + P_dbl_d2, cbox_select.SelectedIndex + 1).ToString();
            }
            else
            {
                MessageBox.Show(//提示错误信息
                    "输入数值不正确！", "提示！");
            }
        }

        /// <summary>
        /// 计算double值四舍五入的方法
        /// </summary>
        /// <param name="dbl">进行四舍五入的数值</param>
        /// <param name="i">保留的小数位</param>
        /// <returns>返回四舍五入后的double值</returns>
        internal double Round(double dbl, int i)
        {
            string P_str_dbl = dbl.ToString();//将double数值转换为字符串
            string P_str_lower = //将double数值小数位转换为字符串
                P_str_dbl.Split('.')[1];
            int P_str_length = P_str_lower.Length;//计算double数值小数位长度
            dbl += GetValue(i, P_str_length);//开始进行四舍五入运算
            P_str_dbl = dbl.ToString();//将运算后的值转换为字符串
            if (P_str_dbl.Contains("."))//判断是否存在小数位
            {
                string P_str_upper = //得到整数位字符串
                    P_str_dbl.Split('.')[0];
                P_str_lower = P_str_dbl.Split('.')[1];//得到小数位字符串
                if (P_str_lower.Length > i)//判断数值位数是否大于保留小数位数
                {
                    P_str_lower = P_str_lower.Substring(//截取保留的小数位
                        0, i);
                    return double.Parse(//返回double数值
                        P_str_upper + "." + P_str_lower);
                }
                else
                {
                    return double.Parse(P_str_dbl);//如数值位数小于保留小数位数则直接返回
                }
            }
            else
            {
                return double.Parse(P_str_dbl);//如果没有小数位则直接返回值
            }
        }

        /// <summary>
        /// 得到小数数值的方法
        /// </summary>
        /// <param name="int_null">四舍五入保留的位数</param>
        /// <param name="length">四舍五入丢失的位数</param>
        /// <returns>返回小数值用于四舍五入计算</returns>
        internal double GetValue(int int_null, int length)
        {
            string P_str_dbl = "0.";//定义字符串变量并赋值
            for (int i = 0; i < length; i++)//使用for循环添加小数位
            {
                if (i > int_null - 1)
                {
                    P_str_dbl += "5";//向小数的四舍五入部分加5
                }
                else
                {
                    P_str_dbl += "0";//向小数的保留部分加0
                }
            }
            return double.Parse(P_str_dbl);//返回小数数值
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//cbox_select控件默认选择第一项
        }
    }
}
