using System;

namespace techincalRadiation.Models.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string PublishDate { get; set; }

        // Metadata / Database specific properties
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}