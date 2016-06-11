using System.Drawing;
using System.Windows.Forms;

namespace DisplayPicture
{
    public partial class Form1 : Form
    {
        private readonly Image piccy;
        private readonly Point[] piccyBounds;

        public Form1()
        {
            InitializeComponent();

            piccy =
                Image.FromFile(
                    @"[place the location of your image here]");
            this.AutoScrollMinSize = piccy.Size;
            this.Text = "St. Petersburg Summer 2007";
            piccyBounds = new Point[3];
            piccyBounds[0] = new Point(0, 0); // top left
            piccyBounds[1] = new Point(piccy.Width, 0); // top right
            piccyBounds[2] = new Point(0, piccy.Height); // bottom left
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            dc.ScaleTransform(1.0f, 1.0f);
            dc.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            dc.DrawImage(piccy, piccyBounds);
        }
    }
}
