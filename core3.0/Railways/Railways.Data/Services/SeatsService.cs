using Railways.Data.Interfaces;
using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Services
{
    public class SeatsService : ISeatsService
    {
        private readonly ISeatsRepository _seatsRepository;

        public SeatsService(ISeatsRepository seatsRepository)
        {
            _seatsRepository = seatsRepository;
        }

        public async Task<IEnumerable<Run>> GetTrainSeats(int runId)
        {
            return await _seatsRepository.GetTrainSeats(runId);
        }
    }
}