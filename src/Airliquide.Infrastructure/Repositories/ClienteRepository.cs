using Airliquide.Domain.Entities;
using Airliquide.Domain.Interfaces;
using Airliquide.Domain.Interfaces.Base;
using Airliquide.Infrastructure.Data.Contexts;
using Airliquide.Infrastructure.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Airliquide.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente, AirliquideClienteDbContext>, IClienteRepository
    {
        public ClienteRepository(ILogger<IRepository<Cliente>> logger, AirliquideClienteDbContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
