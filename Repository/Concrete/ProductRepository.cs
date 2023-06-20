using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contracts;
using Domain.Entities;
using Repository.EfCore;

namespace Repository.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository, IRepositoryBase<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public List<Product> GetAllProducts(bool isTrackChanges) => FindAll(isTrackChanges).ToList();

        public Product? GetOneProductById(int id, bool isTrackChanges) => FindByCondition(isTrackChanges, p => p.Id.Equals(id));

        public int GetTotalProduct()
        {
            return FindAll(false).Count();
        }
    }
}