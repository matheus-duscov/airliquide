using Airliquide.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airliquide.Contracts.Interfaces
{
    public interface IClienteService : IServiceBase<ClienteDto>
    {
        Task<IEnumerable<ClienteDto>> ListAsync(Guid? id);
    }
}
