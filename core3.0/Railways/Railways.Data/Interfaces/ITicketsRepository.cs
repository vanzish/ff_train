using Railways.Entities;
using Railways.Entities.DTO.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ITicketsRepository
    {
        Task<IEnumerable<Ticket>> ReserveTickets(TicketsOptions options, bool isPurchasing);

        Task<IEnumerable<Ticket>> PurchaseReservationTickets(Reservation reservation);
    }
}