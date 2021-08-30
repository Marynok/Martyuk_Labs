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
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IManufacturerController _controller;

        public ManufacturerController(ILogger<ManufacturerController> logger, IManufacturerController manufacturerController)
        {
            _logger = logger;
            _controller = manufacturerController;
        }

        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            return _controller.GetAll();
        }

        [HttpGet("{id}")]
        public Manufacturer Get(int id)
        {
            return _controller.SearchManufacturer(id);
        }

        [HttpPost]
        public ActionResult<Manufacturer> Post(Manufacturer manufacturer)
        {
            var newManufacturer = _controller.CreateManufacturer(manufacturer);
            if (newManufacturer is null)
            {
                return BadRequest();
            }

            return Ok(newManufacturer);
        }

        [HttpPut]
        public ActionResult<Manufacturer> Put(Manufacturer manufacturer)
        {
            if (_controller.UpdateManufacturer(manufacturer) is null)
            {
                return BadRequest();
            }

            return Ok(manufacturer);
        }

        [HttpDelete("{id}")]
        public ActionResult<Manufacturer> Delete(int id)
        {
            if (!_controller.DeleteManufacturer(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
