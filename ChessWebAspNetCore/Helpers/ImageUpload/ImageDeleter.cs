using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers.ImageUpload
{
    public class ImageDeleter
    {
        public static bool RemoveImageWithPath(string fileName)
        {

            if (String.IsNullOrWhiteSpace(fileName))
                return false;

            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
