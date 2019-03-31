using System.Net;
using ApiStructure.Extensions;
using ApiStructure.Models;
using ApiStructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using ApiStructure.Middlewares;

namespace ApiStructure
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var environment = serviceProvider.GetService<IHostingEnvironment>();

            services.Configure<AppSettingsModel>(configuration)
                    .AddTransient<IMiServicioTrasient, MiServicioTrasient>()
                    .AddScoped<IMiServicioScoped, MiServicioScoped>()
                    .AddSingleton<IMiServicioSingleton, MiServicioSingleton>()
                    .AddScoped<ILanguageService, LanguageService>()
                    .AddIfElse(
                        environment.IsDevelopment(), 
                        servicesCollection => servicesCollection.AddTransient<IServiceEnvironment, MiServicioEnDev>(),
                        servicesCollection => servicesCollection.AddTransient<IServiceEnvironment, MiServicioEnProd>());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            app.UseMiddleware<LanguageMiddleware>()
               .MapWhen(context => !context.Request.Path.StartsWithSegments("/api"),
                        appBuilder =>
                        {
                            appBuilder.Run(async (context) => context.Response.StatusCode = (int)HttpStatusCode.NotFound);
                        })
               .Run(async (context) =>
               {
                   logger.LogWarning("Siempre se hace la misma llamada");

                   var miServicioScopedFirstCreated = context.RequestServices.GetService(typeof(IMiServicioScoped)) as IMiServicioScoped;
                   var miServicioSingletonFirstCreated = context.RequestServices.GetService(typeof(IMiServicioSingleton)) as IMiServicioSingleton;
                   var miServicioTrasientFirstCreated = context.RequestServices.GetService(typeof(IMiServicioTrasient)) as IMiServicioTrasient;

                   await Task.Delay(2000);

                   var miServicioScoped = context.RequestServices.GetService(typeof(IMiServicioScoped)) as IMiServicioScoped;
                   var miServicioSingleton = context.RequestServices.GetService(typeof(IMiServicioSingleton)) as IMiServicioSingleton;
                   var miServicioTrasient = context.RequestServices.GetService(typeof(IMiServicioTrasient)) as IMiServicioTrasient;
                   var miServicioEnvironment = context.RequestServices.GetService(typeof(IServiceEnvironment)) as IServiceEnvironment;
                   var languageService = context.RequestServices.GetService(typeof(ILanguageService)) as ILanguageService;
                   var configuration = context.RequestServices.GetService(typeof(IOptionsSnapshot<AppSettingsModel>)) as IOptionsSnapshot<AppSettingsModel>;

                   var language = languageService.GetLanguage();

                   await context.Response.WriteAsync(
                       $"Api Request: {miServicioSingleton.GetApiCreateDateTime()}. Date Request: {miServicioScoped.GetRequestDate()}. Date service:{miServicioTrasient.GetNewServiceDate()}.\n" +
                       $"Hello { configuration.Value.ProjectSettings.ProjectName }!\n" +
                       $"Hello environment { miServicioEnvironment.GetEnvironment() }!\n" +
                       $"{ (!string.IsNullOrEmpty(language) ? $"Hello lang {language}!" : "No hay lenguaje") }");
               }
            );
        }
    }
}
