﻿using DeliveryService.Interfaces;
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
        private readonly ILogger<foodService> _logger;
        private readonly IFoodTypeService _service;

        public FoodTypeController(ILogger<foodService> logger, IFoodTypeService foodTypeService)
        {
            _logger = logger;
            _service = foodTypeService;
        }

        [HttpGet]
        public IEnumerable<FoodType> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public FoodType Get(int id)
        {
            return _service.SearchFoodType(id);
        }

        [HttpPost]
        public ActionResult<FoodType> Post(FoodType foodType)
        {
            var newFoodType = _service.CreateFoodType(foodType);
            if (newFoodType is null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult<FoodType> Put(FoodType foodType)
        {
            if (_service.UpdateFoodType(foodType) is null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<FoodType> Delete(int id)
        {
            if (!_service.DeleteFoodType(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
