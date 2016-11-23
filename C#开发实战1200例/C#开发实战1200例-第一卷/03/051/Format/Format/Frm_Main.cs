using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Format
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            double P_dbl_temp;//定义double类型变量
            if (double.TryParse(txt_str.Text, out P_dbl_temp))//验证输入是否正确并赋值
            {
                System.Globalization.NumberFormatInfo GN =//实例化NumberFormatInfo对象
                    new System.Globalization.
                        CultureInfo("zh-CN", false).NumberFormat;
                GN.CurrencyGroupSeparator = ",";//设置货币值中用来分组的字符串
                txt_result.Text = P_dbl_temp.ToString("C", GN);//格式化为货币格式并显示
            }
            else
            {
                MessageBox.Show("请输入正确的货币值！","提示！");//输出错误信息
            }
        }
    }
}
