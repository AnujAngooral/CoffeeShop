using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Interface
{
   public interface ICoffeeRepository:IRepository<Coffee>, IDisposable
    {
    }
}
