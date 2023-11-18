using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ITravelsRepository
    {
        
        /// <summary>
        /// Adds a travels record to the database using the provided travels model object.
        /// </summary>
        /// <param name="travels">The travels model object to add to the database.</param>
        /// <returns>Returns the travels model object that has been added to the database.</returns>
        Task<Travels> Add(Travels travels);
        
        /// <summary>
        /// Deletes a travels record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travels record to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a travels record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travels record to retrieve from the database.</param>
        /// <returns>Returns the travels model object retrieved from the database.</returns>
        Task<Travels> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all travels records from the database.
        /// </summary>
        /// <returns>Returns a list of travels model objects representing all available travels records in the database.</returns>
        List<Travels> GetAll();
        
        /// <summary>
        /// Retrieves the list of all future travels records from the database.
        /// </summary>
        /// <returns>Returns a list of travels model objects representing all available future travels records in the database.</returns>
        List<Travels> GetAllFutureTravels();
        
        /// <summary>
        /// Retrieves the list of all past travels records from the database.
        /// </summary>
        /// <returns>Returns a list of travels model objects representing all available past travels records in the database.</returns>
        List<Travels> GetAllPastTravels();
        
        /// <summary>
        /// Updates an existing travels record in the database using the provided travels model object.
        /// </summary>
        /// <param name="travels">The travels model object to update in the database.</param>
        /// <returns>Returns the travels model object that has been updated in the database.</returns>
        Task<Travels> Update(Travels travels);
    }
}