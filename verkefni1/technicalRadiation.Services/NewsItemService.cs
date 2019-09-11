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
}