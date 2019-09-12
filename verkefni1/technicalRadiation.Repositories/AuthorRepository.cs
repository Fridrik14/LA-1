using System;
using System.Collections.Generic;
using System.Linq;
using techincalRadiation.Models.Dtos;
using technicalRadiation.Models.Entities;
using technicalRadiation.Models.InputModels;
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

        public NewsItemDto getNewsItemsByAuthorId(int authorId)
        {
            var result = DataProvider.NIA.FindAll(r => r.AuthorId == authorId);
            //TODO Throw exception
            if (result == null)
            {
                return null;
            }
            //Populate newsItemsId's of author
            var newsItems = DataProvider.NewsItems.FindAll(n => n.Id == result.NewsItemId);
            //Return newsItemDto's of all newsItems of author
            return DataProvider.NewsItems.Select(s => new NewsItemDto
            {
                s.Id = newsItems.Id,
                s.Title = newsItems.Title,
                s.ImgSource = newsItems.ImgSource,
                s.ShortDescription = newsItems.SortDescription
            });
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var result = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            //TODO throw exception
            if (result == null)
            {
                return null;
            }
            result.Name = author.Name;
            result.ProfileImgSource = author.ProfileImgSource;
            result.Bio = author.Bio;
            result.DateModified = DateTime.Now;
        }

        public AuthorDetailDto CreateNewAuthor(AuthorInputModel author)
        {
            int nextId = DataProvider.Authors.OrderByDescending(r => r.Id).FirstOrDefault() + 1;
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
            if(result == null)
            {
                return null;
            }
            //Remove Author from Authors list
            DataProvider.Authors.Remove(result);
            //Remove Athor->NewsItem link from NIA
            DataProvider.NIA.RemoveAll(s => s.AuthorId == id);
        }

        public NIA CreateNewAuthorNewsItemLink(int authorId, int newsItemId)
        {
            var entity =  new NIA
            {
                AuthorId = authorId,
                NewsItemId = newsItemId
            };
            DataProvider.NIA.Add(entity);
            return new NIA 
            {
                AuthorId = entity.AuthorId,
                NewsItemId = entity.NewsItemId;
            };
        }
    }
}