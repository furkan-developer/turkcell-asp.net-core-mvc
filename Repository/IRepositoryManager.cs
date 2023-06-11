using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contracts;

namespace Repository
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        
        void SaveChanges();
    }
}