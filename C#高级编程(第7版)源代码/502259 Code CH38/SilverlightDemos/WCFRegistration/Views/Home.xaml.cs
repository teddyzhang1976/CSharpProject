using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
// using WCFRegistration.RegistrationService;
using System.Collections.ObjectModel;
using WCFRegistration.RegistrationDataService.EventRegistrationModel;
using System.Data.Services.Client;
using System.Xml.Linq;

namespace WCFRegistration
{
    public partial class Home : Page
    {
        public Home()
        {
            CurrentAttendee = new Attendee();
            EventList = new ObservableCollection<Event>();
            InitializeComponent();

            this.DataContext = this;
        }

        public ObservableCollection<Event> EventList { get; private set; }
        public Attendee CurrentAttendee { get; private set; }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri serviceRoot = new Uri("EventRegistrationDataService.svc", UriKind.Relative);
            EventRegistrationEntities data = new EventRegistrationEntities(serviceRoot);
            var q = from ev in data.Events
                    where ev.DateFrom >= DateTime.Today && ev.DateFrom <= DateTime.Today.AddMonths(2)
                    select ev;

            DataServiceQuery<Event> query = (DataServiceQuery<Event>)q;
            query.BeginExecute(ar =>
                {
                    var query1 = ar.AsyncState as DataServiceQuery<Event>;
                    var events = query1.EndExecute(ar);
                    foreach (var ev in events)
                    {
                        EventList.Add(ev);
                    }
                }, query);

            
            //var client = new RegistrationServiceClient();
            //client.GetEventsCompleted += (sender, e1) =>
            //    {
            //        if (e1.Error != null)
            //        {
                        
            //        }
            //        else
            //        {
            //            foreach (var ev in e1.Result)
            //            {
            //                eventList.Add(ev);
            //            }
            //        }
            //    };
            //client.GetEventsAsync(DateTime.Today, DateTime.Today.AddMonths(2));
        }

        private void OnRegistration(object sender, RoutedEventArgs e)
        {
            CurrentAttendee.EventId = (comboEvents.SelectedItem as Event).Id;

            var client = new WebClient();
            client.DownloadStringCompleted += (sender1, e1) =>
                {
                    if (e1.Error != null)
                    {
                        NavigationService.Navigate(new Uri("/ErrorPage", UriKind.Relative));
                    }

                    bool result = bool.Parse(XElement.Parse(e1.Result).Value);
                    if (result)
                        NavigationService.Navigate(new Uri("/Success", UriKind.Relative));
                    else
                        NavigationService.Navigate(new Uri("ErrorPage", UriKind.Relative));

                };
            Uri requestUri = new Uri(
                 String.Format("../../EventRegistrationDataService.svc/AddAttendee?name='{0}'&email='{1}'&company='{2}'&registrationCode='{3}'&eventid={4}",
                CurrentAttendee.Name, CurrentAttendee.Email, CurrentAttendee.Company, CurrentAttendee.RegistrationCode, CurrentAttendee.EventId),
                UriKind.Relative);
            client.DownloadStringAsync(requestUri);
            
            //var client = new RegistrationServiceClient();
            //CurrentAttendee.EventId = (comboEvents.SelectedItem as Event).Id;
            //client.RegisterAttendeeCompleted += (sender1, e1) =>
            //    {
            //        if (e1.Error == null)
            //        {
            //            if (e1.Result)
            //            {
            //                NavigationService.Navigate(new Uri("/Success", UriKind.Relative));
            //            }
            //            else
            //            {
            //                NavigationService.Navigate(new Uri("/ErrorPage", UriKind.Relative));       
            //            }
            //        }
            //        else
            //        {
            //            // display error
            //        }
            //    };

            //client.RegisterAttendeeAsync(CurrentAttendee);

        }
    }
}