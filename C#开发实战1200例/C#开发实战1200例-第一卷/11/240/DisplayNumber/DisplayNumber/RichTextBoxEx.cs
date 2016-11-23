using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//该命名空间提供各种各样支持 COM interop 及平台调用服务的成员

namespace DisplayNumber
{
    class RichTextBoxEx:RichTextBox 
    {
        #region
        public RichTextBoxEx()
        {
            this.Top = 13;//设置自定义控件与其容器工作区上边缘之间的距离
            this.Left = 5;//设置自定义控件与其容器工作区左边缘之间的距离
            this.Height = 186;//设置自定义控件的高度
            this.Width = 371;//设置自定义控件的宽度
        }

        [StructLayout(LayoutKind.Sequential)]
        private class PARAFORMAT2
        {
            public int cbSize;//用来保存该类型的大小
            public int dwMask;  //标识操作文本的方式
            public short wNumbering; //标识项目编号
            public int dxStartIndent;//标识文本的起始缩进量
            public int dxRightIndent;//标识文本的右缩进
            public int dxOffset; //标识项目编号的偏移量
            public short wAlignment;//标识文本的对齐方式
            [MarshalAs(UnmanagedType.ByValArray,SizeConst = 0x20)]
            public int[] rgxTabs;//定义一个整型数组

            public int dySpaceBefore;//用来表示编号前的纵向间隔
            public int dySpaceAfter;//用来表示编号后的纵向间隔
            public int dyLineSpacing;//按指定的规则编号后的行间隔
            public short sStyle;//样式句柄
            public byte bLineSpacingRule;//行间隔的规则
            public short wShadingWeight;//设置偏移量
            public short wShadingStyle;//设置偏移后的样式
            public short wNumberingStart;//设置项目编号的其实质
            public short wNumberingStyle;//设置项目编号的样式
            public short wNumberingTab;//设置按Tab键的偏移量
            public short wBorderSpace;//设置边框占据的空间
            public short wBorderWidth;//设置边框占据的宽度

            public PARAFORMAT2()
            {
                this.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));//
            }
        }

        #region PARAFORMAT MASK VALUES
        private const uint PFM_OFFSET = 0x00000004;//设置项目符号的偏移量
        private const uint PFM_NUMBERING = 0x00000020;//设置编号方式

        private const uint PFM_NUMBERINGSTYLE = 0x00002000;//设置项目编号的样式
        private const uint PFM_NUMBERINGTAB = 0x00004000;//设置项目编号按下Tab键的信息
        private const uint PFM_NUMBERINGSTART = 0x00008000;//设置项目编号的开始标识

        public enum AdvRichTextBulletType
        {
            Normal = 1,//设置项目符号的标识为1
            Number = 2, //设置项目编号的标识为2
            LowerCaseLetter = 3,//设置小写英文编号的标识为3
            UpperCaseLetter = 4,//设置大写英文编号的表示为4
            LowerCaseRoman = 5,//设置小写罗马数字的标识为5
            UpperCaseRoman = 6 //设置大写罗马数字的标识为6
        }

        public enum AdvRichTextBulletStyle
        {
            RightParenthesis = 0x000,//在文本的右边加圆括号
            DoubleParenthesis = 0x100,//在文本的右边加双括号
            Period = 0x200,//在文本的旁边加点
            Plain = 0x300,//设置文本为无格式
            NoNumber = 0x400//设置样式为无数字
        }
        #endregion

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam,
           [In,Out,MarshalAs(UnmanagedType.LPStruct)] PARAFORMAT2 lParam);//定义一个向窗口进程发送消息的API函数

        private AdvRichTextBulletType _BulletType = AdvRichTextBulletType.Number;//设定项目编号的起始类型
        private AdvRichTextBulletStyle _BulletStyle = AdvRichTextBulletStyle.Period;//设定项目编号的起始样式
        private short _BulletNumberStart = 1;//设定项目编号的起始数字为1


        public AdvRichTextBulletType BulletType
        {
            get { return _BulletType; }//返回项目符号的类型
            set
            {
                _BulletType = value;//为项目符号的类型赋值
                NumberedBullet(true);//设定新实例的各个属性
            }
        }
        public AdvRichTextBulletStyle BulletStyle
        {
            get { return _BulletStyle; }//返回项目符号的样式
            set
            {
                _BulletStyle = value;//为项目符号样式设定值
                NumberedBullet(true);//设定新实例的各个属性
            }
        }
        public void NumberedBullet(bool TurnOn)
        {
            PARAFORMAT2 paraformat1 = new PARAFORMAT2();//初始化类PARAFORMAT2的一个新实例
            paraformat1.dwMask = (int)(PFM_NUMBERING | PFM_OFFSET | PFM_NUMBERINGSTART |
                PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB);//设置实例的dwMask属性
            if(!TurnOn)//当和TurnOn的初始值相反时
            {
                paraformat1.wNumbering = 0;//设置wNumbering属性为0
                paraformat1.dxOffset = 0;//设置dxOffset属性为0
            }
            else//当和TurnOn的初始值相同时
            {
                paraformat1.wNumbering = (short)_BulletType;//设置wNumbering的值
                paraformat1.dxOffset = this.BulletIndent;//设置dxOffset的值
                paraformat1.wNumberingStyle = (short)_BulletStyle;//设置项目编号的样式
                paraformat1.wNumberingStart = _BulletNumberStart;//设置项目编号的起始位置
                paraformat1.wNumberingTab = 500;//设置按Tab键文本移动的距离
            }
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, this.Handle),
                0x447,0,paraformat1);//发送指定的消息
        }
        #endregion
    }
}
