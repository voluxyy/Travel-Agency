using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ITravelTypeService
    {
        
        /// <summary>
        /// Adds a new travel type using the provided data.
        /// </summary>
        /// <param name="dto">The travel type data to add.</param>
        /// <returns>Returns the added travel type data.</returns>
        Task<TravelTypeDto> Add(TravelTypeDto dto);
        
        /// <summary>
        /// Deletes a travel type based on its ID.
        /// </summary>
        /// <param name="id">The ID of the travel type to delete.</param>
        /// <returns>Returns the number of travel types deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves travel type data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the travel type to retrieve.</param>
        /// <returns>Returns the travel type data if found, otherwise null.</returns>
        Task<TravelTypeDto> Get(int id);
        
        /// <summary>
        /// Updates an existing travel type using the provided data.
        /// </summary>
        /// <param name="dto">The travel type data to update.</param>
        /// <returns>Returns the updated travel type data.</returns>
        Task<TravelTypeDto> Update(TravelTypeDto dto);
        
        /// <summary>
        /// Retrieves a list of all travel types.
        /// </summary>
        /// <returns>Returns a list of travel type data.</returns>
        List<TravelTypeDto> GetAll();
    }
}