using System.Collections.Generic;

namespace Railways.Entities.DTO.Results.Runs
{
    public class RunWithSeatsDto
    {
        public RunDto Run { get; set; }

        public IEnumerable<SeatDto> Seats { get; set; }
    }
}