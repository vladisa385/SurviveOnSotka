using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.RateReviews;

namespace SurviveOnSotka.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                //log
                var errorDetails = new ErrorDetails(exception);
                await HandleExceptionAsync(httpContext,errorDetails);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context,ErrorDetails errorDetails)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorDetails.StatusCode;
            return context.Response.WriteAsync(errorDetails.ToString());
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
