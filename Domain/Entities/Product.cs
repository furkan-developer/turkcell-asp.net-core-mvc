using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        public String Name { get; set; } = String.Empty;
        
        public decimal Price { get; set; }
        public String? ImgUrl { get; set; } = String.Empty;

        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null;
    }
}
