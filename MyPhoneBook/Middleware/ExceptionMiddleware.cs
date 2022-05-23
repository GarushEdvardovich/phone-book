using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using log4net;

namespace MyPhoneBook
{

    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
                        var ex = contextFeature?.Error;

                        var isDev = false; env.IsDevelopment();
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(
                            new ProblemDetails
                            {

                                Type = ex.GetType().Name,
                                Status = (int)HttpStatusCode.InternalServerError,
                                Instance = contextFeature?.Path,
                                Title = isDev ? $"{ex.Message}" : " ",
                                Detail = isDev ? ex.StackTrace : null

                                //Title = $"{ex.Message}",
                                //Detail = ex.StackTrace
                            }));
                    }
                });
            });
        }
    }

}
