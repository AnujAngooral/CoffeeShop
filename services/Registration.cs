using AutoMapper;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using services.Impl;
using services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace services
{
    public static class Registration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddDbContext<CoffeeDbContext>(opt =>
                                                 opt.UseInMemoryDatabase("CoffeeShop"));
            Register.ConfigureServices(services);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ViewModels.Coffee, Dal.Models.Coffee>();
            CreateMap<Dal.Models.Coffee, ViewModels.Coffee>();
         

        }
    }
}
