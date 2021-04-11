using Airliquide.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Airliquide.Domain.Interfaces.Base
{
    public interface IUnitOfWork<T> : IDisposable, IAsyncDisposable where T : EntityBase
    {
        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
