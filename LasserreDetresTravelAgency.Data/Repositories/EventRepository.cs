using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Event> Add(Event evenement)
        {
            _context.Events.Add(evenement);

            await _context.SaveChangesAsync();

            return evenement;
        }


        public async Task<Event> Update(Event evenement)
        {
            _context.Events.Update(evenement);

            await _context.SaveChangesAsync();

            return evenement;
        }


        public async Task<int> Delete(int id)
        {
            Event evenement = await _context.Events.FindAsync(id);

            _context.Events.Remove(evenement);

            return await _context.SaveChangesAsync();
        }


        public async Task<Event> Get(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public List<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public List<Event> GetAllEventByDest(int id)
        {
            return _context.Events.Where(x => x.DestinationId == id).ToList();
        }
    }
}
