using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace  LasserreDetresTravelAgency.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a user record to the database using the provided user model object.
        /// </summary>
        /// <param name="user">The user model object to add to the database.</param>
        /// <returns>Returns the user model object that has been added to the database.</returns>
        Task<User> Add(User user);
        
        /// <summary>
        /// Deletes a user record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user record to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a user record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user record to retrieve from the database.</param>
        /// <returns>Returns the user model object retrieved from the database.</returns>
        Task<User> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all user records from the database.
        /// </summary>
        /// <returns>Returns a list of user model objects representing all available user records in the database.</returns>
        List<User> GetAll();
        
        /// <summary>
        /// Updates an existing user record in the database using the provided user model object.
        /// </summary>
        /// <param name="user">The user model object to update in the database.</param>
        /// <returns>Returns the user model object that has been updated in the database.</returns>
        Task<User> Update(User user);
        
        /// <summary>
        /// Retrieves the list of all minor travelers from the database.
        /// </summary>
        /// <returns>Returns a list of user model objects representing all minor travelers in the database.</returns>
        List<User> GetAllMinorTravelers();
    }
}