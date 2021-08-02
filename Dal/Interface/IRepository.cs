using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IRepository<T>
    {
        public  Task Add(T entity);
        public Task<T> Get(Expression<Func<T, bool>> filter);
        public Task<IEnumerable<T>> Get();
        public Task CommitAsync();

    }
}
