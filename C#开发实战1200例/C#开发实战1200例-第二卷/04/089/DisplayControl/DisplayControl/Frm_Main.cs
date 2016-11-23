using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
namespace DisplayControl
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string MaxValue;//显示器支持的最大刷新率
        string MinValue;//显示器支持的最小刷新率
        string NowValue;//当前刷新率
        bool flag = true;

        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MONITORPOWER = 0xF170;
        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);

        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DEVMODE
        {
            public const int DM_DISPLAYFREQUENCY = 0x400000;
            public const int DM_PELSWIDTH = 0x80000;
            public const int DM_PELSHEIGHT = 0x100000;
            public const int DM_BITSPERPEL = 262144;
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public DMDO dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);


        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox5.Text = "当前时间：" + DateTime.Now.ToString();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach(ManagementObject myobject in searcher.Get() )
            {
                string Vname = myobject["Name"].ToString();
                if (Vname.Length >40)
                {
                    string a = Vname.Substring(0,45);
                    string b = Vname.Substring(46);
                    lblInfo.Text = a + "\n" + b;
                }
                else
                {
                    lblInfo.Text = Vname;
                }
                string colorValue = myobject["CurrentNumberOfColors"].ToString();
                if (colorValue == "65536")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                MaxValue=myobject["MaxRefreshRate"].ToString();
                if (Convert.ToInt32(MaxValue) > 85)
                    MaxValue = "85";
                MinValue = myobject["MinRefreshRate"].ToString();
                NowValue=myobject["CurrentRefreshRate"].ToString();
                AddHZ();
                GetDis();
                ChangeDis(1);
            }

        }
        int dWidth = 0;
        int dHeight = 0;
        private void GetDis()//获取分辨率
        {
            Size s = SystemInformation.PrimaryMonitorSize;
            dWidth = s.Width;
            dHeight = s.Height;
            lblDisInfo.Text = dWidth.ToString() + " × " + dHeight.ToString() + " 像素";
        }

        private void ChangeDis(int i)//变换分辨率
        {
            int dValue;
            dValue = trackBar1.Value;
            if (i == 0)
            {
                switch (dValue)
                {
                    case 0: dWidth = 800; dHeight = 600; break;
                    case 1: dWidth = 1024; dHeight = 768; break;
                    case 2: dWidth = 1152; dHeight = 864; break;
                    case 3: dWidth = 1280; dHeight = 600; break;
                    case 4: dWidth = 1280; dHeight = 720; break;
                    case 5: dWidth = 1280; dHeight = 768; break;
                    case 6: dWidth = 1280; dHeight = 760; break;
                    case 7: dWidth = 1280; dHeight = 1024; break;
                    case 8: dWidth = 1400; dHeight = 1050; break;
                    case 9: dWidth = 1600; dHeight = 900; break;
                    case 10: dWidth = 1600; dHeight = 1200; break;
                }
                lblDisInfo.Text = dWidth.ToString() + " × " + dHeight.ToString() + " 像素";
            }
            else
            {
                int dSum=dWidth+dHeight;
                switch (dSum)
                {
                    case 1400: trackBar1.Value = 0; break;
                    case 1792: trackBar1.Value = 1; break;
                    case 2016: trackBar1.Value = 2; break;
                    case 1880: trackBar1.Value = 3; break;
                    case 2000: trackBar1.Value = 4; break;
                    case 2048: trackBar1.Value = 5; break;
                    case 2240: trackBar1.Value = 6; break;
                    case 2304: trackBar1.Value = 7; break;
                    case 2450: trackBar1.Value = 8; break;
                    case 2500: trackBar1.Value = 9; break;
                    case 2800: trackBar1.Value = 10; break;
                }
            }
        }


        private void AddHZ()
        {
            int[] hz = new int[] { 60, 70, 75, 85, 100, 120 };
            comboBox2.Items.Clear();
            if (checkBox1.Checked)
            {
                for (int i = 0; i < hz.Length; i++)
                {
                    if (hz[i] <= Convert.ToInt32(MaxValue))
                    {
                        comboBox2.Items.Add(hz[i].ToString() + "赫兹");
                    }
                }
                comboBox2.Text = NowValue + "赫兹";
            }
            else
            {
                for (int j = 0; j < hz.Length; j++)
                {
                    comboBox2.Items.Add(hz[j].ToString() + "赫兹");
                }
                comboBox2.Text = NowValue + "赫兹";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AddHZ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ChangeDis(0);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox5.Enabled = true;
            }
            else
            {
                groupBox5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)//设置分辨率、颜色质量、刷新率
            {
                long RetVal = 0;
                DEVMODE dm = new DEVMODE();
                dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
                dm.dmPelsWidth = dWidth;//宽
                dm.dmPelsHeight = dHeight;//高
                int f =Convert.ToInt32(comboBox2.Text.Trim().Remove(comboBox2.Text.Trim().Length-2));
                dm.dmDisplayFrequency = f;//刷新率
                if (comboBox1.SelectedIndex == 0)
                    dm.dmBitsPerPel = 16;
                else
                    dm.dmBitsPerPel = 32;
                dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT | DEVMODE.DM_DISPLAYFREQUENCY | DEVMODE.DM_BITSPERPEL;
                RetVal = ChangeDisplaySettings(ref dm, 0);
            }
            if (radioButton2.Checked)//关闭显示器
            {
                timer1.Start();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == DateTime.Now.ToLongTimeString())
            {
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
                timer1.Stop();
            }
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

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            groupBox5.Text = "当前时间：" + DateTime.Now.ToString();
        }
    }
}
