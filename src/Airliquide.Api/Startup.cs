using Airliquide.CrossCutting;
using Airliquide.CrossCutting.Extensions.ExceptionHandling;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airliquide
{
    public class Startup
    {
        private readonly IApplicationStartup _startup;

        public Startup(IConfiguration configuration, IApplicationStartup startup)
        {
            Configuration = configuration;
            _startup = startup;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(opt => opt.LowercaseUrls = true);

            services.AddMvc();

            services.AddCors(x => x.AddPolicy("CustomCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            _startup.ConfigureServices(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            _startup.ConfigureContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CustomCorsPolicy");

            if (env.IsDevelopment()) // Usar para exibir stacktrace das exceções
            {
                app.UseDeveloperExceptionPage();
            }
            else // Usar para exibir mensagem custom das exceções
            {
                app.UseExceptionHandlingMiddlewares(env);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            _startup.Configure(app, env);
        }
    }
}
