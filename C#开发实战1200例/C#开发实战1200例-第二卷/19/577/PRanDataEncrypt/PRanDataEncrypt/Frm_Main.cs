using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRanDataEncrypt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (DecryptPwd(textBox3.Text) == textBox2.Text)
                    MessageBox.Show("用户登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("用户密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            textBox2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = EncryptPwd(textBox2.Text);
        }

        //定义加密用户密码所用的伪随机数
        private string randStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

        #region 使用伪随机数加密用户登录密码
        /// <summary>
        /// 使用伪随机数加密用户登录密码
        /// </summary>
        /// <param name="str">用户登录密码</param>
        /// <returns>加密后的用户登录密码</returns>
        private string EncryptPwd(string str)
        {
            byte[] btData = Encoding.Default.GetBytes(str);
            int j, k, m;
            int len = randStr.Length;
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < btData.Length; i++)
            {
                j = (byte)rand.Next(6);
                btData[i] = (byte)((int)btData[i] ^ j);
                k = (int)btData[i] % len;
                m = (int)btData[i] / len;
                m = m * 8 + j;
                sb.Append(randStr.Substring(k, 1) + randStr.Substring(m, 1));
            }
            return sb.ToString();
        }
        #endregion

        #region 解密用户登录密码
        /// <summary>
        /// 解密用户登录密码
        /// </summary>
        /// <param name="str">经过加密的用户登录密码</param>
        /// <returns>解密后的用户登录密码</returns>
        private string DecryptPwd(string str)
        {
            try
            {
                int j, k, m, n = 0;
                int len = randStr.Length;
                byte[] btData = new byte[str.Length / 2];
                for (int i = 0; i < str.Length; i += 2)
                {
                    k = randStr.IndexOf(str[i]);
                    m = randStr.IndexOf(str[i + 1]);
                    j = m / 8;
                    m = m - j * 8;
                    btData[n] = (byte)(j * len + k);
                    btData[n] = (byte)((int)btData[n] ^ m);
                    n++;
                }
                return Encoding.Default.GetString(btData);
            }
            catch { return ""; }
        }
        #endregion
    }
}