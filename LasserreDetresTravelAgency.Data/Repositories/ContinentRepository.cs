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

        public async Task<Continent> Add(Continent continent)
        {
            _context.Continents.Add(continent);

            await _context.SaveChangesAsync();

            return continent;
        }

        public async Task<Continent> Update(Continent continent)
        {
            _context.Continents.Update(continent);

            await _context.SaveChangesAsync();

            return continent;
        }

        public async Task<int> Delete(int id)
        {
            Continent continent = await _context.Continents.FindAsync(id);

            _context.Continents.Remove(continent);

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