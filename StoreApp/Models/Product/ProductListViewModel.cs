using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos;

namespace StoreApp.Models.Product
{
    public class ProductListViewModel
    {
        public List<ProductDto> Products { get; set; }
    }
}