using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSettings.Configuration;
using AppSettings.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AppSettings
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettingsConfiguration>(Configuration);
            services.AddScoped<IUserService, UserSevice>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
                {
                    logger.LogInformation("Middleware executed");

                    await next.Invoke();

                    logger.LogInformation("Middleware end");
                })
                .UseCustomMiddleware()
                .Run(async (context) =>
                {
                    logger.LogWarning("Siempre es la misma llamada");
                    var config = context.RequestServices.GetService(typeof(IOptionsSnapshot<AppSettingsConfiguration>)) as IOptionsSnapshot<AppSettingsConfiguration>;
                    var userservice = context.RequestServices.GetService(typeof(IUserService)) as IUserService;
                    var username = userservice.GetUserName();
                    await context.Response.WriteAsync($"Hello {username}!");
                });
        }
    }
}
