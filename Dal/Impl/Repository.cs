using Dal.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal CoffeeDbContext dbContext;
        internal DbSet<T> dbSet;

        public Repository(CoffeeDbContext context)
        {
            this.dbContext = context;
            this.dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbContext.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.FirstAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
