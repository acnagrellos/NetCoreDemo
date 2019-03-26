using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Primitives;

namespace AppSettings.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
        }
        public async Task Invoke(HttpContext context, IUserService userService)
        {
            if (context.Request.Headers.ContainsKey("username"))
            {
                var value = context.Request.Headers.TryGetValue("username", out StringValues stringValue);
                userService.SetUserName(stringValue);
            }

            await _next.Invoke(context);
            this._logger.LogDebug("after");
        }
    }
}
