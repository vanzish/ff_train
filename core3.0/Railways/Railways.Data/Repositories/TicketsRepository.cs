using Microsoft.EntityFrameworkCore;
using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railways.Data.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly RailwaysContext _context;

        public TicketsRepository(RailwaysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> ReserveTickets(TicketsOptions options, bool isPurchasing)
        {
            var tickets = new List<Ticket>();

            await using (_context)
            {
                var routePoints = await _context.RoutePoints.AsNoTracking().Include(x => x.Station.City).ToListAsync();
                var run = await _context.Runs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == options.RunId);
                var arrivalRoutePoint = routePoints.First(x => x.Station.CityId == options.ArrivalCityId);
                var departureRoutePoint = routePoints.First(x => x.Station.CityId == options.DepartureCityId);
                Reservation reservation = null;
                if (!isPurchasing)
                {
                    reservation = new Reservation();
                    DateTime cancelReservationDateTime = DateTime.UtcNow + _context.Configuration.First().CancelReservationOffset;
                    if (cancelReservationDateTime > run.RunTime)
                    {
                        cancelReservationDateTime = run.RunTime;
                    }

                    reservation.CancelReservationDateTime = cancelReservationDateTime;
                    reservation.Number = Guid.NewGuid();
                    await _context.Reservations.AddAsync(reservation);
                }

                foreach (var passenger in options.PassengersData)
                {
                    tickets.Add(new Ticket
                    {
                        PassengerName = passenger.FullName,
                        SeatId = passenger.SeatId,
                        Number = Guid.NewGuid(),
                        RunId = options.RunId,
                        HasLinen = options.HasLinen,
                        ArrivalRoutePointId = arrivalRoutePoint.Station.CityId,
                        DepartureRoutePointId = departureRoutePoint.Station.CityId,
                        ArrivalDateTime = run.RunTime + arrivalRoutePoint.ArrivalOffset,
                        DepartureDateTime = run.RunTime + arrivalRoutePoint.DepartureOffset,
                        ArrivalRoutePoint = arrivalRoutePoint,
                        DepartureRoutePoint = departureRoutePoint,
                        Run = run,
                        IsPurchased = isPurchasing,
                        Reservation = reservation,
                        ReservationId = reservation?.Id
                    });
                }

                await _context.Tickets.AddRangeAsync(tickets);
                await _context.SaveChangesAsync();
            }

            return tickets;
        }

        public async Task<IEnumerable<Ticket>> PurchaseReservationTickets(Reservation reservation)
        {
            await using (_context)
            {
                var tickets = _context.Tickets.Where(x => x.ReservationId == reservation.Id);

                foreach (var ticket in tickets)
                {
                    ticket.Reservation = null;
                    ticket.ReservationId = null;
                    ticket.IsPurchased = true;
                }

                await _context.SaveChangesAsync();

                _context.Reservations.Remove(reservation);

                return tickets;
            }
        }
    }
}