using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business.Handlers;
using Railways.Data.Interfaces;
using Railways.Entities.DTO.Options;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Railways.Entities;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class TicketsController : BaseApiController
    {
        private readonly ITicketsService _ticketsService;
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        private readonly IReservationService _reservationService;

        public TicketsController(
            ITicketsService ticketsService,
            IMapper mapper,
            ICityService cityService,
            IReservationService reservationService)
        {
            _ticketsService = ticketsService;
            _mapper = mapper;
            _cityService = cityService;
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("tickets/reserve")]
        public async Task<IActionResult> ReserveTickets(TicketsOptions options)
        {
            if (options == null)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Options can not be null.");
            }

            if (options.RunId == 0 || options.PassengersData?.Any() == false || options.ArrivalCityId == 0 || options.DepartureCityId == 0)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var handler = new TicketsHandler(_ticketsService, _mapper, _cityService);
            var result = await handler.HandleReserve(options);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }

        [Authorize]
        [HttpPost]
        [Route("tickets/purchase")]
        public async Task<IActionResult> PurchaseTickets(TicketsOptions options)
        {
            if (options == null)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Options can not be null.");
            }

            if (options.RunId == 0 || options.PassengersData?.Any() == false || options.ArrivalCityId == 0 || options.DepartureCityId == 0)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var handler = new TicketsHandler(_ticketsService, _mapper, _cityService);
            var result = await handler.HandlePurchase(options);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        [Authorize]
        [Route("tickets/purchase-reservation")]
        public async Task<IActionResult> PurchaseReservationTickets(string reservationNumber)
        {
            if (!string.IsNullOrWhiteSpace(reservationNumber))
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var reservation = await _reservationService.GetReservation(reservationNumber);
            if (reservation == null)
            {
                return ErrorResult(HttpStatusCode.OK, "Sorry! You've overstayed your reservation.");
            }

            var handler = new TicketsHandler(_ticketsService, _mapper, _cityService);
            var result = await handler.HandlePurchaseReserve(reservation);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}