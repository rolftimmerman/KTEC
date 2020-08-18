using System;

namespace KTEC.Core.Domain
{
    public class Location
    {
        public Location(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("Latitude moet tussen -90 and 90 graden zijn.");
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("Longitude moet tussen -180 and 180 graden zijn.");

            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}