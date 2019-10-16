using Railways.Data.Interfaces;
using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }
    }
}