using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wrox.ProCSharp.WCF.RoomReservationService;

namespace Wrox.ProCSharp.WCF
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

        private void OnReserveRoom(object sender, RoutedEventArgs e)
        {
            var reservation = new RoomReservation()
            {
                RoomName = textRoom.Text,
                Event = textEvent.Text,
                Contact = textContact.Text,
                StartDate = DateTime.Parse(textStartTime.Text),
                EndDate = DateTime.Parse(textEndTime.Text)
            };

            var client = new RoomServiceClient();
            bool reserved = client.ReserveRoom(reservation);
            client.Close();
            if (reserved)
                MessageBox.Show("reservation ok");
        }

    }
}
