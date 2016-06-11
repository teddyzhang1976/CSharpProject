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
using System.Net;
using System.Net.PeerToPeer;
using System.Net.PeerToPeer.Collaboration;

namespace PNMSample
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         // Sign in to PNM
         PeerCollaboration.SignIn(PeerScope.NearMe);

         // Get local peer name to display
         this.Title = string.Format("PNMSample - {0}", ContactManager.LocalContact.Nickname);
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         // Sign out of PNM
         PeerCollaboration.SignOut(PeerScope.NearMe);
      }

      private void RefreshButton_Click(object sender, RoutedEventArgs e)
      {
         // Get local peers
         PeerNearMeCollection peersNearMe = PeerCollaboration.GetPeersNearMe();

         // Prepare for new peers
         PeerList.Items.Clear();

         // Examine peers
         foreach (PeerNearMe peerNearMe in peersNearMe)
         {
            PeerList.Items.Add(
               new PeerEntry
               {
                  PeerNearMe = peerNearMe,
                  PresenceStatus = peerNearMe.GetPresenceInfo(peerNearMe.PeerEndPoints[0]).PresenceStatus,
                  DisplayString = peerNearMe.Nickname
               });
         }

         // Add failure message if necessary
         if (PeerList.Items.Count == 0)
         {
            PeerList.Items.Add(
               new PeerEntry
               {
                  DisplayString = "No peers found."
               });
         }
      }
   }
}
