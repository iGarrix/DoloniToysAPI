using Microsoft.OpenApi.Models;

namespace DoloniToysApi.JwtConfiguration
{
    public static class JwtSwaggerAuthentificator
    {
        public static void useSwaggerGen(this WebApplicationBuilder builder, string assemblyName)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = assemblyName, Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
                var fileDoc = Path.Combine(System.AppContext.BaseDirectory, $"{assemblyName}.xml");
                c.IncludeXmlComments(fileDoc);
            });
        }
    }
}
