using Railways.Data.Interfaces;
using Railways.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Services
{
    public class RunsService : IRunsService
    {
        private readonly IRunsRepository _runsRepository;

        public RunsService(IRunsRepository runsRepository)
        {
            _runsRepository = runsRepository;
        }

        public async Task<IEnumerable<Run>> GetAvailableRuns(
            DateTime departureDate,
            int departureCityId,
            int destinationCityId)
        {
            return await _runsRepository.GetAvailableRuns(departureDate, departureCityId, destinationCityId);
        }
    }
}