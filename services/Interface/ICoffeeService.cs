using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace services.Interface
{
    public interface ICoffeeService
    {
        public Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> AddAsync(ViewModels.Coffee coffee);

        public Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> GetAsync(int Id);
        public Task<(bool IsSuccess, IEnumerable<Coffee> Coffees, string ErrorMessage)> GetAsync();
    }
}
