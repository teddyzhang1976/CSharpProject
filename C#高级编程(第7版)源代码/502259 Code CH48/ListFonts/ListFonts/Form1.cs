using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ListFonts
{
    public partial class Form1 : Form
    {
        private const int margin = 10;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int verticalCoordinate = margin;
            InstalledFontCollection insFont = new InstalledFontCollection();
            FontFamily[] families = insFont.Families;
            e.Graphics.TranslateTransform(AutoScrollPosition.X,
                                          AutoScrollPosition.Y);

            foreach (FontFamily family in families)
            {
                if (family.IsStyleAvailable(FontStyle.Regular))
                {
                    Font f = new Font(family.Name, 10);
                    Point topLeftCorner = new Point(margin, verticalCoordinate);
                    verticalCoordinate += f.Height;
                    e.Graphics.DrawString(family.Name, f,
                                          Brushes.Black, topLeftCorner);
                    f.Dispose();
                }
            }
        }
    }
}