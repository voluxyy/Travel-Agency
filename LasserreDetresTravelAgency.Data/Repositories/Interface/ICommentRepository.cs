using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICommentRepository
    {
        
        /// <summary>
        /// Adds a comment to the database using the provided comment model object.
        /// </summary>
        /// <param name="comment">The comment model object to add to the database.</param>
        /// <returns>Returns the comment model object that has been added to the database.</returns>
        Task<Comment> Add(Comment comment);
        
        /// <summary>
        /// Deletes a comment from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the comment to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a comment from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the comment to retrieve from the database.</param>
        /// <returns>Returns the comment model object retrieved from the database.</returns>
        Task<Comment> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all comments from the database.
        /// </summary>
        /// <returns>Returns a list of comment model objects representing all available comments in the database.</returns>
        List<Comment> GetAll();
        
        /// <summary>
        /// Updates an existing comment in the database using the provided comment model object.
        /// </summary>
        /// <param name="comment">The comment model object to update in the database.</param>
        /// <returns>Returns the comment model object that has been updated in the database.</returns>
        Task<Comment> Update(Comment comment);
        
        /// <summary>
        /// Retrieves the list of all comments associated with a specific destination from the database.
        /// </summary>
        /// <param name="id">The identifier of the destination for which to retrieve comments.</param>
        /// <returns>Returns a list of comment model objects associated with the specified destination.</returns>
        List<Comment> GetAllByDestinationId(int id);
    }
}