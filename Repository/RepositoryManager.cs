using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contracts;
using Repository.EfCore;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext context;
        private readonly Lazy<IProductRepository> productRepository;
        private readonly Lazy<ICategoryRepository> categoryRepository;

        public RepositoryManager(AppDbContext context,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
        {
            this.context = context;
            this.productRepository = new Lazy<IProductRepository>(()=> productRepository);
            this.categoryRepository = new Lazy<ICategoryRepository>(()=> categoryRepository);
        }

        public IProductRepository ProductRepository => productRepository.Value;

        public ICategoryRepository CategoryRepository => categoryRepository.Value;

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}