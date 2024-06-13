using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CreateCategoryDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

    }
}
