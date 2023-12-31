using LasserreDetresTravelAgency.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> Delete(int id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public List<User> GetAllMinorTravelers()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            return _context.Users
                .Where(x => x.Birthday.AddYears(18) > today)
                .ToList();
        }
    }
}