using System.Drawing;
using System.Windows.Forms;

namespace BigShapes
{
    public partial class Form1 : Form
    {
        private readonly Pen bluePen = new Pen(Color.Blue, 3);
        private readonly Size ellipseSize = new Size(200, 150);
        private readonly Point ellipseTopLeft = new Point(50, 200);
        private readonly Size rectangleSize = new Size(200, 200);
        private readonly Point rectangleTopLeft = new Point(0, 0);
        private readonly Pen redPen = new Pen(Color.Red, 2);

        public Form1()
        {
            InitializeComponent();

            BackColor = Color.White;

            Size = new Size(300, 300);
            Text = "Scroll Shapes Correct";

            AutoScrollMinSize = new Size(250, 350);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;

            Size scrollOffset = new Size(AutoScrollPosition);
            if (e.ClipRectangle.Top + scrollOffset.Width < 350 ||
                e.ClipRectangle.Left + scrollOffset.Height < 250)
            {
                Rectangle rectangleArea = new Rectangle
                    (rectangleTopLeft + scrollOffset, rectangleSize);
                Rectangle ellipseArea = new Rectangle
                    (ellipseTopLeft + scrollOffset, ellipseSize);
                dc.DrawRectangle(bluePen, rectangleArea);
                dc.DrawEllipse(redPen, ellipseArea);
            }

            //if (e.ClipRectangle.Top < 350 || e.ClipRectangle.Left < 250)
            //{
            //    Rectangle rectangleArea =
            //       new Rectangle(rectangleTopLeft, rectangleSize);
            //    Rectangle ellipseArea =
            //       new Rectangle(ellipseTopLeft, ellipseSize);
            //    dc.DrawRectangle(bluePen, rectangleArea);
            //    dc.DrawEllipse(redPen, ellipseArea);
            //}
        }
    }
}