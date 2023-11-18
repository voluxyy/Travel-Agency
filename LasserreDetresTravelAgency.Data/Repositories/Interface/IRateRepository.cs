using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IRateRepository
    {
        
        /// <summary>
        /// Adds a rate to the database using the provided rate model object.
        /// </summary>
        /// <param name="rate">The rate model object to add to the database.</param>
        /// <returns>Returns the rate model object that has been added to the database.</returns>
        Task<Rate> Add(Rate rate);
        
        /// <summary>
        /// Deletes a rate from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the rate to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a rate from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the rate to retrieve from the database.</param>
        /// <returns>Returns the rate model object retrieved from the database.</returns>
        Task<Rate> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all rates from the database.
        /// </summary>
        /// <returns>Returns a list of rate model objects representing all available rates in the database.</returns>
        List<Rate> GetAll();
        
        /// <summary>
        /// Updates an existing rate in the database using the provided rate model object.
        /// </summary>
        /// <param name="rate">The rate model object to update in the database.</param>
        /// <returns>Returns the rate model object that has been updated in the database.</returns>
        Task<Rate> Update(Rate rate);
    }
}