using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ITravelsService
    {
        
        /// <summary>
        /// Adds a new travel using the provided data.
        /// </summary>
        /// <param name="dto">The travel data to add.</param>
        /// <returns>Returns the added travel data.</returns>
        Task<TravelsDto> Add(TravelsDto dto);
        
        /// <summary>
        /// Deletes a travel based on its ID.
        /// </summary>
        /// <param name="id">The ID of the travel to delete.</param>
        /// <returns>Returns the number of travels deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves travel data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the travel to retrieve.</param>
        /// <returns>Returns the travel data if found, otherwise null.</returns>
        Task<TravelsDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all travels.
        /// </summary>
        /// <returns>Returns a list of travel data.</returns>
        List<TravelsDto> GetAll();
        
        /// <summary>
        /// Updates an existing travel using the provided data.
        /// </summary>
        /// <param name="dto">The travel data to update.</param>
        /// <returns>Returns the updated travel data.</returns>
        Task<TravelsDto> Update(TravelsDto dto);
        
        /// <summary>
        /// Retrieves a list of all future travels.
        /// </summary>
        /// <returns>Returns a list of future travel data.</returns>
        List<TravelsDto> GetAllFutureTravels();
        
        /// <summary>
        /// Retrieves a list of all past travels.
        /// </summary>
        /// <returns>Returns a list of past travel data.</returns>
        List<TravelsDto> GetAllPastTravels();
    }
}