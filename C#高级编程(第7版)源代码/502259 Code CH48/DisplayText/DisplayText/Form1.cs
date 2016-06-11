using System.Drawing;
using System.Windows.Forms;

namespace DisplayText
{
    public partial class Form1 : Form
    {
        private readonly Brush blackBrush = Brushes.Black;
        private readonly Brush blueBrush = Brushes.Blue;
        private readonly Font boldTimesFont = new Font("Times New Roman", 10, FontStyle.Bold);
        private readonly Font haettenschweilerFont = new Font("Haettenschweiler", 12);

        private readonly Font italicCourierFont = new Font("Courier", 11, FontStyle.Italic |
                                                                          FontStyle.Underline);

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            dc.DrawString("This is a groovy string", haettenschweilerFont, blackBrush,
                          10, 10);
            dc.DrawString("This is a groovy string " +
                          "with some very long text that will never fit in the box",
                          boldTimesFont, blueBrush,
                          new Rectangle(new Point(10, 40), new Size(100, 40)));
            dc.DrawString("This is a groovy string", italicCourierFont, blackBrush,
                          new Point(10, 100));
        }
    }
}