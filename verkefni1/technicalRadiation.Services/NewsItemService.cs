using System.Collections.Generic;
using technicalRadiation.Repositories;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.InputModels;

namespace technicalRadiation.Service
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepository = new NewsItemRepository();

        public IEnumerable<NewsItemDto> getAllNewsItems()
        {
            return _newsItemRepository.GetAllNewsItems();
        }

        public NewsItemDto getNewsItemById(int id)
        {
            return _newsItemRepository.GetNewsItemById(id);
        }

        public void UpdateNewsItemById(NewsItemInputModel newsItem, int id)
        {
            _newsItemRepository.updateNewsItemById(newsItem,id);
        }

        public NewsItemDetailDto CreateNewNewsItem(NewsItemInputModel newsItem)
        {
            return _newsItemRepository.CreateNewNewsItem(newsItem);
        }

        public void DeleteNewsItemById(int newsItemId)
        {
            _newsItemRepository.DeleteNewsItemById(newsItemId);
        }
        public void DeleteNewsItemAuthorConnection(int newsItemId)
        {
            _newsItemRepository.DeleteNewsItemAuthorConnection(newsItemId);
        }

        public void DeleteNewsItemCategoriesConnection(int newsItemId)
        {
            _newsItemRepository.DeleteNewsItemCategoriesConnection(newsItemId);
        }
        
    }
}