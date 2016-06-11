using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTest
{
    public enum Orientation
    {
        NorthEast,
        NorthWest,
        SouthEast,
        SouthWest
    }


    class Program
    {
        public static Tuple<int, int, int, int, int, int, Orientation> Parse(string s)
        {


            try
            {
                string[] coordinates = s.Split(',');
                char[] separators = { '°', '\'', '\"' };
                string[] longitudeVals = coordinates[0].Split(separators);
                string[] latitudeVals = coordinates[1].Split(separators);

                if (longitudeVals.Length != 4 && latitudeVals.Length != 4)
                    throw new ArgumentException(
                          "Argument has a wrong syntax. " +
                          "This syntax is required: 37˚47\'0\"N,122˚26\'0\"W");


                Orientation orientation;
                if (longitudeVals[3] == "N" && latitudeVals[3] == "E")
                    orientation = Orientation.NorthEast;
                else if (longitudeVals[3] == "S" && latitudeVals[3] == "W")
                    orientation = Orientation.SouthWest;
                else if (longitudeVals[3] == "S" && latitudeVals[3] == "E")
                    orientation = Orientation.SouthEast;
                else
                    orientation = Orientation.NorthWest;

                return Tuple.Create(
                      int.Parse(longitudeVals[0]), int.Parse(longitudeVals[1]),
                      int.Parse(longitudeVals[2]),
                      int.Parse(latitudeVals[0]), int.Parse(latitudeVals[1]),
                      int.Parse(latitudeVals[2]), orientation);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException(
                      "Argument has a wrong syntax. " +
                      "This syntax is required: 37˚47\'0\"N,122˚26\'0\"W",
                      ex.Message);
            }

        }


        static void Main(string[] args)
        {
            var t = Parse("50°10'0\"N,16°20'0\"E");
            Console.WriteLine(t.Item7);
        }
    }
}
