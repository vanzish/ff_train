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

        public async Task<Run> GetTrainSeats(int runId)
        {
            await using (_context)
            {
                var run = await _context.Runs.Include(x => x.Train).ThenInclude(x => x.Carriages).Include($"Train.Carriages.Seats.SeatType")
                                        .Include($"Train.Carriages.Seats.Ticket").AsNoTracking().FirstAsync(x => x.Id == runId);

                return run;
            }
        }
    }
}