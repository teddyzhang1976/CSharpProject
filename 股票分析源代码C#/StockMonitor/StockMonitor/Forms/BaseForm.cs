using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;

namespace StockMonitor.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);
            this.menuBar.MouseDoubleClick += new MouseEventHandler(menuBar_MouseDoubleClick);
            this.lblMin.Paint += new PaintEventHandler(lblMin_Paint);
            this.lblMax.Paint += new PaintEventHandler(lblMax_Paint);
            this.lblClose.Paint += new PaintEventHandler(lblClose_Paint);
            this.lblMin.MouseMove+=new MouseEventHandler(button_MouseMove);
            this.lblMin.MouseLeave+=new EventHandler(button_MouseLeave);
            this.lblMax.MouseMove += new MouseEventHandler(button_MouseMove);
            this.lblMax.MouseLeave += new EventHandler(button_MouseLeave);
            this.lblClose.MouseMove += new MouseEventHandler(button_MouseMove);
            this.lblClose.MouseLeave += new EventHandler(button_MouseLeave);
            this.lblMin.MouseDown += new MouseEventHandler(lblMin_MouseDown);
            this.lblMax.MouseDown += new MouseEventHandler(lblMax_MouseDown);
            this.lblClose.MouseDown += new MouseEventHandler(lblClose_MouseDown);
            this.Paint += new PaintEventHandler(CustomForm_Paint);
            this.Resize += new EventHandler(CustomForm_Resize);
            this.MouseDown+=new MouseEventHandler(CustomForm_MouseDown);
            this.MouseUp += new MouseEventHandler(CustomForm_MouseUp);
            this.MouseMove+=new MouseEventHandler(CustomForm_MouseMove);
            this.MouseLeave+=new EventHandler(CustomForm_MouseLeave);
            //设置最大化的尺寸
            this.MaximumSize = new Size(Screen.GetWorkingArea(this).Width, Screen.GetWorkingArea(this).Height);
            this.Resize += new EventHandler(BaseForm_Resize);
            //设置最小化的尺寸
            this.MinimumSize = new Size(200, 100);
            setTaskBarMenu();
            currentWindowState = this.WindowState;
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            this.lblMin.Location = new Point(this.Width - 78, 3);
            this.lblMax.Location = new Point(this.Width - 53, 3);
            this.lblClose.Location = new Point(this.Width - 28, 3);
        }

        /// <summary>
        /// Get the GraphicsPath by cornerRadius and Rectangle.
        /// </summary>
        /// <param name="cornerRadius"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public GraphicsPath GetGraphicsPath(int cornerRadius, Rectangle rect)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        /// <summary>
        /// 改变窗体大小事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// 绘制菜单的标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SizeF sf = g.MeasureString(this.Text, new Font("New Times Roman", 10.5f));
            float x = (menuBar.Size.Width - sf.Width) / 2;
            float y = (menuBar.Size.Height - sf.Height) / 2;
            g.DrawString(this.Text, new Font("Tahoma", 9f, FontStyle.Bold), new SolidBrush(Color.FromArgb(55, 30, 130)), x, y);
        }

        /// <summary>
        /// 当前的窗体状态
        /// </summary>
        FormWindowState currentWindowState;

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMax_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                setMaxOrNormal();
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
                this.currentWindowState = this.WindowState;
            }
        }

        /// <summary>
        /// 双击菜单最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                setMaxOrNormal();
            }
        }

        private void setMaxOrNormal()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.currentWindowState = this.WindowState;
            lblMax.Invalidate();
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        ///任务栏右键菜单
        private void setTaskBarMenu()
        {
            int WS_SYSMENU = 0x00080000;
            int WS_MINIMIZEBOX = 0x20000;
            int windowLong = (GetWindowLong(new HandleRef(this, this.Handle), -16));
            SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
        }

        /// <summary>
        /// 绘制窗体的边线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Raised);
        }

        /// <summary>
        /// 绘制关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen outerPen = new Pen(Color.FromArgb(81, 117, 165));
            Brush innerBrush = new SolidBrush(Color.White);
            Brush bgBrush = new SolidBrush(Color.FromArgb(175, 202, 240));
            Label closeButton = sender as Label;
            Rectangle rect = new Rectangle(0, 0, lblClose.Width, lblClose.Height);
            LinearGradientBrush lgb;
            GraphicsPath roundedRect = GetGraphicsPath(4, new Rectangle(0, 0, lblClose.Width - 1, lblClose.Height - 1));
            if (closeButton.Tag != null && Convert.ToBoolean(closeButton.Tag) == true)
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(155, 185, 220), Color.FromArgb(159, 194, 255), 90);
                g.FillRectangle(lgb, rect);
            }
            else
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(212, 228, 250), Color.FromArgb(139, 175, 229), 90);
            }
            g.FillRectangle(lgb, rect);
            g.DrawPath(outerPen, roundedRect);
            roundedRect.Dispose();
            roundedRect = new GraphicsPath();
            roundedRect.AddLine(7, 13, 5, 11);
            roundedRect.AddLine(5, 11, Convert.ToSingle(11 - Math.Sqrt(2)), 8);
            roundedRect.AddLine(Convert.ToSingle(11 - Math.Sqrt(2)), 8, 5, 5);
            roundedRect.AddLine(5, 5, 7, 3);
            roundedRect.AddLine(7, 3, 11, Convert.ToSingle(8 - Math.Sqrt(2)));
            roundedRect.AddLine(11, Convert.ToSingle(8 - Math.Sqrt(2)), 15, 3);
            roundedRect.AddLine(15, 3, 17, 5);
            roundedRect.AddLine(17, 5, Convert.ToSingle(11 + Math.Sqrt(2)), 8);
            roundedRect.AddLine(Convert.ToSingle(11 + Math.Sqrt(2)), 8, 17, 11);
            roundedRect.AddLine(17, 11, 15, 13);
            roundedRect.AddLine(15, 13, 11, Convert.ToSingle(8 + Math.Sqrt(2)));
            roundedRect.CloseFigure();
            g.FillPath(innerBrush, roundedRect);
            g.DrawPath(outerPen, roundedRect);
            roundedRect.Dispose();
            outerPen.Dispose();
            innerBrush.Dispose();
            bgBrush.Dispose();
        }

        /// <summary>
        /// 绘制最大化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMax_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen outerPen = new Pen(Color.FromArgb(81, 117, 165));
            Brush innerBrush = new SolidBrush(Color.White);
            Brush bgBrush = new SolidBrush(Color.FromArgb(175, 202, 240));
            Rectangle rect = new Rectangle(0, 0, lblMax.Width, lblMax.Height);
            Label maxButton = sender as Label;
            LinearGradientBrush lgb;
            GraphicsPath roundedRect = GetGraphicsPath(4, new Rectangle(0, 0, lblMax.Width - 1, lblMax.Height - 1));
            if (maxButton.Tag != null && Convert.ToBoolean(maxButton.Tag) == true)
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(155, 185, 220), Color.FromArgb(159, 194, 255), 90);
            }
            else
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(212, 228, 250), Color.FromArgb(139, 175, 229), 90);
            }
            g.FillRectangle(lgb, rect);
            g.DrawPath(outerPen, roundedRect);
            roundedRect.Dispose();

            if (this.WindowState == FormWindowState.Maximized)
            {
                Rectangle outerRightRect = new Rectangle(8, 3, 10, 8);
                roundedRect = GetGraphicsPath(2, outerRightRect);
                g.FillPath(innerBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
                Rectangle innerRightRect = new Rectangle(10, 5, 6, 4);
                roundedRect = GetGraphicsPath(1, innerRightRect);
                g.FillPath(bgBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
                Rectangle outerLeftRect = new Rectangle(4, 6, 10, 8);
                roundedRect = GetGraphicsPath(2, outerLeftRect);
                g.FillPath(innerBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
                Rectangle innerLeftRect = new Rectangle(6, 8, 6, 4);
                roundedRect = GetGraphicsPath(1, innerLeftRect);
                g.FillPath(bgBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                Rectangle outerRect = new Rectangle(5, 3, 12, 10);
                roundedRect = GetGraphicsPath(2, outerRect);
                g.FillPath(innerBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
                Rectangle innerRect = new Rectangle(7, 5, 8, 6);
                roundedRect = GetGraphicsPath(1, innerRect);
                g.FillPath(bgBrush, roundedRect);
                g.DrawPath(outerPen, roundedRect);
                roundedRect.Dispose();
            }
            outerPen.Dispose();
            innerBrush.Dispose();
            bgBrush.Dispose();
            lgb.Dispose();
        }

        /// <summary>
        /// 绘制最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen outerPen = new Pen(Color.FromArgb(81, 117, 165));
            Brush innerBrush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(0, 0, lblMin.Width, lblMin.Height);
            LinearGradientBrush lgb;
            Label minButton = sender as Label;
            GraphicsPath roundedRect = GetGraphicsPath(4, new Rectangle(0, 0, lblMin.Width - 1, lblMin.Height - 1));
            if (minButton.Tag != null && Convert.ToBoolean(minButton.Tag) == true)
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(155, 185, 220), Color.FromArgb(159, 194, 255), 90);
            }
            else
            {
                lgb = new LinearGradientBrush(rect, Color.FromArgb(212, 228, 250), Color.FromArgb(139, 175, 229), 90);
            }
            g.FillRectangle(lgb, new Rectangle(0, 0, lblMin.Width, lblMin.Height));
            g.DrawPath(outerPen, roundedRect);
            Rectangle rectLine = new Rectangle(lblMin.Width / 4 + 1, lblMin.Height / 5 * 4 - 2, 10, 3);
            roundedRect.Dispose();
            roundedRect = GetGraphicsPath(1, rectLine);
            g.FillPath(innerBrush, roundedRect);
            g.DrawPath(outerPen, roundedRect);
            roundedRect.Dispose();
            outerPen.Dispose();
            innerBrush.Dispose();
            lgb.Dispose();
        }

        /// <summary>
        /// 窗体的拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x0112, 0xF010 + 0x0002, 0x000B);
            }
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.Tag = true;
                lbl.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标移出按钮时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.Tag = false;
                lbl.Invalidate();
            }
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (currentWindowState != this.WindowState)
            {
                lblMax.Invalidate();
                currentWindowState = this.WindowState;
            }
            base.WndProc(ref m);
        }
        #region 拖动窗体大小
        internal static class MState
        {
            private static int m_Left;
            private static int m_Top;
            private static int m_Right;
            private static int m_Bottom;
            private static int m_LastX;
            private static int m_LastY;
            private static MouseAction m_State;
            private static MouseAction m_LastState;

            public static int Left
            {
                get { return MState.m_Left; }
            }

            public static int Top
            {
                get { return MState.m_Top; }
            }

            public static int Right
            {
                get { return MState.m_Right; }
            }

            public static int Bottom
            {
                get { return MState.m_Bottom; }
            }

            public static MouseAction State
            {
                get { return MState.m_State; }
            }

            public static int LastX
            {
                get { return MState.m_LastX; }
            }

            public static int LastY
            {
                get { return MState.m_LastY; }
            }

            public static MouseAction LastState
            {
                get { return MState.m_LastState; }
            }

            public static void SetData(Rectangle bounds, Point point)
            {
                m_Left = bounds.Left;
                m_Top = bounds.Top;
                m_Right = bounds.Right;
                m_Bottom = bounds.Bottom;
                m_LastX = point.X;
                m_LastY = point.Y;
                m_LastState = m_State;
            }

            public static void SetState(MouseAction state)
            {
                m_State = state;
            }

            public static void ResetState()
            {
                m_State = MouseAction.None;
                m_LastState = MouseAction.None;
            }
        }

        internal enum MouseAction
        {
            None,
            Left,
            LeftTop,
            Top,
            RightTop,
            Right,
            RightBottom,
            Bottom,
            LeftBottom
        }

        private int m_BorderWidth = 4;

        private void CustomForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                MState.SetData(this.Bounds, Cursor.Position);
            }
        }

        private void CustomForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            { 
                int dx = 0;
                int dy = 0;
                int dr = 0;
                int db = 0;
                Point cp = Cursor.Position;
                if (MState.LastState == MouseAction.Left)
                {
                    dx = cp.X - MState.LastX;
                }
                else if (MState.LastState == MouseAction.Right)
                {
                    dr = cp.X - MState.LastX;
                }
                else if (MState.LastState == MouseAction.Top)
                {
                    dy = cp.Y - MState.LastY;
                }
                else if (MState.LastState == MouseAction.Bottom)
                {
                    db = cp.Y - MState.LastY;
                }
                else if (MState.LastState == MouseAction.LeftTop)
                {
                    dx = cp.X - MState.LastX;
                    dy = cp.Y - MState.LastY;
                }
                else if (MState.LastState == MouseAction.RightTop)
                {
                    dr = cp.X - MState.LastX;
                    dy = cp.Y - MState.LastY;
                }
                else if (MState.LastState == MouseAction.LeftBottom)
                {
                    dx = cp.X - MState.LastX;
                    db = cp.Y - MState.LastY;
                }
                else if (MState.LastState == MouseAction.RightBottom)
                {
                    dr = cp.X - MState.LastX;
                    db = cp.Y - MState.LastY;
                }
                int left = MState.Left + dx;
                int top = MState.Top + dy;
                int right = MState.Right + dr;
                int bottom = MState.Bottom + db;
                if (dx != 0)
                {
                    if (left >= this.Right - MinimumSize.Width)
                    {
                        left = this.Right - MinimumSize.Width;
                    }
                }
                if (dy != 0)
                {
                    if (top >= this.Bottom - MinimumSize.Height)
                    {
                        top = this.Bottom - MinimumSize.Height;
                    }
                }
                if (dr != 0)
                {
                    if (right <= this.Left + MinimumSize.Width)
                    {
                        right = this.Left + MinimumSize.Width;
                    }
                }
                if (db != 0)
                {
                    if (bottom <= this.Top + MinimumSize.Height)
                    {
                        bottom = this.Top + MinimumSize.Height;
                    }
                }
                this.Bounds = Rectangle.FromLTRB(left, top, right, bottom);
                this.Size = new Size(this.Bounds.Width, this.Bounds.Height);
                this.Invalidate();
                MState.ResetState();
            }
            this.Cursor = Cursors.Default;
        }

        Rectangle mouseRect = Rectangle.Empty;

        private void CustomForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.Capture && WindowState != FormWindowState.Maximized)
            {
                MState.SetState(this.setMouse(e.Location));
                return;
            }
        }

        private void CustomForm_MouseLeave(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                this.Cursor = Cursors.Default;
            }
        }

        private MouseAction setMouse(Point point)
        {
            Rectangle rect = this.ClientRectangle;

            if ((point.X <= rect.Left + m_BorderWidth) && (point.Y <= rect.Top + m_BorderWidth))
            {
                this.Cursor = Cursors.SizeNWSE;
                return MouseAction.LeftTop;
            }
            else if ((point.X >= rect.Left + rect.Width - m_BorderWidth) && (point.Y <= rect.Top + m_BorderWidth))
            {
                this.Cursor = Cursors.SizeNESW;
                return MouseAction.RightTop;
            }
            else if ((point.X <= rect.Left + m_BorderWidth) && (point.Y >= rect.Top + rect.Height - m_BorderWidth))
            {
                this.Cursor = Cursors.SizeNESW;
                return MouseAction.LeftBottom;
            }
            else if ((point.X >= rect.Left + rect.Width - m_BorderWidth) && (point.Y >= rect.Top + rect.Height - m_BorderWidth))
            {
                this.Cursor = Cursors.SizeNWSE;
                return MouseAction.RightBottom;
            }
            else if ((point.X <= rect.Left + m_BorderWidth - 1))
            {
                this.Cursor = Cursors.SizeWE;
                return MouseAction.Left;
            }
            else if ((point.X >= rect.Left + rect.Width - m_BorderWidth))
            {
                this.Cursor = Cursors.SizeWE;
                return MouseAction.Right;
            }
            else if ((point.Y <= rect.Top + m_BorderWidth - 1))
            {
                this.Cursor = Cursors.SizeNS;
                return MouseAction.Top;
            }
            else if ((point.Y >= rect.Top + rect.Height - m_BorderWidth))
            {
                this.Cursor = Cursors.SizeNS;
                return MouseAction.Bottom;
            }
            this.Cursor = Cursors.Default;
            return MouseAction.None;
        }
        #endregion
    }
}