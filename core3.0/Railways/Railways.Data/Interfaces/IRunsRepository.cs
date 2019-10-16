using Railways.Entities.DTO.Results.Runs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface IRunsRepository
    {
        Task<IEnumerable<RunWithSeats>> GetAvailableRuns(DateTime departureDate, int departureCityId, int destinationCityId);
    }
}