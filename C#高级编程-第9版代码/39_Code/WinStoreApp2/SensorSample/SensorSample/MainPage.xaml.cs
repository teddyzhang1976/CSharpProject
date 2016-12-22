using SensorSample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SensorSample
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


    private void OnGetLight(object sender, RoutedEventArgs e)
    {
      LightSensor sensor = LightSensor.GetDefault();
      if (sensor != null)
      {
        LightSensorReading reading = sensor.GetCurrentReading();
        this.DefaultViewModel["LightResult"] = string.Format("Illuminance: {0} Lux", reading.IlluminanceInLux);
      }
      else
      {
        this.DefaultViewModel["LightResult"] = "No light sensor found";
      }

    }

    private LightSensor sensor;
    private void OnGetLight2(object sender, RoutedEventArgs e)
    {
      sensor = LightSensor.GetDefault();
      sensor.ReportInterval = sensor.MinimumReportInterval;
      sensor.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["LightResult"] = string.Format("{0:T}\tIlluminance: {1} Lux", e1.Reading.Timestamp, e1.Reading.IlluminanceInLux);
        };
    }

    private async void OnGetCompass(object sender, RoutedEventArgs e)
    {
      Compass compass = Compass.GetDefault();
      if (compass != null)
      {
        CompassReading reading = compass.GetCurrentReading();

        this.DefaultViewModel["CompassResult"] = GetCompassResult(reading);
      }
      else
      {
        var dlg = new MessageDialog("No compass found");
        await dlg.ShowAsync();
      }
    }
    
    private Compass compass;
    private void OnGetCompass2(object sender, RoutedEventArgs e)
    {
      compass = Compass.GetDefault();
      compass.ReportInterval = compass.MinimumReportInterval;
      compass.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["CompassResult"] = GetCompassResult(e1.Reading);
        };
    }

    private string GetCompassResult(CompassReading reading)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("heading accuracy: {0}\n", reading.HeadingAccuracy);
      sb.AppendFormat("magnetic north: {0}\n", reading.HeadingMagneticNorth);
      sb.AppendFormat("true north: {0}\n", reading.HeadingTrueNorth);
      return sb.ToString();
    }

    private void OnGetAccelerometer(object sender, RoutedEventArgs e)
    {
      Accelerometer accelerometer = Accelerometer.GetDefault();
      AccelerometerReading reading = accelerometer.GetCurrentReading();
      this.DefaultViewModel["AccelerometerResult"] = GetAccelerometerResult(reading);
    }

    private Accelerometer accelerometer;
    private void OnGetAccelerometer2(object sender, RoutedEventArgs e)
    {
      accelerometer = Accelerometer.GetDefault();
      accelerometer.ReportInterval = accelerometer.MinimumReportInterval;
      accelerometer.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["AccelerometerResult"] = GetAccelerometerResult(e1.Reading);
        };
      accelerometer.Shaken += (sender1, e1) =>
        {
          this.DefaultViewModel["AccelerometerResult"] = string.Format("shaken at {0:T}", e1.Timestamp);
        };
    }

    private string GetAccelerometerResult(AccelerometerReading reading)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("x: {0}\n", reading.AccelerationX);
      sb.AppendFormat("y: {0}\n", reading.AccelerationY);
      sb.AppendFormat("z: {0}\n", reading.AccelerationZ);
      return sb.ToString();
    }

    private void OnGetInclinometer(object sender, RoutedEventArgs e)
    {
      Inclinometer inclinometer = Inclinometer.GetDefault();
      InclinometerReading reading = inclinometer.GetCurrentReading();
      this.DefaultViewModel["InclinometerResult"] = GetInclinometerResult(reading);
    }

    private Inclinometer inclinometer;
    private void OnGetInclinometer2(object sender, RoutedEventArgs e)
    {
      inclinometer = Inclinometer.GetDefault();
      inclinometer.ReportInterval = inclinometer.MinimumReportInterval;
      inclinometer.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["InclinometerResult"] = GetInclinometerResult(e1.Reading);
        };
    }

    private string GetInclinometerResult(InclinometerReading reading)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("pitch {0} degrees\n", reading.PitchDegrees);
      sb.AppendFormat("roll {0} degrees\n", reading.RollDegrees);
      sb.AppendFormat("yaw accuracy {0}\n", reading.YawAccuracy);
      sb.AppendFormat("yaw {0} degrees\n", reading.YawDegrees);
      return sb.ToString();
    }

    private void OnGetGyrometer(object sender, RoutedEventArgs e)
    {
      Gyrometer gyrometer = Gyrometer.GetDefault();
      GyrometerReading reading = gyrometer.GetCurrentReading();
      this.DefaultViewModel["GyrometerResult"] = GetGyrometerResult(reading);
    }

    private Gyrometer gyrometer;
    private void OnGetGyrometer2(object sender, RoutedEventArgs e)
    {
      gyrometer = Gyrometer.GetDefault();
      gyrometer.ReportInterval = gyrometer.MinimumReportInterval;
      gyrometer.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["GyrometerResult"] = GetGyrometerResult(e1.Reading);
        };
     
    }


    private string GetGyrometerResult(GyrometerReading reading)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("x {0}\n", reading.AngularVelocityX);
      sb.AppendFormat("y {0}\n", reading.AngularVelocityY);
      sb.AppendFormat("z {0}\n", reading.AngularVelocityZ);
      return sb.ToString();
    }

    private void OnGetOrientation(object sender, RoutedEventArgs e)
    {
      OrientationSensor orientation = OrientationSensor.GetDefault();
      OrientationSensorReading reading = orientation.GetCurrentReading();

      this.DefaultViewModel["OrientationSensorResult"] = GetOrientationSensorResult(reading);
    }

    private OrientationSensor orientation;
    private void OnGetOrientation2(object sender, RoutedEventArgs e)
    {
      orientation = OrientationSensor.GetDefault();
      orientation.ReadingChanged += (sender1, e1) =>
        {
          this.DefaultViewModel["OrientationSensorResult"] = GetOrientationSensorResult(e1.Reading);
        };
    }

    private string GetOrientationSensorResult(OrientationSensorReading reading)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("quaternion w: {0}, x: {1}, y: {2}, z: {3}\n", reading.Quaternion.W, reading.Quaternion.X, reading.Quaternion.Y, reading.Quaternion.Z);
      sb.AppendFormat("{0,10:0.000}{1,10:0.000}{2,10:0.000}\n{3,10:0.000}{4,10:0.000}{5,10:0.000}\n{6,10:0.000}{7,10:0.000}{8,10:0.000}\n", reading.RotationMatrix.M11, reading.RotationMatrix.M12, reading.RotationMatrix.M13, reading.RotationMatrix.M21, reading.RotationMatrix.M22, reading.RotationMatrix.M23, reading.RotationMatrix.M31, reading.RotationMatrix.M32, reading.RotationMatrix.M33);
      sb.AppendFormat("yaw accuracy: {0}\n", reading.YawAccuracy);
      return sb.ToString();
    }









  }
}
