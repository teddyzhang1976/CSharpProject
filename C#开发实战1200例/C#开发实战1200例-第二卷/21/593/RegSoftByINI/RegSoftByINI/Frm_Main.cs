using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace RegSoftByINI
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 为INI文件中指定的节点取得字符串
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region 修改INI文件中内容
        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region 从INI文件中读取指定节点的内容
        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="def">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion

        string strPath = Application.StartupPath + "\\Set.ini";//定义要读取的INI文件

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            textBox1.Text = ReadString("Regedit", "Name", "", strPath);//显示登录名称
            textBox2.Text = ReadString("Regedit", "Pwd", "", strPath);//显示登录口令
            textBox3.Text = ReadString("Regedit", "RegCode", "", strPath);//显示注册码
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strName = ReadString("Regedit", "Name", "", strPath);//获取登录名称
            string strPwd = ReadString("Regedit", "Pwd", "", strPath);//获取登录口令
            string strRegcode = ReadString("Regedit", "RegCode", "", strPath);//获取注册码
            //判断INI文件中是否已经存在相同信息
            if (strName == textBox1.Text && strPwd == textBox2.Text && strRegcode == textBox3.Text)
            {
                MessageBox.Show("此信息已注册过！");
            }
            else
            {
                WritePrivateProfileString("Regedit", "Name", textBox1.Text, strPath);//向INI文件中写入登录名称
                WritePrivateProfileString("Regedit", "Pwd", textBox2.Text, strPath);//向INI文件中写入登录口令
                WritePrivateProfileString("Regedit", "RegCode", textBox3.Text, strPath);//向INI文件中写入注册码
                MessageBox.Show("注册信息已经成功写入INI文件！", "信息");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";//清空文本框
            textBox1.Focus();//使登录名称文本框获得鼠标焦点
        }
    }
}