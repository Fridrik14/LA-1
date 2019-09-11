using System.Collections.Generic;
using technicalRadiation.Repositories;
using technicalRadiation.Models.Dtos;

namespace technicalRadiation.Service
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository = new AuthorRepository();

        public IEnumerable<AuthorDto> getAllAuthors()
        {
            return _authorRepository.getAllAuthors();
        }

        public AuthorDto getAuthorById(int id)
        {
            return _authorRepository.getAuthorById(id);
        }
    }
}