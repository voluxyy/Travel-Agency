using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ITravelTypeRepository
    {
        
        /// <summary>
        /// Adds a travel type record to the database using the provided travel type model object.
        /// </summary>
        /// <param name="travelType">The travel type model object to add to the database.</param>
        /// <returns>Returns the travel type model object that has been added to the database.</returns>
        Task<TravelType> Add(TravelType TravelType);
        
        /// <summary>
        /// Deletes a travel type record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel type record to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a travel type record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel type record to retrieve from the database.</param>
        /// <returns>Returns the travel type model object retrieved from the database.</returns>
        Task<TravelType> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all travel type records from the database.
        /// </summary>
        /// <returns>Returns a list of travel type model objects representing all available travel type records in the database.</returns>
        List<TravelType> GetAll();
        
        /// <summary>
        /// Updates an existing travel type record in the database using the provided travel type model object.
        /// </summary>
        /// <param name="travelType">The travel type model object to update in the database.</param>
        /// <returns>Returns the travel type model object that has been updated in the database.</returns>
        Task<TravelType> Update(TravelType TravelType);
    }
}