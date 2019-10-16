using Railways.Entities;
using Railways.Entities.DTO.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ISeatsService
    {
        Task<IEnumerable<Seat>> GetAvailableTrainSeats(SeatsOptions seatsOptions);
    }
}