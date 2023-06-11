using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}