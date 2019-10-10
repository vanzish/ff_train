using System.Collections.Generic;

namespace Railways.Entities
{
    public class Carriage
    {
        public Carriage()
        {
            Seats = new List<Seat>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public int TrainId { get; set; }

        public Train Train { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}