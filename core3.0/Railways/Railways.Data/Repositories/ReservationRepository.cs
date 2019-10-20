using System;
using System.Linq;
using Railways.Data.Interfaces;
using Railways.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Railways.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RailwaysContext _context;

        public ReservationRepository(RailwaysContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetReservation(string reservationNumber)
        {
            await using (_context)
            {
                return await _context.Reservations.Include(x => x.Tickets).Where(x => x.CancelReservationDateTime < DateTime.UtcNow)
                                     .FirstAsync(x => string.Equals(x.Number.ToString(), reservationNumber));
            }
        }
    }
}