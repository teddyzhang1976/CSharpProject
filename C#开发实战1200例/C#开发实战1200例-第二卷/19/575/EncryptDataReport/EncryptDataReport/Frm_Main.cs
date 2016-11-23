using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.IO;

namespace EncryptDataReport
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局对象及变量
        private IPEndPoint Server;//服务器端
        private IPEndPoint Client;//客户端
        private Socket mySocket;//套接字
        private EndPoint ClientIP;//IP地址
        byte[] buffer, data;//接收缓存
        bool blFlag = true;//标识是否第一次发送信息
        bool ISPort = false;//判断端口打开
        int SendNum1, ReceiveNum1, DisNum1; //记录窗体加载时的已发送\已接收\丢失的数据报
        int SendNum2, ReceiveNum2, DisNum2; //记录当前已发送\已接收\丢失的数据报
        int SendNum3, ReceiveNum3, DisNum3; //缓存已发送\已接收\丢失的数据报
        int port;//端口号
        #endregion

        //异步接收信息
        private void StartLister(IAsyncResult IAResult)
        {
            int Num = mySocket.EndReceiveFrom(IAResult, ref ClientIP);
            string strInfo = Encoding.Unicode.GetString(buffer, 0, Num);
            rtbContent.AppendText("用户" + ClientIP.ToString());
            rtbContent.AppendText("：");
            rtbContent.AppendText("\r\n");
            rtbContent.AppendText(DecryptDES(strInfo, "mrsoftxk"));//对接收到的信息进行解密
            rtbContent.AppendText("\r\n");
            mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ClientIP, new AsyncCallback(StartLister), null);
        }

        //初始化已发送、已接收和丢失的数据报
        private void Form1_Load(object sender, EventArgs e)
        {
            if (blFlag == true)
            {
                IPGlobalProperties NetInfo = IPGlobalProperties.GetIPGlobalProperties();
                UdpStatistics myUdpStat = null;
                myUdpStat = NetInfo.GetUdpIPv4Statistics();
                SendNum1 = Int32.Parse(myUdpStat.DatagramsSent.ToString());
                ReceiveNum1 = Int32.Parse(myUdpStat.DatagramsReceived.ToString());
                DisNum1 = Int32.Parse(myUdpStat.IncomingDatagramsDiscarded.ToString());
            }
        }

        //设置端口号
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                port = Convert.ToInt32(textBox4.Text);
                CheckForIllegalCrossThreadCalls = false;
                buffer = new byte[1024];
                data = new byte[1024];
                Server = new IPEndPoint(IPAddress.Any, port);
                Client = new IPEndPoint(IPAddress.Broadcast, port);
                ClientIP = (EndPoint)Server;
                mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                mySocket.Bind(Server);
                mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ClientIP, new AsyncCallback(StartLister), null);
                ISPort = true;//打开指定端口号
            }
            catch { }
        }

        //发送信息
        private void button2_Click(object sender, EventArgs e)
        {
            if (ISPort == true)//判断是否有打开的端口号
            {
                IPGlobalProperties NetInfo = IPGlobalProperties.GetIPGlobalProperties();
                UdpStatistics myUdpStat = null;
                myUdpStat = NetInfo.GetUdpIPv4Statistics();
                try
                {
                    if (blFlag == false)//非第一次发送
                    {
                        SendNum2 = Int32.Parse(myUdpStat.DatagramsSent.ToString());
                        ReceiveNum2 = Int32.Parse(myUdpStat.DatagramsReceived.ToString());
                        DisNum2 = Int32.Parse(myUdpStat.IncomingDatagramsDiscarded.ToString());
                        textBox1.Text = Convert.ToString(SendNum2 - SendNum3);
                        textBox2.Text = Convert.ToString(ReceiveNum2 - ReceiveNum3);
                        textBox3.Text = Convert.ToString(DisNum2 - DisNum3);
                    }
                    SendNum2 = Int32.Parse(myUdpStat.DatagramsSent.ToString());
                    ReceiveNum2 = Int32.Parse(myUdpStat.DatagramsReceived.ToString());
                    DisNum2 = Int32.Parse(myUdpStat.IncomingDatagramsDiscarded.ToString());
                    SendNum3 = SendNum2; //记录本次的发送数据报
                    ReceiveNum3 = ReceiveNum2;//记录本次的接收数据报
                    DisNum3 = DisNum2; //记录本次的丢失数据报
                    if (blFlag == true)//第一次发送
                    {
                        textBox1.Text = Convert.ToString(SendNum2 - SendNum1);
                        textBox2.Text = Convert.ToString(ReceiveNum2 - ReceiveNum1);
                        textBox3.Text = Convert.ToString(DisNum2 - DisNum1);
                        blFlag = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string str = EncryptDES(rtbSend.Text, "mrsoftxk");//加密要发送的信息
                data = Encoding.Unicode.GetBytes(str);
                mySocket.SendTo(data, data.Length, SocketFlags.None, Client);
                rtbSend.Text = "";
            }
            else
            {
                MessageBox.Show("请首先打开端口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Focus();
            }
        }

        //清屏
        private void button1_Click(object sender, EventArgs e)
        {
            rtbContent.Clear();
        }

        //退出
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //按<Ctrl+Enter>组合键发送信息
        private void rtbSend_KeyDown(object sender, KeyEventArgs e)
        {
            //当同时按下Ctrl和Enter时，发送消息
            if (e.Control && e.KeyValue == 13)
            {
                e.Handled = true;
                button2_Click(this, null);
            }
        }

        //聊天记录随时滚动
        private void rtbContent_TextChanged(object sender, EventArgs e)
        {
            rtbContent.ScrollToCaret();
        }

        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };//密钥

        #region DES加密字符串
        ///<summary>   
        ///DES加密字符串   
        ///</summary>   
        ///<param name="str">待加密的字符串</param>   
        ///<param name="key">加密密钥,要求为8位</param>   
        ///<returns>加密成功返回加密后的字符串，失败返回源字符串</returns>   
        public string EncryptDES(string str, string key)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
                DESCryptoServiceProvider myDES = new DESCryptoServiceProvider();
                MemoryStream MStream = new MemoryStream();
                CryptoStream CStream = new CryptoStream(MStream, myDES.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                CStream.Write(inputByteArray, 0, inputByteArray.Length);
                CStream.FlushFinalBlock();
                return Convert.ToBase64String(MStream.ToArray());
            }
            catch
            {
                return str;
            }
        }
        #endregion

        #region DES解密字符串
        ///<summary>   
        ///DES解密字符串   
        ///</summary>   
        ///<param name="str">待解密的字符串</param>   
        ///<param name="key">解密密钥,要求为8位,和加密密钥相同</param>   
        ///<returns>解密成功返回解密后的字符串，失败返源字符串</returns>   
        public string DecryptDES(string str, string key)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(str);
                DESCryptoServiceProvider myDES = new DESCryptoServiceProvider();
                MemoryStream MStream = new MemoryStream();
                CryptoStream CStream = new CryptoStream(MStream, myDES.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                CStream.Write(inputByteArray, 0, inputByteArray.Length);
                CStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(MStream.ToArray());
            }
            catch
            {
                return str;
            }
        }
        #endregion
    }
}