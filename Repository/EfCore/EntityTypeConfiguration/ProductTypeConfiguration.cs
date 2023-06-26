using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EfCore.EntityTypeConfiguration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product() { Id = 1, Name = "Computer", Price = 17_000, ImgUrl = "/images/1.jpg", CategoryId = 1 },
                    new Product() { Id = 2, Name = "Keyboard", Price = 1_000, ImgUrl = "/images/2.jpg", CategoryId = 2 },
                    new Product() { Id = 3, Name = "Mouse", Price = 500, ImgUrl = "/images/3.jpg", CategoryId = 2 },
                    new Product() { Id = 4, Name = "Monitor", Price = 7_000, ImgUrl = "/images/4.jpg", CategoryId = 2 },
                    new Product() { Id = 5, Name = "Deck", Price = 50, CategoryId = 1 },
                    new Product() { Id = 6, Name = "Suç ve Ceza", Price = 60, CategoryId = 1 }
                );

            builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}