﻿using Microsoft.EntityFrameworkCore;
using Railways.Data.Interfaces;
using Railways.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railways.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly RailwaysContext _context;

        public CityRepository(RailwaysContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            await using (_context)
                return await _context.Cities.AsNoTracking().Include(x => x.Stations).ToListAsync();
        }

        public async Task<City> GetCity(int cityId)
        {
            await using (_context)
                return await _context.Cities.AsNoTracking().Include(x => x.Stations).FirstAsync(x => x.Id == cityId);
        }
    }
}