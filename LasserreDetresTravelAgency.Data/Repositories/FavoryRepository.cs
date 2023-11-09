using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class FavoryRepository : IFavoryRepository
    {
        private readonly DataContext _context;

        public FavoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Favory> Add(Favory favory)
        {
            _context.Favories.Add(favory);
            await _context.SaveChangesAsync();
            return favory;
        }

        public async Task<Favory> Update(Favory favory)
        {
            _context.Favories.Update(favory);
            await _context.SaveChangesAsync();
            return favory;
        }

        public async Task<int> Delete(int id)
        {
            Favory favory = await _context.Favories.FindAsync(id);
            _context.Favories.Remove(favory);
            return await _context.SaveChangesAsync();
        }

        public async Task<Favory> Get(int id)
        {
            return await _context.Favories.FindAsync(id);
        }

        public List<Favory> GetAll()
        {
            return _context.Favories.ToList();
        }
    }
}
