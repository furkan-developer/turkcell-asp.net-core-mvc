using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Domain.Entities;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area(areaName: "admin")]
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(Product.Name), nameof(Product.Price), nameof(Product.ImgUrl))][FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProductService.CreateOneProduct(product);
                return RedirectToAction(actionName: nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _serviceManager.ProductService.GetOneProductById(false,id);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind(nameof(Product.Id),nameof(Product.Name), nameof(Product.Price), nameof(Product.ImgUrl))][FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProductService.UpdateOneProduct(product);

                TempData["ModelProcess"] = "Ürün güncellendi";
                return RedirectToAction(actionName: nameof(Index));
            }

            return View();
        }
    }
}