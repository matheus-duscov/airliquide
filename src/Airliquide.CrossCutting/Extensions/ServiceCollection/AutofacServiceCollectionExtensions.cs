using Airliquide.CrossCutting.Modules;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace Airliquide.CrossCutting.Extensions.ServiceCollection
{
    public static class AutofacServiceCollectionExtensions
    {
        public static void ConfigureModules(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<RepositoryModule>();
        }
    }
}
