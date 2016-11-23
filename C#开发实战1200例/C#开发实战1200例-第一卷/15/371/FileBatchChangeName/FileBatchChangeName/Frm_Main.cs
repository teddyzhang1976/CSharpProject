using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
namespace FileBatchChangeName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string[] files;//选择文件的集合
        FileInfo fi;//创建一个FileInfo对象，用于获取文件信息
        string[] lvFiles=new string[7];//向控件中添加的行信息
        Thread td;//处理批量更名方法的线程
        private void 添加文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.GridLines = true;
                listView1.Items.Clear();
                files = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    string path = files[i].ToString();
                    fi = new FileInfo(path);
                    string name = path.Substring(path.LastIndexOf("\\") + 1, path.Length - 1 - path.LastIndexOf("\\"));
                    string ftype = path.Substring(path.LastIndexOf("."), path.Length - path.LastIndexOf("."));
                    string createTime = fi.CreationTime.ToShortDateString();
                    double a = Convert.ToDouble(Convert.ToDouble(fi.Length) / Convert.ToDouble(1024));
                    string fsize = a.ToString("0.0")+" KB";
                    lvFiles[0] = name;
                    lvFiles[1] = name;
                    lvFiles[2] = ftype;
                    lvFiles[3] = createTime;
                    lvFiles[4] = path.Remove(path.LastIndexOf("\\") + 1);
                    lvFiles[5] = fsize;

                    ListViewItem lvi = new ListViewItem(lvFiles);
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems[1].BackColor = Color.AliceBlue;
                    
                    listView1.Items.Add(lvi);
                }
                tsslSum.Text = listView1.Items.Count.ToString();
            }
        }


        bool flag = true;
        private void 总在最前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                总在最前ToolStripMenuItem.Checked = true;
                this.TopMost = true;
                flag = false;
            }
            else
            {
                总在最前ToolStripMenuItem.Checked = false;
                this.TopMost = false;
                flag = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//文件名大写
        {
            if (listView1.Items.Count > 0)
            {
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Remove(name.LastIndexOf("."));
                        string newName = name.Replace(name1,name1.ToUpper());
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//文件名小写
        {
            if (listView1.Items.Count > 0)
            {
                if (radioButton2.Checked)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Remove(name.LastIndexOf("."));
                        string newName = name.Replace(name1, name1.ToLower());
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//第一个字母大写
        {
            if (listView1.Items.Count > 0)
            {
                if (radioButton3.Checked)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Substring(0,1);
                        string name2 = name.Substring(1);
                        string newName = name1.ToUpper() + name2;
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)//扩展名大写
        {
            if (listView1.Items.Count > 0)
            {
                if (radioButton4.Checked)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Substring(name.LastIndexOf("."), name.Length - name.LastIndexOf("."));
                        string newName = name.Replace(name1, name1.ToUpper());
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (radioButton5.Checked)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Substring(name.LastIndexOf("."), name.Length - name.LastIndexOf("."));
                        string newName = name.Replace(name1, name1.ToLower());
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }

        bool IsOK = false;//判断是否应用了模板
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//选择模板的下拉框
        {
            int k = (int)nuStart.Value;
            if (comboBox2.Text != "")
            {
                txtTemplate.Text = comboBox2.Text.Remove(comboBox2.Text.LastIndexOf("_"));
                int B = comboBox2.SelectedIndex;
                switch (B)
                {
                    case 0:
                        if (listView1.Items.Count > 0)
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                string name = listView1.Items[i].SubItems[1].Text;
                                string name1 = name.Remove(name.LastIndexOf("."));
                                string name2 = "pic_" + k.ToString();
                                k = k + (int)nuAdd.Value;
                                string newName = name.Replace(name1, name2);
                                listView1.Items[i].SubItems[1].Text = newName;
                            }
                            IsOK = true;
                        }
                        break;
                    case 1:
                        if (listView1.Items.Count > 0)
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                string name = listView1.Items[i].SubItems[1].Text;
                                string name1 = name.Remove(name.LastIndexOf("."));
                                string name2 = "file_" + k.ToString();
                                k = k +(int) nuAdd.Value;
                                string newName = name.Replace(name1,name2);
                                listView1.Items[i].SubItems[1].Text = newName;
                            }
                            IsOK = true;
                        }
                        break;
                }
            }
        }

        private void StartNumAndAdd()//设置起始数字和增量值
        {
             int k = (int)nuStart.Value;
             if (comboBox2.Text != "")
             {
                 if (listView1.Items.Count > 0)
                 {
                     for (int i = 0; i < listView1.Items.Count; i++)
                     {
                         string name = listView1.Items[i].SubItems[1].Text;
                         string name1 = name.Remove(name.LastIndexOf("."));
                         string name2 = name1.Remove(name.LastIndexOf("_")+1)+k.ToString();
                         k = k + (int)nuAdd.Value;
                         string newName = name.Replace(name1, name2);
                         listView1.Items[i].SubItems[1].Text = newName;
                     }
                     IsOK = true;
                 }
             }
        }


        private void nuStart_ValueChanged(object sender, EventArgs e)//选择起始数字
        {
            StartNumAndAdd();
        }

        private void nuAdd_ValueChanged(object sender, EventArgs e)//选择增量值
        {
            StartNumAndAdd();
        }

        private void txtTemplate_TextChanged(object sender, EventArgs e)//更换模板样式
        {
            if (listView1.Items.Count > 0)
            {
                if (IsOK&&txtTemplate.Text.Trim()!=""&&comboBox2.Text!="")
                {
                    
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string name = listView1.Items[i].SubItems[1].Text;
                        string name1 = name.Remove(name.LastIndexOf("_") + 1);
                        string newName = name.Replace(name1, txtTemplate.Text.Trim() + "_");
                        listView1.Items[i].SubItems[1].Text = newName;
                    }
                }
            }
        }


        private void ChangeName()
        {
            int flag = 0;
            try
            {
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = listView1.Items.Count - 1;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string path = listView1.Items[i].SubItems[4].Text;
                    string sourcePath = path + listView1.Items[i].SubItems[0].Text;
                    string newPath = path + listView1.Items[i].SubItems[1].Text;
                    File.Copy(sourcePath, newPath);
                    File.Delete(sourcePath);
                    toolStripProgressBar1.Value = i;
                    listView1.Items[i].SubItems[0].Text = listView1.Items[i].SubItems[1].Text;
                    listView1.Items[i].SubItems[6].Text = "√成功";
                }
            }
            catch(Exception ex)
            {
                flag++;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tsslError.Text = flag.ToString() + " 个错误";
            }
        }

        private void 更名ToolStripMenuItem_Click(object sender, EventArgs e)//开始批量更名
        {
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].SubItems[6].Text = "";
                }
                tsslError.Text = "";
                td = new Thread(new ThreadStart(ChangeName));
                td.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void 导出文件列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw;
                string txt = "";
                string path = saveFileDialog1.FileName;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    txt = listView1.Items[i].SubItems[0].Text + "  " + listView1.Items[i].SubItems[1].Text;
                    sw = File.AppendText(path);
                    sw.WriteLine(txt);
                    sw.Close();
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static string TraditionalChineseToSimplifiedChinese(string str)//繁体转简体
        {
            return (Microsoft.VisualBasic.Strings.StrConv(str,Microsoft.VisualBasic.VbStrConv.SimplifiedChinese,0));
        }

        private static string SimplifiedChineseToTraditionalChinese(string str)//简体转繁体
        {
            return (Microsoft.VisualBasic.Strings.StrConv(str as string ,Microsoft.VisualBasic.VbStrConv.TraditionalChinese,0));
        }

        private void 繁体转简体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string name = listView1.Items[i].SubItems[1].Text;
                    string name1 = TraditionalChineseToSimplifiedChinese(name);
                    listView1.Items[i].SubItems[1].Text = name1;
                }
            }
        }

        private void 简体转繁体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string name = listView1.Items[i].SubItems[1].Text;
                    string name1 = SimplifiedChineseToTraditionalChinese(name);
                    listView1.Items[i].SubItems[1].Text = name1;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (td != null)
            {
                td.Abort();
            }
        }
    }
}
