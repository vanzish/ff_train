using System.Collections.Generic;

namespace Railways.Entities.DTO.Results
{
    public class CitiesResult
    {
        public IEnumerable<CityDto> Cities { get; set; }
    }
}