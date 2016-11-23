using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TxtValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //身份证号码18
            this.maskedTextBox1.Mask = "000000-00000000-000A";
            //身份证号码15
            this.maskedTextBox2.Mask = "000000-000000-000";
            //邮政编码
            this.maskedTextBox3.Mask = "000000";
            //出生日期
            this.maskedTextBox4.Mask = "0000年90月90日";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("请输入18位身份证号",//弹出消息对话框 
                "信息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("请输入15位身份证号", //弹出消息对话框
                "信息提示", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("请输入正确邮政编号", //弹出消息对话框
                "信息提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("请输入正确出生日期格式", //弹出消息对话框
                "信息提示", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}