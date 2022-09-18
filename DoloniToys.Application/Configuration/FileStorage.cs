using DoloniToys.Domain.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Configuration
{
    public static class FileStorage
    {
        public static void useFileStorage(this WebApplication app)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), "Images/");
            var category = Path.Combine(root, ImagePaths.Category);
            var product = Path.Combine(root, ImagePaths.Product);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(category))
            {
                Directory.CreateDirectory(category);
            }
            if (!Directory.Exists(product))
            {
                Directory.CreateDirectory(product);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(root),
                RequestPath = "/Images"
            });
        }
    }
}
