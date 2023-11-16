using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext _context;

        public DestinationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Destination> Add(Destination destination)
        {
            _context.Destinations.Add(destination);

            await _context.SaveChangesAsync();

            return destination;
        }

        public async Task<Destination> Update(Destination destination)
        {
            _context.Destinations.Update(destination);

            await _context.SaveChangesAsync();

            return destination;
        }

        public async Task<int> Delete(int id)
        {
            Destination destination = await _context.Destinations.FindAsync(id);

            _context.Destinations.Remove(destination);

            return await _context.SaveChangesAsync();
        }

        public async Task<Destination> Get(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public List<Destination> GetAll()
        {
            return _context.Destinations.ToList();
        }
    }
}
