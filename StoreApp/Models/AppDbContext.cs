using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { Id = 1, Name = "Computer", Price = 17_000 },
                    new Product() { Id = 2, Name = "Keyboard", Price = 1_000 },
                    new Product() { Id = 3, Name = "Mouse", Price = 500 },
                    new Product() { Id = 4, Name = "Monitor", Price = 7_000 },
                    new Product() { Id = 5, Name = "Deck", Price = 1_500 }
                );
        }
    }
}