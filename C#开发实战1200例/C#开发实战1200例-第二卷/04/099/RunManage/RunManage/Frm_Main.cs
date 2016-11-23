using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace RunManage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string[] Machine;
        string[] User;
        private void getMachineInfo()//读取HKEY_LOCAL_MACHINE分支下的启动项
        {
            string[] reginfo = new string[2];
            RegistryKey rk= Registry.LocalMachine;
            RegistryKey rk2=rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string[] MachineFiles = rk2.GetValueNames();
            Machine = rk2.GetValueNames();
            foreach (string name in MachineFiles)
            {
                string registdata;
                RegistryKey rk3;
                RegistryKey rk4;
                rk3 = Registry.LocalMachine;
                rk4 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                registdata = rk4.GetValue(name).ToString();
                reginfo[0] = name;
                reginfo[1] = registdata;
                ListViewItem lvi = new ListViewItem(reginfo);
                listView1.Items.Add(lvi);
            }
        }

        private void getUserInfo()
        {
            string[] reginfo = new string[2];
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey rk2 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string[] UserFiles = rk2.GetValueNames();
            User = rk2.GetValueNames();
            foreach (string name in UserFiles)
            {
                string registdata;
                RegistryKey rk3;
                RegistryKey rk4;
                rk3 = Registry.CurrentUser;
                rk4 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                registdata = rk4.GetValue(name).ToString();
                reginfo[0] = name;
                reginfo[1] = registdata;
                ListViewItem lvi = new ListViewItem(reginfo);
                listView1.Items.Add(lvi);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getMachineInfo();
            getUserInfo();
        }

        private bool IsMachine(string name)
        {
            bool flag = false;
            for (int i = 0; i < Machine.Length; i++)
            {
                if (Machine[i] == name)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private bool IsUser(string name)
        {
            bool flag = false;
            for (int i = 0; i <User.Length; i++)
            {
                if (User[i] == name)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked == true)
                    {
                        string name = listView1.Items[i].SubItems[0].Text;
                        if (IsMachine(name))
                        {
                            RegistryKey rk0;
                            RegistryKey rk00;
                            rk0 = Registry.LocalMachine;
                            rk00 = rk0.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                            rk00.DeleteValue(name);
                        }
                        if (IsUser(name))
                        {
                            RegistryKey rk0;
                            RegistryKey rk00;
                            rk0 = Registry.CurrentUser;
                            rk00 = rk0.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                            rk00.DeleteValue(name);
                        }
                    }
                }
                listView1.Items.Clear();
                getMachineInfo();
                getUserInfo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
