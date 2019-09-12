using System;
using System.Collections.Generic;
using techincalRadiation.Models.Entities;

namespace techincalRadiation.Repositories.Data
{
    // Dummy data to test the system
    // REQUIRES DUMMY DATA
    public class DataProvider
    {
        private static readonly string _adminName = "TechnicalRadiationAdmin";

        // public static List<Entity> Entities = new List<Entity> {}
        // dummy data for Authors
        public static List<Author> Authors = new List<Author> 
        {
            new Author
            {
                Id = 1,
                Name = "Stephen Hawkings",
                ProfileImgSource = "http://www.gstatic.com/tv/thumb/persons/315047/315047_v9_ba.jpg",
                Bio = "A man who lived in a wheelchair and was so smart he understood the universe.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 2,
                Name = "Stephenie Meyer",
                ProfileImgSource = "https://m.media-amazon.com/images/M/MV5BMTM3NTQ0NjA2Ml5BMl5BanBnXkFtZTcwMjA4MTUwNw@@._V1_.jpg",
                Bio = "A woman who really loves vampires and werewolves.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
        // dummy data for Cateories
        public static List<Category> Categories = new List<Category> 
        {
            new Category
            {
                Id = 1,
                Name = "Popular science",
                Slug = "popular-science",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 2,
                Name = "Romance",
                Slug = "romance",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
        // dummy data for NewsItems
        public static List<NewsItem> NewsItems = new List<NewsItem> 
        {
            new NewsItem
            {
                Id = 1,
                Title = "The Hawk publishes a new book!",
                ImgSource = "https://img.etimg.com/thumb/msid-63298227,width-640,resizemode-4,imgsize-281391/the-prolific-author.jpg",
                ShortDescription = "Stephen Hawking has now published a new book called A Breef History of Time.",
                LongDescription = "This new book by Mr.Hawking is sure to revolutionize the popular science genre and will leave poeple wanting to know more about the universe than they could ever have imagend.",
                PublishDate = "1.3.1988",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            },
            new NewsItem
            {
                Id = 2,
                Title = "Another disater book from Mayers",
                ImgSource = "https://i.pinimg.com/originals/bb/d2/0e/bbd20e862c9757ca6602e8b90cc7f63e.jpg",
                ShortDescription = "Stephanie Mayers has published another book and fans are not happy.",
                LongDescription = "Midnight Sun, the new book by Ms.Mayers has fans leaving wanting more, they feel it is no good.",
                PublishDate = "19.08.2015",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            }
        };


        // NIA => News Item Authors
        public static List<NewsItemAuthors> NIA = new List<NewsItemAuthors> 
        {
            new NewsItemAuthors
            {
                AuthorId = 1,
                NewsItemId = 1
            },
            new NewsItemAuthors
            {
                AuthorId = 2,
                NewsItemId = 2
            }
        };
        // NIC => News Item Categories
        public static List<NewsitemCategories> NIC = new List<NewsitemCategories> 
        {
            new NewsitemCategories
            {
                NewsItemId = 1,
                CategoryId = 1
            }
        };
    }
}