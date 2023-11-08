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

        private CategoryDto ModelToDto(Category Category)
        {
            CategoryDto CategoryDto = new CategoryDto
            {
                Id = Category.Id,
                NameCategory = Category.NameCategory,
                Description = Category.Description,
                Destinations = Category.Destinations,
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
                Destinations = CategoryDto.Destinations,
            };

            return Category;
        }
    }
}
