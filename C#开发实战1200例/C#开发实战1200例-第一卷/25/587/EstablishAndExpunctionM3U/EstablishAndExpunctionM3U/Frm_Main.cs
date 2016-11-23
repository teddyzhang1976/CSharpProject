using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EstablishAndExpunctionM3U
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 变量声明
        private static string temp = null;//保存打开文件的文件路径
        #endregion

        #region  创建m3u文件
        /// <summary>
        /// 创建m3u文件
        /// </summary>
        /// <param FileDir="string">m3u路径</param>
        public void m3uCreate(string FileDir)
        {
            FileStream fs;//声明一个公开以文件为主的 Stream对象，既支持同步读写操作，也支持异步读写操作
            Byte[] info;//声明一个字节数组
            if(File.Exists(FileDir)) //如果文件存在,则退出操作
            {
                MessageBox.Show("文件已存在，请重新设置文件名！");//弹出信息提示
                return;//直接返回
            }
            else    //如果文件不存在,则创建File.CreateText对象
            {
                fs = File.Create(FileDir);//创建M3U文件
            }
            info = new UTF8Encoding(true).GetBytes("#EXTM3U");//定义M3U文件的编码方式
            fs.Write(info,0,info.Length);//向数据流中写入内容
            fs.Close();//关闭FileStream对象
            fs.Dispose();//释放FileStream对象所占用的资源
        }
        #endregion

        #region  写入m3u文件
        /// <summary>
        /// 写入m3u文件
        /// </summary>
        /// <param FName="string">播放文件名</param>
        /// <param FDir="string">播放文件路径</param>
        /// <param FileDir="string">m3u路径</param>
        public void m3uWrite(string FName,string FDir,string FileDir)
        {
            if(!File.Exists(FileDir))//当不存在文件路径时
            {
                MessageBox.Show("文件不存在！");//弹出信息提示
                return;//直接返回
            }
            StreamWriter ASW = new StreamWriter(FileDir,true,Encoding.Default);//定义实现一个 TextWriter对象，使其以一种特定的编码向流中写入字符
            ASW.WriteLine();//将行结束符写入文本流
            ASW.Write(FDir,Encoding.Default);//将数据流中的文件以特定的编码方式写入指定路径中的文件
            ASW.Flush();//清理当前编写器的所有缓冲区，并使所有缓冲数据写入基础流
            ASW.Close();//关闭当前的 StreamWriter 对象和基础流
            ASW.Dispose();//释放由此 TextWriter 对象使用的所有资源
        }
        #endregion

        #region  删除m3u文件
        /// <summary>
        /// 删除m3u文件
        /// </summary>
        /// <param FileDir="string">m3u路径</param>
        public void m3uDelete(string FileDir)
        {
            if(!File.Exists(FileDir))//当不存在文件路径时
            {
                MessageBox.Show("文件不存在!");//弹出信息提示
                return;//直接返回
            }
            File.Delete(FileDir);//删除指定路径下的文件

        }
        #endregion

        #region 当单击“创建”按钮时
        private void found_Click(object sender,EventArgs e)
        {
            SaveFileDialog M3UDialog = new SaveFileDialog();//声明一个提示用户选择文件的保存位置对象
            M3UDialog.Filter = "M3U文件(*.M3U)|*.M3U";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。 （继承自 FileDialog。）
            if(M3UDialog.ShowDialog() == DialogResult.OK)//当选定保存位置，点击“保存”按钮时
            {
                m3uCreate(M3UDialog.FileName);//创建一个M3U文件
                M3UName.Text = "恭喜你，创建成功！";//在文本框中显示提示信息
                M3UName.ForeColor = Color.Red;//设定文本框中文字的颜色
                M3UName.BackColor = Color.Black;//设定文本框的背景颜色
                found.Enabled = false;//设定“创建”按钮为不可用状态
            }
            else          //当选择“取消”按钮时
            {
                found.Enabled = true; //设置“创建”按钮为可用状态
                M3UName.Text = "对不起，创建失败！";//在文本框中显示提示信息
                M3UName.ForeColor = Color.Red;//设定文本框中字体的颜色
                M3UName.BackColor = Color.Black;//设定文本框中的背景颜色
            }
        }
        #endregion

        #region 当单击打开M3U文件的“打开”按钮时
        private void openM3U_Click(object sender,EventArgs e)
        {
            M3UPath.Text = ListM3UFile();//在文本框中显示M3U文件的路径
        }
        #endregion

        #region 自定义一个打开M3U文件方法
        private string ListM3UFile()
        {
            OpenFileDialog M3U_Dialog = new OpenFileDialog(); //声明一个提示用户打开文件的对象
            M3U_Dialog.Filter = "M3U文件(*.M3U)|*.M3U"; //获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。 （继承自 FileDialog。）
            if(M3U_Dialog.ShowDialog() == DialogResult.OK)//当选定文件之后单击“打开”按钮时
            {
                temp = M3U_Dialog.FileName;//保存所打开的文件名
            }
            return temp;//返回保存的值
        }
        #endregion

        #region 单击打开歌曲的“打开”按钮时
        private void openMusic_Click(object sender,EventArgs e)
        {
            OpenFileDialog MusicDialog = new OpenFileDialog();//声明一个提示用户打开文件的对象
            MusicDialog.Filter = "MP3文件(*.MP3)|*.MP3|WAV文件(*.WAV)|*.WAV|WMA文件(*.WMA)|*.WMA";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。 （继承自 FileDialog。）
            if(MusicDialog.ShowDialog() == DialogResult.OK)//当选定文件之后单击“打开”按钮时
            {
                musicPath.Text = MusicDialog.FileName;//保存打开文件的文件路径
                musicName.Text = System.IO.Path.GetFileNameWithoutExtension(musicPath.Text);//保存打开的文件的文件名
            }
        }
        #endregion

        #region 单击“写入”按钮时
        private void writeIn_Click(object sender,EventArgs e)
        {
            m3uWrite(musicName.Text,musicPath.Text,M3UPath.Text);//向M3U文件中写入内容
        }
        #endregion

        #region 单击“打开”按钮时
        private void unfold_Click(object sender,EventArgs e)
        {
            fileName.Text = ListM3UFile();//打开一个M3U文件
        }
        #endregion

        #region 单击“删除”按钮时
        private void Expunction_Click(object sender,EventArgs e)
        {
            m3uDelete(fileName.Text); //删除指定的文件
            temp = null;//清空变量temp中保存的值
            fileName.Clear();//清空文本框中的内容
            MessageBox.Show("祝贺你，删除成功！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出消息提示
        }
        #endregion


    }
}
