using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICategoryRepository
    {
        
        /// <summary>
        /// Adds a category to the database using the provided category model object.
        /// </summary>
        /// <param name="category">The category model object to add to the database.</param>
        /// <returns>Returns the category model object that has been added to the database.</returns>
        Task<Category> Add(Category category);
        
        /// <summary>
        /// Deletes a category from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a category from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to retrieve from the database.</param>
        /// <returns>Returns the category model object retrieved from the database.</returns>
        Task<Category> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all categories from the database.
        /// </summary>
        /// <returns>Returns a list of category model objects representing all available categories in the database.</returns>
        List<Category> GetAll();
        
        /// <summary>
        /// Updates an existing category in the database using the provided category model object.
        /// </summary>
        /// <param name="category">The category model object to update in the database.</param>
        /// <returns>Returns the category model object that has been updated in the database.</returns>
        Task<Category> Update(Category category);
    }
}