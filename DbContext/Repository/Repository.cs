using DbContext.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DbContext.Repository
{
    public class Repository<T>(AppDbContext db) : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db = db;
        internal DbSet<T> dbSet = db.Set<T>();

        public void Add(T entity) => dbSet.Add(entity);

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null,
            string? includeProp = null, bool isTraking = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);


            if (includeProp != null)
            {
                foreach (var IncPr in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncPr);
                }
            }

            if (!isTraking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProp = null, bool isTraking = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);


            if (includeProp != null)
            {
                foreach (var IncPr in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncPr);
                }
            }

            if (orderBy != null)
                query = orderBy(query);

            if (!isTraking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public void Remove(T entity) => dbSet.Remove(entity);


        public void Save() => _db.SaveChanges();
    }
}
