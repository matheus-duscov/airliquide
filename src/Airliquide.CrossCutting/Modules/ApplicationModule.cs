using Airliquide.Application.Services;
using Airliquide.Contracts.Interfaces;
using Autofac;

namespace Airliquide.CrossCutting.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteService>()
                .As<IClienteService>()
                .InstancePerLifetimeScope();
        }
    }
}
