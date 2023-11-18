using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Country> Add(Country country)
        {
            _context.Countries.Add(country);

            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<Country> Update(Country country)
        {
            _context.Countries.Update(country);

            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<int> Delete(int id)
        {
            Country country = await _context.Countries.FindAsync(id);

            _context.Countries.Remove(country);

            return await _context.SaveChangesAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }
    }
}