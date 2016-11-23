using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayPictures
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Images>()//绑定到图片集合
            { 
                new Images(){Im=Image.FromFile("1.bmp")},
                new Images(){Im=Image.FromFile("2.bmp")},
                new Images(){Im=Image.FromFile("3.bmp")},
                new Images(){Im=Image.FromFile("4.bmp")},
                new Images(){Im=Image.FromFile("5.bmp")},
                new Images(){Im=Image.FromFile("6.bmp")},
                new Images(){Im=Image.FromFile("7.bmp")}
            };
            dgv_Message.Columns[0].HeaderText = "图片";//设置列文本
            dgv_Message.Columns[0].Width = 70;//设置列宽度
            for (int i = 0; i < dgv_Message.Rows.Count; i++)
            {
                dgv_Message.Rows[i].Height = 70;//设置行高度
            }
        }
    }
}
