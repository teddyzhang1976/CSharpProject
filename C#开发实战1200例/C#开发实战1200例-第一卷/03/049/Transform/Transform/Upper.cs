using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transform
{
    class Upper
    {
        public string NumToChinese(string x)
        {
            //数字转换为中文后的数组
            string[] P_array_num = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            //为数字位数建立一个位数组
            string[] P_array_digit = new string[] { "", "拾", "佰", "仟" };
            //为数字单位建立一个单位数组
            string[] P_array_units = new string[] { "", "万", "亿", "万亿" };
            string P_str_returnValue = ""; //返回值
            int finger = 0; //字符位置指针
            int P_int_m = x.Length % 4; //取模
            int P_int_k = 0;
            if (P_int_m > 0)
                P_int_k = x.Length / 4 + 1;
            else
                P_int_k = x.Length / 4;
            //外层循环,四位一组,每组最后加上单位: ",万亿,",",亿,",",万,"
            for (int i = P_int_k; i > 0; i--)
            {
                int P_int_L = 4;
                if (i == P_int_k && P_int_m != 0)
                    P_int_L = P_int_m;
                //得到一组四位数
                string four = x.Substring(finger, P_int_L);
                int P_int_l = four.Length;
                //内层循环在该组中的每一位数上循环
                for (int j = 0; j < P_int_l; j++)
                {
                    //处理组中的每一位数加上所在的位
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < P_int_l - 1 && Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !P_str_returnValue.EndsWith(P_array_num[n]))
                            P_str_returnValue += P_array_num[n];
                    }
                    else
                    {
                        if (!(n == 1 && (P_str_returnValue.EndsWith(P_array_num[0]) | P_str_returnValue.Length == 0) && j == P_int_l - 2))
                            P_str_returnValue += P_array_num[n];
                        P_str_returnValue += P_array_digit[P_int_l - j - 1];
                    }
                }
                finger += P_int_L;
                //每组最后加上一个单位:",万,",",亿," 等
                if (i < P_int_k) //如果不是最高位的一组
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0则加上单位",万,",",亿,"等
                        P_str_returnValue += P_array_units[i - 1];
                }
                else
                {
                    //处理最高位的一组,最后必须加上单位
                    P_str_returnValue += P_array_units[i - 1];
                }
            }
            return P_str_returnValue;
        }
    }
}

