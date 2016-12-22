using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;

namespace GeolocationBackground
{
    public class GeolocationBackgroundTask : IBackgroundTask
    {
      public void Run(IBackgroundTaskInstance taskInstance)
      {
        var locator = new Geolocator();
        locator.GetGeopositionAsync()
      }
    }
}
