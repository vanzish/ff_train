using System;
using System.Collections.Generic;

namespace Railways.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public TimeSpan ArrivalOffset { get; set; }

        public TimeSpan DepartureOffset { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }

        public virtual ICollection<Ticket> ArrivalTickets { get; set; }

        public virtual ICollection<Ticket> DepartureTickets { get; set; }

    }
}