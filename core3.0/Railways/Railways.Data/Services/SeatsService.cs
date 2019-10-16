using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO.Options;
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

        public async Task<IEnumerable<Seat>> GetAvailableTrainSeats(SeatsOptions seatsOptions)
        {
            return await _seatsRepository.GetAvailableTrainSeats(seatsOptions);
        }
    }
}