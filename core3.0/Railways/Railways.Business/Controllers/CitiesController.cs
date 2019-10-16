using Microsoft.AspNetCore.Mvc;
using Railways.Business.Business.Handlers;
using Railways.Data.Interfaces;
using Railways.Entities;
using System.Threading.Tasks;

namespace Railways.Business.Controllers
{
    [ApiController]
    public class CitiesController : BaseApiController
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [Route("cities")]
        [HttpGet]
        public async Task<IActionResult> Cities()
        {
            var handler = new CitiesHandler(_cityService);
            var result = await handler.Handle();

            if (result.IsFailure)
            {
                return FromResult(result);
            }

            return Ok(result.Value);
        }
    }
}