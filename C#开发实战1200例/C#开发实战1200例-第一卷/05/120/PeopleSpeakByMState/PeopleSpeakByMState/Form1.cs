using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeopleSpeakByMState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//判断是否输入了姓名
            {
                Console.WriteLine("请输入姓名：");
                return;
            }
            richTextBox1.Clear();//清空文本框内容
            string strName = textBox1.Text;//记录用户输入的名字
            People[] people = new People[2];//声明People类型数组
            people[0] = new Chinese();//使用第一个派生类对象初始化数组的第一个元素
            people[1] = new American();//使用第二个派生类对象初始化数组的第二个元素
            for (int i = 0; i < people.Length; i++)//遍历赋值后的数组
            {
                people[i].Say(richTextBox1,strName);//根据数组元素调用相应派生类中的重写方法
            }
        }
    }
    class People//定义基类
    {
        public virtual void Say(RichTextBox rtbox, string name)//定义一个虚方法，用来表示人的说话行为
        {
            rtbox.Text += name;//输出人的名字
        }
    }
    class Chinese : People//定义派生类，继承于People类
    {
        public override void Say(RichTextBox rtbox, string name)//重写基类中的虚方法
        {
            base.Say(rtbox, name + "说汉语！\n");
        }
    }
    class American : People//定义派生类，继承于People类
    {
        public override void Say(RichTextBox rtbox, string name)//重写基类中的虚方法
        {
            base.Say(rtbox, name + "说英语！");
        }
    }
}
