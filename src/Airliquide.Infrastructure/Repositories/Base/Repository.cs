using Airliquide.Domain.Entities;
using Airliquide.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airliquide.Infrastructure.Repositories.Base
{
    public class Repository<T, E> : IRepository<T>
        where T : EntityBase
        where E : DbContext
    {
        protected readonly ILogger<IRepository<T>> _logger;
        protected readonly E _dbContext;

        public Repository(
            ILogger<IRepository<T>> logger,
            E dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                await _dbContext.AddAsync<T>(entity);

                _logger.LogInformation("Entity type {0} was persisted successfully.", typeof(T));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error trying to persist entity type {0}: {1}", typeof(T), ex.Message);

                _logger.LogError(message);

                throw;
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            try
            {
                await Task.Run(() => _dbContext.Remove<T>(entity));

                _logger.LogInformation("Entity type {0} was removed successfully.", typeof(T));
            }
            catch (Exception ex)
            {
                var message = string.Format("Error trying to remove entity type {0}: {1}", typeof(T), ex.Message);

                _logger.LogError(message);

                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Getting entity of type {0} using id {1}.", typeof(T), id);

                var query = await _dbContext.FindAsync<T>(id);

                if (query == null)
                    _logger.LogInformation("Entity type {0} is not found using id {1}.", typeof(T), id);

                return query;
            }
            catch (Exception ex)
            {
                var message = string.Format("Error getting entity type {0}, using id {1}: {2}", typeof(T), id, ex.Message);

                _logger.LogError(message);

                throw;
            }
        }

        public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Getting an entity of type {0} based on predicate.", typeof(T));

                var query = await _dbContext.Set<T>()
                                    .Where(predicate)
                                    .ToListAsync();

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                var message = string.Format("Error getting list of entity type {0}: {1}", typeof(T), ex.Message);

                _logger.LogError(message);

                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            try
            {
                _logger.LogInformation("Listing all entities of type {0}.", typeof(T));

                return await _dbContext.Set<T>().AsQueryable<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                var message = string.Format("Error getting list of entity type {0}: {1}", typeof(T), ex.Message);

                _logger.LogError(message);

                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Listing all entities of type {0} based on predicate.", typeof(T));

                return await _dbContext.Set<T>()
                                .AsQueryable<T>()
                                .Where(predicate)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = string.Format("Error getting list of entity type {0}: {1}", typeof(T), ex.Message);
                _logger.LogError(message);

                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Updating an entity of type {0} with id {1}.", typeof(T), entity.Id);

                await Task.Run(() => _dbContext.Set<T>().Update(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to update an entity type {0} with id {1}: {2}", typeof(T), entity.Id, ex.Message);

                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                _logger.LogInformation("Saving changes on dbcontext synchronously for entity type {0}.", typeof(T));

                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to save changes on dbcontext synchronously for entity type {0}: {1}", typeof(T), ex.Message);

                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes on dbcontext asynchronously for entity type {0}.", typeof(T));

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error trying to save changes on dbcontext asynchronously for entity type {0}: {1}", typeof(T), ex.Message);

                throw;
            }
        }
    }
}
