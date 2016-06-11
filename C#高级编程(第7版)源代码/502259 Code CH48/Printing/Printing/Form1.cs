using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Printing
{
    public partial class Form1 : Form
    {
        #region constant fields

        // default text in titlebar
        private const uint margin = 10;
        private const string standardTitle = "CapsEditor";
        // horizontal and vertical margin in client area

        #endregion

        private int printingPageNo = 0;

        #region Member fields

        private bool documentHasData = false;
        private readonly ArrayList documentLines = new ArrayList(); // the 'document'
        private Size documentSize; // how big a client area is needed to 
        private readonly Brush emptyDocumentBrush = Brushes.Red;
        // display document
        private Font emptyDocumentFont; // font used to display empty message
        private readonly OpenFileDialog fileOpenDialog = new OpenFileDialog();
        private uint lineHeight; // height in pixels of one line
        private readonly Brush mainBrush = Brushes.Blue;
        private Font mainFont; // font used to display all lines
        // brush used to display document text
        // brush used to display empty document message
        private Point mouseDoubleClickPosition;
        private uint nLines; // number of lines in document
        // location mouse is pointing to when double-clicked
        // set to true if document has some data in it

        #endregion

        public Form1()
        {
            InitializeComponent();

            CreateFonts();
            fileOpenDialog.FileOk += OpenFileDialog_FileOk;
        }

        protected void OpenFileDialog_FileOk(object Sender, CancelEventArgs e)
        {
            LoadFile(fileOpenDialog.FileName);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            fileOpenDialog.ShowDialog();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateFonts()
        {
            mainFont = new Font("Arial", 10);
            lineHeight = (uint) mainFont.Height;
            emptyDocumentFont = new Font("Verdana", 13, FontStyle.Bold);
        }

        private void LoadFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            string nextLine;
            documentLines.Clear();
            nLines = 0;
            TextLineInformation nextLineInfo;
            while ((nextLine = sr.ReadLine()) != null)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = nextLine;
                documentLines.Add(nextLineInfo);
                ++nLines;
            }
            sr.Close();
            if (nLines > 0)
            {
                documentHasData = true;
                menuFilePrint.Enabled = true;
                menuFilePrintPreview.Enabled = true;
            }
            else
            {
                documentHasData = false;
                menuFilePrint.Enabled = false;
                menuFilePrintPreview.Enabled = false;
            }

            CalculateLineWidths();
            CalculateDocumentSize();

            Text = standardTitle + " - " + FileName;
            Invalidate();
        }

        private void CalculateLineWidths()
        {
            Graphics dc = CreateGraphics();
            foreach (TextLineInformation nextLine in documentLines)
            {
                nextLine.Width = (uint) dc.MeasureString(nextLine.Text,
                                                         mainFont).Width;
            }
        }

        private void CalculateDocumentSize()
        {
            if (!documentHasData)
            {
                documentSize = new Size(100, 200);
            }
            else
            {
                documentSize.Height = (int) (nLines*lineHeight) + 2*(int) margin;
                uint maxLineLength = 0;
                foreach (TextLineInformation nextWord in documentLines)
                {
                    uint tempLineLength = nextWord.Width + 2*margin;
                    if (tempLineLength > maxLineLength)
                        maxLineLength = tempLineLength;
                }
                documentSize.Width = (int) maxLineLength;
            }
            AutoScrollMinSize = documentSize;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            int scrollPositionX = AutoScrollPosition.X;
            int scrollPositionY = AutoScrollPosition.Y;
            dc.TranslateTransform(scrollPositionX, scrollPositionY);

            if (!documentHasData)
            {
                dc.DrawString("<Empty document>", emptyDocumentFont,
                              emptyDocumentBrush, new Point(20, 20));
                base.OnPaint(e);
                return;
            }
            // work out which lines are in clipping rectangle
            int minLineInClipRegion =
                WorldYCoordinateToLineIndex(e.ClipRectangle.Top - scrollPositionY);
            if (minLineInClipRegion == -1)
                minLineInClipRegion = 0;
            int maxLineInClipRegion =
                WorldYCoordinateToLineIndex(e.ClipRectangle.Bottom -
                                            scrollPositionY);
            if (maxLineInClipRegion >= documentLines.Count ||
                maxLineInClipRegion == -1)
                maxLineInClipRegion = documentLines.Count - 1;

            TextLineInformation nextLine;
            for (int i = minLineInClipRegion; i <= maxLineInClipRegion; i++)
            {
                nextLine = (TextLineInformation) documentLines[i];
                dc.DrawString(nextLine.Text, mainFont, mainBrush,
                              LineIndexToWorldCoordinates(i));
            }
            base.OnPaint(e);
        }

        private Point LineIndexToWorldCoordinates(int index)
        {
            Point TopLeftCorner = new Point(
                (int) margin, (int) (lineHeight*index + margin));
            return TopLeftCorner;
        }

        private int WorldYCoordinateToLineIndex(int y)
        {
            if (y < margin)
                return -1;
            return (int) ((y - margin)/lineHeight);
        }

        private int WorldCoordinatesToLineIndex(Point position)
        {
            if (!documentHasData)
                return -1;
            if (position.Y < margin || position.X < margin)
                return -1;
            int index = (int) (position.Y - margin)/(int) lineHeight;
            // check position isn't below document
            if (index >= documentLines.Count)
                return -1;
            // now check that horizontal position is within this line
            TextLineInformation theLine =
                (TextLineInformation) documentLines[index];
            if (position.X > margin + theLine.Width)
                return -1;

            // all is OK. We can return answer
            return index;
        }

        private Point LineIndexToPageCoordinates(int index)
        {
            return LineIndexToWorldCoordinates(index) +
                   new Size(AutoScrollPosition);
        }

        private int PageCoordinatesToLineIndex(Point position)
        {
            return WorldCoordinatesToLineIndex(position - new
                                                              Size(AutoScrollPosition));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDoubleClickPosition = new Point(e.X, e.Y);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            int i = PageCoordinatesToLineIndex(mouseDoubleClickPosition);
            if (i >= 0)
            {
                TextLineInformation lineToBeChanged =
                    (TextLineInformation) documentLines[i];
                lineToBeChanged.Text = lineToBeChanged.Text.ToUpper();
                Graphics dc = CreateGraphics();
                uint newWidth = (uint) dc.MeasureString(lineToBeChanged.Text,
                                                        mainFont).Width;
                if (newWidth > lineToBeChanged.Width)
                    lineToBeChanged.Width = newWidth;
                if (newWidth + 2*margin > documentSize.Width)
                {
                    documentSize.Width = (int) newWidth;
                    AutoScrollMinSize = documentSize;
                }
                Rectangle changedRectangle = new Rectangle(
                    LineIndexToPageCoordinates(i),
                    new Size((int) newWidth,
                             (int) lineHeight));
                Invalidate(changedRectangle);
            }
            base.OnDoubleClick(e);
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            // Calculate the number of lines per page.
            int linesPerPage = (int) (e.MarginBounds.Height/
                                      mainFont.GetHeight(e.Graphics));
            //			linesPerPage = 10;
            int lineNo = printingPageNo*linesPerPage;

            // Print each line of the file.
            int count = 0;
            while (count < linesPerPage && lineNo < nLines)
            {
                string line = ((TextLineInformation) documentLines[lineNo]).Text;
                float yPos = topMargin + (count*mainFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, mainFont, Brushes.Blue,
                                      leftMargin, yPos, new StringFormat());
                lineNo++;
                count++;
            }

            // If more lines exist, print another page.
            if (nLines > lineNo)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            printingPageNo++;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += pd_PrintPage;
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += pd_PrintPage;
            ppd.Document = pd;
            ppd.ShowDialog();
        }
    }

    internal class TextLineInformation
    {
        public string Text;
        public uint Width;
    }
}