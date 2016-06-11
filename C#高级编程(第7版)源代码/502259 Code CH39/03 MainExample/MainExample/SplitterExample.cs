using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MainExample
{
    public partial class SplitterExample : Form
    {
        public SplitterExample()
        {
            InitializeComponent();

            // Load up the tree control
            DirectoryInfo di = new DirectoryInfo(@"C:\");

            TreeNode root = new TreeNode(di.Name);
            root.Tag = di;

            this.treeView1.Nodes.Add(root);
        }

        /// <summary>
        /// Populate the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFolderSelected(object sender, TreeViewEventArgs e)
        {
            DirectoryInfo di = e.Node.Tag as DirectoryInfo;

            if (null != di)
            {
                try
                {
                    this.listView1.BeginUpdate();
                    this.treeView1.BeginUpdate();
                    this.listView1.Items.Clear();

                    ListViewGroup directoryGroup = listView1.Groups.Add("Directories", "Directories");
                    ListViewGroup fileGroup = listView1.Groups.Add("Files", "Files");

                    FileInfo[] files = di.GetFiles();

                    bool addToTree = (0 == e.Node.Nodes.Count);

                    foreach (DirectoryInfo info in di.GetDirectories())
                    {
                        ListViewItem lvi = new ListViewItem(info.Name);
                        lvi.Tag = info;
                        lvi.Group = directoryGroup;
                        this.listView1.Items.Add(lvi);

                        if (addToTree)
                        {
                            TreeNode node = new TreeNode(info.Name);
                            node.Tag = info;
                            e.Node.Nodes.Add(node);
                        }
                    }

                    foreach (FileInfo fi in di.GetFiles())
                    {
                        ListViewItem lvi = new ListViewItem(fi.Name);
                        lvi.Group = fileGroup;
                        lvi.Tag = fi;

                        listView1.Items.Add(lvi);
                    }

                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(string.Format("You don't appear to have access to the requested directory or files - {0}", ex), "Oops");
                }
                finally
                {
                    this.listView1.EndUpdate();
                    this.treeView1.EndUpdate();
                }
            }
        }

    }
}
