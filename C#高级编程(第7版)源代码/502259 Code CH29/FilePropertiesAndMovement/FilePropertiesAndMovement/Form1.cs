using System;
using System.IO;
using System.Windows.Forms;

namespace FilePropertiesAndMovement
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
            textBoxFolder.Text = "";
            textBoxFolder.Text = "";
            textBoxFileName.Text = "";
            textBoxCreationTime.Text = "";
            textBoxLastAccessTime.Text = "";
            textBoxLastWriteTime.Text = "";
            textBoxFileSize.Text = "";
        }

        protected void DisplayFileInfo(string fileFullName)
        {
            FileInfo theFile = new FileInfo(fileFullName);
            if (!theFile.Exists)
                throw new FileNotFoundException("File not found: " + fileFullName);
            textBoxFileName.Text = theFile.Name;
            textBoxCreationTime.Text = theFile.CreationTime.ToLongTimeString();
            textBoxLastAccessTime.Text = theFile.LastAccessTime.ToLongDateString();
            textBoxLastWriteTime.Text = theFile.LastWriteTime.ToLongDateString();
            textBoxFileSize.Text = theFile.Length + " bytes";

            // enable move, copy, delete buttons
            textBoxNewPath.Text = theFile.FullName;
            textBoxNewPath.Enabled = true;
            buttonCopyTo.Enabled = true;
            buttonDelete.Enabled = true;
            buttonMoveTo.Enabled = true;
        }

        protected void DisplayFolderList(string folderFullName)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folderFullName);
            if (!theFolder.Exists)
                throw new DirectoryNotFoundException("Folder not found: "
                    + folderFullName);
            ClearAllFields();
            DisableMoveFeatures();
            textBoxFolder.Text = theFolder.FullName;
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
                string folderPath = textBoxInput.Text;
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
                    + "this name: " + textBoxInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DisableMoveFeatures()
        {
            textBoxNewPath.Text = "";
            textBoxNewPath.Enabled = false;
            buttonCopyTo.Enabled = false;
            buttonDelete.Enabled = false;
            buttonMoveTo.Enabled = false;
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

        protected void OnDeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath,
                    textBoxFileName.Text);
                string query = "Really delete the file\n" + filePath + "?";
                if (MessageBox.Show(query,
                    "Delete File?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(filePath);
                    DisplayFolderList(currentFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete file. The following exception"
                    + " occurred:\n" + ex.Message, "Failed");
            }
        }

        protected void OnMoveButtonClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath,
                    textBoxFileName.Text);
                string query = "Really move the file\n" + filePath + "\nto "
                    + textBoxNewPath.Text + "?";
                if (MessageBox.Show(query,
                    "Move File?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Move(filePath, textBoxNewPath.Text);
                    DisplayFolderList(currentFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to move file. The following exception"
                    + " occurred:\n" + ex.Message, "Failed");
            }
        }
        protected void OnCopyButtonClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(currentFolderPath,
                    textBoxFileName.Text);
                string query = "Really copy the file\n" + filePath + "\nto "
                    + textBoxNewPath.Text + "?";
                if (MessageBox.Show(query,
                    "Copy File?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Copy(filePath, textBoxNewPath.Text);
                    DisplayFolderList(currentFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to copy file. The following exception"
                    + " occurred:\n" + ex.Message, "Failed");
            }
        }
    }
}