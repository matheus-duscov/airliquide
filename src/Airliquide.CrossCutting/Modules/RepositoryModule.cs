using Airliquide.Domain.Interfaces;
using Airliquide.Infrastructure.Repositories;
using Autofac;

namespace Airliquide.CrossCutting.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteRepository>()
                .As<IClienteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClienteUnitOfWork>()
                .As<IClienteUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
