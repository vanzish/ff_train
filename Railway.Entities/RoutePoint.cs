using System;

namespace Railways.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public DateTimeOffset ArrivalOffset { get; set; }

        public DateTimeOffset DepartureOffset { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }

        public Ticket Ticket { get; set; }
    }
}