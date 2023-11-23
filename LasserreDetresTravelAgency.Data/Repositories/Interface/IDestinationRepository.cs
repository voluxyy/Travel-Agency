using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IDestinationRepository
    {
        
        /// <summary>
        /// Adds a destination to the database using the model object passed as a parameter.
        /// </summary>
        /// <param name="destination">The destination model object to add to the database.</param>
        /// <returns>Returns the destination model object that has been added to the database.</returns>
        Task<Destination> Add(Destination destination);
        
        /// <summary>
        /// Deletes a destination from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to delete from the database.</param>
        /// <returns>Returns the number of modifications made in the database (usually 1 in case of success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a destination from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to retrieve from the database.</param>
        /// <returns>Returns the destination model object retrieved from the database.</returns>
        Task<Destination> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all destinations from the database.
        /// </summary>
        /// <returns>Returns a list of destination model objects representing all destinations available in the database.</returns>
        List<Destination> GetAll();
        
        /// <summary>
        /// Updates an existing destination in the database using the model object passed as a parameter.
        /// </summary>
        /// <param name="destination">The destination model object to update in the database.</param>
        /// <returns>Returns the destination model object that has been updated in the database.</returns>
        Task<Destination> Update(Destination destination);
    }
}