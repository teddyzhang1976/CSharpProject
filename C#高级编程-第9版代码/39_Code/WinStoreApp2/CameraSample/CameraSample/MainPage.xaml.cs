using CameraSample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CameraSample
{
  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class MainPage : Page
  {

    private NavigationHelper navigationHelper;
    private ObservableDictionary defaultViewModel = new ObservableDictionary();

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


    public MainPage()
    {
      this.InitializeComponent();
      this.navigationHelper = new NavigationHelper(this);
      this.navigationHelper.LoadState += navigationHelper_LoadState;
      this.navigationHelper.SaveState += navigationHelper_SaveState;
    }

    /// <summary>
    /// Populates the page with content passed during navigation. Any saved state is also
    /// provided when recreating a page from a prior session.
    /// </summary>
    /// <param name="sender">
    /// The source of the event; typically <see cref="NavigationHelper"/>
    /// </param>
    /// <param name="e">Event data that provides both the navigation parameter passed to
    /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
    /// a dictionary of state preserved by this page during an earlier
    /// session. The state will be null the first time a page is visited.</param>
    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
    }

    /// <summary>
    /// Preserves state associated with this page in case the application is suspended or the
    /// page is discarded from the navigation cache.  Values must conform to the serialization
    /// requirements of <see cref="SuspensionManager.SessionState"/>.
    /// </summary>
    /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
    /// <param name="e">Event data that provides an empty dictionary to be populated with
    /// serializable state.</param>
    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
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

    private async void OnRecordVideo(object sender, RoutedEventArgs e)
    {
      var cam = new CameraCaptureUI();
      cam.VideoSettings.AllowTrimming = true;
      cam.VideoSettings.MaxResolution = CameraCaptureUIMaxVideoResolution.StandardDefinition;
      cam.VideoSettings.Format = CameraCaptureUIVideoFormat.Wmv;
      cam.VideoSettings.MaxDurationInSeconds = 5;
      StorageFile file = await cam.CaptureFileAsync(CameraCaptureUIMode.Video);

      if (file != null)
      {
        var picker = new FolderPicker();
        picker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
        picker.FileTypeFilter.Add(".wmv");
        StorageFolder folder = await picker.PickSingleFolderAsync();
        await file.CopyAsync(folder);
      }

    }

    private async void OnTakePhoto(object sender, RoutedEventArgs e)
    {
      var cam = new CameraCaptureUI();
      cam.PhotoSettings.AllowCropping = true;
      cam.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Png;
      cam.PhotoSettings.CroppedAspectRatio = new Size(3, 1);
//      cam.PhotoSettings.CroppedSizeInPixels = new Size(300, 600);
      StorageFile file = await cam.CaptureFileAsync(CameraCaptureUIMode.Photo);

      if (file != null)
      {
        var picker = new FolderPicker();
        picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        picker.FileTypeFilter.Add(".png");
        StorageFolder folder = await picker.PickSingleFolderAsync();
        await file.CopyAsync(folder);
      }
    }
  }
}
