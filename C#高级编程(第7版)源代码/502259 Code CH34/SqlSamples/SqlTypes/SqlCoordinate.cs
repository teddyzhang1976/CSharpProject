using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Wrox.ProCSharp.SqlServer
{
    public enum Orientation
    {
        NorthEast,
        NorthWest,
        SouthEast,
        SouthWest
    }


    [Serializable]
    [SqlUserDefinedType(Format.Native)]
    public struct SqlCoordinate : INullable
    {
        private int longitude;
        private int latitude;
        private bool isNull;

        public SqlCoordinate(int longitude, int latitude)
        {
            isNull = false;
            this.longitude = longitude;
            this.latitude = latitude;
        }


        public SqlCoordinate(int longitudeDegrees, int longitudeMinutes,
              int longitudeSeconds, int latitudeDegrees, int latitudeMinutes,
              int latitudeSeconds, Orientation orientation)
        {
            isNull = false;
            this.longitude = longitudeSeconds + 60 * longitudeMinutes + 3600 *
                  longitudeDegrees;
            this.latitude = latitudeSeconds + 60 * latitudeMinutes + 3600 *
                  latitudeDegrees;
            switch (orientation)
            {
                case Orientation.SouthWest:
                    longitude = -longitude;
                    latitude = -latitude;
                    break;
                case Orientation.SouthEast:
                    longitude = -longitude;
                    break;
                case Orientation.NorthWest:
                    latitude = -latitude;
                    break;
            }
        }

        public bool IsNull
        {
            get
            {
                return isNull;
            }
        }

        public static SqlCoordinate Null
        {
            get
            {
                return new SqlCoordinate { isNull = true };
            }
        }



        public override string ToString()
        {
            if (this.isNull)
                return null;

            char northSouth = longitude > 0 ? 'N' : 'S';
            char eastWest = latitude > 0 ? 'E' : 'W';

            int longitudeDegrees = Math.Abs(longitude) / 3600;
            int remainingSeconds = Math.Abs(longitude) % 3600;
            int longitudeMinutes = remainingSeconds / 60;
            int longitudeSeconds = remainingSeconds % 60;

            int latitudeDegrees = Math.Abs(latitude) / 3600;
            remainingSeconds = Math.Abs(latitude) % 3600;
            int latitudeMinutes = remainingSeconds / 60;
            int latitudeSeconds = remainingSeconds % 60;

            return String.Format("{0}˚{1}'{2}\"{3},{4}˚{5}'{6}\"{7}",
                  longitudeDegrees, longitudeMinutes, longitudeSeconds,
                  northSouth, latitudeDegrees, latitudeMinutes,
                  latitudeSeconds, eastWest);
        }



        public static SqlCoordinate Parse(SqlString s)
        {
            if (s.IsNull)
                return SqlCoordinate.Null;

            try
            {
                string[] coordinates = s.Value.Split(',');
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

                return new SqlCoordinate(
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
    }
}