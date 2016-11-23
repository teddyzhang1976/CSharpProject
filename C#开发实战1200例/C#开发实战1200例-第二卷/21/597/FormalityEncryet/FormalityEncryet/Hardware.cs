using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;//在添加引用窗体的.net中添加System.Management
using System.IO;//为FileStream添加的命名空间
using System.Collections;//为ArrayList添加命名空间
using System.Security.Cryptography;//MD5的命名空间
using System.Net;//添加主机信息的命名空间

namespace FormalityEncryet
{
    class Hardware
    {
        /// <summary> 
        /// Hardware_Mac 的摘要说明。 
        /// </summary> 
        public class HardwareInfo
        {

            public static int ArrInt = 0;
            public static string PFileDir = "";
            public static string PFileN = "";
            
            
            //取机器名 
            public string GetHostName()
            {
                return System.Net.Dns.GetHostName();
            }

            #region  获取主机名
            /// <summary>
            /// 获取主机名
            /// </summary>
            public String GetBIOSNumber()
            {
                // 显示主机名
                string hostname = Dns.GetHostName();
                // 显示每个IP地址
                IPHostEntry hostent = Dns.GetHostEntry(hostname); // 主机信息
                Array addrs = hostent.AddressList;            // IP地址数组
                IEnumerator it = addrs.GetEnumerator();       // 迭代器，添加名命空间using System.Collections;
                while (it.MoveNext())
                {   // 循环到下一个IP 地址
                    IPAddress ip = (IPAddress)it.Current;      //获得IP地址，添加名命空间using System.Net;
                    return ip.ToString();
                }
                return "";
            }
            #endregion

            /// <summary>
            /// 获取CPU序列号
            /// </summary>
            /// <returns>CPU序列号</returns>
            public String GetCpuID()
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_Processor");
                    ManagementObjectCollection moc = mc.GetInstances();

                    String strCpuID = null;
                    foreach (ManagementObject mo in moc)
                    {
                        strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                        mo.Dispose();
                        break;
                    }
                    moc.Dispose();
                    mc.Dispose();
                    return strCpuID;
                }
                catch
                {
                    return "";
                }

            }

            /// <summary>
            /// 获取网卡硬件地址
            /// </summary>
            /// <returns>网卡硬件地址</returns>
            public String GetNetworkCard()
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                    ManagementObjectCollection moc2 = mc.GetInstances();
                    string StrNetworkCard = null;
                    foreach (ManagementObject mo in moc2)
                    {
                        if ((bool)mo["IPEnabled"] == true)
                        {
                            StrNetworkCard = mo["MacAddress"].ToString();
                            mo.Dispose();
                            break;
                        }
                        mo.Dispose();
                    }
                    moc2.Dispose();
                    mc.Dispose();
                    return StrNetworkCard;
                }
                catch
                {
                    return "";
                }
            }

            /// <summary>
            /// 获取本地计算机的硬盘盘符
            /// </summary>
            /// <param cBox="ComboBox">ComboBox控件</param>
            public void GetHardDisk(ComboBox cBox)
            {
                try
                {
                    cBox.Items.Clear();
                    ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                    ManagementObjectCollection mocHD = mcHD.GetInstances();
                    foreach (ManagementObject mo in mocHD) //遍历硬盘信息
                    {
                        cBox.Items.Add(mo["DeviceID"].ToString());//添加硬盘的盘符名称
                        mo.Dispose();
                    }
                    mcHD.Dispose();
                }
                catch { }
            }

            /// <summary>
            /// 获序硬盘序列号
            /// </summary>
            /// <param Disk="string">盘符</param>
            /// <returns>硬盘序列号</returns>
            public String GetHardDiskID(string Disk)
            {
                try
                {
                    String strHardDiskID = null;
                    String DiskStr = Disk.Substring(0, 1) + ":";
                    ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                    ManagementObjectCollection mocHD = mcHD.GetInstances();
                    foreach (ManagementObject mo in mocHD) //遍历硬盘信息
                    {
                        if (mo["DeviceID"].ToString() == DiskStr)//如果硬盘等于指定的盘符
                        {
                            strHardDiskID = mo["VolumeSerialNumber"].ToString();//获取当前硬盘的序列号
                            mo.Dispose();
                            break;
                        }
                        mo.Dispose();
                    }
                    mcHD.Dispose();
                    return strHardDiskID;
                }
                catch
                {
                    return "";
                }
            }

            /// <summary>
            /// 对字符串进行加密
            /// </summary>
            /// <param former="string">加密字符串</param>
            /// <param spoon="string">密钥</param>
            /// <param n="int">密钥标识</param>
            /// <returns>加密后的字符串</returns>
            public string Encrypt(string former, string spoon,int n)
            {
                byte[] FByteArray = Encoding.Default.GetBytes(former);//将字符串生成字节数组
                byte[] SByteArray = Encoding.Default.GetBytes(spoon);
                int Aleng = 0;
                if (FByteArray.Length > SByteArray.Length)//获取字节数组的最大长度
                    Aleng = FByteArray.Length;
                else
                    Aleng = SByteArray.Length;
                char[] charData = new char[Aleng];//定义指定长度的字符数组
                for (int i = 0; i < FByteArray.Length; i++)//对字节数组中的单个字节进行异或运算
                {
                    FByteArray[i] = Convert.ToByte(Convert.ToInt32(FByteArray[i]) ^ Convert.ToInt32(SByteArray[n]));
                }

                Decoder d = Encoding.UTF8.GetDecoder();//获取一个解码器
                d.GetChars(FByteArray, 0, FByteArray.Length, charData, 0);//将编码字节数组转换为字符数组
                d.Reset();//将解码器设为初始状态
                string Zpp = "";
                for (int i = 0; i < charData.Length; i++)//将字符数组组合成字符串
                {
                    Zpp = Zpp + charData[i].ToString();
                }
                n = n + 1;
                if (n < SByteArray.Length-1)
                    Encrypt(Zpp, spoon, n);//进行函数的递归调用
                return Zpp;
            }


            /// <summary>
            /// 根据条件生成加密字符串
            /// </summary>
            /// <param GroupB="GroupBox">GroupBox控件</param>
            /// <param Comb="ComboBox">ComboBox控件</param>
            /// <returns>加密后的字符串</returns>
            public String CreatePass(GroupBox GroupB, ComboBox Comb)
            {
                ArrInt = 0;
                string PrassSum = null;
                ArrayList List = new ArrayList();
                foreach (Control Gb in GroupB.Controls)
                {
                    if (Gb is CheckBox)
                    {
                        if (((CheckBox)Gb).Checked == true)
                        {
                            switch (Convert.ToInt32(((CheckBox)Gb).Tag))
                            {
                                case 0://主板序列号
                                    {
                                        PrassSum = GetBIOSNumber();
                                        if (PrassSum.Trim() == "")
                                            MessageBox.Show("无法获取主板序列号。");
                                        break;
                                    }
                                case 1://CPU序列号
                                    {
                                        PrassSum = GetCpuID();
                                        if (PrassSum.Trim() == "")
                                            MessageBox.Show("无法获取CPU序列号。");
                                        break;
                                    }
                                case 2://网卡硬件地址
                                    {
                                        PrassSum = GetNetworkCard();
                                        if (PrassSum.Trim() == "")
                                            MessageBox.Show("无法获取网卡硬件地址。");
                                        break;
                                    }
                                case 3://硬盘序列号
                                    {
                                        PrassSum = GetHardDiskID(Comb.Text);
                                        if (PrassSum.Trim() == "")
                                            MessageBox.Show("无法获取" + Comb.Text + "盘序列号。");
                                        break;
                                    }
                            }
                            if (PrassSum.Trim() != "")
                            {
                                ArrInt = ArrInt + 1;
                                List.Add(ArrInt);
                                List[ArrInt - 1] = PrassSum;
                                PrassSum = null;
                            }
                        }

                    }
                }

                if (List.Count == 0)
                {
                    MessageBox.Show("请选择加密的条件。");
                    return "";
                }
                int Ci = 1;
                PrassSum = List[0].ToString();
                for (int i = Ci; i < List.Count; i++)
                {
                    PrassSum = Encrypt(PrassSum, List[i].ToString(), 0);
                }

                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hdcode1 = System.Text.Encoding.UTF8.GetBytes(PrassSum + "new");
                byte[] hdcode2 = md5.ComputeHash(hdcode1);
                md5.Clear();
                char[] charData = new char[hdcode2.Length];//建立一个字符组
                Decoder d = Encoding.UTF8.GetDecoder();//实例化一个解码器
                d.GetChars(hdcode2, 0, hdcode2.Length, charData, 0);//将编码字节数组转换为字符数组
                PrassSum = "";
                for (int i = 0; i < charData.Length; i++)//将字符数组组合成字符串
                {
                    PrassSum = PrassSum + charData[i].ToString();
                }
                return PrassSum;
            }

            /// <summary>
            /// 将密码写入EXE文件中
            /// </summary>
            /// <param StrDir="string">EXE文件的路径</param>
            /// <param Prass="string">加密数据</param>
            public void WriteEXE(string StrDir, string Prass)
            {
                byte[] byData = new byte[100];//建立一个FileStream要用的字节组
                char[] charData = new char[100];//建立一个字符组
                try
                {
                    Prass = Prass.Trim();
                    FileStream aFile = new FileStream(StrDir, FileMode.Open);//创建一个FileStream对象，用来操作data.txt文件，操作类型是
                    charData = Prass.ToCharArray();//将字符串内的字符复制到字符组里
                    aFile.Seek(0, SeekOrigin.End);//将指针移到文件尾
                    Encoder el = Encoding.UTF8.GetEncoder();//解码器
                    el.GetBytes(charData, 0, charData.Length, byData, 0, true);//将字符数组存入到字节数组中
                    aFile.Write(byData, 0, byData.Length);//将字节写入到文件中
                    aFile.Dispose();
                }
                catch
                {
                    MessageBox.Show("EXE文件加密失败。");
                }
            }

            /// <summary>
            /// 生成TXT文件
            /// </summary>
            /// <param Prass="string">加密数据</param>            
            public void CreateTXT(string Prass)
            {
                FileStream aFile;
                string TemDir = PFileDir.Substring(0, PFileDir.LastIndexOf("\\"));//获取当前可执行文件的路径（不包含文件名）
                TemDir = TemDir + "\\" + PFileN + ".TXT";//在可执行文件的路径下添加一个同名的TXT文件
                byte[] byData = new byte[100];//建立一个FileStream要用的字节组
                char[] charData = new char[100];//建立一个字符组
                try
                {
                    aFile = new FileStream(TemDir, FileMode.CreateNew);//创建一个FileStream对象，用来操作data.txt文件，操作类型是
                }
                catch
                {
                    aFile = new FileStream(TemDir, FileMode.Truncate);
                }
                try
                {
                    Prass = "密码：" + Prass.Trim();
                    charData = Prass.ToCharArray();//将字符串内的字符复制到字符组里
                    aFile.Seek(0, SeekOrigin.Begin);//将指针移到文件首
                    Encoder el = Encoding.UTF8.GetEncoder();//解码器
                    el.GetBytes(charData, 0, charData.Length, byData, 0, true);//将密码转换成字节
                    aFile.Write(byData, 0, byData.Length);//将密码写入文本中
                    aFile.Dispose();
                }
                catch
                {
                    MessageBox.Show("TXT文件生成失败。");
                }
            }

        }

    }
}
