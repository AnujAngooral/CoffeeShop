using Dal.Impl;
using Dal.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public static class Register
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        }
    }
}
