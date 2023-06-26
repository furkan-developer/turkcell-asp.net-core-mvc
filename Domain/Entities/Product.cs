using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public String Name { get; set; } = String.Empty;
        
        [Required]
        public decimal Price { get; set; }
        public String? ImgUrl { get; set; } = String.Empty;

        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null;
    }
}
