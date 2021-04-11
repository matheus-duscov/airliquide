using Airliquide.CrossCutting.Extensions.ServiceCollection;
using Airliquide.Infrastructure.Data.Contexts;
using AirLiquide.Resources.Constants;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airliquide.CrossCutting
{
    public class ApplicationStartup : IApplicationStartup
    {
        private readonly IConfiguration _configuration;

        public ApplicationStartup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                ExecuteMigrations(app);
            }

            app.UseSwagger();
            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint(url: SwaggerSettingsConstants.Endpoint, name: SwaggerSettingsConstants.Title);
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureModules(_configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAirliquideApiSwaggerGen();
            services.AddAirliquideClienteDbContext(_configuration);
            services.AddAutomapperConfiguration();
        }

        protected virtual void ExecuteMigrations(IApplicationBuilder app)
        {
            using (var dbContext = app.ApplicationServices.GetService<AirliquideClienteDbContext>())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
