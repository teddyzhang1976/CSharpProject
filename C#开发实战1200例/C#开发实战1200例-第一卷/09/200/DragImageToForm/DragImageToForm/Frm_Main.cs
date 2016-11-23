using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//添加的命名空间，对文件进行操作
using System.Threading;//线程序的命名空间

namespace DragImageToForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public static bool Var_Style = true;
        public static string tempstr="";

        /// <summary>
        /// 在窗体背景中显示被拖放的图片
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="DragEventArgs">DragDrop、DragEnter 或 DragOver 事件提供数据</param>
        public void SetDragImageToFrm(Form Frm, DragEventArgs e)
        {
            if (Var_Style == true)
            {
                e.Effect = DragDropEffects.Copy;//设置拖放操作中目标放置类型为复制
                String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
                string tempstr;
                Bitmap bkImage;//定义Bitmap变量
                tempstr = str_Drop[0];//获取拖放文件的目录
                try
                {
                    bkImage = new Bitmap(tempstr);//存储拖放的图片
                    //根据图片设置窗体的大小
                    Frm.Size = new System.Drawing.Size(bkImage.Width + 6, bkImage.Height + 33);
                    Frm.BackgroundImage = bkImage;//在窗体背景中显示图片
                }
                catch { }
            }
        }

        private void Frm_Main_DragEnter(object sender, DragEventArgs e)
        {
            SetDragImageToFrm(this, e);//在窗体中显示拖放到窗体上的图片
        }
    }
}
