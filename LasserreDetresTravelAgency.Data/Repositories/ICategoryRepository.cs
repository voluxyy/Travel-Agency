using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Add(Category category);
        Task<int> Delete(int id);
        Task<Category> Get(int id);
        List<Category> GetAll();
        Task<Category> Update(Category category);
    }
}