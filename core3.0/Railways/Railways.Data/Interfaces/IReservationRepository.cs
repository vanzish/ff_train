using Railways.Entities;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(string reservationNumber);
    }
}