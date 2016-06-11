using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCSCustomWebControls
{
    public class RainbowLabel : Label
    {
        private Color[] colors = new Color[] {Color.Red,
                                            Color.Orange,
                                            Color.Yellow,
                                            Color.GreenYellow,
                                            Color.Blue,
                                            Color.Indigo,
                                            Color.Violet};

        private int offset
        {
            get
            {
                object rawOffset = ViewState["_offset"];
                if (rawOffset != null)
                {
                    return (int)rawOffset;
                }
                else
                {
                    ViewState["_offset"] = 0;
                    return 0;
                }
            }
            set
            {
                ViewState["_offset"] = value;
            }
        }

        public void Cycle()
        {
            offset = ++offset;
        }

        protected override void Render(HtmlTextWriter output)
        {
            string text = Text;
            for (int pos = 0; pos < text.Length; pos++)
            {
                int rgb = colors[(pos + offset) % colors.Length].ToArgb()
                                                              & 0xFFFFFF;
                output.Write(string.Format(
                   "<font color=\"#{0:X6}\">{1}</font>", rgb, text[pos]));
            }
        }
    }
}