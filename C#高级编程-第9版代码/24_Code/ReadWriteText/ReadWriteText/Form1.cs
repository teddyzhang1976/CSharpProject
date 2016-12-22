using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ReadWriteText
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

            menuFileSave.Click += OnFileSave;
        }

        private void OnFileOpen(object Sender, EventArgs e)
        {
            chooseOpenFileDialog.ShowDialog();
        }

        private void OnFileSave(object Sender, EventArgs e)
        {
            SaveFile();
        }

        private void OnOpenFileDialogOK(object Sender, CancelEventArgs e)
        {
            chosenFile = chooseOpenFileDialog.FileName;
            Text = Path.GetFileName(chosenFile);
            DisplayFile();
        }

        private void SaveFile()
        {
            StreamWriter sw = new StreamWriter(chosenFile, false,
                                               Encoding.Unicode);
            foreach (string line in textBoxContents.Lines)
                sw.WriteLine(line);
            sw.Close();
        }

        private void DisplayFile()
        {
            StringCollection linesCollection = ReadFileIntoStringCollection();
            string[] linesArray = new string[linesCollection.Count];
            linesCollection.CopyTo(linesArray, 0);
            textBoxContents.Lines = linesArray;
        }

        private StringCollection ReadFileIntoStringCollection()
        {
            const int MaxBytes = 65536;
            StreamReader sr = new StreamReader(chosenFile);
            StringCollection result = new StringCollection();
            int nBytesRead = 0;
            string nextLine;
            while ((nextLine = sr.ReadLine()) != null)
            {
                nBytesRead += nextLine.Length;
                if (nBytesRead > MaxBytes)
                    break;
                result.Add(nextLine);
            }
            sr.Close();
            return result;
        }
    }
}