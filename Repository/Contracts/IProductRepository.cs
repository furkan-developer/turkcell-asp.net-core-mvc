using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RequestParameters;

namespace Repository.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(bool isTrackChanges);
        List<Product> GetAllProductsWithDetails(bool isTrackChanges, ProductRequestParameter parameter);
        Product? GetOneProductById(int id, bool isTrackChanges);
        void CreateOneProduct(Product product);
        int GetTotalProduct();
        void UpdateOneProduct(Product product);
    }
}