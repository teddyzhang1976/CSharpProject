using Wrox.ProCSharp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using Wrox.ProCSharp.Storage;
using Wrox.ProCSharp.Model;
using System.Diagnostics.Contracts;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace Wrox.ProCSharp
{
  /// <summary>
  /// A page that displays a collection of item previews.  In the Split Application this page
  /// is used to display and select one of the available groups.
  /// </summary>
  public sealed partial class MenuItemsPage : Page
  {
    private NavigationHelper navigationHelper;
    private ObservableDictionary defaultViewModel = new ObservableDictionary();

    private MenuCard card;

    /// <summary>
    /// This can be changed to a strongly typed view model.
    /// </summary>
    public ObservableDictionary DefaultViewModel
    {
      get { return this.defaultViewModel; }
    }

    /// <summary>
    /// NavigationHelper is used on each page to aid in navigation and 
    /// process lifetime management
    /// </summary>
    public NavigationHelper NavigationHelper
    {
      get { return this.navigationHelper; }
    }

    public MenuItemsPage()
    {
      this.InitializeComponent();
      this.navigationHelper = new NavigationHelper(this);
      this.navigationHelper.LoadState += navigationHelper_LoadState;
    }

    /// <summary>
    /// Populates the page with content passed during navigation.  Any saved state is also
    /// provided when recreating a page from a prior session.
    /// </summary>
    /// <param name="sender">
    /// The source of the event; typically <see cref="NavigationHelper"/>
    /// </param>
    /// <param name="e">Event data that provides both the navigation parameter passed to
    /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
    /// a dictionary of state preserved by this page during an earlier
    /// session.  The state will be null the first time a page is visited.</param>
    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
      card = e.NavigationParameter as MenuCard;
      if (card != null)
      {
        this.DefaultViewModel["Items"] = card.MenuItems;

        //sharing = new SharingContract();
        //sharing.ShareMenuCard(card);
      }
    }

    #region NavigationHelper registration

    /// The methods provided in this section are simply used to allow
    /// NavigationHelper to respond to the page's navigation methods.
    /// 
    /// Page specific logic should be placed in event handlers for the  
    /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
    /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
    /// The navigation parameter is available in the LoadState method 
    /// in addition to page state preserved during an earlier session.

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedFrom(e);
    }

    #endregion

    private RelayCommand saveCommand;
    public RelayCommand SaveCommand
    {
      get
      {
        return saveCommand ?? (saveCommand = new RelayCommand(OnSave));
      }
    }

    private async void OnSave()
    {
      Contract.Requires<InvalidOperationException>(card != null);

      var picker = new FileSavePicker();
      picker.DefaultFileExtension = ".xml";
      picker.SuggestedFileName = string.Format("MenuCard {0}.xml", card.Title);
      picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
      picker.FileTypeChoices.Add("XML File", new List<string>() { ".xml" });

      StorageFile file = await picker.PickSaveFileAsync();
      var storage = new MenuCardStorage();
      await storage.WriteMenuCardToFileAsync(card, file);
    }

  }
}
