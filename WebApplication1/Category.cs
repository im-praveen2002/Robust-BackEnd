using System.ComponentModel.DataAnnotations;
namespace WebApplication1
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number {  get; set; }



    }
}
