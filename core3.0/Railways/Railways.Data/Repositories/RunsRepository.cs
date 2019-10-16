using Microsoft.EntityFrameworkCore;
using Railways.Data.Interfaces;
using Railways.Entities.DTO.Results.Runs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Railways.Entities;

namespace Railways.Data.Repositories
{
    public class RunsRepository : IRunsRepository
    {
        private readonly RailwaysContext _context;

        public RunsRepository(RailwaysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Run>> GetAvailableRuns(
            DateTime departureDate,
            int departureCityId,
            int destinationCityId)
        {
            await using (_context)
            {
                var runs = from run in _context.Runs
                           join route in _context.Routes on run.RouteId equals route.Id
                           join routePoint in _context.RoutePoints on route.Id equals routePoint.RouteId
                           where route.RoutePoints.Select(x => x.Station.CityId).Contains(departureCityId) &&
                                 route.RoutePoints.Select(x => x.Station.CityId).Contains(destinationCityId) &&
                                 route.RoutePoints.First(x => x.Station.City.Id == departureCityId).DepartureOffset <
                                 route.RoutePoints.First(x => x.Station.City.Id == destinationCityId).DepartureOffset &&
                                 (run.RunTime + route.RoutePoints.First(x => x.Station.City.Id == departureCityId).DepartureOffset)
                                 .Date == departureDate.Date
                           select run;

                var seats = from run in runs.Distinct()
                            join train in _context.Trains on run.TrainId equals train.Id
                            join carriage in _context.Carriages on train.Id equals carriage.TrainId
                            join seat in _context.Seats on carriage.Id equals seat.CarriageId
                            join ticket in _context.Tickets on run.Id equals ticket.RunId
                            join route in _context.Routes on run.RouteId equals route.Id
                            where seat.Ticket == null ||
                                  ( // select tickets which end before departure city departure time or start after dest city arrival time
                                      seat.Ticket.DepartureDateTime > run.RunTime + route
                                                                                    .RoutePoints.First(
                                                                                        x => x.Station.City.Id == destinationCityId)
                                                                                    .ArrivalOffset &&
                                      seat.Ticket.ArrivalDateTime < run.RunTime + route
                                                                                  .RoutePoints.First(
                                                                                      x => x.Station.City.Id == departureCityId)
                                                                                  .DepartureOffset
                                  )
                            select seat;

                var runList = await runs.Distinct().Include(x => x.Train).Include(x=>x.Route)
                                        .Where(x => seats.Select(s => s.Carriage.TrainId).Contains(x.TrainId)).ToListAsync();

                return runList;
            }
        }
    }
}