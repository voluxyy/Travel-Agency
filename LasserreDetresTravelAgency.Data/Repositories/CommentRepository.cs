using LasserreDetresTravelAgency.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Comment> Add(Comment comment)
        {
            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment> Update(Comment comment)
        {
            _context.Comments.Update(comment);

            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<int> Delete(int id)
        {
            Comment comment = await _context.Comments.FindAsync(id);

            _context.Comments.Remove(comment);

            return await _context.SaveChangesAsync();
        }

        public async Task<Comment> Get(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public List<Comment> GetAllByDestinationId(int id)
        {
            return _context.Comments.Where(x => x.DestinationId == id).ToList();
        }
    }
}