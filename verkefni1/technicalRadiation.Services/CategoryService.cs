using System.Collections.Generic;
using technicalRadiation.Repositories;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.Entities;

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

        public CategoryDetailDto CreateNewCategory(CategoryInputModel category)
        {
            return _categoryRepository.CreateNewCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int categoryId)
        {
            _categoryRepository.UpdateCategoryById(category,categoryId);
        }

        public void DeleteCategoryById(int categoryId)
        {
            _categoryRepository.DeleteCategoryById(categoryId);
        }

        public NewsitemCategories CreateNewAuthorNewsItemLink(int categoryId, int newsItemId)
        {
            return _categoryRepository.CreateNewAuthorNewsItemLink(categoryId,newsItemId);
        }

    }
}