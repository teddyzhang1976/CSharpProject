using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace MusicViewDesk
{
    class baseClass
    {
        #region 读写INI文件
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        [DllImport("user32")]
        public static extern int SendMessageA(int hWnd,int Msg,int wParam,int lParam);
        private const int HWND_BROADCAST = 0xffff;
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_SCREENSAVE = 0xf140;

        public static void ScreenStart()
        {
            SendMessageA(HWND_BROADCAST,WM_SYSCOMMAND,SC_SCREENSAVE,0);
        }
        public static void IniWriteValue(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        public static string IniReadValue(string section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }
        #endregion

        #region 关闭计算机的API
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool ExitWindowsEx(int flg, int rea);
        public const int EWX_SHUTDOWN = 0x00000001;
        #endregion

        #region 隐藏显示任务栏和桌面图标
        [DllImport("user32")]
        public static extern int FindWindow(string ClassName, string WindowName);
        [DllImport("user32")]
        public static extern int ShowWindow(int handle, int cmdshow);
        #endregion

        #region 设置壁纸位置（居中、平铺和拉伸）
        public static void SetDesk(int i)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Control Panel\\desktop", true);
            if (i == 0)//居中
            {
                regkey.SetValue("TileWallpaper", "0");
                regkey.SetValue("WallpaperStyle", "0");
            }
            if (i == 1)//平铺
            {
                regkey.SetValue("TileWallpaper", "1");
                regkey.SetValue("WallpaperStyle", "0");
            }
            if (i == 2)//拉伸
            {
                regkey.SetValue("TileWallpaper", "0");
                regkey.SetValue("WallpaperStyle", "2");
            }
            regkey.Close();
        }
        #endregion

        #region 调用API设置电脑桌面
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfoA")]
        public static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, string lpvparam, Int32 fuwinIni);
        #endregion
    }
}
