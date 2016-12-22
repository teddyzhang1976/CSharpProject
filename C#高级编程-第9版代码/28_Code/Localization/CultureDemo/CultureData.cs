using System;
using System.Collections.Generic;
using System.Globalization;

namespace CultureDemo
{
  public class CultureData
  {
    public CultureInfo CultureInfo { get; set; }
    public List<CultureData> SubCultures { get; set; }

    double numberSample = 9876543.21;
    public string NumberSample
    {
      get { return numberSample.ToString("N", CultureInfo); }
    }

    public string DateSample
    {
      get { return DateTime.Today.ToString("D", CultureInfo); }
    }

    public string TimeSample
    {
      get { return DateTime.Now.ToString("T", CultureInfo); }
    }

    public RegionInfo RegionInfo
    {
      get {
        RegionInfo ri;
        try
        {
          ri = new RegionInfo(CultureInfo.Name);
        }
        catch (ArgumentException)
        {
          // with some neutral cultures regions are not available
          return null;
        }
        return ri; }
    }
  }
}
