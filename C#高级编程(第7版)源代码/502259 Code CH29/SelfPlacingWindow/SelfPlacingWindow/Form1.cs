using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SelfPlacingWindow
{
    public partial class Form1 : Form
    {
        private readonly ColorDialog chooseColorDialog = new ColorDialog();

        public Form1()
        {
            InitializeComponent();

            buttonChooseColor.Click += OnClickChooseColor;

            try
            {
                if (ReadSettings() == false)
                    listBoxMessages.Items.Add("No information in registry");
                else
                    listBoxMessages.Items.Add("Information read in from registry");
                StartPosition = FormStartPosition.Manual;
            }
            catch (Exception e)
            {
                listBoxMessages.Items.Add("A problem occurred reading in data from registry:");
                listBoxMessages.Items.Add(e.Message);
            }
        }

        private void OnClickChooseColor(object Sender, EventArgs e)
        {
            if (chooseColorDialog.ShowDialog() == DialogResult.OK)
                BackColor = chooseColorDialog.Color;
        }

        private void SaveSettings()
        {
            RegistryKey softwareKey =
                Registry.LocalMachine.OpenSubKey("Software", true);
            RegistryKey wroxKey = softwareKey.CreateSubKey("WroxPress");
            RegistryKey selfPlacingWindowKey =
                wroxKey.CreateSubKey("SelfPlacingWindow");
            selfPlacingWindowKey.SetValue("BackColor", BackColor.ToKnownColor());
            selfPlacingWindowKey.SetValue("Red", (int) BackColor.R);
            selfPlacingWindowKey.SetValue("Green", (int) BackColor.G);
            selfPlacingWindowKey.SetValue("Blue", (int) BackColor.B);
            selfPlacingWindowKey.SetValue("Width", Width);
            selfPlacingWindowKey.SetValue("Height", Height);
            selfPlacingWindowKey.SetValue("X", DesktopLocation.X);
            selfPlacingWindowKey.SetValue("Y", DesktopLocation.Y);
            selfPlacingWindowKey.SetValue("WindowState", WindowState.ToString());
        }

        private bool ReadSettings()
        {
            RegistryKey softwareKey =
                Registry.LocalMachine.OpenSubKey("Software");
            RegistryKey wroxKey = softwareKey.OpenSubKey("WroxPress");
            if (wroxKey == null)
                return false;
            RegistryKey selfPlacingWindowKey =
                wroxKey.OpenSubKey("SelfPlacingWindow");
            if (selfPlacingWindowKey == null)
                return false;
            else
                listBoxMessages.Items.Add("Successfully opened key " +
                                          selfPlacingWindowKey);
            int redComponent = (int) selfPlacingWindowKey.GetValue("Red");
            int greenComponent = (int) selfPlacingWindowKey.GetValue("Green");
            int blueComponent = (int) selfPlacingWindowKey.GetValue("Blue");
            BackColor = Color.FromArgb(redComponent, greenComponent,
                                       blueComponent);
            listBoxMessages.Items.Add("Background color: " + BackColor.Name);
            int X = (int) selfPlacingWindowKey.GetValue("X");
            int Y = (int) selfPlacingWindowKey.GetValue("Y");
            DesktopLocation = new Point(X, Y);
            listBoxMessages.Items.Add("Desktop location: " +
                                      DesktopLocation);
            Height = (int) selfPlacingWindowKey.GetValue("Height");
            Width = (int) selfPlacingWindowKey.GetValue("Width");
            listBoxMessages.Items.Add("Size: " + new Size(Width, Height));
            string initialWindowState =
                (string) selfPlacingWindowKey.GetValue("WindowState");
            listBoxMessages.Items.Add("Window State: " + initialWindowState);
            WindowState = (FormWindowState) FormWindowState.Parse
                                                (WindowState.GetType(), initialWindowState);
            return true;
        }
    }
}