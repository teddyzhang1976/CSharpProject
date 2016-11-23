using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conversion
{
    class Transform
    {
        internal string TenToBinary(long value)//将十进制转换为二进制
        {
            return Convert.ToString(value, 2);
        }
        internal string TenToEight(long value)//将十进制转换为八进制
        {
            return Convert.ToString(value, 8);
        }
        internal string TenToSixteen(long value)//将十进制转换为十六进制
        {
            return Convert.ToString(value, 16);
        }
        internal string BinaryToEight(long value)//将二进制转换为八进制
        {
            return Convert.ToString(
                Convert.ToInt64(value.ToString(), 2), 8);
        }
        internal string BinaryToTen(long value)//将二进制转换为十进制
        {
            return Convert.ToInt64(
                value.ToString(), 2).ToString();
        }
        internal string BinaryToSixteen(long value)//将二进制转换为十六进制
        {
            return Convert.ToString(
                Convert.ToInt64(value.ToString(), 2), 16);
        }
        internal string EightToBinary(long value)//将八进制转换为二进制
        {
            return Convert.ToString(
                Convert.ToInt64(value.ToString(), 8), 2);
        }
        internal string EightToTen(long value)//将八进制转换为十进制
        {
            return Convert.ToInt64(
                value.ToString(), 8).ToString();
        }
        internal string EightToSixteen(long value)//将八进制转换为十六进制
        {
            return Convert.ToString(
                Convert.ToInt64(value.ToString(), 8), 16);
        }
        internal string SixteenToBinary(string value)//将十六进制转换为二进制
        {
            return Convert.ToString(
                Convert.ToInt64(value, 16), 2);
        }
        internal string SixteenToEight(string value)//将十六进制转换为八进制
        {
            return Convert.ToString(
                Convert.ToInt64(value, 16), 8);
        }
        internal string SixteenToTen(string value)//将十六进制转换为十进制
        {
            return Convert.ToUInt64(value, 16).ToString();
        }
    }
}
