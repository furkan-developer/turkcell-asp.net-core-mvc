using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Models.Product;

namespace StoreApp.Models.Carts
{
    public class CartLine 
    {
        public ProductForCartViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}