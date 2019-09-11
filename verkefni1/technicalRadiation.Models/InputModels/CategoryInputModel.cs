using System.ComponentModel.DataAnnotations;

namespace techincalRadiation.Models.Dtos
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}