using Railways.Data.Interfaces;
using Railways.Data.Services;
using Railways.Entities.DTO.Results;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Railways.Entities.DTO;

namespace Railways.Business.Business.Handlers
{
    public class CitiesHandler
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<Result<CitiesResult>> Handle()
        {
            try
            {
                var cities = await _cityService.GetAllCities();
                var result = new CitiesResult { Cities = cities.Select(x => _mapper.Map<CityDto>(x)) };
                return Result.Ok(result);
            }
            catch (Exception)
            {
                return Result.Fail<CitiesResult>(HttpStatusCode.InternalServerError, "Something went wrong. Please repeat the operation.");
            }
        }
    }
}