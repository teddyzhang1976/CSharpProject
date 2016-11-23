using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conversion
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_transform_Click(object sender, EventArgs e)
        {
            try
            {
                Action();//调用Action方法进行转换操作
            }
            catch (Exception ex)
            {
                MessageBox.Show(//如果出现异常则提示错误信息
                    ex.Message+" 请重新输入","出错！");
            }
        }

        /// <summary>
        /// 此方法用于进制转换
        /// </summary>
        private void Action()
        {
            if (cbox_select.SelectedIndex != 3)//判断用户输入是否为十六进制数
            {
                long P_lint_value;//定义长整型变量
                if (long.TryParse(txt_value.Text, out P_lint_value))//判断输入数值是否正确并赋值
                {
                    if (cbox_select.SelectedIndex == 0)//判断用户输入的是否为十进制数
                    {
                        switch (cbox_select2.SelectedIndex)
                        {
                            case 0:
                                txt_result.Text = txt_value.Text;//将十进制转为十进制
                                break;
                            case 1:
                                txt_result.Text = //将十进制转为二进制
                                    new Transform().TenToBinary(long.Parse(txt_value.Text));
                                break;
                            case 2:
                                txt_result.Text = //将十进制转为八进制
                                    new Transform().TenToEight(long.Parse(txt_value.Text));
                                break;
                            case 3:
                                txt_result.Text = //将十进制转为十六进制
                                    new Transform().TenToSixteen(long.Parse(txt_value.Text));
                                break;
                        }
                    }
                    else
                    {
                        if (cbox_select.SelectedIndex == 1)//判断用户输入的是否为二进制数
                        {
                            switch (cbox_select2.SelectedIndex)
                            {
                                case 0:
                                    txt_result.Text = //将二进制转为十进制
                                        new Transform().BinaryToTen(long.Parse(txt_value.Text));
                                    break;
                                case 1:
                                    txt_result.Text = txt_value.Text;//将二进制转为二进制
                                    break;
                                case 2:
                                    txt_result.Text = //将二进制转为八进制
                                        new Transform().BinaryToEight(long.Parse(txt_value.Text));
                                    break;
                                case 3:
                                    txt_result.Text = //将二进制转为十六进制
                                        new Transform().BinaryToSixteen(long.Parse(txt_value.Text));
                                    break;
                            }
                        }
                        else
                        {
                            if (cbox_select.SelectedIndex == 2)//判断用户输入的是否为八进制数
                            {
                                switch (cbox_select2.SelectedIndex)
                                {
                                    case 0:
                                        txt_result.Text = //将八进制转为十进制
                                            new Transform().EightToTen(long.Parse(txt_value.Text));
                                        break;
                                    case 1:
                                        txt_result.Text = //将八进制转为二进制
                                            new Transform().EightToBinary(long.Parse(txt_value.Text));
                                        break;
                                    case 2:
                                        txt_result.Text = txt_value.Text;//将八进制转为八进制
                                        break;
                                    case 3:
                                        txt_result.Text = //将八进制转为十六进制
                                            new Transform().EightToSixteen(long.Parse(txt_value.Text));
                                        break;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("请输入正确数值！", "提示！");//提示错误信息
                }
            }
            else
            {
                switch (cbox_select2.SelectedIndex)
                {
                    case 0:
                        txt_result.Text = //将十六进制转为十进制
                            new Transform().SixteenToTen(txt_value.Text);
                        break;
                    case 1:
                        txt_result.Text = //将十六进制转为二进制
                            new Transform().SixteenToBinary(txt_value.Text);
                        break;
                    case 2:
                        txt_result.Text = //将十六进制转为八进制
                            new Transform().SixteenToEight(txt_value.Text);
                        break;
                    case 3:
                        txt_result.Text = //将十六进制转为十六进制
                            txt_value.Text;
                        break;
                }
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//初始化Cbox_select默认选项
            cbox_select2.SelectedIndex = 3;//初始化Cbox_select2默认选项
        }
    }
}
