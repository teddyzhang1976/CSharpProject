using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulTextBox
{
    public partial class NumberBox : TextBox
    {
        public NumberBox()
        {
            InitializeComponent();
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberBox1_KeyPress);//重载事件
            this.Leave += new System.EventHandler(this.numberBox1_Leave);
        }

        #region 常量
        const Int64 UpLine64 = +9223372036854775807;
        const Int64 DownLine64 = -9223372036854775808;
        public static bool ifInt = true;
        #endregion

        #region 添加属性
        public enum StyleSort
        {
            Null = 0,//无
            Integer = 1,//整数
            Decimal = 2,//小数
        }

        private StyleSort TDataStyle = StyleSort.Integer;
        [Browsable(true), Category("数据文本框"), Description("数据的分类")] //在“属性”窗口中显示DataStyle属性
        public StyleSort DataStyle
        {
            get { return TDataStyle; }
            set
            {
                TDataStyle = value;
                if (ifInt)
                {
                    SetTextBox();
                }
                ifInt = true;
            }
        }

        private int TDecimalDigit = 2;
        [Browsable(true), Category("数据文本框"), Description("保留的小数位数")] //在“属性”窗口中显示DecimalDigit属性
        public int DecimalDigit
        {
            get { return TDecimalDigit; }
            set
            {
                TDecimalDigit = value;
                if (TDecimalDigit < 1)
                    TDecimalDigit = 1;
                if (TDecimalDigit < this.ReservedDigit)
                    this.ReservedDigit = TDecimalDigit;
                SetTextBox();
            }
        }

        public enum Reserved
        {
            MinInt = 0,//保留最小整数
            Round = 1,//四舍五入
            MaxInt = 2,//保留最大整数
            Tropism = 3,//小数取位（不进行舍入）
        }

        private Reserved TReservedStyle = Reserved.Round;
        [Browsable(true), Category("数据文本框"), Description("小数保留的类型")] //在“属性”窗口中显示ReservedStyle属性
        public Reserved ReservedStyle
        {
            get { return TReservedStyle; }
            set
            {
                TReservedStyle = value;
                SetTextBox();
            }
        }

        private int TReservedDigit = 1;
        [Browsable(true), Category("数据文本框"), Description("舍入后小数保留的位数")] //在“属性”窗口中显示ReservedDigit属性
        public int ReservedDigit
        {
            get { return TReservedDigit; }
            set
            {
                TReservedDigit = value;
                if (TReservedDigit >= this.DecimalDigit)
                    TReservedDigit = this.DecimalDigit;
                else
                    SetTextBox();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 执行自定义控件的KeyPress事件
        /// </summary>
        protected virtual void numberBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Estimate_Key(e, ((TextBox)sender).Text, Convert.ToInt32(this.DataStyle));
        }

        /// <summary>
        /// 执行自定义控件的Leave事件
        /// </summary>
        public virtual void numberBox1_Leave(object sender, System.EventArgs e)
        {
            SetTextBox();
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 根据属性设置文本框中的内容
        /// </summary>
        public void SetTextBox()
        {
            bool tem_BoolInt = true;//定义一个变量，判断是否为数值型
            if (this.Multiline == true)//如果允许输入多行
                return;//退出当前操作
            if (this.Text.Length == 0)//如果Text属性为空
                return;//退出当前操作
            if (this.Text.Trim() == "-")
            {
                this.Text = "";
                return;//退出当前操作
            }
            else
            {
                char tem_char = '0';
                for (int i = 0; i < this.Text.Length - 1; i++)//循环遍历文本框中的数值
                {
                    tem_char = Convert.ToChar(this.Text.Substring(i, 1));//获取单个字符
                    if ((tem_char > '9' || tem_char < '0'))//如果字符不是数字
                    {
                        if (!(tem_char == '.' || tem_char == '-'))//如果字符不是'.'和'-'
                        {
                            //当前文本不能转换成数值型数据
                            MessageBox.Show("无法将字符串转换成整数或小数");
                            ifInt = false;
                            this.DataStyle = StyleSort.Null;
                            return;
                        }
                    }
                }

                if (tem_BoolInt)//如果是数值型
                {
                    Decimal tem_value = Convert.ToDecimal(this.Text);//获取当前的值
                    switch (Convert.ToInt32(this.DataStyle))//根据数据类型来进行操作
                    {
                        case 1://整型
                        case 2://小数
                            {
                                if (Math.Floor(tem_value) == tem_value)//如果输入的是整型
                                    break;//不进行操作
                                switch (Convert.ToInt32(this.ReservedStyle))//判断小数的保留类型
                                {
                                    case 0://保留最小整数
                                        {
                                            tem_value = Math.Floor(tem_value);
                                            break;
                                        }
                                    case 1://对小数进行四舍五入
                                        {
                                            if (Convert.ToInt32(this.DataStyle) == 1)
                                            {
                                                tem_value = Math.Round(tem_value, 1);
                                            }
                                            else
                                            {
                                                tem_value = Math.Round(tem_value, this.ReservedDigit);
                                            }
                                            break;
                                        }
                                    case 2://保留最大整数
                                        {
                                            tem_value = Convert.ToDecimal(this.Text);
                                            tem_value = Math.Ceiling(tem_value);
                                            break;
                                        }
                                    case 3://保留指定的小数位数
                                        {
                                            string var_str = this.Text;
                                            if (Convert.ToInt32(this.DataStyle) == 2)
                                            {
                                                tem_value = Convert.ToDecimal(var_str.Substring(0, var_str.IndexOf('.') + ReservedDigit + 1));
                                            }
                                            break;
                                        }

                                }
                                break;
                            }

                    }
                    this.Text = tem_value.ToString();//显示保留后的数据
                }

            }
        }

        /// <summary>
        /// 文本框只能输入数字型和单精度型的字符串.
        /// </summary>
        /// <param name="e">KeyPressEventArgs类</param>
        /// <param name="s">文本框的字符串</param>
        /// <param name="n">标识，判断是字符型、数字型或单精度型</param>
        public void Estimate_Key(KeyPressEventArgs e, string s, int n)
        {
            string tem_s = "";
            if (e.KeyChar == '-')//如果键值为'-'
                //如果“-”不在起始位输入，或以存在'-'
                if (this.SelectionStart != 0 && this.Text.Substring(0, 1) == "-" && this.SelectedText.IndexOf('-') < 0)
                    e.Handled = true;//处理KeyPress事件
            if (e.KeyChar != '\b')//如果当前键值不为backspace键
            {
                if (e.KeyChar <= '9' && e.KeyChar >= '0')//如果输入的数字
                {
                    //根据键值组合输入后文本
                    tem_s = s.Substring(0, this.SelectionStart) + e.KeyChar.ToString() + s.Substring(this.SelectionStart, this.Text.Length - this.SelectionLength - this.SelectionStart);
                    if (!Int64Bound(tem_s))//判断是否在指定范围内
                        e.Handled = true;//处理KeyPress事件
                }
            }

            switch (n)
            {
                case 0: break;//字符串型
                case 1://整数型
                    {
                        //当输入的键值不在0~9或回车键、backspace键
                        if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b' && e.KeyChar != '-')
                        {
                            e.Handled = true;//处理KeyPress事件
                        }
                        break;
                    }
                case 2://小数
                    {
                        //当输入的键值不在0~9或回车键、backspace键、'.'
                        if ((!(e.KeyChar <= '9' && e.KeyChar >= '0')) && e.KeyChar != '.' && e.KeyChar != '\r' && e.KeyChar != '\b' && e.KeyChar != '-')
                        {
                            e.Handled = true;//处理KeyPress事件
                        }
                        else
                        {
                            if (e.KeyChar == '.' || e.KeyChar == '\r' || e.KeyChar == '\b')//如果输入'.'
                            {
                                if (e.KeyChar != '\r' && e.KeyChar != '\b')
                                {
                                    if (s == "")//当前文本框为空
                                        e.Handled = true;   //处理KeyPress事件
                                    else
                                    {
                                        if (s.Length > 0)//当文本框不为空时
                                        {
                                            if (s.IndexOf(".") > -1)//查找是否已输入过'.'
                                                if (this.SelectedText.IndexOf('.') < 0)
                                                    e.Handled = true;//处理KeyPress事件
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (s.IndexOf(".") > -1)//如果输入了'.'
                                    if (((s.Length - s.IndexOf(".")) > DecimalDigit))//如果超出了小数的保留位数
                                    {
                                        if (this.SelectionStart > s.IndexOf("."))//如果在整数位输入键值
                                        {
                                            if (this.SelectedText.Length == 0)//光标定位
                                                e.Handled = true;
                                            
                                        }
                                    }
                            }
                        }
                        break;
                    }
            }

            if (this.Text.Length > 0)//如果值不为空
            {
                if (this.DataStyle != StyleSort.Null && e.KeyChar == '\r')//如果当前输入的是整数或小数，并且按回车键
                {
                    SetTextBox();//对值进行处理
                }
            }
        }

        /// <summary>
        /// 计算指定的字符串是否可以转换成Int64范围内的数字
        /// </summary>
        /// <param IB="string">字符串</param>
        /// <return>布尔型</return>
        public bool Int64Bound(string IB)
        {
            if (IB.IndexOf('-')>0)//如果在文本框中除第一位以外，还有'-'符号
                return false;//数据错误
            double tem_d = Convert.ToDouble(IB);//将字符型转换成双精度型
            tem_d = Math.Floor(tem_d);//取整
            if (tem_d <= UpLine64 && tem_d >= DownLine64)//判断整数位是否在Int64的范围内
                return true;//数据正确
            else
                return false;
        }
        #endregion
    }
}
