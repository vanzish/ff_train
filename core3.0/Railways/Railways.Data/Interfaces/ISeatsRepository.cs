using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Railways.Entities.DTO.Options;

namespace Railways.Data.Interfaces
{
    public interface ISeatsRepository
    {
        Task<IEnumerable<Seat>> GetAvailableTrainSeats(SeatsOptions seatsOptions);
    }
}