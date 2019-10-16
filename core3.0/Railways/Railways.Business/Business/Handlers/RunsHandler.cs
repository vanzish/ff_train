using AutoMapper;
using Railways.Data.Interfaces;
using Railways.Entities.DTO;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Railways.Entities.DTO.Results.Runs;

namespace Railways.Business.Business.Handlers
{
    public sealed class RunsHandler
    {
        private readonly IRunsService _runsService;
        private readonly IMapper _mapper;

        public RunsHandler(IRunsService runsService, IMapper mapper)
        {
            _runsService = runsService;
            _mapper = mapper;
        }

        public async Task<Result<RunsResult>> Handle(RunsOptions options)
        {
            try
            {
                var runs = await _runsService.GetAvailableRuns(options.DepartureDate, options.DepartureCityId, options.DestinationCityId);
                var result = new RunsResult { Runs = runs.Select(x => _mapper.Map<RunWithSeatsDto>(x)) };
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<RunsResult>(HttpStatusCode.InternalServerError, "Something went wrong. Please repeat the operation.");
            }
        }
    }
}