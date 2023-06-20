using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> productService;
        private readonly Lazy<ICategoryService> categoryService;

        public ServiceManager(IProductService productService,
        ICategoryService categoryService)
        {
            this.productService = new Lazy<IProductService>(() => productService);
            this.categoryService = new Lazy<ICategoryService>(() => categoryService);
        }

        public IProductService ProductService => productService.Value;
        public ICategoryService CategoryService => categoryService.Value;
    }
}