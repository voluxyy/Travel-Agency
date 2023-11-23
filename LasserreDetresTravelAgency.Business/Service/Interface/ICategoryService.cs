using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICategoryService
    {
        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="dto">The data of the category to be added.</param>
        /// <returns>Returns the data of the added category.</returns>
        Task<CategoryDto> Add(CategoryDto dto);

        /// <summary>
        /// Deletes a category based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to be deleted.</param>
        /// <returns>Returns the number of deleted records (usually 1 if the category existed).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a category based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to retrieve.</param>
        /// <returns>Returns the data of the retrieved category.</returns>
        Task<CategoryDto> Get(int id);

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="dto">The new data of the category to be updated.</param>
        /// <returns>Returns the data of the updated category.</returns>
        Task<CategoryDto> Update(CategoryDto dto);
        
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>Returns a list of all categories.</returns>
        List<CategoryDto> GetAll();
    }
}