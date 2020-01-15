using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ChessWebAspNetCore.Helpers.ImageUpload
{
    public class ImageWriter : IImageWriter
    {


        //Throw Argument Exception if file is not in correct format
        public async Task<string> UploadImage(IFormFile fromFile)
        {
            if (CheckIfImageFile(fromFile))
            {
                return await WriteFile(fromFile);
            }
            throw new FormatException("Image is not in correct format");
        }
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }
        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName = String.Empty;
            DateTime dateTime = DateTime.Now;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                fileName = GetCurrentTimeForFileName(dateTime) + extension;
                                                                  
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return fileName;
        }
        private string GetCurrentTimeForFileName(DateTime dateTime)
        {
            string result = $"" +
                $"{dateTime.Year}." +
                $"{dateTime.Month}." +
                $"{dateTime.Day}." +
                $"{dateTime.Hour}." +
                $"{dateTime.Minute}." +
                $"{dateTime.Second}." +
                $"{dateTime.Millisecond}";

            return result;
        }
    }
}
