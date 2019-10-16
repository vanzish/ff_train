using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business.Handlers;
using Railways.Entities;
using Railways.Entities.DTO.Options;
using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Railways.Data.Interfaces;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class RunsController : BaseApiController
    {
        private readonly IRunsService _runsService;
        private readonly IMapper _mapper;

        public RunsController(IRunsService runsService, IMapper mapper)
        {
            _runsService = runsService;
            _mapper = mapper;
        }

        [Route("runs")]
        [HttpPost]
        public async Task<IActionResult> GetAvailableRuns([FromBody] RunsOptions runsOptions)
        {
            if (runsOptions == null)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Options can not be null.");
            }

            if (runsOptions.DestinationCityId == 0 || runsOptions.DepartureCityId == 0 ||
                runsOptions.DepartureDate < DateTime.Today)
            {
                return ErrorResult(HttpStatusCode.BadRequest, "Request parameters missing or have incorrect format");
            }

            var handler = new RunsHandler(_runsService, _mapper);
            var result = await handler.Handle(runsOptions);

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}