using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class TravelsRepository : ITravelsRepository
    {
        private readonly DataContext _context;

        public TravelsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Travels> Add(Travels travels)
        {
            _context.Travels.Add(travels);

            await _context.SaveChangesAsync();

            return travels;
        }


        public async Task<Travels> Update(Travels travels)
        {
            _context.Travels.Update(travels);

            await _context.SaveChangesAsync();

            return travels;
        }


        public async Task<int> Delete(int id)
        {
            Travels travels = await _context.Travels.FindAsync(id);

            _context.Travels.Remove(travels);

            return await _context.SaveChangesAsync();
        }


        public async Task<Travels> Get(int id)
        {
            return await _context.Travels.FindAsync(id);
        }

        public List<Travels> GetAll()
        {
            return _context.Travels.ToList();
        }

        public List<Travels> GetAllFutureTravels()
        {
            return _context.Travels.Where(x => x.DateStart).ToList();
        }
        public List<Travels> GetAllPasteTravels()
        {
            return _context.Travels.Where(x => DateTime.TryParse(x.DateStart)).ToList();
        }
    }
}
