using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Domain.Entities;
using Services.Dtos;
using StoreApp.Models.Product;
using AutoMapper;
using StoreApp.Utilities.FileUpload;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area(areaName: "admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public ProductController(IServiceManager serviceManager,IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
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
        public async Task<IActionResult> Create([FromForm] ProductCreateViewModel createViewModel,[FromServices]IBufferedFileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                await createViewModel.SetImgUrl(createViewModel.FormFile,fileUpload);
                
                ProductDtoForCreate dtoForCreate = _mapper.Map<ProductDtoForCreate>(createViewModel);   

                _serviceManager.ProductService.CreateOneProduct(dtoForCreate);
                
                return RedirectToAction(actionName: nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _serviceManager.ProductService.GetOneProductById(false,id);
            ProductUpdateViewModel updateViewModel = _mapper.Map<ProductUpdateViewModel>(product);

            return View(updateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductUpdateViewModel updateViewModel,[FromServices]IBufferedFileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                await updateViewModel.SetImgUrl(updateViewModel.FormFile,fileUpload);

                ProductDtoForUpdate dto = _mapper.Map<ProductDtoForUpdate>(updateViewModel);

                _serviceManager.ProductService.UpdateOneProduct(dto);

                TempData["ModelProcess"] = "Ürün güncellendi";
                return RedirectToAction(actionName: nameof(Index));
            }

            return View();
        }
    }
}