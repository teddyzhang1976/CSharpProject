using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SetValue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            double P_dbl_value;//定义double类型变量
            if (double.TryParse(txt_input.Text, out P_dbl_value))//判断输入是否正确
            {
                NumberFormatInfo GN = //实例化NumberFormatInfo对象
                    new CultureInfo("zh-CN", false).NumberFormat;
                GN.CurrencyDecimalDigits = Convert.ToInt32(cbox_select.Text);//设置保留位数
                txt_output.Text = P_dbl_value.ToString("C", GN);//将输入的小数转换为货币形式
            }
            else
            {
                MessageBox.Show("请输入正确的数值！", "提示！");//用户提示信息
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//设置cbox_select默认选项
        }
    }
}
