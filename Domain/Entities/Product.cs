namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public String? ImgUrl { get; set; } = String.Empty;
    }
}
