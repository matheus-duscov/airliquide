using Airliquide.CrossCutting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airliquide
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s =>
                {
                    s.AddScoped<IApplicationStartup, ApplicationStartup>();
                    s.AddAutofac();
                })
                .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args) => CreateWebHostBuilder(args).Build();
    }
}
