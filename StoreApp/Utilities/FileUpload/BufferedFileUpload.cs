using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Utilities.FileUpload
{
    public class BufferedFileUpload : IBufferedFileUpload
    {
        public async Task<string> FileUpload(IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",formFile.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }       

            return $"/images/{formFile.FileName}";
        }
    }
}