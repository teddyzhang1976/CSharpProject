using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using Microsoft.Win32;
namespace TimeCloseComputer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public bool flag = true;
        string strg;//数据库路径
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataReader sdr;
      [StructLayout(LayoutKind.Sequential, Pack=1)] 
      internal struct TokPriv1Luid 
      { 
         public int  Count; 
         public long  Luid; 
         public int  Attr; 
      } 

      [DllImport("kernel32.dll", ExactSpelling=true) ] 
      internal static extern IntPtr GetCurrentProcess(); 
      [DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ] 
      internal static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok ); 
      [DllImport("advapi32.dll", SetLastError=true) ] 
      internal static extern bool LookupPrivilegeValue( string host, string name, ref long pluid ); 
      [DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ] 
      internal static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall, 
         ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen ); 
      [DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
      internal static extern bool ExitWindowsEx(int uFlags, int dwReserved); 

      internal const int  SE_PRIVILEGE_ENABLED = 0x00000002; 
      internal const int  TOKEN_QUERY    = 0x00000008; 
      internal const int  TOKEN_ADJUST_PRIVILEGES = 0x00000020; 
      internal const string SE_SHUTDOWN_NAME  = "SeShutdownPrivilege"; 
      internal const int  EWX_LOGOFF    = 0x00000000; 
      internal const int  EWX_SHUTDOWN   = 0x00000001; 
      internal const int  EWX_REBOOT    = 0x00000002; 
      internal const int  EWX_FORCE    = 0x00000004; 
      internal const int  EWX_POWEROFF   = 0x00000008; 
      internal const int  EWX_FORCEIFHUNG   = 0x00000010; 

      private bool DoExitWin( int flg ) 
      {
          bool ok;
         ok = ExitWindowsEx(flg, 0 ); 
         return ok; 
      } 
        private void logout()//注销
        {
            ExitWindowsEx(EWX_LOGOFF, 0);
            flag = false;
            Application.Exit();
        }

        private void Shutdown()//关机
        {
            DoExitWin(EWX_SHUTDOWN);
            flag = false;
            Application.Exit();
        }

        private void BeginPC()//重启
        { 
            DoExitWin(EWX_REBOOT);
            flag = false;
            Application.Exit();
        }
        string settime;
        int settype;
        int autorun;
        string message;
        int cycle;

        bool judge = true;//判断是否存在ID为1的数据
        private void GetSetInfo()
        {
            JudgeID();//判断是否存在ID为1的数据
            if (judge)
            {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strg);
                conn.Open();
                cmd = new OleDbCommand("select * from SetSystem where ID=1", conn);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                settime = sdr["SetTime"].ToString();//获取设置的关机时间
                settype = Convert.ToInt32(sdr["SetType"]);//获取关机类型
                autorun = Convert.ToInt32(sdr["IsAutoRun"]);//获取是否开机运行
                message = sdr["Message"].ToString();//获取提示信息
                cycle = Convert.ToInt32(sdr["cycle"]);//执行的周期
                sdr.Close();
                conn.Close();
                dateTimePicker1.Text = settime;
                switch (settype)
                {
                    case 0: rbShutDown.Checked = true; break;
                    case 1: rbBegin.Checked = true; break;
                    case 2: rbLogout.Checked = true; break;
                    case 3: rbShowMessage.Checked = true;
                        txtMessage.Text = message;
                        break;
                }
                if (autorun == 0)
                {
                    chbAutoRun.Checked = false;
                }
                else
                {
                    chbAutoRun.Checked = true;
                }
                if (cycle == 0)//每天
                {
                    rbcycleDay.Checked = true;
                    cbbWeek.SelectedIndex = 0;
                }
                else//周几
                {
                    rbcycleWeek.Checked = true;
                    if (cycle >= 1 || cycle <= 7)
                    {
                        cbbWeek.SelectedIndex = cycle - 1;
                    }
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("请设置数据，初始化程序！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbWeek.SelectedIndex = 0;
            }
        }

        private void refurbishInfo()
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strg);
            conn.Open();
            cmd = new OleDbCommand("select * from SetSystem where ID=1", conn);
            sdr = cmd.ExecuteReader();
            sdr.Read();
            settime = sdr["SetTime"].ToString();//获取设置的关机时间
            settype = Convert.ToInt32(sdr["SetType"]);//获取关机类型
            autorun = Convert.ToInt32(sdr["IsAutoRun"]);//获取是否开机运行
            message = sdr["Message"].ToString();//获取提示信息
            cycle = Convert.ToInt32(sdr["cycle"]);//执行的周期
            sdr.Close();
            conn.Close();
        }

        private void ExecuteCommand()
        {
            refurbishInfo();
            string setTime =dateTimePicker1.Text;
            string nowTime = DateTime.Now.ToLongTimeString();
            if (setTime.Equals(nowTime))
            {
                switch (settype)
                {
                    case 0: Shutdown(); break;
                    case 1: BeginPC(); break;
                    case 2: logout(); break;
                    case 3: MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                }
            }
        }

        private void AddCommand()
        {
            string settime1;
            int settype1=0;
            int autorun1=0;
            string message1="请输入提示信息";
            int cycle1;

            settime1 = dateTimePicker1.Text;
            if (rbShutDown.Checked)
            {
                settype1 = 0;
            }
            if (rbBegin.Checked)
            {
                settype1 = 1;
            }
            if (rbLogout.Checked)
            {
                settype1 = 2;
            }
            if (rbShowMessage.Checked)
            {
                settype1 = 3;
            }

            if (chbAutoRun.Checked)
            {
                autorun1 = 1;
                autoruns(1);
            }
            else
            {
                autorun1 = 0;
                autoruns(0);
            }

            if (rbShowMessage.Checked)
            {
                if (txtMessage.Text == "")
                {
                    MessageBox.Show("输入提示信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    message1 = txtMessage.Text.Trim();
                }
            }
            if (rbcycleDay.Checked)
            {
                cycle1 = 0;
            }
            else
            {
                cycle1 = cbbWeek.SelectedIndex + 1;
            }
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strg);
            conn.Open();
            string strSQL="";
            if(judge)
            {
                strSQL="update SetSystem set SetTime='" + settime1 + "',SetType='" + settype1 + "',IsAutoRun='" + autorun1 + "',Message='" + message1 + "',cycle='"+cycle1+"' where ID=1";
            }
            else
            {
                strSQL = "insert into SetSystem(ID,SetTime,SetType,IsAutoRun,Message,cycle) values (1,'" + settime1 + "','" + settype1 + "','" + autorun1 + "','" + message1 + "','" + cycle1 + "')";
            }
            cmd = new OleDbCommand(strSQL, conn);
            int k = cmd.ExecuteNonQuery();
            if (k > 0)
            {
                if (MessageBox.Show("设置成功") == DialogResult.OK)
                {
                    conn.Close();
                    GetSetInfo();
                    judge = true;
                    timer1.Start();
                    this.Close();
                }
            }
        }

        private void JudgeID()//判断是否有ID为1的数据
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strg);
            conn.Open();
            cmd = new OleDbCommand("select count(*) from SetSystem where ID=1", conn);
            int i = (int)cmd.ExecuteScalar();
            if (i == 0)
            {
                judge = false;
            }
            else
            {
                judge = true;
            }
        }

        private void autoruns(int k)
        {
            if (k == 0)//不运行
            {
                string strName = Application.ExecutablePath;
                if (!System.IO.File.Exists(strName))
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (RKey == null)
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                RKey.DeleteValue(strnewName, false);
            }
            else
            {
                string strName = Application.ExecutablePath;
                if (!System.IO.File.Exists(strName))
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (RKey == null)
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                RKey.SetValue(strnewName, strName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString();
            strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\db.mdb";
            GetSetInfo();

            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)//取消按钮
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//确定按钮
        {
            AddCommand();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            if (flag)
            {
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = false;
            Application.Exit();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString();
            refurbishInfo();
            if (cycle==0)
            {
                ExecuteCommand();
            }
            else
            {
                int nowWeek = DateTime.Now.DayOfWeek.GetHashCode();
                if (nowWeek == cycle)
                {
                    ExecuteCommand();
                }
            }
        }
    }
}
