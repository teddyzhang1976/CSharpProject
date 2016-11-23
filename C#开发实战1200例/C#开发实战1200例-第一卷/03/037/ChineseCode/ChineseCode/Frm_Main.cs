using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (txt_Chinese.Text != string.Empty)//判断输入是否为空
            {
                try
                {
                    txt_Num.Text = //得到汉字区位码信息
                        getCode(txt_Chinese.Text);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(//使用消息对话框提示异常信息
                        ex.Message + "请输入正确的汉字", "出错！");
                }
            }
        }
        /// <summary>
        /// 得到汉字区位码方法
        /// </summary>
        /// <param name="strChinese">汉字字符</param>
        /// <returns>返回汉字区位码</returns>
        public string getCode(string Chinese)
        {
            byte[] P_bt_array = Encoding.Default.GetBytes(Chinese);//得到汉字的Byte数组
            int front = (short)(P_bt_array[0] - '\0');//将字节数组的第一位转换成short类型
            int back = (short)(P_bt_array[1] - '\0');//将字节数组的第二位转换成short类型
            return (front - 160).ToString() + (back - 160).ToString();//计算并返回区位码
        }
    }
}
