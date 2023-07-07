using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Utilities.FileUpload;

namespace StoreApp.Models.Product
{
    public class ProductViewModel
    {
        protected String? imgUrl = string.Empty;

        [Required]
        public String Name { get; init; } = String.Empty;

        [Required]
        public decimal Price { get; init; }
        public String? ImgUrl { get; set; }

        public int? CategoryId { get; init; }

        public async Task SetImgUrl(IFormFile file, IBufferedFileUpload fileUpload)
        {
            if(file is not null)
                ImgUrl = await fileUpload.FileUpload(file);
        }
    }
}