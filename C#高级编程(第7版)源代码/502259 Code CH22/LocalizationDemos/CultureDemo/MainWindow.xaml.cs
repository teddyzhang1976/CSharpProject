using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CultureDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddCulturesToTree();
        }

        private void AddCulturesToTree()
        {
            var culturesByName = new Dictionary<string, TreeViewItem>();

            // get all cultures
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            Array.Sort(cultures, (c1, c2) => c1.Name.CompareTo(c2.Name));

            var nodes = new TreeViewItem[cultures.Length];

            int i = 0;
            foreach (var ci in cultures)
            {
                nodes[i] = new TreeViewItem();
                nodes[i].Header = ci.DisplayName;
                nodes[i].Tag = ci;
                culturesByName.Add(ci.Name, nodes[i]);

                TreeViewItem parent;
                if (!String.IsNullOrEmpty(ci.Parent.Name) &&
                      culturesByName.TryGetValue(ci.Parent.Name, out parent))
                {
                    parent.Items.Add(nodes[i]);
                }
                else
                {
                    treeCultures.Items.Add(nodes[i]);
                }
                i++;
            }

        }

        private void treeCultures_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ClearTextFields();

            // get CultureInfo object from tree
            CultureInfo ci = (CultureInfo)((TreeViewItem)e.NewValue).Tag;

            textCultureName.Text = ci.Name;
            textNativeName.Text = ci.NativeName;
            textEnglishName.Text = ci.EnglishName;

            chkIsNeutral.IsChecked = ci.IsNeutralCulture;

            // default calendar
            textCalendar.Text = ci.Calendar.ToString().
                  Remove(0, 21).Replace("Calendar", "");

            // fill optional calendars
            listCalendars.Items.Clear();
            foreach (var optCal in ci.OptionalCalendars)
            {
                var calName = new StringBuilder(50);
                calName.Append(optCal.ToString());
                calName.Remove(0, 21);
                calName.Replace("Calendar", "");

                // for GregorianCalendar add type information
                GregorianCalendar gregCal = optCal as GregorianCalendar;
                if (gregCal != null)
                {
                    calName.AppendFormat(" {0}", gregCal.CalendarType.ToString());
                }
                listCalendars.Items.Add(calName.ToString());
            }
            // display number and date samples
            if (!ci.IsNeutralCulture)
            {
                groupSamples.IsEnabled = true;
                ShowSamples(ci);

                // invariant culture doesn’t have a region
                if (String.Compare(ci.ThreeLetterISOLanguageName, "IVL", true) == 0)
                {
                    groupRegion.IsEnabled = false;
                }
                else
                {
                    groupRegion.IsEnabled = true;
                    ShowRegionInformation(ci.Name);
                }
            }
            else // neutral culture: no region, no number/date formatting
            {
                groupSamples.IsEnabled = false;
                groupRegion.IsEnabled = false;
            }

        }

        private void ShowSamples(CultureInfo ci)
        {
            double number = 9876543.21;
            textNumber.Text = number.ToString("N", ci);

            DateTime today = DateTime.Today;
            textDate.Text = today.ToString("D", ci);

            DateTime now = DateTime.Now;
            textTime.Text = now.ToString("T", ci);
        }

        private void ShowRegionInformation(string culture)
        {
            var ri = new RegionInfo(culture);
            textRegion.Text = ri.DisplayName;
            textCurrency.Text = ri.CurrencySymbol;
            textCurrencyISO.Text = ri.ISOCurrencySymbol;
            checkIsMetric.IsChecked = ri.IsMetric;
        }


        private void ClearTextFields()
        {
            textCultureName.Text = String.Empty;
            textNativeName.Text = String.Empty;
            textEnglishName.Text = String.Empty;

            textCalendar.Text = string.Empty;

            listCalendars.Items.Clear();

            groupSamples.IsEnabled = false;
            textNumber.Text = string.Empty;
            textDate.Text = string.Empty;
            textTime.Text = string.Empty;

            groupRegion.IsEnabled = false;
            textRegion.Text = string.Empty;
            textCurrency.Text = string.Empty;
            textCurrencyISO.Text = string.Empty;
        }
    }
}
