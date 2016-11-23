using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Frm_Start frm = new Frm_Start();//实例化Form2窗体对象
            frm.StartPosition = FormStartPosition.CenterScreen;//设置窗体居中显示
            frm.ShowDialog();//显示Form2窗体
        }
    }
}
