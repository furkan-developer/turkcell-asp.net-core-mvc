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

        public ServiceManager(IProductService productService)
        {
            this.productService = new Lazy<IProductService>(() => productService);
        }

        public IProductService ProductService => productService.Value;
    }
}