using Railways.Data.Interfaces;
using Railways.Data.Services;
using Railways.Entities.DTO.Results;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Railways.Business.Business.Handlers
{
    public class CitiesHandler
    {
        private readonly ICityService _cityService;

        public CitiesHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<Result<CitiesResult>> Handle()
        {
            try
            {
                var cities = await _cityService.GetAllCities();
                var result = new CitiesResult { Cities = cities };
                return Result.Ok(result);
            }
            catch (Exception)
            {
                return Result.Fail<CitiesResult>(HttpStatusCode.InternalServerError, "Something went wrong. Please repeat the operation.");
            }
        }
    }
}