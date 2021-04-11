using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airliquide.Contracts.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();

        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T model);

        Task UpdateAsync(T model);

        Task RemoveAsync(Guid id);
    }
}
