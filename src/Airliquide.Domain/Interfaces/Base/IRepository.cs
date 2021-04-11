using Airliquide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airliquide.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
