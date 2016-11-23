using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FormatDisk
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("shell32.dll")]
        private static extern int SHFormatDrive(IntPtr hWnd, int drive, long fmtID, int Options);

        public const long SHFMT_ID_DEFAULT = 0xFFFF;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //调用API函数SHFormatDrive执行格式化磁盘操作
                SHFormatDrive(this.Handle, comboBox1.SelectedIndex, SHFMT_ID_DEFAULT, 0);
                MessageBox.Show("格式化完成", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("格式化失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}