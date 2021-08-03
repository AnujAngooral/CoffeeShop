using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Api.Controllers
{
    [ApiController]
   // [Route("api/[controller]")]
    public class CoffeeController : Controller
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly ICoffeeService ICoffeeService;

        public CoffeeController(ILogger<CoffeeController> logger, ICoffeeService ICoffeeService)
        {
            _logger = logger;
            this.ICoffeeService = ICoffeeService;
        }

        [HttpPost]
        [Route("api/coffee")]
        public async Task<IActionResult> Add(Coffee model)
        {
            var result = await ICoffeeService.AddAsync(model);
            if (result.IsSuccess)
                return Ok(result.Coffee);
            return StatusCode(500);

        }

        [HttpGet]
        [Route("api/coffee/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await ICoffeeService.GetAsync(id);
            if (result.IsSuccess)
                return Ok(result.Coffee);
            return NotFound();

        }

        [HttpGet]
        [Route("api/coffee")]
        public async Task<IActionResult> Get()
        {
            var result = await ICoffeeService.GetAsync();
            if (result.IsSuccess)
                return Ok(result.Coffees);
            return NotFound();

        }
    }
}
