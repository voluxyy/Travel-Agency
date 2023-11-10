using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Add(CategoryDto dto)
        {
            Category category = DtoToModel(dto);
            await categoryRepository.Add(category);
            CategoryDto categoryDto = ModelToDto(category);

            return categoryDto;
        }

        public async Task<CategoryDto> Update(CategoryDto dto)
        {
            Category category = DtoToModel(dto); 
            await categoryRepository.Update(category);
            CategoryDto categoryDto = ModelToDto(category);

            return categoryDto;
        }

        public async Task<int> Delete(int id)
        {
            return await categoryRepository.Delete(id);
        }

        public async Task<CategoryDto> Get(int id)
        {
            return ModelToDto(await categoryRepository.Get(id));
        }

        public List<CategoryDto> GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
            List<CategoryDto> categoriesDtos = ListModelToDto(categories);
            return categoriesDtos;
        }

        private List<CategoryDto> ListModelToDto(List<Category> categories)
        {
            List<CategoryDto> categoriesDtos = new List<CategoryDto>();
            foreach (Category cat in categories)
            {
                categoriesDtos.Add(ModelToDto(cat));
            }
            return categoriesDtos;
        }

        private CategoryDto ModelToDto(Category Category)
        {
            CategoryDto CategoryDto = new CategoryDto
            {
                Id = Category.Id,
                NameCategory = Category.NameCategory,
                Description = Category.Description,
                Destinations = (Category.Destinations != null) ? Category.Destinations : null,
            };

            return CategoryDto;
        }

        private Category DtoToModel(CategoryDto CategoryDto)
        {
            Category Category = new Category
            {
                Id = CategoryDto.Id,
                NameCategory = CategoryDto.NameCategory,
                Description = CategoryDto.Description,
                Destinations = null,
            };

            return Category;
        }
    }
}
