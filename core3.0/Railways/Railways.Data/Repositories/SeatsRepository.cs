using Railways.Data.Interfaces;
using Railways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Railways.Entities.DTO.Options;

namespace Railways.Data.Repositories
{
    public class SeatsRepository : ISeatsRepository
    {
        private readonly RailwaysContext _context;

        public SeatsRepository(RailwaysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetAvailableTrainSeats(SeatsOptions seatsOptions)
        {
            await using (_context)
            {
                var runsWithSeats = from run in _context.Runs
                                    join train in _context.Trains on run.TrainId equals train.Id
                                    join carriage in _context.Carriages on train.Id equals carriage.TrainId
                                    join seat in _context.Seats on carriage.Id equals seat.CarriageId
                                    join ticket in _context.Tickets on run.Id equals ticket.RunId
                                    where seat.Ticket == null && run.Id == seatsOptions.RunId
                                    select seat;

                return await runsWithSeats.Distinct().ToListAsync();
            }
        }
    }
}