using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using R = Wrox.ProCSharp.DataServices.RestaurantService.RestaurantModel;

namespace Wrox.ProCSharp.DataServices
{
    public partial class MainWindow : Window
    {
        private R.RestaurantEntities data;
        private DataServiceCollection<R.Menu> trackedMenus;

        public MainWindow()
        {
            Uri serviceRoot = new Uri(Properties.Settings.Default.RestaurantServiceURL);
            data = new R.RestaurantEntities(serviceRoot);
            data.SendingRequest += data_SendingRequest;

            InitializeComponent();
            this.DataContext = this;

            var q = from m in data.Menus.AddQueryOption("$expand", "Category")
                      where m.Category.Name == "Soup"
                      orderby m.Name
                      select m;
            var l1 = q.ToList<R.Menu>();


            var q2 = from m in data.Menus.Expand("Category")
                    where m.Category.Name == "Soup"
                    orderby m.Name
                    select m;
            var l2 = q2.ToList<R.Menu>();

        }

        public IEnumerable<R.Category> Categories
        {
            get
            {
                return from c in data.Categories
                       orderby c.Name
                       select c;
            }
        }

        public IEnumerable<R.Menu> Menus
        {
            get
            {
                if (trackedMenus == null)
                    trackedMenus = DataServiceCollection.CreateTracked<R.Menu>(
                        data,
                        from m in data.Menus
                        where m.CategoryId == (comboCategories.SelectedItem as R.Category).Id && m.Active
                        select m);
                return trackedMenus;
            }
        }

        

        void data_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Method: {0}\n", e.Request.Method);
            sb.AppendFormat("Uri: {0}\n", e.Request.RequestUri.ToString());
            this.textStatus.Text = sb.ToString();
        }

        private void OnCategorySelection(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedCategory = comboCategories.SelectedItem as R.Category;
            if (selectedCategory != null && trackedMenus != null)
            {
                trackedMenus.Clear();
                trackedMenus.Load(from m in data.Menus
                                  where m.CategoryId == selectedCategory.Id
                                  select m);
            }
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                DataServiceResponse response = data.SaveChanges(SaveChangesOptions.Batch);
            }
            catch (DataServiceRequestException ex)
            {
                textStatus.Text = ex.ToString();
            }
        }

        private void OnShowEntities(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var entity in data.Entities)
            {
                sb.AppendFormat("state = {0}, Uri = {1}, Element = {2}\n", entity.State, entity.Identity, entity.Entity);
            }
            this.textStatus.Text = sb.ToString();
        }

        private void OnAddMenu(object sender, RoutedEventArgs e)
        {
            var menu = new R.Menu();
            menu.Category = this.comboCategories.SelectedItem as R.Category;
            menu.CategoryId = (this.comboCategories.SelectedItem as R.Category).Id;
            menu.Name = "[please add name]";
            menu.Description = "[please add description]";
            menu.Price = 0m;
            menu.Active = true;

            trackedMenus.Add(menu);
        }
    }
}
