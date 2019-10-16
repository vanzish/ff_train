using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO.Options;

namespace Railways.Data.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        public async Task<IEnumerable<Ticket>> BuyTickets(TicketsOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
