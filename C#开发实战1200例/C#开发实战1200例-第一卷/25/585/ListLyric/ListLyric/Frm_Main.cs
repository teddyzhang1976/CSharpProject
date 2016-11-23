using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ListLyric
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 当单击“退出”按钮时
        private void exit_Click(object sender,EventArgs e)
        {
            Application.Exit(); //退出应用程序
        }
        #endregion

        #region 当有歌词存在时直接加载
        private void ListLyric_Load(object sender,EventArgs e)
        {
            if(File.Exists("青花瓷.lrc"))//当存在歌词“青花瓷”时
            {
                listLyric("青花瓷.lrc");//在RichTextBox中显示已存在的歌词
            }
        }
        #endregion

        #region  获取MP3的歌词
        /// <summary>
        /// 获取MP3的歌词
        /// </summary>
        /// <param FileName="string">歌词路径</param>
        public string[] LRC_Lyric(string FileName)
        {
            ArrayList ArrLyric = new ArrayList();//声明一个使用大小可动态增加的数组对象
            FileStream fs = new FileStream(@FileName,FileMode.Open,FileAccess.Read,FileShare.None);//定义一个公开以文件为主的 Stream，既支持同步读写操作，也支持异步读写操作的对象。
            StreamReader sr = new StreamReader(fs,System.Text.Encoding.Default);//声明一个读取数据的对象
            sr.BaseStream.Seek(0,SeekOrigin.Begin);//从指定的起始点开始读取数据
            string Tem_strLine = sr.ReadLine();//读取当前流中的一行数据
            string Tem_Str = "";//定义一个string型临时变量Tem_Str
            string sp = "";//定义一个string型临时变量sp
            int Tem_p = 0;//记录当前[的位置
            int Tem_q = 0;//记录当前]的位置
            string Tem_Time = "";//记录播放时间
            string Tem_Slyrec = "";//记录歌词
            bool Tem_bool = true;//循环条件

            while(Tem_strLine != null) //只要当前流中还存在数据就继续循环
            {
                Tem_bool = true; //设定Tem_bool的值为true
                Tem_Str = Tem_strLine;//为变量Tem_Str赋值
                sp = Tem_strLine;//为变量sp赋值
                if(sp.IndexOf(Convert.ToChar("[")) == -1 || sp.Trim() == "")//当"["字符在此字符串中的第一个匹配项的索引为-1或当从当前 String 对象的开始和末尾移除所有空白字符后保留的字符串为空值时
                {
                    Tem_strLine = sr.ReadLine();//继续从流中读取数据
                    continue;//跳出此层循环
                }

                sp = sp.Substring(sp.IndexOf(Convert.ToChar("[")) + 1,1);//从此实例检索子字符串。子字符串从指定的字符位置开始且具有指定的长度
                Tem_Slyrec = Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1,Tem_Str.Length - (Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1));//截取歌词中“[”和“]”中的内容
                if(EstimateFig(sp))//当字符串中存在数字时
                {
                    while(Tem_bool)//只要Tem_bool为真就不断的循环
                    {
                        Tem_p = Tem_Str.IndexOf(Convert.ToChar("["));//获取字符“[”的索引
                        Tem_q = Tem_Str.IndexOf(Convert.ToChar("]"));//获取字符“]”的索引
                        Tem_Time = Tem_Str.Substring(Tem_p + 1,Tem_q - Tem_p - 1);//获取当前行的播放时间
                        ArrLyric.Add(Tem_Time + "|" + Tem_Slyrec); //在播放时间和歌词之间添加“|”
                        if(Tem_q != Tem_Str.LastIndexOf(Convert.ToChar("]"))) //当没有循环到字符串的结尾时
                            Tem_Str = Tem_Str.Substring(Tem_q + 1,Tem_Str.Length - Tem_q - 1);//保存字符串的值
                        else                  //当循环到结尾时
                            Tem_bool = false;//设置Tem_bool的值为false
                    }
                }
                Tem_strLine = sr.ReadLine();//从当前流中读取一行数据
            }
            sr.Dispose(); //释放由sr对象使用的所有资源
            fs.Dispose(); //释放由fs对象使用的所有资源

            int Tem_DatetimeUp;//记录前一个时间
            int Tem_DstetimeDown;//记录后一个时间
            string Tem_taxisTime = "";//记当截取后的时间字符串
            string Tem_Transitorily = "";//排序时临时存储的字符串
            string[] ArrayStr = new string[ArrLyric.Count];//定义一个string型的数组ArrayStr
            for(int i = 0; i < ArrayStr.Length; i++)//循环遍历数组ArrayStr中的每一个元素
            {
                Tem_Str = ArrLyric[i].ToString();//记录数组ArrayStr中的元素
                Tem_taxisTime = Tem_Str.Substring(0,Tem_Str.LastIndexOf(Convert.ToChar("|")));//截取歌词的播放时间
                Tem_taxisTime = BuildMillisecond(Tem_taxisTime);//保存歌词的播放时间总数
                ArrayStr[i] = Tem_taxisTime + "|" + Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("|")) + 1,Tem_Str.Length - Tem_Str.LastIndexOf(Convert.ToChar("|")) - 1);//将时间和歌词内容赋值给字符数组ArrayStr
            }
            string iStr = "";//定义一个string型的变量iStr
            string jStr = "";//定义一个string型的变量jStr
            for(int i = 0; i < ArrayStr.Length - 2; i++) //循环遍历数组ArrayStr中的每一行数据
            {
                for(int j = 0; j < ArrayStr.Length - 1 - i; j++)//循环遍历数组ArrayStr中的每一行数据
                {
                    iStr = ArrayStr[j];//记录数组ArrayStr中的当前数据
                    jStr = ArrayStr[j + 1];//记录数组ArrayStr中的下一条数据
                    Tem_taxisTime = iStr.Substring(0,iStr.LastIndexOf(Convert.ToChar("|")));//截取当前行中的时间部分
                    Tem_DatetimeUp = Convert.ToInt32(Tem_taxisTime);//将时间类型转化为整型
                    Tem_taxisTime = jStr.Substring(0,jStr.LastIndexOf(Convert.ToChar("|")));//截取下一行中的时间部分
                    Tem_DstetimeDown = Convert.ToInt32(Tem_taxisTime);//将时间类型转化为整型
                    if(Tem_DstetimeDown < Tem_DatetimeUp) //当下一行的时间小于当前行的时间
                    {
                        Tem_Transitorily = ArrayStr[j];//记录当前行的时间
                        ArrayStr[j] = ArrayStr[j + 1];//为当前行的时间重新赋值
                        ArrayStr[j + 1] = Tem_Transitorily;//为下一行的时间赋值
                    }
                }
            }
            return ArrayStr;//返回数组ArrayStr
        }
        #endregion

        #region  在字符串中截取数字
        /// <summary>
        /// 在字符串中截取数字
        /// </summary>
        /// <param Istr="string">包含数字的字符串</param>
        public bool EstimateFig(string Istr)
        {
            string Tem_Sint = "";//定义一个string型变量Tem_Sint
            bool Tem_Bool = false;//定一个Tem_Bool型变量Tem_Bool
            CharEnumerator Tem_CharEnum = Istr.GetEnumerator();//定义一个支持循环访问 String 对象并读取它的各个字符的对象
            while(Tem_CharEnum.MoveNext())//循环访问字符串中的每一个字符
            {
                byte[] Tem_byte = new byte[1];//定义一个字节型数组
                Tem_byte = System.Text.Encoding.ASCII.GetBytes(Tem_CharEnum.Current.ToString());//保存当前字符串的编码类型
                int Tem_ASCII_Code = (short)(Tem_byte[0]);//将字节数组中的字符转化为int型的
                if(Tem_ASCII_Code >= 48 && Tem_ASCII_Code <= 57)//当该字符为数字时
                    Tem_Sint += Tem_CharEnum.Current.ToString();//保存该字符的值
            }
            if(Tem_Sint != "")//当变量Tem_Sint的值不为空时
                Tem_Bool = true;//设定Tem_Bool的值为true
            return Tem_Bool;//返回Tem_Bool的值
        }
        #endregion

        #region  计算时间的毫秒数
        /// <summary>
        /// 计算时间的毫秒数
        /// </summary>
        /// <param Istr="string">时间</param>
        public string BuildMillisecond(string Istr)
        {
            string Tem_Value = ""; //定义一个string型的变量Tem_Value
            int Tem_Cent = 0;//定义一个int型的变量Tem_Cent
            int Tem_Sec = 0;//定义一个int型的变量Tem_Sec
            int Tem_Mill = 0;//定义一个int型的变量Tem_Mill
            Tem_Cent = Convert.ToInt32(Istr.Substring(0,Istr.IndexOf(Convert.ToChar(":"))));//获取歌词播放多少分钟
            Tem_Sec = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(":")) + 1,Istr.IndexOf(Convert.ToChar(".")) - Istr.IndexOf(Convert.ToChar(":")) - 1));//获取歌词播放的秒数
            Tem_Mill = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(".")) + 1,Istr.Length - Istr.IndexOf(Convert.ToChar(".")) - 1));//获取歌词的播放毫秒数
            Tem_Cent = Tem_Cent * 60000 + Tem_Sec * 1000 + Tem_Mill;//计算歌词播放的总时间数
            Tem_Value = Tem_Cent.ToString();//保存歌词的播放时间
            return Tem_Value;//返回歌词的播放时间
        }
        #endregion

        #region 打开歌曲的歌词
        private void unfold_Click(object sender,EventArgs e)
        {
            string filePath = null;//定义一个字符串，并为其赋值为null
            OpenFileDialog LyricDialog = new OpenFileDialog();//定义一个提示用户打开文件对象
            LyricDialog.Filter = "LRC文件（*.LRC）|*.LRC";//设置打开文件的过滤参数
            if(LyricDialog.ShowDialog() == DialogResult.OK)//当用户选定所要打开的文件点击“打开”按钮时
            {
                filePath = LyricDialog.FileName;//将选定文件的路径名称赋值给变量filePath
                listLyric(filePath);//显示指定路径下的歌词
                unfold.Enabled = false;//设置打开按钮的可用状态为不可用
            }
        }
        #endregion

        #region 自定义显示歌词的ListLyric方法
        private void listLyric(string lyricName)
        {
            ArrayList GetArrLyric = new ArrayList();//声明一个使用大小可动态增加的数组对象
            GetArrLyric = new ArrayList(LRC_Lyric(lyricName));//为声明的动态数组对象赋值
            for(int i = 0; i < GetArrLyric.Count; i++)//循环遍历数组中的每一个元素
            {
                richTextBox1.Text += GetArrLyric[i].ToString() + "\r";//将读出的内容显示在RichTextBox中
            }
        }
        #endregion

    }
}