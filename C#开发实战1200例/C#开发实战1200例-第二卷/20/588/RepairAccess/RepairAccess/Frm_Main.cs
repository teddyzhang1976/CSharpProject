using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;//引用C:\Program Files\Common Files\System\ado\msadox.dll,该DLL包含ADOX命名空间;
using JRO;//引用C:\Program Files\Common Files\System\ado\msjro.dll,该DLL包含JRO命名空间
using System.IO;

namespace RepairAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //打开选择数库咱径
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Access数据库|*.mdb";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                strPathMdb = textBox1.Text.TrimEnd();
            }

        }
        //开始压缩数据库库
        string strPathMdb = null;
        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(strPathMdb))//检查数据库是否已存在
            {
                MessageBox.Show("目标数据库不存在,无法压缩","操作提示");
                return;
            }
            //声明临时数据库的名称
            string temp = DateTime.Now.Year.ToString();
            temp += DateTime.Now.Month.ToString();
            temp += DateTime.Now.Day.ToString();
            temp += DateTime.Now.Hour.ToString();
            temp += DateTime.Now.Minute.ToString();
            temp += DateTime.Now.Second.ToString() + ".bak";
            temp = strPathMdb.Substring(0, strPathMdb.LastIndexOf("\\") + 1) + temp;
            //定义临时数据库的连接字符串
            string temp2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + temp;
            //定义目标数据库的连接字符串
            string strPathMdb2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPathMdb;
            JRO.JetEngineClass jt = new JRO.JetEngineClass();//创建一个JetEngineClass对象
            //使用JetEngineClass对象的CompactDatabase方法压缩修复数据库
            jt.CompactDatabase(strPathMdb2, temp2);
            
            File.Copy(temp, strPathMdb, true);//拷贝临时数据库到目标数据库(覆盖)
            File.Delete(temp);//删除临时数据库
            MessageBox.Show("修复完成");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}