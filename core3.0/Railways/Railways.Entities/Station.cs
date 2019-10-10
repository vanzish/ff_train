﻿namespace Railways.Entities
{
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoutePoint RoutePoint { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}