using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;//注册码的合名空间
using System.IO;//FileStream类的命名空间

namespace DispelFormality
{
    public partial class Frm_Logon : Form
    {
        public Frm_Logon()
        {
            InitializeComponent();
        }

        public string HighValue = "";//高等信息的值
        public string HighSgin = "";//高等信息的标识
        public string IfShow = "";//是否显示解密窗体
        public bool Bypast = false;//判断程序是不过期
        public string NewDate = "";//记录日期，判断是否修改过日期
        public string TemporarilyDate="";//获取注册表中计算月数和天数的临时时间

        /// <summary>
        /// 比较前一个日期是否大于后一个日期
        /// </summary>
        /// <param Date_1="string">日期</param> 
        /// <param Date_2="string">日期</param>  
        public bool DateCompare(string Date_1,string Date_2)
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

        //加密程序的添加方法
        public bool sdkf()
        {
            string FDir = "";
            bool pp = false;
            //bool enrolIf = false;
            string enrolValse = "";
            int job = 0;
            FDir = Application.ExecutablePath;
            FDir = FDir.Substring(FDir.LastIndexOf("\\") + 1, FDir.Length - FDir.LastIndexOf("\\") - 1);
            RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("LB").CreateSubKey(FDir);
            
            //读取注册表中的信息
            foreach (string strRNum in retkey.GetSubKeyNames())
            {
                RegistryKey sikey = retkey.OpenSubKey(strRNum);//打开子键
                foreach (string sVName in sikey.GetValueNames())
                {
                    if (sVName == "UserName")
                    {
                        enrolValse = sikey.GetValue(sVName).ToString();
                    }
                    if (sVName == "DateCounter")
                    {
                        NewDate = sikey.GetValue(sVName).ToString();
                    }
                    if (sVName == "DateMonth")
                    {
                        TemporarilyDate = sikey.GetValue(sVName).ToString();
                    }
                }
            }
            if (NewDate!="")
                if (Convert.ToDateTime(NewDate) > System.DateTime.Now)
                {
                    Bypast = true;
                    return true;
                }
            if (enrolValse.Length == 0)
                return false;
            ReadRegistered(enrolValse);//分解注册表中的信息
            if (IfShow=="T")//(enrolValse.LastIndexOf("T") > -1)
                pp = true;
            else
                pp = false;

            //修改注册表
            if (pp == false)
            {
                FDir = Application.ExecutablePath;
                FDir = FDir.Substring(FDir.LastIndexOf("\\") + 1, FDir.Length - FDir.LastIndexOf("\\") - 1);
                retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("LB").CreateSubKey(FDir).CreateSubKey("Altitude");

                //判断应用程序的使用期限
                switch (HighSgin)
                {
                    case "D"://日期
                        {
                            if (DateCompare(System.DateTime.Now.ToShortDateString().Trim(),HighValue.Trim()))
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

             return pp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Frm_Logon_Load(object sender, EventArgs e)
        {
            if (sdkf() == false)
            {
                if (Bypast==true)
                    Application.Exit();
                Frm_Dispel FrmDispel = new Frm_Dispel();
                if (FrmDispel.ShowDialog() == DialogResult.OK)
                {
                    //对登录窗体进行相应的操作
                }
                else
                    Application.Exit();
 
            }
            if (Bypast == true)
                Application.Exit();
        }
    }
}