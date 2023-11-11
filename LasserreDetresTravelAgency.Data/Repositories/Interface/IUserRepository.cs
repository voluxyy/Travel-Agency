using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace  LasserreDetresTravelAgency.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<int> Delete(int id);
        Task<User> Get(int id);
        List<User> GetAll();
        Task<User> Update(User user);
        List<User> GetAllMinorTravelers();
    }
}