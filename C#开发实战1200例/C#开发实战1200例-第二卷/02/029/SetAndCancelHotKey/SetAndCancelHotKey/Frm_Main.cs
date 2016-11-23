using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SetAndCancelHotKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        HOOK Hook = new HOOK();//实例化自定义类HOOK
        public static string[] Arrstr = new string[6];//记录屏蔽的热键
        public static string[,] ArrHotkey = new string[3,2];//记录自定义的热键
        public static bool istabPage = true;//判断是设置热键，还是屏蔽热键
        bool isShift = false;//判断是否为组合键
        string front = "";//记录组合键前一键的值
        string tem_s = "";//记录单键或组合键的值
        string tem_dir = "";//记录路径
        public static int tem_Set = 0;//标识，判断当前键是否为屏蔽的热键
        public static int tem_Hotkey = 0;//标识，判断当前键是否为自定义的热键

        private void Form1_Load(object sender, EventArgs e)
        {
            Hook.KeyDown += new KeyEventHandler(Hook_KeyDown);//加载键盘的按下事件
            Hook.KeyUp += new KeyEventHandler(Hook_KeyUp);//加载键盘的松开事件
            Hook.KeyPress += new KeyPressEventHandler(Hook_KeyPress);//加载键盘的单击事件
            HOOK.isSet = false;//判断是否设置热键
            //对记录屏蔽热键的数组进行初始化
            for (int i = 0; i < 6; i++)
            {
                Arrstr[i] = "";
            }
            //对记录设置热键的数组进行初始化
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2;j++ )
                    ArrHotkey[i,j] = "";
            }
        }

        private void Form1_FontChanged(object sender, EventArgs e)
        {
            Hook.Stop();//卸载钩子
        }

        void Hook_KeyPress(object sender, KeyPressEventArgs e)
        {
            //在单击按键时，是否对该键进行屏蔽
            AddKeyboardEvent("KeyPress", "", e.KeyChar.ToString(), "", "", "");
        }

        void Hook_KeyUp(object sender, KeyEventArgs e)
        {
            //在按下按钮时，是否对该键进行屏蔽
            AddKeyboardEvent("KeyUp", e.KeyCode.ToString(), "", e.Shift.ToString(), e.Alt.ToString(), e.Control.ToString());
        }

        void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            //在松开组合键时，是否对该组合键进行屏蔽
            AddKeyboardEvent("KeyDown", e.KeyCode.ToString(), "", e.Shift.ToString(), e.Alt.ToString(), e.Control.ToString());
        }

        /// <summary>
        /// 用于屏蔽指定的系统热键，以及执行自定义热键
        /// </summary>
        /// <param eventType="string">按键操作的类型</param>
        /// <param keyCode="string">键名称</param> 
        /// <param keyChar="string">键值</param> 
        /// <param shift="string">是否为Shift键</param> 
        /// <param alt="string">是否为Alt键</param> 
        /// <param control="string">是否为Ctrl键</param> 
        public void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
        {
            tem_Set = 0;//初始化
            tem_Hotkey = 0;//初始化
            bool b = false;//初始化
            string keyvalue = "";//初始化
            
            GeyKeys(keyCode, out b, out keyvalue);//获取当前键的键值
            if (eventType == "KeyDown")//如果当前为按下键
            {
                isShift = true;
                if (tem_s == "")//如果当前不是组合键
                {
                    if (HOOK.isSet == false)//设置屏蔽
                    {
                        if (istabPage == true)//如果是“屏蔽热键”选项卡
                            SetTextBox(keyvalue);//在指定文本框中显示热键
                    }
                    else
                    {
                        //遍历当前热键是否为屏蔽的热键
                        for (int i = 0; i < 6; i++)
                        {
                            if (Arrstr[i] == tem_s)//如果是屏蔽的热键
                            {
                                tem_Set = 1;//当前为屏蔽的热键
                                break;//退出本次循环
                            }
                            else
                                tem_Set = 0;//不是屏蔽的热键
                        }
                    }
                    if (HOOK.isHotkey == false)//设置自定义热键
                    {
                        if (istabPage == false)//如果当前是设置自定义热键
                            SetTextBox(keyvalue);//在指定的文本框显示热键
                    }
                    else
                    {
                        //遍历当前热键是否为自定义热键
                        for (int i = 0; i < 3; i++)
                        {
                            if (ArrHotkey[i, 0] == tem_s)//如果是自定义热键
                            {
                                tem_Hotkey = 1;//屏蔽当前热键
                                try
                                {
                                    //如果自定义热已设置
                                    if (ArrHotkey[i, 1].Trim().Length != 0 && tem_dir != ArrHotkey[i, 1].Trim())
                                        System.Diagnostics.Process.Start(ArrHotkey[i, 1]);//执行自定义热键的相关操作
                                    tem_dir = ArrHotkey[i, 1].Trim();//记录执行的路径
                                }
                                catch
                                {
                                    MessageBox.Show("文件无法打开。");
                                }

                                break;
                            }
                            else
                                tem_Hotkey = 0;//执行当前热键
                        }
                    }
                }
            }
            if (eventType == "KeyUp")//如果当前是键盘松开操作
            {
                isShift = false;//没有组合键
                front = "";//清空组合键的前一个键值
                tem_dir = "";//清空自定义热键的操作路径

            }
            if (isShift == true && eventType == "KeyDown")//如果是键盘按下操作
            {

                if (front != keyvalue)
                {
                    tem_s = "";//清空键或组合键的值
                    if (front == "")//如果不是组合键
                    {
                        tem_s = keyvalue;//获取当前键的值
                        if (HOOK.isSet == false)//设置屏蔽
                        {
                            if (istabPage == true)//如果当前为“屏蔽热键”选项卡
                            {
                                SetTextBox("");//清空显示热键的文本框
                                SetTextBox(keyvalue);//将热键显示在指定的文本框中
                            }
                        }
                        else
                        {
                            //遍历要屏蔽的热键
                            for (int i = 0; i < 6; i++)
                            {
                                if (Arrstr[i] == tem_s)//如果存在
                                {
                                    tem_Set = 1;//屏蔽系统热键
                                    break;
                                }
                                else
                                    tem_Set = 0;//不屏蔽
                            }
                        }
                        if (HOOK.isHotkey == false)//设置热键
                        {
                            if (istabPage == false)//如果是“设置热键”选项卡
                                SetTextBox(keyvalue);//在文本框中显示当前热键
                        }
                        else
                        {
                            //遍历自定义热键
                            for (int i = 0; i < 3; i++)
                            {
                                if (ArrHotkey[i, 0] == tem_s)//如果存在
                                {
                                    tem_Hotkey = 1;//屏蔽当前热键
                                    try
                                    {
                                        if (ArrHotkey[i, 1].Trim().Length != 0 && tem_dir != ArrHotkey[i, 1].Trim())//如果对自定义热键进行了设置
                                            System.Diagnostics.Process.Start(ArrHotkey[i, 1]);//执行自定义热键的操作
                                        tem_dir = ArrHotkey[i, 1].Trim();//记录路径
                                    }
                                    catch
                                    {
                                        MessageBox.Show("文件无法打开。");
                                    }

                                    break;
                                }
                                else
                                    tem_Hotkey = 0;//执行自定义热键
                            }
                        }
                    }
                    else//如果当前是组合键
                    {
                        tem_s = front + "+" + keyvalue;//记录组合键
                        if (HOOK.isSet == false)//设置屏蔽
                        {
                            if (istabPage == true)//如果当前为“屏蔽热键”选项卡
                            {
                                SetTextBox("");//清空指定的文本框
                                SetTextBox(front + "+" + keyvalue);//在文本框中显示屏蔽热键
                            }
                        }
                        else
                        {
                            //遍历设置的自定义热键
                            for (int i = 0; i < 6; i++)
                            {
                                if (Arrstr[i] == tem_s)//如果存在
                                {
                                    tem_Set = 1;//屏蔽当前热键
                                    break;//退出本次循环
                                }
                                else
                                    tem_Set = 0;//执行当前热键
                            }
                        }
                        if (HOOK.isHotkey == false)//设置热键
                        {
                            if (istabPage == false)//如果当前为“设置热键”选项卡
                            {
                                SetTextBox("");//清空显示热键的文本框
                                SetTextBox(front + "+" + keyvalue);//在指定的文本框中显示组合键
                            }
                        }
                        else
                        {
                            //遍历自定义热键
                            for (int i = 0; i < 3; i++)
                            {
                                if (ArrHotkey[i, 0] == tem_s)//如果是设置的自定义组合热键
                                {
                                    tem_Hotkey = 1;//屏蔽当前组合热键
                                    try
                                    {
                                        if (ArrHotkey[i, 1].Trim().Length != 0 && tem_dir != ArrHotkey[i, 1].Trim())//如果对自定义组合热键进行了设置
                                            System.Diagnostics.Process.Start(ArrHotkey[i, 1]);//执行自定义组合热键的操作
                                        tem_dir = ArrHotkey[i, 1].Trim();//记录路径
                                    }
                                    catch
                                    {
                                        MessageBox.Show("文件无法打开。");
                                    }

                                    break;
                                }
                                else
                                    tem_Hotkey = 0;//执行当前组合热键
                            }
                        }
                        tem_s = "";//清空热键
                    }
                }
                front = keyvalue;//记录组合键的前一个键值
            }
            if (tem_Hotkey > 0 || tem_Set > 0)//如果屏蔽系统热键或自定义热键
                HOOK.pp = 1;//屏蔽
            else
                HOOK.pp = 0;//执行

            if (HOOK.isSet == false)//设置屏蔽的系统热键
                HOOK.pp = 1;
            if (HOOK.isHotkey == false)//设置屏蔽的自定义热键
                HOOK.pp = 1;
        }

        /// <summary>
        /// 在指定文本框中显示要屏蔽或设置的热键
        /// </summary>
        /// <param value="string">热键</param>
        public void SetTextBox(string value)
        {
            if (textBox1.Focused)//如果获取焦点
                textBox1.Text=value;//显示热键
            if (textBox2.Focused)
                textBox2.Text = value;
            if (textBox3.Focused)
                textBox3.Text = value;
            if (textBox4.Focused)
                textBox4.Text = value;
            if (textBox5.Focused)
                textBox5.Text = value;
            if (textBox6.Focused)
                textBox6.Text = value;
            if (textBox7.Focused)
                textBox7.Text = value;
            if (textBox9.Focused)
                textBox9.Text = value;
            if (textBox11.Focused)
                textBox11.Text = value;
        }

        /// <summary>
        /// 通过热键获取其指定的名称
        /// </summary>
        /// <param value="string">热键</param>
        /// <return b="bool">是否有当前热键</return>
        /// <return keyvalue="string">当前热键的指定名称</return>
        public void GeyKeys(string k, out bool b, out string keyvalue)
        {
            if (k.Contains("ControlKey"))//如果字符串K的值在指定的字符串中
            {
                b = true;//返回true
                keyvalue = "Ctrl";//返回指定的键值
                return;
            }
            if (k.Contains("Shift"))
            {
                b = true;
                keyvalue = "Shift";
                return;
            }
            if (k.Contains("Win"))
            {
                b = true;
                keyvalue = "Win";
                return;
            }
            if (k.Contains("Menu"))
            {
                b = true;
                keyvalue = "Alt";
                return;
            }
            if (k.Length == 2 && k.Substring(0, 1) == "D")//返回F1~F12的键名称
            {
                b = true;
                keyvalue = k.Substring(1, 1);
                return;
            }
            if (k.Contains("Menu"))
            {
                b = true;
                keyvalue = "Alt";
                return;
            }
            if (k.Contains("OemMinus"))
            {
                b = true;
                keyvalue = "_";
                return;
            }
            if (k.Contains("Oem5"))
            {
                b = true;
                keyvalue = "\\";
                return;
            }
            b = true;
            keyvalue = k;//返回除以上键值的键名称
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //显示当前已设置的要屏蔽的热键键值
            HOOK.isSet = false;
            textBox1.Text = Arrstr[0];
            textBox2.Text = Arrstr[1];
            textBox3.Text = Arrstr[2];
            textBox4.Text = Arrstr[3];
            textBox5.Text = Arrstr[4];
            textBox6.Text = Arrstr[5];
            Hook.Stop();
            Hook.Start();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Arrstr[0] = textBox1.Text;
            Arrstr[1] = textBox2.Text;
            Arrstr[2] = textBox3.Text;
            Arrstr[3] = textBox4.Text;
            Arrstr[4] = textBox5.Text;
            Arrstr[5] = textBox6.Text;
            HOOK.isSet = true;
            HOOK.isHotkey = true;
            Hook.Stop();
            Hook.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HOOK.isHotkey = false;
            textBox7.Text = ArrHotkey[0, 0];
            textBox8.Text = ArrHotkey[0, 1];
            textBox9.Text = ArrHotkey[1, 0];
            textBox10.Text = ArrHotkey[1, 1];
            textBox11.Text = ArrHotkey[2, 0];
            textBox12.Text = ArrHotkey[2, 1];
            Hook.Stop();
            Hook.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox8.Text = openFileDialog1.FileName;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox10.Text = openFileDialog1.FileName;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox12.Text = openFileDialog1.FileName;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ArrHotkey[0, 0] = textBox7.Text;
            ArrHotkey[0, 1] = textBox8.Text;
            ArrHotkey[1, 0] = textBox9.Text;
            ArrHotkey[1, 1] = textBox10.Text;
            ArrHotkey[2, 0] = textBox11.Text;
            ArrHotkey[2, 1] = textBox12.Text;
            HOOK.isSet = true;
            HOOK.isHotkey = true;
            Hook.Stop();
            Hook.Start();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
                istabPage = true;
            else
                istabPage = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }
    }
}
