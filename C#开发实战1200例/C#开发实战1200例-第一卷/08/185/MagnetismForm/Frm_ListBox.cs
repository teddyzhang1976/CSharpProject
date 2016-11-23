using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagnetismForm
{
    public partial class Frm_ListBox : Form
    {
        public Frm_ListBox()
        {
            InitializeComponent();
        }

        #region  公共变量
        FrmClass Cla_FrmClass = new FrmClass();
        #endregion

        private void Frm_ListBox_Load(object sender, EventArgs e)
        {
            this.Left = FrmClass.Example_Play_Left;
            this.Top = FrmClass.Example_Play_Top + FrmClass.Example_Play_Height;
            Cla_FrmClass.FrmInitialize(this);
        }

        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            FrmClass.CPoint = new Point(-e.X, -e.Y);
        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            FrmClass.Example_Assistant_AdhereTo = false;
            FrmClass.Example_List_AdhereTo = false;
            Cla_FrmClass.FrmMove(this, e);
        }

        private void panel_Title_MouseUp(object sender, MouseEventArgs e)
        {
            Cla_FrmClass.FrmPlace(this);
        }
    }
}
