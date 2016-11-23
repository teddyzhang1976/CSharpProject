using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetFocus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void AllControl_Enter(object sender,EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.CornflowerBlue;//当当前控件成为活动控件时设置它的背景颜色为蓝色
        }

        private void AllControl_Leave(object sender,EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;//当当前控件成为不活动控件时设置它的背景颜色为白色
        }

        private void AllControl_KeyDown(object sender,KeyEventArgs e)
        {
            if(e.KeyValue == 13) //当按下“Enter”键时
            {
                int n = Convert.ToInt32(((TextBox)sender).Tag.ToString());//获取控件标识
                Clear_Control(groupBox1.Controls, n, 6); //进入下一个控件
            }
        }
        #region  遍历指定的控件
        /// <summary>
        /// 遍历指定的控件
        /// </summary>
        /// <param Con="ControlCollection">可视化控件</param>
        /// <param n="int">控件标识</param>
        /// <param m="int">最大标识</param>
        public void Clear_Control(Control.ControlCollection Con,int n,int m)
        {
            int tem_n = 0;//初始化一个int型变量
            foreach(Control C in Con)//遍历可视化组件中的所有控件
            { 
                if(C.GetType().Name == "TextBox")  //判断是否为TextBox控件
                {
                    if(n == m)//当循环至最后一个控件时
                        tem_n = 1;//设置控件标识的值为1
                    else //当没有循环到最后一个控件时
                        tem_n = n + 1;//使控件的标识值递增1
                    if(Convert.ToInt32(((TextBox)C).Tag.ToString()) == tem_n)//当与当前控件关联的数据对象为下一个控件时
                        ((TextBox)C).Focus();//为当前控件设置焦点
                }
            }
        }
        #endregion

    }
}
