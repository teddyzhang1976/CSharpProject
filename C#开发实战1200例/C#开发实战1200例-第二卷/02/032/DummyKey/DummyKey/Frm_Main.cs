using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DummyKey
{
    public partial class Frm_Main : Form
    {
        private HookEx.UserActivityHook hook;//实例化HookEx.UserActivityHook
        private static IDictionary<short, IList<FecitButton>> spacialVKButtonsMap;//表示键/值对应的泛型集合
        private static IDictionary<short, IList<FecitButton>> combinationVKButtonsMap;//表示键/值对应的泛型集合

        public Frm_Main()
        {
            InitializeComponent();

            #region 将指定的按钮值添加到键类型中
            spacialVKButtonsMap = new Dictionary<short, IList<FecitButton>>();
            combinationVKButtonsMap = new Dictionary<short, IList<FecitButton>>();
            IList<FecitButton> buttonList = new List<FecitButton>();//实例化IList<FecitButton>(按照索引单独访问的一组对象)
            buttonList.Add(this.btnLCTRL);//添加左面的CTRL键
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_CONTROL, buttonList);//添加左面的CTRL键值
            buttonList = new List<FecitButton>();
            buttonList.Add(this.btnLSHFT);//添加左面的LSHFT键
            buttonList.Add(this.btnRSHFT);//添加右面的LSHFT键
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_SHIFT, buttonList);//添加LSHFT键值
            buttonList = new List<FecitButton>();//实例化IList<FecitButton>
            buttonList.Add(this.btnLALT);//添加左面的ALT键
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_MENU, buttonList);//添加左面的ALT键值
            buttonList = new List<FecitButton>();//实例化IList<FecitButton>
            buttonList.Add(this.btnLW);//添加左面的WIN键
            combinationVKButtonsMap.Add(KeyboardConstaint.VK_LWIN, buttonList);//添加左面的WIN键值
            buttonList = new List<FecitButton>();//实例化IList<FecitButton>
            buttonList.Add(this.btnLOCK);//添加LOCK键
            spacialVKButtonsMap.Add(KeyboardConstaint.VK_CAPITAL, buttonList);//添加LOCK键值
            #endregion

            foreach (Control ctrl in this.Controls)
            {
                FecitButton button = ctrl as FecitButton;
                if (button == null)
                {
                    continue;
                }

                #region 设置按键的消息值
                short key = 0;//记录键值
                bool isSpacialKey = true;
                //记录快捷键的键值
                switch (button.Name)//获取键名称
                {
                    case "btnLCTRL"://CTRL键的左键名称
                    case "btnRCTRL"://CTRL键的右键名称
                        key = KeyboardConstaint.VK_CONTROL;//获取CTRL键的键值
                        break;
                    case "btnLSHFT"://SHFT键的左键名称
                    case "btnRSHFT"://SHFT键的左键名称
                        key = KeyboardConstaint.VK_SHIFT;//获取SHFT键的键值
                        break;
                    case "btnLALT"://ALT键的左键名称
                    case "btnRALT"://ALT键的左键名称
                        key = KeyboardConstaint.VK_MENU;//获取ALT键的键值
                        break;
                    case "btnLW"://WIN键的左键名称
                    case "btnRW"://WIN键的左键名称
                        key = KeyboardConstaint.VK_LWIN;//获取WIN键的键值
                        break;
                    case "btnESC"://ESC键的名称
                        key = KeyboardConstaint.VK_ESCAPE;//获取ESC键的键值
                        break;
                    case "btnTAB"://TAB键的名称
                        key = KeyboardConstaint.VK_TAB;//获取TAB键的键值
                        break;
                    case "btnF1"://F1键的名称
                        key = KeyboardConstaint.VK_F1;//获取F1键的键值
                        break;
                    case "btnF2":
                        key = KeyboardConstaint.VK_F2;
                        break;
                    case "btnF3":
                        key = KeyboardConstaint.VK_F3;
                        break;
                    case "btnF4":
                        key = KeyboardConstaint.VK_F4;
                        break;
                    case "btnF5":
                        key = KeyboardConstaint.VK_F5;
                        break;
                    case "btnF6":
                        key = KeyboardConstaint.VK_F6;
                        break;
                    case "btnF7":
                        key = KeyboardConstaint.VK_F7;
                        break;

                    case "btnF8":
                        key = KeyboardConstaint.VK_F8;
                        break;
                    case "btnF9":
                        key = KeyboardConstaint.VK_F9;
                        break;
                    case "btnF10":
                        key = KeyboardConstaint.VK_F10;
                        break;
                    case "btnF11":
                        key = KeyboardConstaint.VK_F11;
                        break;
                    case "btnF12":
                        key = KeyboardConstaint.VK_F12;
                        break;
                    case "btnENT":
                    case "btnNUMENT":
                        key = KeyboardConstaint.VK_RETURN;
                        break;
                    case "btnWave":
                        key = KeyboardConstaint.VK_OEM_3;
                        break;
                    case "btnSem":
                        key = KeyboardConstaint.VK_OEM_1;
                        break;
                    case "btnQute":
                        key = KeyboardConstaint.VK_OEM_7;
                        break;
                    case "btnSpace":
                        key = KeyboardConstaint.VK_SPACE;
                        break;
                    case "btnBKSP":
                        key = KeyboardConstaint.VK_BACK;
                        break;
                    case "btnComma":
                        key = KeyboardConstaint.VK_OEM_COMMA;
                        break;
                    case "btnFullStop":
                        key = KeyboardConstaint.VK_OEM_PERIOD;
                        break;
                    case "btnLOCK":
                        key = KeyboardConstaint.VK_CAPITAL;
                        break;
                    case "btnMinus":
                        key = KeyboardConstaint.VK_OEM_MINUS;
                        break;
                    case "btnEqual":
                        key = KeyboardConstaint.VK_OEM_PLUS;
                        break;
                    case "btnLBracket":
                        key = KeyboardConstaint.VK_OEM_4;
                        break;
                    case "btnRBracket":
                        key = KeyboardConstaint.VK_OEM_6;
                        break;
                    case "btnPath":
                        key = KeyboardConstaint.VK_OEM_5;
                        break;
                    case "btnDivide":
                        key = KeyboardConstaint.VK_OEM_2;
                        break;
                    case "btnPSC":
                        key = KeyboardConstaint.VK_SNAPSHOT;
                        break;
                    case "btnINS"://Insert键的名称
                        key = KeyboardConstaint.VK_INSERT;//获取Insert键的键值
                        break;
                    case "btnDEL"://Delete键的名称
                        key = KeyboardConstaint.VK_DELETE;//获取Delete键的键值
                        break;
                    default:
                        isSpacialKey = false;
                        break;
                }
                if (!isSpacialKey)
                {
                    key = (short)button.Name[3];//获取按钮的键值
                }
                button.Tag = key;//在按钮的Tag属性中记录相应的键值
                #endregion
                button.Click += ButtonOnClick;//重载按钮的单击事件
            }
            this.hook = new HookEx.UserActivityHook(true, true);
            HookEvents();
        }

        private void HookEvents()
        {
            this.hook.KeyDown += HookOnGlobalKeyDown;//重载hook类中的自定义事件KeyDown
            this.hook.KeyUp += HookOnGlobalKeyUp;//重载hook类中的自定义事件KeyUp
            this.hook.MouseActivity += HookOnMouseActivity;//重载hook类中的自定义事件MouseActivity
        }

        private void ButtonOnClick(object sender, EventArgs e)//按键的单击事件
        {
            FecitButton btnKey = sender as FecitButton;//获取当前按键的信息
            if (btnKey == null)//如果按键为空值
                return;
            SendKeyCommand(btnKey);//发送按键的信息
        }

        /// <summary>
        /// 接收并发送按键信息
        /// </summary>
        /// <param keyButton="FecitButton">按键信息</param>
        private void SendKeyCommand(FecitButton keyButton)
        {
            short key = Convert.ToInt16(keyButton.Tag.ToString());//获取当前键的键值
            if (combinationVKButtonsMap.ContainsKey(key))//如果键值在键值列表中
            {
                if (keyButton.Checked)//如果按钮处于按下状态
                {
                    SendKeyUp(key);//对按钮进行抬起操作
                }
                else
                {
                    SendKeyDown(key);//对按钮进行按下操作
                }
            }
            else
            {
                //执行按钮按下和抬起的操作
                SendKeyDown(key);
                SendKeyUp(key);
            }
        }

        /// <summary>
        /// 记录键盘的按下操作的值
        /// </summary>
        /// <param key="short">键值</param>
        private void SendKeyDown(short key)
        {
            Input[] input = new Input[1];//实例化Input[]
            input[0].type = INPUT.KEYBOARD;//记录当有键值的类型
            input[0].ki.wVk = key;//记录当前键值
            input[0].ki.time = NativeMethods.GetTickCount();//获取自windows启动以来经历的时间长度（毫秒）
            //消息的输入
            if (NativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());//指定错误的初始化
            }
        }

        /// <summary>
        /// 记录键盘抬起操作的值
        /// </summary>
        /// <param key="short">键值</param>
        private void SendKeyUp(short key)
        {
            Input[] input = new Input[1];//实例化Input[]
            input[0].type = INPUT.KEYBOARD;//记录当有键值的类型
            input[0].ki.wVk = key;//记录当前键值
            input[0].ki.dwFlags = KeyboardConstaint.KEYEVENTF_KEYUP;
            input[0].ki.time = NativeMethods.GetTickCount();//获取自windows启动以来经历的时间长度（毫秒）
            //消息的输入
            if (NativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());//指定错误的初始化
            }
        }

        //键盘的按下事件
        private void HookOnGlobalKeyDown(object sender, HookEx.KeyExEventArgs e)
        {
            SetButtonStatus(e, true);
        }

        //键盘的抬起事件
        private void HookOnGlobalKeyUp(object sender, HookEx.KeyExEventArgs e)
        {
            SetButtonStatus(e, false);
        }

        /// <summary>
        /// 设置当前按钮的状态
        /// </summary>
        /// <param args="KeyExEventArgs">键信息</param>
        /// <param isDown="bool">标识，当前键是否按下</param>
        private void SetButtonStatus(HookEx.KeyExEventArgs args, bool isDown)
        {
            IList<FecitButton> buttonList = FindButtonList(args);//查找当有键
            if (buttonList.Count <= 0)//如果没有找到
                return;//退出本次操作
            short key = (short)args.KeyValue;//获取当前键的键值
            if (spacialVKButtonsMap.ContainsKey(key))//如果键/值列表中有该键
            {
                if (!isDown)//如果按钮没有被按下
                {
                    FecitButton button = spacialVKButtonsMap[key][0];//设置按钮的信息
                    button.Checked = !button.Checked;//设置当前按钮为按下状态
                }
            }
            else
            {
                foreach (FecitButton button in buttonList)//遍历IList中的所有按钮
                {
                    if (button == null)//如果按钮为空
                        break;//退出循环
                    button.Checked = isDown;//设置按钮的状态
                }
            }
        }

        /// <summary>
        /// 鼠标事件
        /// </summary>
        /// <param sener="object">鼠标对象</param>
        /// <param e="MouseExEventArgs">为MouseUp、MouseDown和MouseMove事件提供数据</param>
        private void HookOnMouseActivity(object sener, HookEx.MouseExEventArgs e)
        {
            Point location = e.Location;//获取鼠标的位置
            if (e.Button == MouseButtons.Left)//如果是鼠标左键
            {
                Rectangle captionRect = new Rectangle(this.Location, new Size(this.Width, SystemInformation.CaptionHeight));//获取窗体的所在区域
                if (captionRect.Contains(location))//如果鼠标在该窗体范围内
                {   //设置窗体的扩展样式
                    NativeMethods.SetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE, (int)NativeMethods.GetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE) & (~KeyboardConstaint.WS_DISABLED));
                    //将消息发送给指定窗体 
                    NativeMethods.SendMessage(this.Handle, KeyboardConstaint.WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero);
                }
                else
                {
                    //设置窗体的扩展样式
                    NativeMethods.SetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE, (int)NativeMethods.GetWindowLong(this.Handle, KeyboardConstaint.GWL_EXSTYLE) | KeyboardConstaint.WS_DISABLED);
                }
            }
        }

        /// <summary>
        /// 在键列表中查找键值
        /// </summary>
        /// <param args="KeyExEventArgs">键信息</param>
        private IList<FecitButton> FindButtonList(HookEx.KeyExEventArgs args)
        {
            short key = (short)args.KeyValue;//获取键值
            if (key == KeyboardConstaint.VK_LCONTROL || key == KeyboardConstaint.VK_RCONTROL)//如果是CTRL键
            {
                key = KeyboardConstaint.VK_CONTROL;//记录CTRL键值
            }
            else if (key == KeyboardConstaint.VK_LSHIFT || key == KeyboardConstaint.VK_RSHIFT)//如果是SHIFT键
            {
                key = KeyboardConstaint.VK_SHIFT;//记录SHIFT键值
            }
            else if (key == KeyboardConstaint.VK_LMENU || key == KeyboardConstaint.VK_RMENU)//如果是ALT键
            {
                key = KeyboardConstaint.VK_MENU;//记录ALT键值
            }
            else if (key == KeyboardConstaint.VK_RWIN)//如果是WIN键
            {
                key = KeyboardConstaint.VK_LWIN;//记录WIN键值
            }

            if (combinationVKButtonsMap.ContainsKey(key))//如果在IDictionary的集合中
            {
                return combinationVKButtonsMap[key];//返回当前键的键值
            }
            IList<FecitButton> buttonList = new List<FecitButton>();//实例化IList<FecitButton>
            foreach (Control ctrl in this.Controls)//遍历当前窗体中的所有控件
            {
                FecitButton button = ctrl as FecitButton;//如果当前控件是FecitButton按钮
                if (button == null)//如果当前按钮为空
                    continue;//重新循环
                short theKey = Convert.ToInt16(button.Tag.ToString());//获取当前按钮的键值
                if (theKey == key)//如果与当前操作的按钮相同
                {
                    buttonList.Add(button);//添加当前操作的按键信息
                    break;
                }
            }
            return buttonList;
        }
    }
}
