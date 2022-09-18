using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Helpers.ImageManager
{
    public static class ImageManager
    {
        public static string CopyImage(IFormFile imageFile, string folderName)
        {
            try
            {
                if (imageFile is null)
                {
                    throw new Exception("Bad image");
                }
                string FileName = Guid.NewGuid().ToString();
                string FileExt = ".png";
                if (imageFile.Length != 0)
                {
                    FileExt = Path.GetExtension(imageFile.FileName);
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    string fullPath = Path.Combine(pathToSave, FileName + FileExt);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                }
                return FileName + FileExt;
            }
            catch (BadHandler ex)
            {
                throw ex;
            }
            return null;
        }
        public static void RemoveImage(string imageName, string folderName)
        {
            try
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string fullPath = Path.Combine(pathToSave, imageName);
                File.Delete(fullPath);
            }
            catch (BadHandler ex)
            {
                throw ex;
            }
        }
    }
}
