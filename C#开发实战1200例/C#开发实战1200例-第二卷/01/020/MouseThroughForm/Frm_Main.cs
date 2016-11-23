using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MouseThroughForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = (-20);
        private string Var_genre = "";//记录当前操作的类型

        #region 在窗口结构中为指定的窗口设置信息
        /// <summary>
        /// 在窗口结构中为指定的窗口设置信息
        /// </summary>
        /// <param name="hwnd">欲为其取得信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <param name="dwNewLong">由nIndex指定的窗口信息的新值</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        #endregion

        #region 从指定窗口的结构中取得信息
        /// <summary>
        /// 从指定窗口的结构中取得信息
        /// </summary>
        /// <param name="hwnd">欲为其获取信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        #endregion

        #region 使窗口有鼠标穿透功能
        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        private void CanPenetrate()
        {
            uint intExTemp = GetWindowLong(this.Handle, GWL_EXSTYLE);
            uint oldGWLEx = SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;//窗体不出现在Windows任务栏中
            CanPenetrate();
            this.TopMost = true;//使窗体始终在其它窗体之上
        }

        #region 设置颜色和透明度的状态
        /// <summary>
        /// 设置颜色和透明度的状态
        /// </summary>
        private void SetEstate(Form Frm, object sender)
        {
            Var_genre = ((ToolStripMenuItem)sender).Name;
            string Tem_Str = Var_genre;
            if (Var_genre.IndexOf('_') >= 0)
            {
                Var_genre = Tem_Str.Substring(0, Tem_Str.IndexOf('_'));
            }

            switch (Var_genre)
            {
                case "ToolColor":
                    {
                        Color Tem_Color=Color.Gainsboro;
                        switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
                        {
                            case 1: Tem_Color = Color.Gainsboro; break;
                            case 2: Tem_Color = Color.DarkOrchid; break;
                            case 3: Tem_Color = Color.RoyalBlue; break;
                            case 4: Tem_Color = Color.Gold; break;
                            case 5: Tem_Color = Color.LightGreen; break;
                        }
                        Frm.BackColor = Tem_Color;
                        break;
                    }
                case "ToolClarity":
                    {
                        double Tem_Double = 0.0;
                        switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
                        {
                            case 1: Tem_Double = 0.1; break;
                            case 2: Tem_Double = 0.2; break;
                            case 3: Tem_Double = 0.3; break;
                            case 4: Tem_Double = 0.4; break;
                            case 5: Tem_Double = 0.5; break;
                            case 6: Tem_Double = 0.6; break;
                            case 7: Tem_Double = 0.7; break;
                            case 8: Tem_Double = 0.8; break;
                            case 9: Tem_Double = 0.9; break;

                        }
                        Frm.Opacity = Tem_Double;
                        break;
                    }
                case "ToolAcquiescence":
                    {
                        Frm.BackColor = Color.Gainsboro;
                        Frm.Opacity = 0.6;
                        break;
                    }
                case "ToolClose":
                    {
                        Close();
                        break;
                    }

            }
        }
        #endregion

        private void ToolColor_Glass_Click(object sender, EventArgs e)
        {
            SetEstate(this, sender);
        }
    }
}
