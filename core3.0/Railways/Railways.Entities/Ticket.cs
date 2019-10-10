using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railways.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public Guid Number { get; set; }

        public int RunId { get; set; }

        public Run Run { get; set; }

        public int ArrivalRoutePointId { get; set; }

        [ForeignKey("ArrivalRoutePointId")] public RoutePoint ArrivalRoutePoint { get; set; }

        public int DepartureRoutePointId { get; set; }

        [ForeignKey("DepartureRoutePointId")] public RoutePoint DepartureRoutePoint { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public int SeatId { get; set; }

        public Seat Seat { get; set; }

        public bool HasLinen { get; set; }
    }
}