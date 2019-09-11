using System.Collections.Generic;
using technicalRadiation.Repositories;
using technicalRadiation.Models.Dtos;

namespace technicalRadiation.Service
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepository = new NewsItemRepository();

        public IEnumerable<NewsItemDto> getAllNewsItems()
        {
            return _newsItemRepository.getAllNewsItems();
        }

        public NewsItemDto getNewsItemById(int id)
        {
            return _newsItemRepository.getNewsItemById(id);
        }
    }
    public class CategoryService 
    {
        private CategoryRepository _categoryRepository = new CategoryRepository();

        public IEnumerable<CategoryDto> getAllCategories()
        {
            return _categoryRepository.getAllCategories();
        }
        public CategoryDto getCategoryById(int id)
        {
            return _categoryRepository.getCategoryById(id);
        }

    }
}