using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(bool isTrackChanges);
        Product? GetOneProductById(int id, bool isTrackChanges);
    }

    public interface ICategoryRepository
    {

    }
}