using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KTEC.Core.Domain
{
    public class Camera
    {
        public Camera(string name, Location location)
        {
            if (name == null)
                throw new ArgumentNullException("Name is verplicht.");

            if (location == null)
                throw new ArgumentNullException("Locatie is verplicht.");

            Number = GenerateNumberFromName(name);
            Name = name;
            Location = location;
        }

        public int Number { get; private set; }
        public string Name { get; private set; }
        public Location Location { get; private set; }

        public override string ToString()
        {
            return $"{ Number } | { Name } | { Location.Latitude.ToString(CultureInfo.InvariantCulture) } | {Location.Longitude.ToString(CultureInfo.InvariantCulture) }";
        }

        private int GenerateNumberFromName(string name)
        {
            var numberFromNameRegex = new Regex(@"^UTR-CM-(\d{3})\b", RegexOptions.Compiled);
            var number = numberFromNameRegex.Match(name);
            if (!number.Success)
                throw new ArgumentException("Onjuiste cameranaam.");

            return int.TryParse(number.Groups[1].Value, out var result) ? result : 0;
        }
    }
}
