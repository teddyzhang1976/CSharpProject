using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace BranchMeans
{
    public partial class Account
    {
        #region 执行两个数的加法运算
        /// <summary>
        /// 执行两个数的加法运算
        /// </summary>
        /// <param name="Former">加数</param>
        /// <param name="After">被加数</param>
        /// <returns>返回相加后的结果</returns>
        public double Addition(double Former, double After)
        {
            return Former + After;
        }
        #endregion

        #region 执行两个数的减法运算
        /// <summary>
        /// 执行两个数的减法运算
        /// </summary>
        /// <param name="Former">减数</param>
        /// <param name="After">被减数</param>
        /// <returns>返回相减后的结果</returns>
        public double Subtration(double Former, double After)
        {
            return Former - After;
        }
        #endregion

        #region 执行两个数的乘法运算
        /// <summary>
        /// 执行两个数的乘法运算
        /// </summary>
        /// <param name="Former">乘数</param>
        /// <param name="After">被乘数</param>
        /// <returns>返回相乘后的结果</returns>
        public double Multiplication(double Former, double After)
        {
            return Former * After;
        }
        #endregion

        #region 执行两个数的除法运算
        /// <summary>
        /// 执行两个数的除法运算
        /// </summary>
        /// <param name="Former">除数</param>
        /// <param name="After">被除数</param>
        /// <returns>返回相除后的结果</returns>
        public double Division(double Former, double After)
        {
            if (After == 0)
            {
                MessageBox.Show("被除数不能为0。");
                return 0;
            }
            return Former / After;
        }
        #endregion
    }

    public partial class Account
    {
        /// <summary>
        /// 计算一个数的倒数
        /// </summary>
        /// <param name="num">数据</param>
        /// <returns>返回倒数值</returns>
        public double Molecule(double num)
        {
            return 1 / num;
        }

        /// <summary>
        /// 计算一个数的开方
        /// </summary>
        /// <param name="num">数据</param>
        /// <returns>返回开方后的值</returns>
        public double Evolution(double num)
        {
            return Math.Sqrt(num);
        }

        /// <summary>
        /// 求一个数的相反数
        /// </summary>
        /// <param name="num">数据</param>
        /// <returns>相反数</returns>
        public double Opposition(double num)
        {
            return -num;
        }

        /// <summary>
        /// 算一个数的百分比
        /// </summary>
        /// <param name="num">数据</param>
        /// <returns>返回百分比</returns>
        public double Par(double num)
        {
            return num / 100 * num;
        }
    }
}
