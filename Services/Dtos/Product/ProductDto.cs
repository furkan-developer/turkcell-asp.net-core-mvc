using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Dtos
{
    public class ProductDto
    {
        public int Id { get; init; }

        [Required]
        public String Name { get; init; } = String.Empty;

        [Required]
        public decimal Price { get; init; }
        public String? ImgUrl { get; init; } = String.Empty;

        public int? CategoryId { get; init; }
        public Category? Category { get; init; } = null;
    }
}