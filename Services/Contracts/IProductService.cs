using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProducts(bool isTrackChanges);
        Product? GetOneProductById(bool isTrackChanges, int id);
        int GetTotalProduct();
    }
}