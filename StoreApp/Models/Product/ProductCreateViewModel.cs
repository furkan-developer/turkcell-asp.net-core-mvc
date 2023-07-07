using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Utilities.FileUpload;

namespace StoreApp.Models.Product
{
    [Bind(nameof(ProductCreateViewModel.FormFile),nameof(ProductViewModel.Name), nameof(ProductViewModel.Price))]
    public class ProductCreateViewModel : ProductViewModel
    {
        public IFormFile? FormFile { get; set; }
    }
}