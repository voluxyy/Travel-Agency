using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class TravelTypeRepository : ITravelTypeRepository
    {
        private readonly DataContext _context;

        public TravelTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TravelType> Add(TravelType TravelType)
        {
            _context.TravelTypes.Add(TravelType);

            await _context.SaveChangesAsync();

            return TravelType;
        }

        public async Task<TravelType> Update(TravelType TravelType)
        {
            _context.TravelTypes.Update(TravelType);

            await _context.SaveChangesAsync();

            return TravelType;
        }

        public async Task<int> Delete(int id)
        {
            TravelType TravelType = await _context.TravelTypes.FindAsync(id);

            _context.TravelTypes.Remove(TravelType);

            return await _context.SaveChangesAsync();
        }

        public async Task<TravelType> Get(int id)
        {
            return await _context.TravelTypes.FindAsync(id);
        }
        public List<TravelType> GetAll()
        {
            return _context.TravelTypes.ToList();
        }

    }
}
