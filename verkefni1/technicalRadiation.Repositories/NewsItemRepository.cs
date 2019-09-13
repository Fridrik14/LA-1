using System;
using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.Entities;
using techincalRadiation.Models.InputModels;
using techincalRadiation.Repositories.Data;

namespace technicalRadiation.Repositories
{
    // Working progress
    public class NewsItemRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            return DataProvider.NewsItems.Select(r => new NewsItemDto
            {
                Id = r.Id,
                Title = r.Title,
                ImgSource = r.ImgSource,
                ShortDescription = r.ShortDescription
            });
        }

        public NewsItemDto GetNewsItemById(int newsId)
        {
            var result = DataProvider.NewsItems.FirstOrDefault(r => r.Id == newsId);

            //TODO: Gera villumeldingu fyrir rangt Id
            if(result == null) 
            {
                return null;
            }
            return new NewsItemDto
            {
                Id = result.Id,
                Title = result.Title,
                ImgSource = result.ImgSource,
                ShortDescription = result.ShortDescription
            };
        }

        public NewsItemDetailDto CreateNewNewsItem(NewsItemInputModel newsItem)
        {
            int nextId = DataProvider.NewsItems.OrderByDescending(r => r.Id).FirstOrDefault().Id+1;
            var entity = new NewsItem
            {
                Id = nextId,
                Title = newsItem.Title,
                ImgSource = newsItem.ImgSource,
                ShortDescription = newsItem.ShortDescription,
                LongDescription = newsItem.LongDescription,
                PublishDate = newsItem.PublishDate,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            DataProvider.NewsItems.Add(entity);
            return new NewsItemDetailDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription,
                LongDescription = entity.LongDescription,
                PublishDate = entity.PublishDate
            };
        }

        public void updateNewsItemById(NewsItemInputModel newsItem, int newsId)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == newsId);
            if (entity == null) { return; /* Throw some exception */ }
            
            entity.Title = newsItem.Title;
            entity.ImgSource = newsItem.ImgSource;
            entity.ShortDescription = newsItem.ShortDescription;
            entity.LongDescription = newsItem.LongDescription;
            entity.PublishDate = newsItem.PublishDate;
            entity.DateModified = DateTime.Now;
        }
        public void DeleteNewsItemById(int newsItemId)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == newsItemId);
            if (entity == null) { return; /* Throw some exception */ }
            DataProvider.NewsItems.Remove(entity);
            DeleteNewsItemCategoriesConnection(newsItemId);
            DeleteNewsItemAuthorConnection(newsItemId);
        }

        public void DeleteNewsItemAuthorConnection(int newsItemId)
        {
            // Find all connections and delete them
            DataProvider.NIA.RemoveAll(r => r.NewsItemId == newsItemId);
        }

        public void DeleteNewsItemCategoriesConnection(int newsItemId)
        {
            // Find all connections and delete 
            DataProvider.NIC.RemoveAll(r=> r.NewsItemId == newsItemId);
        }

        public int getAuthorIdOfNewsItem(int newsItemId)
        {
            var newsItemAuthorConnection =  DataProvider.NIA.FirstOrDefault(r => r.NewsItemId == newsItemId);
            if (newsItemAuthorConnection == null){return -1;}
            else{return newsItemAuthorConnection.AuthorId;}
        }

        public IEnumerable<CategoryDto> getNewsItemcategories(int newsItemId)
        {
            var categoryConnection = DataProvider.NIC.Select(r => r.NewsItemId == newsItemId);
            
        }
    }
}