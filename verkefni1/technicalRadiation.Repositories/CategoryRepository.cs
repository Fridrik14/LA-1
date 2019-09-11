using System;
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
            return DataProvider.Categories.Select(
                r => new CategoryDto
            {
                Id = r.Id,
                Name = r.Name,
                Slug = r.Slug
            });
        }
        
        public CategoryDetailDto getCategoryById(int categoryId)
        {
            var result = DataProvider.Categories.FirstOrDefault(r => r.Id == categoryId);
            //TODO throw exception
            if(result == null)
            {
                return null;
            }
            // ADD count of how many news items this category is assigned
            return new CategoryDetailDto 
            {
                Id = result.Id,
                Name = result.Name,
                Slug = result.Slug
            };
        }
    }
}