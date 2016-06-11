using System;
using System.Drawing;

namespace PointsAndSizes
{
    class Program
    {
        static void Main()
        {
            Point topLeft = new Point(10,10);
            Size rectangleSize = new Size(50,50);
            Point bottomRight = topLeft + rectangleSize;
            Console.WriteLine("topLeft = " + topLeft);
            Console.WriteLine("bottomRight = " + bottomRight);
            Console.WriteLine("Size = " + rectangleSize);

            Console.ReadLine();
        }
    }
}
