using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICommentService
    {
        Task<CommentDto> Add(CommentDto dto);
        Task<int> Delete(int id);
        Task<CommentDto> Get(int id);
        List<CommentDto> GetAll();
        Task<CommentDto> Update(CommentDto dto);
        List<CommentDto> GetAllByDestinationId(int id);
    }
}