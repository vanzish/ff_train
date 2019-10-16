using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business.Handlers;
using Railways.Data.Interfaces;
using Railways.Entities;
using Railways.Entities.DTO.Options;
using System.Net;
using System.Threading.Tasks;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class SeatsController : BaseApiController
    {
        private readonly ISeatsService _seatsService;

        public SeatsController(ISeatsService seatsService)
        {
            _seatsService = seatsService;
        }

        [Route("seats")]
        [HttpPost]
        public async Task<IActionResult> GetAvailableSeats([FromBody] SeatsOptions seatsOptions)
        {
            if (seatsOptions == null)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Options can not be null.");
            }

            if (seatsOptions.RunId == 0)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var handler = new SeatsHandler(_seatsService);
            var result = await handler.Handle(seatsOptions);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}