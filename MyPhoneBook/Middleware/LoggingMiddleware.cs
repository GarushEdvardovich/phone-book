using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using log4net;

namespace MyPhoneBook
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<LoggingMiddleware>();

            try
            {
                _logger.LogInformation($"Request: {context.Request.Path}");

               await _next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
            }
        }
    }
}
