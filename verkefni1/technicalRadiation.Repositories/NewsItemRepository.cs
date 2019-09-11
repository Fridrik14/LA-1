using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
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
    }
}