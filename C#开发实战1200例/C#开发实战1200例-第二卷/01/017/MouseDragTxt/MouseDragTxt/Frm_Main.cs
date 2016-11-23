using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MouseDragTxt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void txt1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)//判断是否按下鼠标左键
            {
                this.Cursor = new Cursor("arrow_l.cur");//设置鼠标样式
                //拖放文本
                DragDropEffects dropEffect = this.txt1.DoDragDrop(this.txt1.Text, DragDropEffects.Copy | DragDropEffects.Link);
            }
        }

        private void txt2_DragDrop(object sender, DragEventArgs e)
        {
            txt2.Text = e.Data.GetData(DataFormats.Text).ToString();//显示拖放文本
        }

        private void txt2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;//设置复制操作
        }
    }
}