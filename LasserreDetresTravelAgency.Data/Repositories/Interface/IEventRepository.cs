using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IEventRepository
    {
        
        /// <summary>
        /// Adds an event to the database using the provided event model object.
        /// </summary>
        /// <param name="evenement">The event model object to add to the database.</param>
        /// <returns>Returns the event model object that has been added to the database.</returns>
        Task<Event> Add(Event evenement);
        
        /// <summary>
        /// Deletes an event from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves an event from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to retrieve from the database.</param>
        /// <returns>Returns the event model object retrieved from the database.</returns>
        Task<Event> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all events from the database.
        /// </summary>
        /// <returns>Returns a list of event model objects representing all available events in the database.</returns>
        List<Event> GetAll();
        
        /// <summary>
        /// Updates an existing event in the database using the provided event model object.
        /// </summary>
        /// <param name="evenement">The event model object to update in the database.</param>
        /// <returns>Returns the event model object that has been updated in the database.</returns>
        Task<Event> Update(Event evenement);
        
        /// <summary>
        /// Retrieves the list of all events associated with a specific destination from the database.
        /// </summary>
        /// <param name="id">The identifier of the destination to filter events by.</param>
        /// <returns>Returns a list of event model objects associated with the specified destination.</returns>
        List<Event> GetAllEventByDest(int id);
    }
}