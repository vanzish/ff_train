using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public async Task<IEnumerable<Ticket>> ReserveTickets(TicketsOptions options, bool isPurchasing = false)
        {
            return await _ticketsRepository.ReserveTickets(options, isPurchasing);
        }

        public async Task<IEnumerable<Ticket>> PurchaseReservationTickets(Reservation reservation)
        {
            return await _ticketsRepository.PurchaseReservationTickets(reservation);
        }
    }
}