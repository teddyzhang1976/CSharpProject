using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChuffedFarm
{
    public partial class CPictureBox : PictureBox
    {
        public CPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private bool boolIsInseminate;
        [Browsable(true), Category("自定义"), Description("确定当前的种子是否已种下")] //在“属性”窗口中显示IsFollow属性
        public bool IsInseminate
        {
            get { return boolIsInseminate; }
            set
            {
                boolIsInseminate = value;
                this.Invalidate();
            }
        }
    }
}
