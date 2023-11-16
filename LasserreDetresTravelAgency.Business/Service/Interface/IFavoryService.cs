using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IFavoryService
    {
        
        /// <summary>
        /// Adds a new favorite using the provided data.
        /// </summary>
        /// <param name="dto">The favorite data to add.</param>
        /// <returns>Returns the added favorite data.</returns>
        Task<FavoryDto> Add(FavoryDto dto);
        
        /// <summary>
        /// Deletes a favorite based on its ID.
        /// </summary>
        /// <param name="id">The ID of the favorite to delete.</param>
        /// <returns>Returns the number of favorites deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves favorite data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the favorite to retrieve.</param>
        /// <returns>Returns the favorite data if found, otherwise null.</returns>
        Task<FavoryDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all favorites.
        /// </summary>
        /// <returns>Returns a list of favorite data.</returns>
        List<FavoryDto> GetAll();
        
        /// <summary>
        /// Updates an existing favorite using the provided data.
        /// </summary>
        /// <param name="dto">The favorite data to update.</param>
        /// <returns>Returns the updated favorite data.</returns>
        Task<FavoryDto> Update(FavoryDto dto);
    }
}