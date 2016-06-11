using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainExample.Properties;

namespace MainExample
{
    public partial class ListExample : Form
    {
        public ListExample()
        {
            InitializeComponent();

            checkedListBox1.DisplayMember = "Name";
            checkedListBox1.ValueMember = "Id";

            LoadData();
        }

        private void LoadData()
        {
            // Get all vendors and add into the controls on screen
            try
            {
                this.comboBox1.BeginUpdate();
                this.listBox1.BeginUpdate();
                this.checkedListBox1.BeginUpdate();
                this.listView1.BeginUpdate();

                foreach (Vendor v in Vendor.GetVendors())
                {
                    this.comboBox1.Items.Add(v);
                    this.listBox1.Items.Add(v);
                    this.checkedListBox1.Items.Add(v);

                    ListViewItem lvi = new ListViewItem(new string[] { v.Id.ToString(), v.Name });
                    lvi.Tag = v;
                    this.listView1.Items.Add(lvi);
                }
            }
            finally
            {
                this.comboBox1.EndUpdate();
                this.listBox1.EndUpdate();
                this.checkedListBox1.EndUpdate();
                this.listView1.EndUpdate();
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox list = sender as CheckedListBox;

            if (null != list)
            {
            }
        }
    }
}
