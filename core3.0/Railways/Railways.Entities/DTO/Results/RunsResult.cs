using Railways.Entities.DTO.Results.Runs;
using System.Collections.Generic;

namespace Railways.Entities.DTO.Results
{
    public class RunsResult
    {
        public IEnumerable<RunWithSeatsDto> Runs { get; set; }
    }
}