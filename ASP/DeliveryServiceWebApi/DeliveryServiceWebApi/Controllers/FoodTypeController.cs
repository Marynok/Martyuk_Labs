using DeliveryService.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DeliveryServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodTypeController _controller;

        public FoodTypeController(ILogger<FoodController> logger, IFoodTypeController foodController)
        {
            _logger = logger;
            _controller = foodController;
        }

        [HttpGet]
        public IEnumerable<FoodType> Get()
        {
            return _controller.Get();
        }

        [HttpGet("{id}")]
        public FoodType Get(int id)
        {
            return _controller.SearchFoodType(id);
        }

        [HttpPost]
        public ActionResult<FoodType> Post(FoodType foodType)
        {
            var newFoodType = _controller.CreateFoodType(foodType);
            if (newFoodType is null)
            {
                return BadRequest();
            }

            return Ok(newFoodType);
        }

        [HttpPut]
        public ActionResult<FoodType> Put(FoodType foodType)
        {
            if (_controller.UpdateFoodType(foodType) is null)
            {
                return BadRequest();
            }

            return Ok(foodType);
        }

        [HttpDelete("{id}")]
        public ActionResult<FoodType> Delete(int id)
        {
            if (!_controller.DeleteFoodType(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
