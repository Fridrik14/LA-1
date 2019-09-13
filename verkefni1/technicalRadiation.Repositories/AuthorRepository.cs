using System;
using System.Collections.Generic;
using static System.Collections.IEnumerable;
using System.Linq;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models;
using techincalRadiation.Models.Entities;
using techincalRadiation.Models.InputModels;
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
                Id = result.Id,
                Name = result.Name,
                ProfileImgSource = result.ProfileImgSource,
                Bio = result.Bio
            };
        }

        
        public IEnumerable<NewsItemDto> getNewsItemsByAuthorId(int authorId)
        {
            var result = DataProvider.NIA.FindAll(r => r.AuthorId == authorId);
            var newsItems = DataProvider.NewsItems.Where(a => result.Any(x => x.NewsItemId == a.Id));
            
            
            //TODO Throw exception
            if (result == null)
            {
                return null;
            }

            return newsItems.Select(r => new NewsItemDto
            {
                Id = r.Id,
                Title = r.Title,
                ImgSource = r.ImgSource,
                ShortDescription = r.ShortDescription
            });
            
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var result = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            //TODO throw exception
            if (result != null)
            {
                result.Name = author.Name;
                result.ProfileImgSource = author.ProfileImgSource;
                result.Bio = author.Bio;
                result.DateModified = DateTime.Now;
            }
            
        }

        public AuthorDetailDto CreateNewAuthor(AuthorInputModel author)
        {
            int nextId = DataProvider.Authors.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = new Author
            {
                Id = nextId,
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = "Admin"
            };
            DataProvider.Authors.Add(entity);
            return new AuthorDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ProfileImgSource = entity.ProfileImgSource,
                Bio = entity.Bio
                
            };
        }
        public void DeleteAuthorById(int id)
        {
            var result = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            //TODO throw exception
            if(result != null)
            {
                //Remove Author from Authors list
                DataProvider.Authors.Remove(result);
                //Remove Athor->NewsItem link from NIA
                DataProvider.NIA.RemoveAll(s => s.AuthorId == id);
            }
            
        }

        public NewsItemAuthors CreateNewAuthorNewsItemLink(int authorId, int newsItemId)
        {
            var entity =  new NewsItemAuthors
            {
                AuthorId = authorId,
                NewsItemId = newsItemId
            };
            DataProvider.NIA.Add(entity);
            return new NewsItemAuthors
            {
                AuthorId = entity.AuthorId,
                NewsItemId = entity.NewsItemId
            };
        }
    }
}