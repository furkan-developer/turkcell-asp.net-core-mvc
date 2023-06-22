using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;


namespace StoreApp.Areas.Admin.Controllers
{
    [Area(areaName:"admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var products = _serviceManager.ProductService.GetAllProducts(false);

            return View(products);
        }
    }
}