using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace MyPhoneBook.Middleware
{
    public class StatusCodePagesMiddleware
    {
        private RequestDelegate _next;
        private StatusCodePagesOptions _options;

        public StatusCodePagesMiddleware(RequestDelegate next,
         IOptions<StatusCodePagesOptions> options)
        {
            _next = next;
            _options = options.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            var response = context.Response;
            if ((response.StatusCode >= 400 && response.StatusCode <= 599) && !response.ContentLength.HasValue && string.IsNullOrEmpty(response.ContentType))
            {               
               
                await _options.HandleAsync(new StatusCodeContext(context, _options, _next));
            }
           

        }
    }
}

