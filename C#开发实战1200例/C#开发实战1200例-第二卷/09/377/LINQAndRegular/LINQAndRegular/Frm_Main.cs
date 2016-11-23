using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LINQAndRegular
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //给字符串变量赋值
            string text = @"A better activation model is to allocate an object for a client only while a call is in progress from the client to the service. 
        That way, you have to create and maintain only as many objects in memory as there are concurrent calls, 
        not as many objects as there are outstanding clients. Between calls, 
        the client holds a reference on a proxy that doesn't have an actual object at the end of the wire. 
        The obvious benefit is that you can now dispose of the expensive resources the service instance occupies long before the client disposes of the proxy. 
        By that same token, acquiring the resources is postponed until they are actually needed by a client. 
        The second benefit is that forcing the service instance to reallocate or connect to its resources on every call caters very well to 
        transactional resources and transactional programming because it eases the task of enforcing consistency with the instance state.";
            //创建匹配以ing结尾单词的正则表达式
            Regex r = new Regex(@"ing\b");
            //按单词转换为字符串数组
            string[] words = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            //LINQ查询以ing结尾的单词
            var query = from item in words
                        where r.Match(item).Success == true
                        select item;

            //显示查询结果
            label1.Text ="以ing结尾的单词：\n";
            foreach (var item in query)
            {
                label1.Text += item.ToString() + "\n";
            }
        }
    }
}
