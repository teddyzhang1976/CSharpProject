using System.Drawing;
using System.Windows.Forms;

namespace DrawingShapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Graphics dc = CreateGraphics();
            Show();
            Pen bluePen = new Pen(Color.Blue, 3);
            dc.DrawRectangle(bluePen, 0, 0, 50, 50);
            Pen redPen = new Pen(Color.Red, 2);
            dc.DrawEllipse(redPen, 0, 50, 80, 60);
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics dc = e.Graphics;
        //    Pen bluePen = new Pen(Color.Blue, 3);
        //    dc.DrawRectangle(bluePen, 0, 0, 50, 50);
        //    Pen redPen = new Pen(Color.Red, 2);
        //    dc.DrawEllipse(redPen, 0, 50, 80, 60);
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;

            if (e.ClipRectangle.Top < 132 && e.ClipRectangle.Left < 82)
            {
                Pen bluePen = new Pen(Color.Blue, 3);
                dc.DrawRectangle(bluePen, 0, 0, 50, 50);
                Pen redPen = new Pen(Color.Red, 2);
                dc.DrawEllipse(redPen, 0, 50, 80, 60);
            }
        } 


    }
}
