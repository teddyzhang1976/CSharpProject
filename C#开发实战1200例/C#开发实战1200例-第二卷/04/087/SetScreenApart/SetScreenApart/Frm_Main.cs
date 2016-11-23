using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SetScreenApart
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
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
        int dWidth = 0;
        int dHeight = 0;
        private void GetDis()//获取分辨率
        {
            Size s = SystemInformation.PrimaryMonitorSize;
            dWidth = s.Width;
            dHeight = s.Height;
            lblDisInfo.Text = dWidth.ToString() + " × " + dHeight.ToString() + " 像素";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDis();
            ChangeDis(1);
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
                int dSum = dWidth + dHeight;
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
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ChangeDis(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long RetVal = 0;
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            dm.dmPelsWidth = dWidth;//宽
            dm.dmPelsHeight = dHeight;//高
            dm.dmDisplayFrequency = 85;//刷新率
            dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT | DEVMODE.DM_DISPLAYFREQUENCY | DEVMODE.DM_BITSPERPEL;
            RetVal = ChangeDisplaySettings(ref dm, 0);
        }
    }
}
