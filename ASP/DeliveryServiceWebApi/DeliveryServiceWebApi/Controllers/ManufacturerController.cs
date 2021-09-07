using DeliveryService.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class manufacturerService : ControllerBase
    {
        private readonly ILogger<manufacturerService> _logger;
        private readonly IManufacturerService _service;

        public manufacturerService(ILogger<manufacturerService> logger, IManufacturerService manufacturerService)
        {
            _logger = logger;
            _service = manufacturerService;
        }

        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public Manufacturer Get(int id)
        {
            return _service.SearchManufacturer(id);
        }

        [HttpPost]
        public ActionResult<Manufacturer> Post(Manufacturer manufacturer)
        {
            var newManufacturer = _service.CreateManufacturer(manufacturer);
            if (newManufacturer is null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult<Manufacturer> Put(Manufacturer manufacturer)
        {
            if (_service.UpdateManufacturer(manufacturer) is null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Manufacturer> Delete(int id)
        {
            if (!_service.DeleteManufacturer(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
