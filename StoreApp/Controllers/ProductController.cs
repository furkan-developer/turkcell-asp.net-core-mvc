using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Repository.EfCore;
using Repository.Contracts;
using Services.Dtos;
using StoreApp.Models.Product;
using Services;
using Domain.RequestParameters;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(ProductRequestParameter parameters)
        {
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(false,parameters);
            var model = new ProductListViewModel()
            {
                Products = products
            };

            return View(model);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            var data = _serviceManager.ProductService.GetOneProductById(false, id);
            return View(data);
        }
    }
}