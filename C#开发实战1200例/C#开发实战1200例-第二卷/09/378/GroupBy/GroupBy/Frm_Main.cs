using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroupBy
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string[] Words = new string[] { "what", "is", "your", "name", "?", "my", "name", "is", "lyf", "." };
            var Groups = from word in Words
                         group word by word.Length into lengthGroups//按单词长度将单词分组
                         orderby lengthGroups.Key descending//按单词长度降序排列
                         select new
                         {
                             Length = lengthGroups.Key,//取单词长度
                             WordCollect = lengthGroups//取该长度的单词分组集合
                         };
            foreach (var group in Groups)//遍历每组单词
            {
                label1.Text +="包含" + group.Length.ToString() + "个字符的单词有:" + "\n";
                foreach (string word in group.WordCollect)
                {
                    label1.Text +="    " + word + ",";
                }
                label1.Text +="\n" ;
            }
        }
    }
}
