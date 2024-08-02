using System.Linq.Expressions;

namespace DbContext.Repository.IRepository
{
    internal interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
                Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>,
                IOrderedQueryable<T>>? orderBy = null,
                string? includeProp = null,
                bool isTraking = true
            );
        Task<T?> FirstOrDefaultAsync(
                Expression<Func<T, bool>>? filter = null,
                string? includeProp = null,
                bool isTraking = true
            );
        void Add(T entity);
        void Remove(T entity);
        void Save();
    }
}
