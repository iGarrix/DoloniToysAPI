using DoloniToys.Application.Configuration;
using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware;
using DoloniToys.Infrastructure.Data;
using DoloniToysApi.JwtConfiguration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

SymmetricSecurityKey signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<String>("JwtKey")));

#region Configuration
builder.useIdentity();
builder.useAuthentication(signinKey);
builder.useScopeServices();
#endregion

string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
builder.Services.AddEndpointsApiExplorer();
builder.useSwaggerGen(assemblyName);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(option => option.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.useFileStorage();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Seeding();

app.Run();
