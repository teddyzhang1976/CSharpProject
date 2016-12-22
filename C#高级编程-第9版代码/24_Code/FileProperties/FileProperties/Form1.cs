using System;
using System.IO;
using System.Windows.Forms;

namespace FileProperties
{
    public partial class Form1 : Form
    {
        private string currentFolderPath;

        public Form1()
        {
            InitializeComponent();
        }

        protected void ClearAllFields()
        {
            listBoxFolders.Items.Clear();
            listBoxFiles.Items.Clear();
            txtBoxFolder.Text = "";
            txtBoxFileName.Text = "";
            txtBoxCreationTime.Text = "";
            txtBoxLastAccessTime.Text = "";
            txtBoxLastWriteTime.Text = "";
            txtBoxFileSize.Text = "";
        }

        protected void DisplayFileInfo(string fileFullName)
        {
            FileInfo theFile = new FileInfo(fileFullName);
            if (!theFile.Exists)
                throw new FileNotFoundException("File not found: " + fileFullName);
            txtBoxFileName.Text = theFile.Name;
            txtBoxCreationTime.Text = theFile.CreationTime.ToLongTimeString();
            txtBoxLastAccessTime.Text = theFile.LastAccessTime.ToLongDateString();
            txtBoxLastWriteTime.Text = theFile.LastWriteTime.ToLongDateString();
            txtBoxFileSize.Text = theFile.Length + " bytes";
        }

        protected void DisplayFolderList(string folderFullName)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folderFullName);
            if (!theFolder.Exists)
                throw new DirectoryNotFoundException("Folder not found: "
                                                     + folderFullName);
            ClearAllFields();
            txtBoxFolder.Text = theFolder.FullName;
            currentFolderPath = theFolder.FullName;

            // list all subfolders in folder

            foreach (DirectoryInfo nextFolder in theFolder.GetDirectories())
                listBoxFolders.Items.Add(nextFolder.Name);

            // list all files in folder

            foreach (FileInfo nextFile in theFolder.GetFiles())
                listBoxFiles.Items.Add(nextFile.Name);
        }

        protected void OnDisplayButtonClick(object sender, EventArgs e)
        {
            try
            {
                string folderPath = txtBoxInput.Text;
                DirectoryInfo theFolder = new DirectoryInfo(folderPath);
                if (theFolder.Exists)
                {
                    DisplayFolderList(theFolder.FullName);
                    return;
                }
                FileInfo theFile = new FileInfo(folderPath);
                if (theFile.Exists)
                {
                    DisplayFolderList(theFile.Directory.FullName);
                    int index = listBoxFiles.Items.IndexOf(theFile.Name);
                    listBoxFiles.SetSelected(index, true);
                    return;
                }
                throw new FileNotFoundException("There is no file or folder with "
                                                + "this name: " + txtBoxInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void OnListBoxFilesSelected(object sender, EventArgs e)
        {
            try
            {
                string selectedString = listBoxFiles.SelectedItem.ToString();
                string fullFileName = Path.Combine(currentFolderPath, selectedString);
                DisplayFileInfo(fullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void OnListBoxFoldersSelected(object sender, EventArgs e)
        {
            try
            {
                string selectedString = listBoxFolders.SelectedItem.ToString();
                string fullPathName = Path.Combine(currentFolderPath, selectedString);
                DisplayFolderList(fullPathName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void OnUpButtonClick(object sender, EventArgs e)
        {
            try
            {
                string folderPath = new FileInfo(currentFolderPath).DirectoryName;
                DisplayFolderList(folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}