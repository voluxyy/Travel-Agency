using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;

        public VisitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Visit> Add(Visit visit)
        {
            _context.Visits.Add(visit);

            await _context.SaveChangesAsync();

            return visit;
        }

        public async Task<Visit> Update(Visit visit)
        {
            _context.Visits.Update(visit);

            await _context.SaveChangesAsync();

            return visit;
        }

        public async Task<int> Delete(int id)
        {
            Visit visit = await _context.Visits.FindAsync(id);

            _context.Visits.Remove(visit);

            return await _context.SaveChangesAsync();
        }

        public async Task<Visit> Get(int id)
        {
            return await _context.Visits.FindAsync(id);
        }

        public List<Visit> GetAll()
        {
            return _context.Visits.ToList();
        }
    }
}