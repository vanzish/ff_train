using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();

        Task<City> GetCity(int cityId);
    }
}