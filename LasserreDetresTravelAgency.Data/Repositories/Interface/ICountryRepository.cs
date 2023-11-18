using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICountryRepository
    {
        
        /// <summary>
        /// Adds a country to the database using the provided country model object.
        /// </summary>
        /// <param name="country">The country model object to add to the database.</param>
        /// <returns>Returns the country model object that has been added to the database.</returns>
        Task<Country> Add(Country country);
        
        /// <summary>
        /// Deletes a country from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a country from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to retrieve from the database.</param>
        /// <returns>Returns the country model object retrieved from the database.</returns>
        Task<Country> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all countries from the database.
        /// </summary>
        /// <returns>Returns a list of country model objects representing all available countries in the database.</returns>
        List<Country> GetAll();
        
        /// <summary>
        /// Updates an existing country in the database using the provided country model object.
        /// </summary>
        /// <param name="country">The country model object to update in the database.</param>
        /// <returns>Returns the country model object that has been updated in the database.</returns>
        Task<Country> Update(Country country);
    }
}