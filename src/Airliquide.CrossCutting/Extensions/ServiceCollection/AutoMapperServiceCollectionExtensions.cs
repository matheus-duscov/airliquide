using Airliquide.CrossCutting.MappingProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Airliquide.CrossCutting.Extensions.ServiceCollection
{
    public static class AutoMapperServiceCollectionExtensions
    {
        public static void AddAutomapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClienteMappingProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
