using System.Collections.Generic;

namespace Railways.Entities.DTO.Results.Runs
{
    public class RunWithSeats
    {
        public Run Run { get; set; }

        public IEnumerable<Seat> Seats { get; set; }
    }
}