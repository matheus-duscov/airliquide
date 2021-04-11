using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airliquide.CrossCutting
{
    public interface IApplicationStartup
    {
        void ConfigureServices(IServiceCollection services);

        void ConfigureContainer(ContainerBuilder builder);

        void Configure(IApplicationBuilder app, IHostEnvironment env);
    }
}
