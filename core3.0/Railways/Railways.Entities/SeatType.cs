using System.Collections.Generic;

namespace Railways.Entities
{
    public class SeatType
    {
        public int Id { get; set; }

        public SeatPositionEnum Position { get; set; }

        public bool IsOutboard { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}