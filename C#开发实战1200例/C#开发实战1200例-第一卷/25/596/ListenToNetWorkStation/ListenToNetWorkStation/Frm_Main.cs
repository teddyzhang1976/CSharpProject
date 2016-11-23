using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ListenToNetWorkStation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender,EventArgs e)
        {
            try
            {
                this.axWindowsMediaPlayer1.URL = path.Text;//设置WindowsMediaPlayer的URL
            }
            catch(Exception ex)//捕获异常
            {
                MessageBox.Show(ex.Message);//显示异常信息
            }
        }
    }
}