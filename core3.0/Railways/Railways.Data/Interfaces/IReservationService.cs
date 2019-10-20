using System.Threading.Tasks;
using Railways.Entities;

namespace Railways.Data.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> GetReservation(string reservationNumber);
    }
}