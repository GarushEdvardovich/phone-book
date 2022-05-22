//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;
//using MyPhoneBook.Bll.Models;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyPhoneBook.Bll.Services
//{
//    public static class ServiceExtensions
//    {
//        // public static void ConfigureIdentity(this IServiceCollection services);
//        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
//        {
//            app.UseExceptionHandler(error =>
//            {
//                error.Run(async context =>
//                {
//                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//                    context.Response.ContentType = "application/Json";
//                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//                    if (contextFeature != null)
//                    {
//                        Log.Error($"Lav ches ara {contextFeature.Error}");
//                        await context.Response.WriteAsync(new Error
//                        {
//                            StatusCode = context.Response.StatusCode,
//                            Message = "@nger lav ches haskanum"
//                        }.ToString());
//                    }
//                });
//            });
//        }
//    }
//}
