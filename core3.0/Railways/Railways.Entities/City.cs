using System;
using System.Collections.Generic;

namespace Railways.Entities
{
    public class City
    {
        public City()
        {
            Stations = new List<Station>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan CityTimeZone { get; set; }

        public ICollection<Station> Stations { get; set; }
    }
}