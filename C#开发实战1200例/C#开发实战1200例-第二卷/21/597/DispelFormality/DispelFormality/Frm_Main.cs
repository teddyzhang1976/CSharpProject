using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DispelFormality
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Frm_Logon FrmLogon = new Frm_Logon();
            if (FrmLogon.ShowDialog() == DialogResult.OK)
            { 
                //对主窗体进行相关操作
            }
            else
                Application.Exit();
        }
    }
}