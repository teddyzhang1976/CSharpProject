using System.Windows;
using System.Windows.Controls;

namespace OutOfBrowserDemo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.Current.IsRunningOutOfBrowser)
            {
                text1.Text = "running out of browser";
            }
            else
            {
                text1.Text = "running in the browser";
                updateButton.Visibility = Visibility.Collapsed;
            }
            if (App.Current.InstallState == InstallState.Installed)
            {
                installButton.Visibility = Visibility.Collapsed;
            }
        }

        private void OnInstall(object sender, RoutedEventArgs e)
        {
            if (App.Current.InstallState == InstallState.NotInstalled)
            {
                bool result = App.Current.Install();
                if (result)
                    text1.Text = "installation successful";
            }
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            App.Current.CheckAndDownloadUpdateCompleted += (sender1, e1) =>
                {
                    if (e1.Error != null)
                    {
                        text1.Text = e1.Error.Message;
                    }
                    else
                    {
                        if (e1.UpdateAvailable)
                            text1.Text = "Update successful and will be used with the next start";
                    }
                };
            App.Current.CheckAndDownloadUpdateAsync();
        }
    }
}
