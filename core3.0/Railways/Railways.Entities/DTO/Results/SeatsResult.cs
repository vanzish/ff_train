using System.Collections.Generic;

namespace Railways.Entities.DTO.Results
{
    public class SeatsResult
    {
        public IEnumerable<RunDto> Seats { get; set; }
    }
}