using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Repositories.Data;

namespace techincalRadiation.Repositories
{
    // Working progress
    public class NewsItemRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            return DataProvider.NewsItems.Select(
                r => new NewsItemDto
            {
                Id = 1,

            });
        }
    }
}