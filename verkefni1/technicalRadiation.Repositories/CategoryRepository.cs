using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Repositories.Data;

namespace technicalRadiation.Repositories
{
    public class CategoryRepository
    {
        public IEnumerable<CategoryDto> getAllCategories()
        {
            return DataProvider.Categories.Select(r => new CategoryDto
            {
                r.Id = Id,
                r.Name = Name,
                r.Slug = Slug
            });
        }
        
        public CategoryDto getCategoryById(int categoryId)
        {
            var result = DataProvider.Categories.FirstOrDefault(r => r.Id == categoryId);
            //TODO throw exception
            if(result == null)
            {
                return null;
            }

            return new CategoryDto 
            {
                result.Id = Id,
                result.Name = Name,
                result.Slug = Slug
            };
        }
    }
}