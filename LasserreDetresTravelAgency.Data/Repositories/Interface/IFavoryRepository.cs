using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IFavoryRepository
    {
        
        /// <summary>
        /// Adds a favory to the database using the provided favory model object.
        /// </summary>
        /// <param name="favory">The favory model object to add to the database.</param>
        /// <returns>Returns the favory model object that has been added to the database.</returns>
        Task<Favory> Add(Favory favory);
        
        /// <summary>
        /// Deletes a favory from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the favory to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a favory from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the favory to retrieve from the database.</param>
        /// <returns>Returns the favory model object retrieved from the database.</returns>
        Task<Favory> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all favories from the database.
        /// </summary>
        /// <returns>Returns a list of favory model objects representing all available favories in the database.</returns>
        List<Favory> GetAll();
        
        /// <summary>
        /// Updates an existing favory in the database using the provided favory model object.
        /// </summary>
        /// <param name="favory">The favory model object to update in the database.</param>
        /// <returns>Returns the favory model object that has been updated in the database.</returns>
        Task<Favory> Update(Favory favory);
    }
}