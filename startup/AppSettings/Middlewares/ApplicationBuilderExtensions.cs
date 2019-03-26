using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace AppSettings.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder build)
        {
            build.UseMiddleware<CustomMiddleware>();
            return build;
        }
    }
}
