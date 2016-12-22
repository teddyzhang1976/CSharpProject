using System;
using Windows.Devices.Sensors;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RollingMarble
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    private Accelerometer accelerometer;
    private double MinX = 0;
    private double MinY = 0;
    private double MaxX = 1000;
    private double MaxY = 600;
    private double currentX = 0;
    private double currentY = 0;
    public MainPage()
    {
      this.InitializeComponent();
      accelerometer = Accelerometer.GetDefault();
      accelerometer.ReportInterval = accelerometer.MinimumReportInterval;
      accelerometer.ReadingChanged += OnAccelerometerReading;
      this.DataContext = this;

      this.LayoutUpdated += (sender, e) =>
        {
          MaxX = this.ActualWidth - 100;
          MaxY = this.ActualHeight - 100;
        };
    }

    private async void OnAccelerometerReading(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
    {
      currentX += args.Reading.AccelerationX * 80;
      if (currentX < MinX) currentX = MinX;
      if (currentX > MaxX) currentX = MaxX;

      currentY += -args.Reading.AccelerationY * 80;
      if (currentY < MinY) currentY = MinY;
      if (currentY > MaxY) currentY = MaxY;

      await this.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
        {
          Canvas.SetLeft(ell1, currentX);
          Canvas.SetTop(ell1, currentY);
        });
    }




    
  }
}
