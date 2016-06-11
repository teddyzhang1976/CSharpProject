using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BinaryFileReader
{
    public partial class Form1 : Form
    {
        private readonly OpenFileDialog chooseOpenFileDialog = new OpenFileDialog();
        private string chosenFile;

        public Form1()
        {
            InitializeComponent();

            menuFileOpen.Click += OnFileOpen;
            chooseOpenFileDialog.FileOk += OnOpenFileDialogOK;
        }

        private void OnFileOpen(object Sender, EventArgs e)
        {
            chooseOpenFileDialog.ShowDialog();
        }

        private void OnOpenFileDialogOK(object Sender, CancelEventArgs e)
        {
            chosenFile = chooseOpenFileDialog.FileName;
            Text = Path.GetFileName(chosenFile);
            DisplayFile();
        }

        private void DisplayFile()
        {
            int nCols = 16;
            FileStream inStream = new FileStream(chosenFile, FileMode.Open,
                                                 FileAccess.Read);
            long nBytesToRead = inStream.Length;
            if (nBytesToRead > 65536/4)
                nBytesToRead = 65536/4;
            int nLines = (int) (nBytesToRead/nCols) + 1;
            string[] lines = new string[nLines];
            int nBytesRead = 0;
            for (int i = 0; i < nLines; i++)
            {
                StringBuilder nextLine = new StringBuilder();
                nextLine.Capacity = 4*nCols;
                for (int j = 0; j < nCols; j++)
                {
                    int nextByte = inStream.ReadByte();
                    nBytesRead++;
                    if (nextByte < 0 || nBytesRead > 65536)
                        break;
                    char nextChar = (char) nextByte;
                    if (nextChar < 16)
                        nextLine.Append(" x0" + string.Format("{0,1:X}",
                                                              (int) nextChar));
                    else if
                        (char.IsLetterOrDigit(nextChar) ||
                         char.IsPunctuation(nextChar))
                        nextLine.Append("  " + nextChar + " ");
                    else
                        nextLine.Append(" x" + string.Format("{0,2:X}",
                                                             (int) nextChar));
                }
                lines[i] = nextLine.ToString();
            }
            inStream.Close();
            textBoxContents.Lines = lines;
        }
    }
}