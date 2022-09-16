using DoloniToys.Domain.Identity;
using DoloniToys.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seeding(this IApplicationBuilder app)
        {
            using (var scope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    Init(scope);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void Init(IServiceScope scope)
        {
            try
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                if (!userManager.Users.Any())
                {

                    var user = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "UserName",
                        Name = "Name",
                        Surname = "Surname",
                        Fax = "",
                        Company = "",
                        Address = "Address",
                        City = "City",
                        Country = "Country",
                        Region = "Region",
                        EmailConfirmed = true,
                        Email = "user@gmail.com",
                        PhoneNumber = "1234567890",
                    };
                    var result = userManager.CreateAsync(user, "qweqwe123123").Result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
