using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Models.Product
{
    [Bind(nameof(ProductUpdateViewModel.FormFile),nameof(ProductViewModel.Name), nameof(ProductViewModel.Price),nameof(ProductUpdateViewModel.Id))]
    public class ProductUpdateViewModel : ProductViewModel
    {
        public int Id { get; init; }
        public IFormFile? FormFile { get; set; }
    }
}