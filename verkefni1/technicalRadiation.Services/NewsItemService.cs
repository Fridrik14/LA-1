using System.Collections.Generic;
using technicalRadiation.Repositories;
using techincalRadiation.Models.Dtos;

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
    }
}