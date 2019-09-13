using System;
using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.Entities;
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
            int newsItems = DataProvider.NIC.FindAll(r => r.CategoryId == categoryId).Count();
            // ADD count of how many news items this category is assigned
            return new CategoryDetailDto 
            {
                Id = result.Id,
                Name = result.Name,
                Slug = result.Slug,
                NumberOfNewsItems = newsItems
            };
        }

        // ADD UPDATE DELETE CONNECTION

        public CategoryDetailDto CreateNewCategory(CategoryInputModel category)
        {
            int nextId = DataProvider.Categories.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            string lowerCaseAndHyphen = category.Name.ToLower().Replace(' ', '-');
            var entity = new Category
            {
                Id = nextId,
                Name = category.Name,
                Slug = lowerCaseAndHyphen,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = "Admin"
            };
            DataProvider.Categories.Add(entity);
            return new CategoryDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug,
                NumberOfNewsItems = 0
                
            };
        }

        public void UpdateCategoryById(CategoryInputModel category, int categoryId)
        {
            var result = DataProvider.Categories.FirstOrDefault(r => r.Id == categoryId);
            //TODO throw exception
            if (result != null)
            {
                string lowerCaseAndHyphen = category.Name.ToLower().Replace(' ', '-');
                result.Name = category.Name;
                result.Slug = lowerCaseAndHyphen;
                result.DateModified = DateTime.Now;
            }
        }

        public void DeleteCategoryById(int categoryId)
        {
            var result = DataProvider.Categories.FirstOrDefault(r => r.Id == categoryId);
            if(result != null)
            {
                DataProvider.Categories.Remove(result);
                DataProvider.NIC.RemoveAll(s => s.CategoryId == categoryId);
            }
        }

        public NewsitemCategories CreateNewAuthorNewsItemLink(int categoryId, int newsItemId)
        {
            var entity =  new NewsitemCategories
            {
                CategoryId = categoryId,
                NewsItemId = newsItemId
            };
            DataProvider.NIC.Add(entity);
            return new NewsitemCategories
            {
                CategoryId = entity.CategoryId,
                NewsItemId = entity.NewsItemId
            };
        }
    }
}