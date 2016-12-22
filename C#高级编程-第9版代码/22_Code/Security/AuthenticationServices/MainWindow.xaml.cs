using System.Net;
using System.Web.Security;
using System.Windows;

namespace AuthenticationServices
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

    }

    void OnLogin(object sender, RoutedEventArgs e)
    {
      try
      {
        labelValidatedInfo.Visibility = Visibility.Hidden;
        if (Membership.ValidateUser(textUsername.Text,
              textPassword.Password))
        {
          // user validated!
          labelValidatedInfo.Visibility = Visibility.Visible;
        }
        else
        {
          MessageBox.Show("Username or password not valid",
                "Client Authentication Services", MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
      }
      catch (WebException ex)
      {
        MessageBox.Show(ex.Message, "Client Application Services",
              MessageBoxButton.OK, MessageBoxImage.Error);
      }

    }
  }
}
