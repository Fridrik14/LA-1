using System.Collections.Generic;
using technicalRadiation.Repositories;
using techincalRadiation.Models.Dtos;

namespace technicalRadiation.Service
{
    public class CategoryService 
    {
        private CategoryRepository _categoryRepository = new CategoryRepository();

        public IEnumerable<CategoryDto> getAllCategories()
        {
            return _categoryRepository.getAllCategories();
        }
        public CategoryDetailDto getCategoryById(int id)
        {
            return _categoryRepository.getCategoryById(id);
        }

    }
}