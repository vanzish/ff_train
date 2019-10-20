using System.Collections.Generic;
using System.Threading.Tasks;
using Railways.Entities;
using Railways.Entities.DTO.Options;

namespace Railways.Data.Interfaces
{
    public interface ITicketsService
    {
        Task<IEnumerable<Ticket>> ReserveTickets(TicketsOptions options, bool isPurchasing = false);

        Task<IEnumerable<Ticket>> PurchaseReservationTickets(Reservation reservation);
    }
}