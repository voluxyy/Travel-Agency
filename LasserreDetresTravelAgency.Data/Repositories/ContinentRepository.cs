using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly DataContext _context;

        public ContinentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Continent> Add(Continent Continent)
        {
            _context.Continents.Add(Continent);

            await _context.SaveChangesAsync();

            return Continent;
        }

        public async Task<Continent> Update(Continent Continent)
        {
            _context.Continents.Update(Continent);

            await _context.SaveChangesAsync();

            return Continent;
        }

        public async Task<int> Delete(int id)
        {
            Continent Continent = await _context.Continents.FindAsync(id);

            _context.Continents.Remove(Continent);

            return await _context.SaveChangesAsync();
        }

        public async Task<Continent> Get(int id)
        {
            return await _context.Continents.FindAsync(id);
        }

        public List<Continent> GetAll()
        {
            return _context.Continents.ToList();
        }
    }
}
