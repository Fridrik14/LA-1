using System.Collections.Generic;
using techincalRadiation.Models.Dtos;
using technicalRadiation.Repositories;


namespace technicalRadiation.Service
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository = new AuthorRepository();

        public IEnumerable<AuthorDto> getAllAuthors()
        {
            return _authorRepository.getAllAuthors();
        }

        public AuthorDetailDto getAuthorById(int id)
        {
            return _authorRepository.getAuthorById(id);
        }
    }
}