using Railways.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface IRunsService
    {
        Task<IEnumerable<Run>> GetAvailableRuns(DateTime departureDate, int departureCityId, int destinationCityId);
    }
}