using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClearRecycle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        const int SHERB_NOCONFIRMATION = 0x000001;	//整型常量在API中表示删除时没有确认对话框
        const int SHERB_NOPROGRESSUI = 0x000002;		//在API中表示不显示删除进度条
        const int SHERB_NOSOUND = 0x000004;			//在API中表示删除完毕时不播放声音

        [DllImportAttribute("shell32.dll")]					//声明API函数
        private static extern int SHEmptyRecycleBin(IntPtr handle, string root, int falgs);

        private void button1_Click(object sender, EventArgs e)
        {
            //清空回收站
            SHEmptyRecycleBin(this.Handle, "", SHERB_NOCONFIRMATION + SHERB_NOPROGRESSUI + SHERB_NOSOUND);
        }

    }
}