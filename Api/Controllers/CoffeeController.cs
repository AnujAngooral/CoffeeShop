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
    [Produces("application/json")]
    [ApiController]

    public class CoffeeController : Controller
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly ICoffeeService ICoffeeService;

        /// <summary>
        /// This method is used to inject the logger and coffeeservice
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="ICoffeeService"></param>
        public CoffeeController(ILogger<CoffeeController> logger, ICoffeeService ICoffeeService)
        {
            _logger = logger;
            this.ICoffeeService = ICoffeeService;
        }

        /// <summary>
        /// Add a coffee into the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /coffee
        ///     {
        ///        "type": "cinnamon-flavored iced coffee",
        ///        "tasty": true
        ///     }
        ///
        /// </remarks>
        /// 
        /// <param name="model">Coffee Model</param>
        /// <returns>A newly created Coffee</returns>
        /// <response code="201">Returns the newly created coffee</response>
        /// <response code="500">In case of any error</response> 
        [HttpPost]
        [Route("coffee")]
        [ProducesResponseType(typeof(Coffee), (int)System.Net.HttpStatusCode.Created)]
        public async Task<IActionResult> Add([FromBody] Coffee model)
        {
            var result = await ICoffeeService.AddAsync(model);
            if (result.IsSuccess)
                return CreatedAtRoute("get", new { id = result.Coffee.Id }, result.Coffee);
            return StatusCode(500);

        }

        /// <summary>
        /// Get a coffee by Id
        /// </summary>
       /// <returns>matched coffee object</returns>
        [HttpGet]
        [Route("coffee/{id}",Name ="get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await ICoffeeService.GetAsync(id);
            if (result.IsSuccess)
                return Ok(result.Coffee);
            return NotFound();

        }

        /// <summary>
        /// List of coffee's available in the system.
        /// </summary>
        /// <returns>List of all the coffee object in the database.</returns>
        [HttpGet]
        [Route("coffee")]
        public async Task<IActionResult> Get()
        {
            var result = await ICoffeeService.GetAsync();
            if (result.IsSuccess)
                return Ok(result.Coffees);
            return StatusCode(500);

        }
    }
}
