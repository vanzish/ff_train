using System;

namespace Railways.Entities.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }

        public Guid Number { get; set; }

        public int RunId { get; set; }

        public string ArrivalRoutePoint { get; set; }

        public string DepartureRoutePoint { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public SeatDto Seat { get; set; }

        public bool HasLinen { get; set; }
    }
}