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
                r.Id = Id,
                r.Name = Name
            });
        }

        public AuthorDto getAuthorById(int authorId)
        {
            var result = DataProvider.Authors.FirstOrDefault(r => r.Id == authorId);
            //TODO throw exception
            if(result == null)
            {
                return null;
            }
            return new AuthorDto
            {
                result.Id = Id,
                result.Name = Name
            };
        }
    }
}