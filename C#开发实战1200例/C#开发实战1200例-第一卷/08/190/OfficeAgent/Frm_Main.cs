using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AgentObjects;

namespace OfficeAgent
{
    public partial class Frm_Main : Form
    {
        IAgentCtlCharacterEx ICCE;//定义一个类IAgentCtlCharacterEx对象
        IAgentCtlRequest ICR;//定义一个类IagentCtlRequest对象
        //定义一个字符串数组，用来存储精灵的各种动作
        string[] strAgents = new string[10] { "Acknowledge", "LookDown", "Sad", "Alert", "LookDownBlink", "Search", "Announce", "LookUp", "Think", "Blink" };

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < strAgents.Length; i++)//循环遍历
            {
                listBox1.Items.Add(strAgents[i]);//向控件listBox1中添加字符串数组中的内容
            }
            ICR = axAgent1.Characters.Load("merlin", "merlin.acs");//加载指定文件
            ICCE = axAgent1.Characters.Character("merlin");//设定模拟Office助手的表情
            ICCE.Show(0);//显示模拟Office助手表情
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICCE.StopAll("");//停止所有模拟Office助手表情
            ICCE.Play(strAgents[listBox1.SelectedIndex]);//显示控件listBox1中选定的表情
        }
    }
}