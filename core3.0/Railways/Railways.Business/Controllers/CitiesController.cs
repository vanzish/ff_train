using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business.Handlers;
using Railways.Data.Interfaces;
using Railways.Entities;
using System.Threading.Tasks;
using AutoMapper;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class CitiesController : BaseApiController
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [Route("cities")]
        [HttpGet]
        public async Task<IActionResult> Cities()
        {
            var handler = new CitiesHandler(_cityService, _mapper);
            var result = await handler.Handle();

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}