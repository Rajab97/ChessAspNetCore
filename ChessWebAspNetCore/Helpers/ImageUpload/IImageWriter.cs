using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers.ImageUpload
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile fromFile);
    }
}
