using Railways.Data.Interfaces;
using Railways.Entities;
using System;
using System.Threading.Tasks;

namespace Railways.Data.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> GetReservation(string reservationNumber)
        {
            return await _reservationRepository.GetReservation(reservationNumber);
        }
    }
}