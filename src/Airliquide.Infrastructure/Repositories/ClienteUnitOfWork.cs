using Airliquide.Domain.Entities;
using Airliquide.Domain.Interfaces;
using Airliquide.Domain.Interfaces.Base;
using Airliquide.Infrastructure.Data.Contexts;
using Airliquide.Infrastructure.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Airliquide.Infrastructure.Repositories
{
    public class ClienteUnitOfWork : UnitOfWork<Cliente, AirliquideClienteDbContext>, IClienteUnitOfWork
    {
        public ClienteUnitOfWork(ILogger<IUnitOfWork<Cliente>> logger, AirliquideClienteDbContext context) : base(logger, context)
        {
        }
    }
}
