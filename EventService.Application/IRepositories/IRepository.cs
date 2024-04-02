using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.IRepositories
{
    public interface IRepository<T>
    {
        Task<T?> GetAsync<TKey>(TKey id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        
        Task<bool> PostAsync(T entity);
        Task<T?> PutAsync<TKey>(TKey id, T entity);
        Task<bool> RemoveAsync<TKey>(TKey id);
    }
}
