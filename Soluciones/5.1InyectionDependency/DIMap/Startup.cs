using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMap.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DIMap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMiServicio, MiServicio>();
            services.AddTransient<IMiServicioWithScopedInjection, MiServicioWithScopedInjection>();
            services.AddTransient<IMiServicioWithSingletonInjection, MiServicioWithSingletonInjection>();

            services.AddTransient<IRandomNumberService, RandomNumberService>();
            services.AddScoped<IRandomNumberServiceScoped, RandomNumberService>();
            services.AddSingleton<IRandomNumberServiceSingleton, RandomNumberService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/equals", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var fakeService = context.RequestServices.GetService(typeof(IMiServicioWithSingletonInjection)) as IMiServicioWithSingletonInjection;
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceSingleton)) as IRandomNumberServiceSingleton;
                        await context.Response.WriteAsync($"RandomNumber: {randomService.GetRandomNumber()}. MiServicio: {fakeService.GetRandomNumber()}");
                    });
                })
                .Map("/diferent", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var fakeService = context.RequestServices.GetService(typeof(IMiServicio)) as IMiServicio;
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberService)) as IRandomNumberService;
                        await context.Response.WriteAsync($"RandomNumber: {randomService.GetRandomNumber()}. MiServicio: {fakeService.GetRandomNumber()}");
                    });
                })
                .Run(async (context) =>
                {
                    var fakeService = context.RequestServices.GetService(typeof(IMiServicioWithScopedInjection)) as IMiServicioWithScopedInjection;
                    var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceScoped)) as IRandomNumberServiceScoped;
                    await context.Response.WriteAsync($"RandomNumber: {randomService.GetRandomNumber()}. MiServicio: {fakeService.GetRandomNumber()}");
                });
        }
    }
}
