using Microsoft.EntityFrameworkCore;
using Railways.Data.Interfaces;
using Railways.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railways.Data.Repositories
{
    public class SeatsRepository : ISeatsRepository
    {
        private readonly RailwaysContext _context;

        public SeatsRepository(RailwaysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Run>> GetTrainSeats(int runId)
        {
            await using (_context)
            {
                var runs = _context.Runs.AsNoTracking().Where(x => x.Id == runId);

                return await runs.Distinct().Include(x => x.Train).ThenInclude(x => x.Carriages).Include($"Train.Carriages.Seats.SeatType")
                                 .Include($"Train.Carriages.Seats.Ticket").ToListAsync();
            }
        }
    }
}