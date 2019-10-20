using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Railways.Business.Business.Handlers
{
    public class TicketsHandler
    {
        private readonly ITicketsService _ticketsService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public TicketsHandler(ITicketsService ticketsService, IMapper mapper, ICityService cityService)
        {
            _ticketsService = ticketsService;
            _mapper = mapper;
            _cityService = cityService;
        }

        public async Task<Result<TicketsResult>> HandleReserve(TicketsOptions options)
        {
            try
            {
                var tickets = await _ticketsService.ReserveTickets(options);
                var city = await _cityService.GetCity(options.DepartureCityId);
                var result = new TicketsResult
                    { Tickets = tickets.Select(x => _mapper.Map<TicketDto>(x)), PlacesToBuy = city.Stations.Select(x => x.Name) };
                return Result.Ok(result);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Sorry! It seems that your seats are already busy.");
            }
            catch (Exception ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Something went wrong. Please repeat the operation. {ex.Message}");
            }
        }

        public async Task<Result<TicketsResult>> HandlePurchase(TicketsOptions options)
        {
            try
            {
                var tickets = await _ticketsService.ReserveTickets(options, true);
                var city = await _cityService.GetCity(options.DepartureCityId);
                var result = new TicketsResult
                    { Tickets = tickets.Select(x => _mapper.Map<TicketDto>(x)), PlacesToBuy = city.Stations.Select(x => x.Name) };
                return Result.Ok(result);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Sorry! It seems that your seats are already busy.");
            }
            catch (Exception ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Something went wrong. Please repeat the operation. {ex.Message}");
            }
        }

        public async Task<Result<TicketsResult>> HandlePurchaseReserve(Reservation reservation)
        {
            try
            {
                var tickets = await _ticketsService.PurchaseReservationTickets(reservation);
                var result = new TicketsResult
                    { Tickets = tickets.Select(x => _mapper.Map<TicketDto>(x)) };
                return Result.Ok(result);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Sorry! It seems that your seats are already busy.");
            }
            catch (Exception ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Something went wrong. Please repeat the operation. {ex.Message}");
            }
        }
    }
}