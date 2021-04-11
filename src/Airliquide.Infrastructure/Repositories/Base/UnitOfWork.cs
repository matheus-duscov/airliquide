using Airliquide.Domain.Entities;
using Airliquide.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Airliquide.Infrastructure.Repositories.Base
{
    public class UnitOfWork<T, E> : IUnitOfWork<T>
        where T : EntityBase
        where E : DbContext
    {
        private readonly ILogger<IUnitOfWork<T>> _logger;
        protected readonly E _context;

        public UnitOfWork(ILogger<IUnitOfWork<T>> logger, E context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _logger.LogInformation("Starting new transaction for session key {0}.", this.GetHashCode());

            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            _logger.LogInformation("Commiting a transaction for session key {0}.", this.GetHashCode());

            await _context.Database.CurrentTransaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            _logger.LogInformation("Rolling back a transaction for session key {0}.", this.GetHashCode());

            await _context.Database.CurrentTransaction.RollbackAsync();
        }

        public async ValueTask DisposeAsync()
        {
            _logger.LogInformation("Disposing a transaction for session key {0}.", this.GetHashCode());

            if (_context.Database?.CurrentTransaction?.TransactionId != null)
            {
                await _context.Database.CurrentTransaction.DisposeAsync();
            }

            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing a transaction for session key {0}.", this.GetHashCode());

            if (_context.Database?.CurrentTransaction?.TransactionId != null)
            {
                _context.Database.CurrentTransaction.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
