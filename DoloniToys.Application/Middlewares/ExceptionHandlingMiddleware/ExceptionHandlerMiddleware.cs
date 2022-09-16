using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var code = HttpStatusCode.OK;

            httpContext.Response.StatusCode = (int)code;
            httpContext.Response.ContentType = "application/json";

            switch (ex)
            {
                case NotFoundHandler:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnAuthorityHandler:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case BadHandler:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            var response = new ExceptionHandlerResponse()
            {
                StatusCode = (int)code,
                Message = ex.Message,
            };

            return httpContext.Response.WriteAsync(response.ToString());
        }
    }
}
