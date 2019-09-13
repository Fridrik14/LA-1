using System.Collections.Generic;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.Entities;
using technicalRadiation.Models;
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
        public IEnumerable<NewsItemDto> getNewsItemsByAuthorId(int id)
        {
            return _authorRepository.getNewsItemsByAuthorId(id);
        }
        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            _authorRepository.UpdateAuthorById(author, id);
        }

        public AuthorDetailDto createNewAuthor(AuthorInputModel author)
        {
            return _authorRepository.CreateNewAuthor(author);
        }
        public void DeleteAuthorById(int id)
        {
            _authorRepository.DeleteAuthorById(id);
        }

        public NewsItemAuthors createNewAuthorNewsItemLink(int authorId, int newsItemId)
        {
            return _authorRepository.CreateNewAuthorNewsItemLink(authorId, newsItemId);
        }
    }
}