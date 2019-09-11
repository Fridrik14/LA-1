using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Repositories.Data;

namespace technicalRadiation.Repositories
{
    public class AuthorRepository
    {
        public IEnumerable<AuthorDto> getAllAuthors()
        {
            return DataProvider.Authors.Select(r => new AuthorDto 
            {
                Id = r.Id,
                Name = r.Name
            });
        }

        public AuthorDetailDto getAuthorById(int authorId)
        {
            var result = DataProvider.Authors.FirstOrDefault(r => r.Id == authorId);
            //TODO throw exception
            if(result == null)
            {
                return null;
            }
            return new AuthorDetailDto
            {
                Id = result.Id ,
                Name = result.Name,
                ProfileImgSource = result.ProfileImgSource,
                Bio = result.Bio
            };
        }

        // WORKING PROGRESS
        public NewsItemDto getNewsItemsByAuthorId(int AuthorId)
        {
            var results = DataProvider.NIA.FindAll(r => r.AuthorId == AuthorId);
            var newsItems = DataProvider.NewsItems;
            
            
            return null;
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {

        }
    }
}