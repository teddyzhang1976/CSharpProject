using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectionWithCSharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OnOpenImage(object sender, RoutedEventArgs e)
        {
          var picker = new FileOpenPicker();
          picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
          picker.FileTypeFilter.Add(".jpg");
          picker.FileTypeFilter.Add(".png");
          StorageFile file = await picker.PickSingleFileAsync();

          var image = new BitmapImage();
          image.SetSource(await file.OpenReadAsync());

          image1.Source = image;
        }
    }
}
