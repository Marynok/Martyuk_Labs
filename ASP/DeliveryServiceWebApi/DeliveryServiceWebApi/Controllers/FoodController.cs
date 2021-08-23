using DeliveryService.Interfaces;
using DeliveryServiceEF.Data;
using DeliveryServiceEF.Data.DataWorkers;
using DeliveryServiceEF.Domain;
using BL = DeliveryService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DeliveryServiceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodController _controller;

        public FoodController(ILogger<FoodController> logger, DataContext context)
        {
            _logger = logger;
            _controller = new BL.FoodController(new UnitOfWork(context));
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
        // GET Food
        // GET Food/{id}
        // POST Food
        // PUT Food
        // DELETE Food/{id}
    }
}
