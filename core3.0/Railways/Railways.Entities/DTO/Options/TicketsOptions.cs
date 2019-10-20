using System;
using System.Collections.Generic;

namespace Railways.Entities.DTO.Options
{
    public class TicketsOptions
    {
        public int RunId { get; set; }

        public int DepartureCityId { get; set; }

        public int ArrivalCityId { get; set; }

        public bool HasLinen { get; set; }

        public IEnumerable<Passenger> PassengersData { get; set; }

        public DateTime CancelReservationDateTime { get; set; }
    }

    public class Passenger
    {
        public string FullName { get; set; }

        public int SeatId { get; set; }
    }
}