using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; } = String.Empty;

        public ICollection<Product> Products { get; set; }
    }
}