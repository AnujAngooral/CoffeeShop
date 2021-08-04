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
        /// <summary>
        /// Injected logger, automapper and coffeerepository.
        /// </summary>
        /// <param name="coffeeRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CoffeeService(ICoffeeRepository coffeeRepository, IMapper mapper, ILogger<CoffeeService> logger)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// This method id used to conver the viewmodel to dto and send it to database layer to insert into db,in-memory
        /// </summary>
        /// <param name="coffee"> View Model Coffee object</param>
        /// <returns> IsSuccess: true in case of success else false. Return created coffee object with newly created id. ErrorMessage in case of any exception.</returns>
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

        /// <summary>
        /// Get a coffee data from database based on id.
        /// </summary>
        /// <param name="Id">coffee id</param>
        /// <returns>IsSuccess: true in case of success else false. Return coffee object based on id. ErrorMessage in case of any exception.</returns>
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

        /// <summary>
        /// Return all the coffee's available in the database.
        /// </summary>
        /// <returns>IsSuccess: true in case of success else false. Return coffee's available in the database. ErrorMessage in case of any exception.</returns>
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
