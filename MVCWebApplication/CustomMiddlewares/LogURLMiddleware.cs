using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MVCWebApplication.CustomMiddlewares
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _parameter;
        public LogURLMiddleware(RequestDelegate next, string parameter)
        {
            _next = next;
            _parameter = parameter;
        }

        public Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(_parameter + context.Request.Path);
            //Write code here to Save the URL in database or File
            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }

    }


    public static class LogURLMiddlewareExtension
    {
        public static IApplicationBuilder UseLogURL(this IApplicationBuilder app,string parameter="Request: ")
        {
            return app.UseMiddleware(typeof(LogURLMiddleware), parameter);
        }
    }
}
