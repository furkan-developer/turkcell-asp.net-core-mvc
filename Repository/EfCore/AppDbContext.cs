using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Repository.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { Id = 1, Name = "Computer", Price = 17_000, ImgUrl= "/images/1.jpg"},
                    new Product() { Id = 2, Name = "Keyboard", Price = 1_000, ImgUrl= "/images/2.jpg"},
                    new Product() { Id = 3, Name = "Mouse", Price = 500 , ImgUrl= "/images/3.jpg"},
                    new Product() { Id = 4, Name = "Monitor", Price = 7_000 , ImgUrl= "/images/4.jpg"},
                    new Product() { Id = 5, Name = "Deck", Price = 1_500}
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { CategoryId = 1, CategoryName = "Book" },
                    new Category() { CategoryId = 2, CategoryName = "Electronic" }
                );
        }
    }
}