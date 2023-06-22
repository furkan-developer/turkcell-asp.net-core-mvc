using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts;
using Repository;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _rpManager;

        public ProductManager(IRepositoryManager rpManager)
        {
            _rpManager = rpManager;
        }

        public void CreateOneProduct(Product product)
        {
            _rpManager.ProductRepository.CreateOneProduct(product);
            _rpManager.SaveChanges();
        }

        public List<Product> GetAllProducts(bool isTrackChanges)
        {
            return _rpManager.ProductRepository.GetAllProducts(isTrackChanges);
        }

        public Product? GetOneProductById(bool isTrackChanges, int id)
        {
            return _rpManager.ProductRepository.GetOneProductById(id,isTrackChanges);
        }

        public int GetTotalProduct()
        {
            return _rpManager.ProductRepository.GetTotalProduct();
        }
    }
}