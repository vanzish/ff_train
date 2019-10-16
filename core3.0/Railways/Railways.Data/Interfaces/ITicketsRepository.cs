using Railways.Entities;
using Railways.Entities.DTO.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ITicketsRepository
    {
        Task<IEnumerable<Ticket>> BuyTickets(TicketsOptions options);
    }
}