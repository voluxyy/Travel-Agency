using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IEventService
    {
        
        /// <summary>
        /// Adds a new event using the provided data.
        /// </summary>
        /// <param name="dto">The event data to add.</param>
        /// <returns>Returns the added event data.</returns>
        Task<EventDto> Add(EventDto dto);
        
        /// <summary>
        /// Deletes an event based on its ID.
        /// </summary>
        /// <param name="id">The ID of the event to delete.</param>
        /// <returns>Returns the number of events deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves event data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>Returns the event data if found, otherwise null.</returns>
        Task<EventDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all events.
        /// </summary>
        /// <returns>Returns a list of event data.</returns>
        List<EventDto> GetAll();
        
        /// <summary>
        /// Updates an existing event using the provided data.
        /// </summary>
        /// <param name="dto">The event data to update.</param>
        /// <returns>Returns the updated event data.</returns>
        Task<EventDto> Update(EventDto dto);
        
        /// <summary>
        /// Retrieves a list of events for a specific destination.
        /// </summary>
        /// <param name="id">The ID of the destination.</param>
        /// <returns>Returns a list of event data for the specified destination.</returns>
        List<EventDto> GetAllEventByDest(int id);
    }
}