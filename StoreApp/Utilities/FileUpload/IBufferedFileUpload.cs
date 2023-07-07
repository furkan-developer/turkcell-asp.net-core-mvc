using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Utilities.FileUpload
{
    public interface IBufferedFileUpload
    {
        Task<string> FileUpload(IFormFile file);
    }
}