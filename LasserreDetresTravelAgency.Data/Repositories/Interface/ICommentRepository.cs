using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> Add(Comment comment);
        Task<int> Delete(int id);
        Task<Comment> Get(int id);
        List<Comment> GetAll();
        Task<Comment> Update(Comment comment);
    }
}