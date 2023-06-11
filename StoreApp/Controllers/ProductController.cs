using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Repository.EfCore;
using Repository.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRp;

        public ProductController(IProductRepository productRp)
        {
            _productRp = productRp;
        }

        public IActionResult Index()
        {
            var data = _productRp.GetAllProducts(false);
            return View(data);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            var data = _productRp.GetOneProductById(id,false);
            return View(data);
        }
    }
}