using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ScrollMoreShapes
{
    public partial class Form1 : Form
    {
        private Rectangle rectangleBounds = new Rectangle(new Point(0, 0),
                                                          new Size(200, 200));

        private Rectangle ellipseBounds = new Rectangle(new Point(50, 200),
                                                        new Size(200, 150));

        private readonly Pen bluePen = new Pen(Color.Blue, 3);
        private readonly Pen redPen = new Pen(Color.Red, 2);
        private readonly Brush solidAzureBrush = Brushes.Azure;
        private readonly Brush solidYellowBrush = new SolidBrush(Color.Yellow);

        private static readonly Brush brickBrush = new HatchBrush(HatchStyle.DiagonalBrick,
                                                         Color.DarkGoldenrod, Color.Cyan);

        private readonly Pen brickWidePen = new Pen(brickBrush, 10);

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            Point scrollOffset = AutoScrollPosition;
            dc.TranslateTransform(scrollOffset.X, scrollOffset.Y);

            if (e.ClipRectangle.Top + scrollOffset.X < 350 ||
                e.ClipRectangle.Left + scrollOffset.Y < 250)
            {
                dc.DrawRectangle(bluePen, rectangleBounds);
                dc.FillRectangle(solidYellowBrush, rectangleBounds);
                dc.DrawEllipse(redPen, ellipseBounds);
                dc.FillEllipse(solidAzureBrush, ellipseBounds);
                dc.DrawLine(brickWidePen, rectangleBounds.Location,
                            ellipseBounds.Location + ellipseBounds.Size);
            }
        }
    }
}
