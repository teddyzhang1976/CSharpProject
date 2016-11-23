using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiltSentence
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //创建字符串
            string text = @"A better activation model is to allocate an object for a client only while a call is in 
    progress from the client to the service. That way, you have to create and maintain only as many 
    objects in memory as there are concurrent calls, not as many objects as there are outstanding 
    clients. Between calls, the client holds a reference on a proxy that doesn't have an actual object 
    at the end of the wire. The obvious benefit is that you can now dispose of the expensive resources 
    the service instance occupies long before the client disposes of the proxy. By that same token, 
    acquiring the resources is postponed until they are actually needed by a client. The second benefit 
    is that forcing the service instance to reallocate or connect to its resources on every call caters 
    very well to transactional resources and transactional programming because it eases the task of 
    enforcing consistency with the instance state.";
            string matches = "of";						//要查询的单词
            string[] sentences = text.Split(new char[] { '.', '?', '!' });	//按句子转换成数组
            //使用LINQ找出所有包含of的句子
            var query = from item in sentences
                        let words = item.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries) //将句子按单词转换成数组
                        where words.Contains(matches)		//判断当前句子的单词中是否包含of
                        select item;
            //显示查询结果
            foreach (var item in query)
            {
                label1.Text += item.ToString() + "\n";
            }
        }
    }
}
