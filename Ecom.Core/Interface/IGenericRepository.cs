using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync( params Expression<Func<T, object>>[]includes);
        Task<T> GetbyIdAsync(int id);
        Task<T> GetbyIdAsync(int id, params Expression<Func<T, object>>[] includes);


        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeletAsync(int id);

    }
}
