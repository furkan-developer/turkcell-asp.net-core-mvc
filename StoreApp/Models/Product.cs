using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}