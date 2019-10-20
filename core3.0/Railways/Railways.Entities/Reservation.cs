using System;
using System.Collections.Generic;

namespace Railways.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public Guid Number { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public DateTime CancelReservationDateTime { get; set; }
    }
}