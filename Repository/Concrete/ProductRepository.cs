using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contracts;
using Domain.Entities;
using Repository.EfCore;
using Domain.RequestParameters;
using Repository.Extensions;

namespace Repository.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository, IRepositoryBase<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product)
        {
            Insert(product);
        }

        public List<Product> GetAllProducts(bool isTrackChanges) => FindAll(isTrackChanges).ToList();

        public List<Product> GetAllProductsWithDetails(bool isTrackChanges, ProductRequestParameter parameter)
        {
            return FindAll(isTrackChanges)
            .FilteredByCategoryId(parameter.CategoryId)
            .SearchedByTermOnProductName(parameter.SearchTerm)
            .ToList();
        }

        public Product? GetOneProductById(int id, bool isTrackChanges) => FindByCondition(isTrackChanges, p => p.Id.Equals(id));

        public int GetTotalProduct()
        {
            return FindAll(false).Count();
        }

        public void UpdateOneProduct(Product product)
        {
            Modify(product);
        }
    }
}