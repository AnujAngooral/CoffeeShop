using Dal.Interface;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Impl
{
    public class CoffeeRepository : Repository<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeDbContext context) : base(context) { }
        public void Dispose()
        {
          //  throw new NotImplementedException();
        }
    }
}
