using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace DispelFormality
{
    public partial class Frm_Dispel : Form
    {
        public Frm_Dispel()
        {
            InitializeComponent();
        }

        public string StrPass = "";//密码
        public string HighValue = "";//高等信息的值
        public string HighSgin = "";//高等信息的标识

        public string enrolValse = "";//记录限定时间
        public string NewDate = "";//记录日期，判断是否修改过日期
        public string TemporarilyDate = "";//获取注册表中计算月数和天数的临时时间
        public string IfShow = "";//是否显示解密窗体
        public bool Bypast = false;//判断程序是不过期

        /// <summary>
        /// 读取当前可执行文件的文件尾部信息
        /// </summary>
        /// <param Prass="string">密码</param> 
        public string ReadEXEFile()
        {
            byte[] byData = new byte[100];//建立一个FileStream要用的字节组
            char[] charData = new char[100];//建立一个字符组

            try
            {
                FileStream aFile = new FileStream(Application.ExecutablePath, FileMode.OpenOrCreate, FileAccess.Read);//实例化一个FileStream对象，用来操作data.txt文件，操作类型是
                aFile.Seek(-100, SeekOrigin.End);//把文件指针指向文件尾，从文件开始位置向前100位字节所指的字节
                aFile.Read(byData, 0, 100);//读取FileStream对象所指的文件到字节数组里
            }
            catch
            {
                MessageBox.Show("读取EXE文件时，发生错误。");
                return "";
            }
            Decoder d = Encoding.UTF8.GetDecoder();//实例化一个解码器
            d.GetChars(byData, 0, byData.Length, charData, 0);//将编码字节数组转换为字符数组
            string Zpp = "";
            for (int i = 0; i < charData.Length; i++)//将字符组合成字符串
            {
                Zpp = Zpp + charData[i].ToString();
            }
            Zpp = Zpp.Replace("\0", "");//将字符串后面的\0替换为空

            return Zpp.Trim();
        }

        /// <summary>
        /// 读取文件尾部的高等信息
        /// </summary>
        /// <param Field="string">文件尾部信息</param> 
        public string ReadAltitude(string Field)
        {
            string Cauda = "";
            StrPass = Field;
            if (Field.LastIndexOf(",") > -1)
            {
                Cauda = Field.Substring(Field.LastIndexOf(",")+1, Field.Length - Field.LastIndexOf(",")-1);
                switch (Cauda.Substring(Cauda.Length - 1, 1))
                {
                    case "D":
                        {
                            StrPass = Field.Substring(0, Field.LastIndexOf(","));//密码
                            HighValue = Cauda.Substring(0, Cauda.Length-1);//高等信息的值
                            HighSgin = "D";//高等信息的标识
                            break;
                        }
                    case "M":
                        {
                            StrPass = Field.Substring(0, Field.LastIndexOf(","));//密码
                            HighValue = Cauda.Substring(0, Cauda.Length - 1);//高等信息的值
                            HighSgin = "M";//高等信息的标识
                            break;
                        }
                    case "A":
                        {
                            StrPass = Field.Substring(0, Field.LastIndexOf(","));//密码
                            HighValue = Cauda.Substring(0, Cauda.Length - 1);//高等信息的值
                            HighSgin = "A";//高等信息的标识
                            break;
                        }
                    case "C":
                        {
                            StrPass = Field.Substring(0, Field.LastIndexOf(","));//密码
                            HighValue = Cauda.Substring(0, Cauda.Length - 1);//高等信息的值
                            HighSgin = "C";//高等信息的标识
                            break;
                        }
                }
            }
            return StrPass;
        }

        /// <summary>
        /// 读取注册表中的信息
        /// </summary>
        /// <param Field="string">注册表中的信息</param> 
        public bool ReadRegistered(string Field)
        {
            string Cauda = Field;
            IfShow = Cauda.Substring(Cauda.Length - 1, 1);
            if (Cauda.Length <= 1)
                return false;
            switch (Cauda.Substring(Cauda.Length - 2, 1))
            {
                case "D":
                    {
                        HighValue = Cauda.Substring(0, Cauda.Length - 2);//高等信息的值
                        HighSgin = "D";//高等信息的标识
                        break;
                    }
                case "M":
                    {
                        HighValue = Cauda.Substring(0, Cauda.Length - 2);//高等信息的值
                        HighSgin = "M";//高等信息的标识
                        break;
                    }
                case "A":
                    {
                        HighValue = Cauda.Substring(0, Cauda.Length - 2);//高等信息的值
                        HighSgin = "A";//高等信息的标识
                        break;
                    }
                case "C":
                    {
                        HighValue = Cauda.Substring(0, Cauda.Length - 2);//高等信息的值
                        HighSgin = "C";//高等信息的标识
                        break;
                    }

            }

            return true;
        }

        /// <summary>
        /// 比较前一个日期是否大于后一个日期
        /// </summary>
        /// <param Date_1="string">日期</param> 
        /// <param Date_2="string">日期</param>  
        public bool DateCompare(string Date_1, string Date_2)
        {
            string[] D1;
            string[] D2;
            bool Comp = false;
            D1 = Date_1.Split(Convert.ToChar('-'));
            D2 = Date_2.Split(Convert.ToChar('-'));
            for (int i = 0; i < D1.Length; i++)
            {
                if (Convert.ToInt32(D1[i]) > Convert.ToInt32(D2[i]))
                {
                    Comp = true;
                    break;
                }
            }
            return Comp;
        }

        /// <summary>
        /// 比较两个日期的月份差
        /// </summary>
        /// <param Old_Date="DateTime">日期</param> 
        /// <param New_Date="DateTime">日期</param>  
        public int MonthJob(DateTime Old_Date, DateTime New_Date)
        {
            int OY = Old_Date.Year;//年
            int OM = Old_Date.Month;//月
            int OD = Old_Date.Day;//日
            int NY = New_Date.Year;
            int NM = New_Date.Month;
            int ND = New_Date.Day;
            int fY = 0;//年进/减减
            int fM = 0;//月进/减减
            int Months = 0;//记录月份的个数
            int d = ND - OD;
            if (NM > OM)
            {
                if (d > 0)
                {

                    fM = 1;
                }

                if (d < 0)
                    fM = -1;
            }
            int m = NM + fM - OM;
            if (m < 0)
            {
                fY = -1;
                m = 12 + m;
            }
            int y = NY + fY - OY;

            Months = y * 12 + m;
            return Months;
        }

        /// <summary>
        /// 比较两个日期的天数差
        /// </summary>
        /// <param Old_Date="DateTime">老日期</param> 
        /// <param New_Date="DateTime">新日期</param>  
        public int DayJob(DateTime Old_Date, DateTime New_Date)
        {
            TimeSpan TMs = New_Date - Old_Date;
            int ms = TMs.Days;
            return ms;
        }

        /// <summary>
        /// 修改注册表
        /// </summary>
        /// <param Field="string">当前可执行文件的名称</param> 
        public void AmendEnrol(string FDir)
        {
            int job = 0;
            RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("LB").CreateSubKey(FDir).CreateSubKey("Altitude");

            //判断应用程序的使用期限
            switch (HighSgin)
            {
                case "D"://日期
                    {
                        if (DateCompare(System.DateTime.Now.ToShortDateString().Trim(), HighValue.Trim()))
                            Bypast = true;
                        break;
                    }
                case "M"://月数
                    {
                        if (Convert.ToInt32(HighValue) <= 0)
                            Bypast = true;
                        else
                        {
                            job = MonthJob(Convert.ToDateTime(TemporarilyDate), Convert.ToDateTime(System.DateTime.Now.ToShortDateString()));
                            if (job > 0)
                                retkey.SetValue("DateMonth", System.DateTime.Now.ToString());
                        }
                        break;
                    }
                case "A"://天数
                    {

                        if (Convert.ToInt32(HighValue) <= 0)
                            Bypast = true;
                        else
                        {
                            job = DayJob(Convert.ToDateTime(TemporarilyDate), Convert.ToDateTime(System.DateTime.Now.ToShortDateString()));
                            if (job > 0)
                                retkey.SetValue("DateMonth", System.DateTime.Now.ToString());
                        }
                        break;
                    }
                case "C"://次数
                    {
                        if (Convert.ToInt32(HighValue) <= 0)
                            Bypast = true;
                        else
                            job = 1;
                        break;
                    }
            }
            if (HighSgin == "M" || HighSgin == "A" || HighSgin == "C")
            {
                job = Convert.ToInt32(HighValue) - job;
                retkey.SetValue("UserName", job.ToString() + HighSgin + IfShow);
            }
            retkey.SetValue("DateCounter", System.DateTime.Now.ToString());
        }





        private void button_OK_Click(object sender, EventArgs e)
        {
            string temStr = "";
            string TPrass = "";
            string PPrass = "";
            string FDir = "";
            string Fshow = "";
            string Str_Altitude = "";
            if (textBox_Dispel.Text.Length == 0)
            {
                MessageBox.Show("请输入解码。");
                return;
            }
            temStr = textBox_Dispel.Text;
            PPrass = ReadEXEFile();//获取尾部信息
            PPrass = ReadAltitude(PPrass);//分离密码与高级信息
            TPrass = textBox_Dispel.Text.Trim();//记录输入的密码
            textBox_Dispel.Text = TPrass;
            if (PPrass == textBox_Dispel.Text)//判断密码是否正确
            {
                if (checkBox_Show.Checked == true)//下次运行是否不显示该窗体
                {
                    Fshow = "T";
                }
                else
                {
                    Fshow = "F";
                }
                //添加的注册码路径：HKEY_CURRENT_USER-Software-LB
                FDir = Application.ExecutablePath;
                FDir = FDir.Substring(FDir.LastIndexOf("\\") + 1, FDir.Length - FDir.LastIndexOf("\\") - 1);
                RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("LB").CreateSubKey(FDir).CreateSubKey("Altitude");//在注册表中添加Altitude文件夹
                enrolValse = "";//记录添加注册表的值
                NewDate = "";//记录当前的时间值
                TemporarilyDate = "";//临时记录时间
                foreach (string sVName in retkey.GetValueNames())//获取注册表中Altitude文件夹中的文件名
                {
                    if (sVName == "UserName")//如果是UserName文件
                    {
                        enrolValse = retkey.GetValue(sVName).ToString();//获取文件中的信息
                    }
                    if (sVName == "DateCounter")//如果是DateCounter文件
                    {
                        NewDate = retkey.GetValue(sVName).ToString();//获取文件中的信息
                    }
                    if (sVName == "DateMonth")//如果是DateMonth文件
                    {
                        TemporarilyDate = retkey.GetValue(sVName).ToString();//获取文件中的信息
                    }
                }
                if (HighSgin == "C")//如果是按运行次数限制EXE文件
                    HighValue = Convert.ToString(Convert.ToInt32(HighValue) - 1);//将总次数减1
                Str_Altitude = HighValue + HighSgin + Fshow;//获取修改后的信息
                if (enrolValse == "" || NewDate == "" || TemporarilyDate == "")//如果有一个值为空
                {
                    retkey.SetValue("UserName", Str_Altitude.Trim());//修改注册表中的信息
                    retkey.SetValue("DateCounter", System.DateTime.Now.ToString());
                    retkey.SetValue("DateMonth", System.DateTime.Now.ToShortDateString());
                }
                else
                {
                    ReadRegistered(enrolValse);//读取要写入注册表中的信息
                    AmendEnrol(FDir);//修改注册表中的信息
                }
                this.DialogResult = DialogResult.OK;//使当前窗体的返回值为OK
                this.Close();//关闭当前窗体
            }
            else
                textBox_Dispel.Text = temStr;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}