using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Railways.Data.Interfaces;
using Railways.Entities.DTO.Options;
using System.Threading.Tasks;
using Railways.Business.Business.Handlers;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class TicketsController : BaseApiController
    {
        private readonly ITicketsService _ticketsService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketsService ticketsService, IMapper mapper)
        {
            _ticketsService = ticketsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("tickets")]
        public async Task<IActionResult> BuyTicket(TicketsOptions options)
        {
            if (options == null)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Options can not be null.");
            }

            if (options.RunId == 0 || options.Seats?.Any() == false || options.ArrivalCityId == 0 || options.DepartureCityId == 0)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var handler = new TicketsHandler(_ticketsService, _mapper);
            var result = await handler.Handle(options);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}