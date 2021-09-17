using DeliveryService.Interfaces;
using DeliveryServiceEF.Data;
using DeliveryServiceEF.Data.DataWorkers;
using DeliveryServiceEF.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodService _service;

        public FoodController(ILogger<FoodController> logger, IFoodService foodService)
        {
            _logger = logger;
            _service = foodService;
        }

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public Food Get(int id)
        {
            return _service.SearchFood(id);
        }

        [HttpPost]
        public IActionResult Post(Food food)
        {
            var newFood = _service.CreateFood(food);
            if (newFood is null)
            {
                return BadRequest(); 
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Food food)
        {
           if(_service.UpdateFood(food) is null)
           {
                return BadRequest();
           }

           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteFood(id) )
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

