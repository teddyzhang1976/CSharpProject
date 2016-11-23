using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace GetDiskList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        BaseClass bc = new BaseClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            bc.listFolders(toolStripComboBox1);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bc.GetPath(toolStripComboBox1.Text, imageList1, listView1, 0);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string pp = listView1.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView1, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bc.GOBack(listView1, imageList1, toolStripComboBox1.Text);
        }
        private int T = 0;
        private string path;
        private static string MyPath;
        private static ArrayList al = new ArrayList();
        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                al.Clear();
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView1.SelectedItems[i].Text);
                }
                T = 0;
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                al.Clear();
                path = bc.Mpath() + "\\" + listView1.SelectedItems[0].Text;
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView1.SelectedItems[i].Text);
                }
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                files.Add(path);
                Clipboard.SetFileDropList(files);
                MyPath = path;
                T = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (T == 0)
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Move(al[i].ToString(), paths);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                            DirectoryInfo di = new DirectoryInfo(al[i].ToString());
                            di.Delete(true);
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Copy(al[i].ToString(), paths, false);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
                catch { }
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Selected = true;
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pp = listView1.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView1, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                listView1.SelectedItems[0].BeginEdit();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        string path = bc.Mpath() + "\\" + listView1.SelectedItems[i].Text;
                        if (File.GetAttributes(path).CompareTo(FileAttributes.Directory) == 0)
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(path);
                            dinfo.Delete(true);
                        }
                        else
                        {
                            string path1 = bc.Mpath() + "\\" + listView1.SelectedItems[i].Text;
                            FileInfo finfo = new FileInfo(path1);
                            finfo.Delete();
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
            }
            catch
            { }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string MyPath = bc.Mpath() + "\\" + listView1.SelectedItems[0].Text;
                string newFilename = e.Label;
                string path2 = bc.Mpath() + "\\" + newFilename;
                if (File.Exists(MyPath))
                {
                    if (MyPath != path2)
                    {
                        File.Move(MyPath, path2);
                    }
                }
                if (Directory.Exists(MyPath))
                {
                    DirectoryInfo di = new DirectoryInfo(MyPath);
                    di.MoveTo(path2);
                }
                listView1.Items.Clear();
                bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
            }
            catch { }
        }
    }
}
