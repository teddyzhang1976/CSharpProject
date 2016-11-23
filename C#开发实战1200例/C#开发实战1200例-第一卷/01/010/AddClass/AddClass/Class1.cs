using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShengXiao
{
    public class Class1
    {
        public string SelectSX(int intYear)
        {
            string strText = "";
            switch (intYear % 12)
            {
                case 4:
                    strText = "鼠";
                    break;
                case 5:
                    strText = "牛";
                    break;
                case 6:
                    strText = "虎";
                    break;
                case 7:
                    strText = "兔";
                    break;
                case 8:
                    strText = "龙";
                    break;
                case 9:
                    strText = "蛇";
                    break;
                case 10:
                    strText = "马";
                    break;
                case 11:
                    strText = "羊";
                    break;
                case 0:
                    strText = "猴";
                    break;
                case 1:
                    strText = "鸡";
                    break;
                case 2:
                    strText = "狗";
                    break;
                case 3:
                    strText = "猪";
                    break;
            }
            return strText;
        }
    }
}
