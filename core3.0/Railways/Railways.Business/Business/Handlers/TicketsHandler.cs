using AutoMapper;
using Railways.Data.Interfaces;
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
        private readonly IMapper _mapper;

        public TicketsHandler(ITicketsService ticketsService, IMapper mapper)
        {
            _ticketsService = ticketsService;
            _mapper = mapper;
        }

        public async Task<Result<TicketsResult>> Handle(TicketsOptions options)
        {
            try
            {
                var tickets = await _ticketsService.BuyTickets(options);
                var result = new TicketsResult { Tickets = tickets.Select(x => _mapper.Map<TicketDto>(x)) };
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<TicketsResult>(HttpStatusCode.InternalServerError,
                                                  $"Something went wrong. Please repeat the operation. {ex.Message}");
            }
        }
    }
}