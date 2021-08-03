using AutoMapper;
using Dal.Impl;
using Dal.Interface;
using Microsoft.Extensions.Logging;
using services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace services.Impl
{
    public class CoffeeService : ICoffeeService
    {
        readonly ICoffeeRepository _coffeeRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<CoffeeService> _logger;
        public CoffeeService(ICoffeeRepository coffeeRepository, IMapper mapper, ILogger<CoffeeService> logger)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> AddAsync(ViewModels.Coffee coffee)
        {
            try
            {
                var coffeeDTO = _mapper.Map<Dal.Models.Coffee>(coffee);
                await _coffeeRepository.AddAsync(coffeeDTO);
                await _coffeeRepository.CommitAsync();
                coffee.Id = coffeeDTO.Id;

                return (true, coffee, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }

        }

        public async Task<(bool IsSuccess, Coffee Coffee, string ErrorMessage)> GetAsync(int Id)
        {
            try
            {
                return (true, _mapper.Map<ViewModels.Coffee>(await _coffeeRepository.GetAsync(x => x.Id == Id)), null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Coffee> Coffees,string ErrorMessage)> GetAsync()
        {
            try
            {
                return (true, _mapper.Map<IEnumerable<Coffee>>(await _coffeeRepository.GetAsync()), null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }
    }
}
