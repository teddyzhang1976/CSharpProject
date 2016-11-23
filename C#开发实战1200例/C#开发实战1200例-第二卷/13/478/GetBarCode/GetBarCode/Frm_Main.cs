using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace BarCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 实例化全局类对象和变量
        private Bitmap mImage;          //声明位图对象
        public string path;				//INI文件名
        #endregion

        #region 将一幅位图从一个设备场景复制到另一个
        /// <summary>
        /// 将一幅位图从一个设备场景复制到另一个
        /// </summary>
        /// <param name="hdcDest">目标设备场景</param>
        /// <param name="nXDest">对目标DC中目标矩形左上角位置进行描述的那个点,用目标DC的逻辑X坐标表示</param>
        /// <param name="nYDest">对目标DC中目标矩形左上角位置进行描述的那个点,用目标DC的逻辑Y坐标表示</param>
        /// <param name="nWidth">欲传输图象的宽度</param>
        /// <param name="nHeight">欲传输图象的高度</param>
        /// <param name="hdcSrc">源设备场景,如光栅运算未指定源，则应设为0</param>
        /// <param name="nXSrc">对源DC中源矩形左上角位置进行描述的那个点用源DC的逻辑X坐标表示</param>
        /// <param name="nYSrc">对源DC中源矩形左上角位置进行描述的那个点用源DC的逻辑Y坐标表示</param>
        /// <param name="dwRop">传输过程要执行的光栅运算</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,int nXDest,int nYDest,int nWidth,
            int nHeight,IntPtr hdcSrc,int nXSrc,int nYSrc,int dwRop);
        #endregion

        #region 修改INI文件中内容
        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="section">欲在其中写入的节点名称</param>
        /// <param name="key">欲设置的项名</param>
        /// <param name="val">要写入的新字符串</param>
        /// <param name="filePath">INI文件名</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
                    string val, string filePath);
        #endregion

        #region 为INI文件中指定的节点取得字符串
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="section">欲在其中查找关键字的节点名称</param>
        /// <param name="key">欲获取的项名</param>
        /// <param name="def">指定的项没有找到时返回的默认值</param>
        /// <param name="retVal">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="size">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="filePath">INI文件名</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
                    StringBuilder retVal, int size, string filePath);
        #endregion

        #region 向INI文件中写入内容
        /// <summary>
        /// 向INI文件中写入内容
        /// </summary>
        /// <param name="Section">节点名称</param>
        /// <param name="Key">项名</param>
        /// <param name="Value">要写入项的内容</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
        #endregion

        #region 读取INI文件内容
        /// <summary>
        /// 读取INI文件内容
        /// </summary>
        /// <param name="Section">节点名称</param>
        /// <param name="Key">项名</param>
        /// <returns>返回INI项的内容</returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //记录INI配置文件路径
            string strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\SystemSet.ini";
            path = strg;
            try
            {
                //显示样式
                cbbstyle.SelectedIndex = Convert.ToInt32(IniReadValue("xiaoke", "style"));
                //显示子演示
                cbbZstyle.SelectedIndex = Convert.ToInt32(IniReadValue("xiaoke", "Substyle"));
                //显示方向
                cbbdirection.SelectedIndex = Convert.ToInt32(IniReadValue("xiaoke", "direction"));
                //显示线条宽度
                cbbWidth.SelectedIndex = Convert.ToInt32(IniReadValue("xiaoke", "width"));
                //显示校验位
                cbbTrue.SelectedIndex = Convert.ToInt32(IniReadValue("xiaoke", "cbbTrue"));
                //判断默认条形码是否显示数据
                int i=Convert.ToInt32(IniReadValue("xiaoke", "dispaly"));
                if (i == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            captureScreen();                                    //绘制条形码
            printPreviewDialog1.ShowDialog();                   //显示打印预览对话框
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axBarCodeCtrl1.Value = txtBarCode.Text.Trim();      //生成条形码
        }        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(mImage,200,50);                //打印条形码
        }

        //是否显示数据
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                axBarCodeCtrl1.ShowData = 1;
                IniWriteValue("xiaoke", "dispaly","1");
            }
            else
            {
                axBarCodeCtrl1.ShowData= 0;
                IniWriteValue("xiaoke", "dispaly","0");
            }
        }

        //设置条形码方向
        private void cbbdirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbdirection.SelectedIndex;
            switch (i)
            {
                case 0: axBarCodeCtrl1.Direction = 0; break;
                case 1: axBarCodeCtrl1.Direction = 1; break;
                case 2: axBarCodeCtrl1.Direction = 2; break;
                case 3: axBarCodeCtrl1.Direction = 3; break;
            }
            IniWriteValue("xiaoke", "direction", i.ToString());
        }

        //设置条形码线条宽度
        private void cbbWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbWidth.SelectedIndex;
            switch (i)
            {
                case 0: axBarCodeCtrl1.LineWeight = 0; break;
                case 1: axBarCodeCtrl1.LineWeight = 1; break;
                case 2: axBarCodeCtrl1.LineWeight = 2; break;
                case 3: axBarCodeCtrl1.LineWeight = 3; break;
                case 4: axBarCodeCtrl1.LineWeight = 4; break;
                case 5: axBarCodeCtrl1.LineWeight = 5; break;
                case 6: axBarCodeCtrl1.LineWeight = 6; break;
                case 7: axBarCodeCtrl1.LineWeight = 7; break;
            }
            IniWriteValue("xiaoke", "width", i.ToString());
        }

        //设置条形码样式
        private void cbbstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbstyle.SelectedIndex;
            switch (i)
            {
                case 0: axBarCodeCtrl1.Style = 0; break;
                case 1: axBarCodeCtrl1.Style = 1; break;
                case 2: axBarCodeCtrl1.Style = 2; break;
                case 3: axBarCodeCtrl1.Style = 3; break;
                case 4: axBarCodeCtrl1.Style = 4; break;
                case 5: axBarCodeCtrl1.Style = 5; break;
                case 6: axBarCodeCtrl1.Style = 6; break;
                case 7: axBarCodeCtrl1.Style = 7; break;
                case 8: axBarCodeCtrl1.Style = 8; break;
                case 9: axBarCodeCtrl1.Style = 9; break;
                case 10: axBarCodeCtrl1.Style = 10; break;
            }

            IniWriteValue("xiaoke", "style", i.ToString());
        }

        //设置条形码子样式
        private void cbbZstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbZstyle.SelectedIndex;
            switch (i)
            {
                case 0: axBarCodeCtrl1.SubStyle = 0; break;
                case 1: axBarCodeCtrl1.SubStyle = 1; break;
                case 2: axBarCodeCtrl1.SubStyle = 2; break;
                case 3: axBarCodeCtrl1.SubStyle = 3; break;
            }
            IniWriteValue("xiaoke", "Substyle", i.ToString());
        }

        //设置条形码校验位
        private void cbbTrue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbTrue.SelectedIndex;
            switch (i)
            {
                case 0: axBarCodeCtrl1.Validation = 0; break;
                case 1: axBarCodeCtrl1.Validation = 1; break;
                case 2: axBarCodeCtrl1.Validation = 2; break;
            }
            IniWriteValue("xiaoke", "cbbTrue", i.ToString());
        }

        #region 绘制条形码
        /// <summary>
        /// 绘制条形码
        /// </summary>
        private void captureScreen()
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                Size s = panel1.Size;//得到面板的高度和宽度
                mImage = new Bitmap(s.Width, s.Height, g);//创建Bitmap对象
                using (Graphics mg = Graphics.FromImage(mImage))
                {
                    IntPtr dc1 = g.GetHdc();//获取上下文句柄
                    IntPtr dc2 = mg.GetHdc();//获取上下文句柄
                    BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width,//得到面板中的图像
                        panel1.ClientRectangle.Height, dc1, 0, 0, 13369376);
                    g.ReleaseHdc(dc1);//释放上下文句柄
                    mg.ReleaseHdc(dc2);//释放上下文句柄
                }
            }
        }
        #endregion
    }
}
