using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Models.Product;

namespace StoreApp.Models.Carts
{
    public class Cart
    {
        public Cart()
        {
            Cartlines = new List<CartLine>();
        }
        public List<CartLine> Cartlines { get; set; }

        public virtual void AddItem(ProductForCartViewModel productViewModel, int quantity)
        {      
            var cartLine = Cartlines.SingleOrDefault(line => line.Product.Id == productViewModel.Id);

            if (cartLine is not default(CartLine))
            {
                cartLine.Quantity += quantity;
            }
            else
            {
                Cartlines.Add(new CartLine(){
                    Product = productViewModel,
                    Quantity = quantity
                });
            }
        }

        public virtual void RemoveLine(ProductForCartViewModel product) =>
            Cartlines.RemoveAll(line => line.Product.Id.Equals(product.Id));
        
        public decimal ComputeTotalValue() => 
            Cartlines.Sum(line => line.Product.Price * line.Quantity);
        
        public virtual void Clear() => Cartlines.Clear();
    }
}