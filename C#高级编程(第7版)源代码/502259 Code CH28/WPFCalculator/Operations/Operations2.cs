using System;
using System.ComponentModel.Composition;
using System.Threading;

namespace Wrox.ProCSharp.MEF
{
    public class Operations2
    {
        //[Export("Add", typeof(Func<double, double, double>))]
        //[ExportMetadata("speed", "slow")]
        [SpeedExport("Add", typeof(Func<double, double, double>), Speed = Speed.Slow)]
        public double Add(double x, double y)
        {
            Thread.Sleep(3000);
            return x + y;
        }
    }
}
