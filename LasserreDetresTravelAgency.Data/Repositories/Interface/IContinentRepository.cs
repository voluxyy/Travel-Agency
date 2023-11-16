using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IContinentRepository
    {
        
        /// <summary>
        /// Adds a continent to the database using the provided continent model object.
        /// </summary>
        /// <param name="continent">The continent model object to add to the database.</param>
        /// <returns>Returns the continent model object that has been added to the database.</returns>
        Task<Continent> Add(Continent Continent);
        
        /// <summary>
        /// Deletes a continent from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the continent to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a continent from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the continent to retrieve from the database.</param>
        /// <returns>Returns the continent model object retrieved from the database.</returns>
        Task<Continent> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all continents from the database.
        /// </summary>
        /// <returns>Returns a list of continent model objects representing all available continents in the database.</returns>
        List<Continent> GetAll();
        
        /// <summary>
        /// Updates an existing continent in the database using the provided continent model object.
        /// </summary>
        /// <param name="continent">The continent model object to update in the database.</param>
        /// <returns>Returns the continent model object that has been updated in the database.</returns>
        Task<Continent> Update(Continent Continent);
    }
}