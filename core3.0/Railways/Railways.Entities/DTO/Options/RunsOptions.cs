using System;

namespace Railways.Entities.DTO.Options
{
    public class RunsOptions
    {
        public DateTime DepartureDate { get; set; }

        public int DepartureCityId { get; set; }

        public int DestinationCityId { get; set; }
    }
}