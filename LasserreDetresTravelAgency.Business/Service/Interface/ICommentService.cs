using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICommentService
    {
        /// <summary>
        /// Adds a new comment using the provided data.
        /// </summary>
        /// <param name="dto">The comment data to add.</param>
        /// <returns>Returns the added comment data.</returns>
        Task<CommentDto> Add(CommentDto dto);
        
        /// <summary>
        /// Deletes a comment based on its ID.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <returns>Returns the number of comments deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves comment data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the comment to retrieve.</param>
        /// <returns>Returns the comment data if found, otherwise null.</returns>
        Task<CommentDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all comments.
        /// </summary>
        /// <returns>Returns a list of comment data.</returns>
        List<CommentDto> GetAll();
        
        /// <summary>
        /// Updates an existing comment using the provided data.
        /// </summary>
        /// <param name="dto">The comment data to update.</param>
        /// <returns>Returns the updated comment data.</returns>
        Task<CommentDto> Update(CommentDto dto);
        
        /// <summary>
        /// Retrieves a list of comments based on the destination ID.
        /// </summary>
        /// <param name="id">The ID of the destination.</param>
        /// <returns>Returns a list of comment data for the specified destination.</returns>
        List<CommentDto> GetAllByDestinationId(int id);
    }
}