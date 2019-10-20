using System;
using System.Collections.Generic;
using Railways.Entities.Interfaces;

namespace Railways.Entities
{
    public class Reservation : IDateCreated, IDateUpdated
    {
        public int Id { get; set; }

        public Guid Number { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public DateTime CancelReservationDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}