using Airliquide.Infrastructure.Data.Contexts;
using AirLiquide.Resources.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airliquide.CrossCutting.Extensions.ServiceCollection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static void AddAirliquideClienteDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AirliquideClienteDbContext>(cfg =>
            {
                cfg.UseSqlServer(
                    configuration.GetConnectionString(ApplicationSettingsConstants.ConnectionString)
                );
            });
        }
    }
}
