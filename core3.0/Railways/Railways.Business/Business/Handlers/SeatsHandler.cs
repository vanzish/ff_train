using Railways.Data.Interfaces;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Railways.Business.Business.Handlers
{
    public class SeatsHandler
    {
        private readonly ISeatsService _seatsService;

        public SeatsHandler(ISeatsService seatsService)
        {
            _seatsService = seatsService;
        }

        public async Task<Result<SeatsResult>> Handle(SeatsOptions options)
        {
            try
            {
                var seats = await _seatsService.GetAvailableTrainSeats(options);
                var result = new SeatsResult { Seats = seats };
                return Result.Ok(result);
            }
            catch (Exception)
            {
                return Result.Fail<SeatsResult>(HttpStatusCode.InternalServerError, "Something went wrong. Please repeat the operation.");
            }
        }
    }
}