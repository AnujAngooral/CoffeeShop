using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace services.Interface
{
    public interface ICoffeeService
    {
        public Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> Add(ViewModels.Coffee coffee);

        public Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> Get(int Id);
        public Task<(bool IsSuccess, IEnumerable<Coffee> Coffees, string ErrorMessage)> Get();
    }
}
