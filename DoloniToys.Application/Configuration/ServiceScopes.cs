using DoloniToys.Application.Helpers.JwtAuth;
using DoloniToys.Application.Services.Common;
using DoloniToys.Application.Services.Identity;
using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Interfaces.Repositories;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Infrastructure.Repositories;
using DoloniToys.Infrastructure.Repositories.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Configuration
{
    public static class ServiceScopes
    {
        public static void useScopeServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IJwtAuthentificator, JwtAuthentificator>();

            #region Repository Scopes

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            #endregion

            #region Service Scopes

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            #endregion

        }
    }
}
