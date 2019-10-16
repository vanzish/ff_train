using Railways.Data.Interfaces;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Railways.Entities.DTO;

namespace Railways.Business.Business.Handlers
{
    public class SeatsHandler
    {
        private readonly ISeatsService _seatsService;
        private readonly IMapper _mapper;

        public SeatsHandler(ISeatsService seatsService, IMapper mapper)
        {
            _seatsService = seatsService;
            _mapper = mapper;
        }

        public async Task<Result<SeatsResult>> Handle(SeatsOptions options)
        {
            try
            {
                var seats = await _seatsService.GetTrainSeats(options.RunId);
                var result = new SeatsResult { Seats = seats.Select(x => _mapper.Map<RunDto>(x)) };
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<SeatsResult>(HttpStatusCode.InternalServerError,
                                                $"Something went wrong. Please repeat the operation. {ex.Message}");
            }
        }
    }
}