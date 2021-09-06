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
        private readonly IFoodController _controller;

        public FoodController(ILogger<FoodController> logger, IFoodController foodController)
        {
            _logger = logger;
            _controller = foodController;
        }

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _controller.Get();
        }

        [HttpGet("{id}")]
        public Food Get(int id)
        {
            return _controller.SearchFood(id);
        }

        

        [HttpPost]
        public ActionResult<Food> Post(Food food)
        {
            var newFood = _controller.CreateFood(food);
            if (newFood is null)
            {
                return BadRequest(); 
            }

            return Ok(newFood);
        }

        [HttpPut]
        public ActionResult<Food> Put(Food food)
        {
           if(_controller.UpdateFood(food) is null)
           {
                return BadRequest();
           }

           return Ok(food);
        }

        [HttpDelete("{id}")]
        public ActionResult<Food> Delete(int id)
        {
            if (! _controller.DeleteFood(id) )
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

