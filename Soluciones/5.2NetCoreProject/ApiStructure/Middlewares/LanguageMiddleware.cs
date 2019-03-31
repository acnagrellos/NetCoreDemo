using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiStructure.Services;

namespace ApiStructure.Middlewares
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ILanguageService languageService)
        {
            if (context.Request.Headers.ContainsKey("x-language"))
            {
                var langHeader = context.Request.Headers.First(header => header.Key == "x-language");
                languageService.SetLanguage(langHeader.Value);
            }
            await _next.Invoke(context);
        }
    }
}
