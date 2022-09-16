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
            var works = Path.Combine(root, "User");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(works))
            {
                Directory.CreateDirectory(works);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(root),
                RequestPath = "/Images"
            });
        }
    }
}
