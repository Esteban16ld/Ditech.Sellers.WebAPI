using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Repository
{
    public class CityRepository : GenericRepository<CityModel>, ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CityModel> FindByDescription(string description)
        {
            CityModel city = await _context.City
                .Where(c => c.DESCRIPTION.Equals(description))
                .SingleOrDefaultAsync();
            return city;
        }

        public async Task<CityModel> FindByCode(int code)
        {
            CityModel city = await _context.City
                .Where(c => c.CODE.Equals(code))
                .SingleOrDefaultAsync();
            return city;
        }

        public async Task DeleteByDescription(string description)
        {
            CityModel city = await _context.City
                .Where(c => c.DESCRIPTION.Equals(description))
                .SingleOrDefaultAsync();
            if (city != null)
                _context.City.Remove(city);
        }

        public async Task<ICollection<CityModel>> FindAll()
        {
            ICollection<CityModel> cities = await _context.City
                .ToListAsync();
            return cities;
        }
    }
}
