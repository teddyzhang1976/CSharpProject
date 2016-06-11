using System;
using System.IO;
using System.Windows.Forms;

namespace DriveViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] di = DriveInfo.GetDrives();

            foreach (DriveInfo itemDrive in di)
            {
                listBox1.Items.Add(itemDrive.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo di = new DriveInfo(listBox1.SelectedItem.ToString());

            MessageBox.Show("Available Free Space: " + di.AvailableFreeSpace + "\n" +
                            "Drive Format: " + di.DriveFormat + "\n" +
                            "Drive Type: " + di.DriveType + "\n" +
                            "Is Ready: " + di.IsReady + "\n" +
                            "Name: " + di.Name + "\n" +
                            "Root Directory: " + di.RootDirectory + "\n" +
                            "ToString() Value: " + di + "\n" +
                            "Total Free Space: " + di.TotalFreeSpace + "\n" +
                            "Total Size: " + di.TotalSize + "\n" +
                            "Volume Label: " + di.VolumeLabel, di.Name +
                                                               " DRIVE INFO");
        }
    }
}