using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploConfiguracion.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace EjemploConfiguracion
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMiServicio, MiServicio>();
            services.AddScoped<IRandomService, RandomService>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var miservicio = context.RequestServices.GetService(typeof(IMiServicio)) as MiServicio;
                var randomService = context.RequestServices.GetService(typeof(IRandomService)) as IRandomService;
                await context.Response.WriteAsync(
                    $"Hello {miservicio.GetRandomNumber()}! " +
                    $"RandomService: {randomService.GetRandomNumber()}");
            });
        }
    }
}
