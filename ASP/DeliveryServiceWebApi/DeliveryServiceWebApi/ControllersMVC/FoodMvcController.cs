using DeliveryService.Interfaces;
using DeliveryServiceEF.Domain;
using DeliveryServiceWebApi.Filters;
using DeliveryServiceWebApi.ViewModels;
using DeliveryServiceWebApi.ViewModels.ViewModelHelpers;
using DeliveryServiceWebApi.ViewModels.ViewModelHelpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ControllersMVC
{
    [ServiceFilter(typeof(FoodExceptionFilter))]
    public class FoodMvcController : Controller
    {
        private readonly IFoodService _service;
        private readonly IFoodMapper _mapper;
        private readonly ILogger<FoodMvcController> _logger;

        public FoodMvcController(ILogger<FoodMvcController> logger,IFoodService foodService, IFoodMapper mapper)
        {
            _logger = logger;
            _service = foodService;
            _mapper = mapper;
        }

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 120)]
        public IActionResult Index()
        {
            return View(_service.Get().Select(food => _mapper.Map(food)));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map(_service.SearchFood(id)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_mapper.Map(_service.SearchFood(id)));
        }

        [HttpGet]
        public IActionResult DeleteView(int id)
        {
            return View("Delete",_mapper.Map(_service.SearchFood(id)));
        }

        [HttpPost]
        [ActionFilter]
        public IActionResult Edit(FoodModel food)
        {
            if (!ModelState.IsValid)
                return View(food);

            return _service.UpdateFood(_mapper.Map(food)) is null ?
                View(food) : 
                RedirectToRoute(new { controller = "FoodMvc", action = "Edit" , id = food.Id}); 
        }

        [HttpPost]
        public IActionResult Create(FoodModel food)
        {
            if (!ModelState.IsValid)
                return View(food);
          
            return _service.CreateFood(_mapper.Map(food)) is null ?
                View(food) :
                RedirectToRoute(new { controller = "FoodMvc", action = "Index" }); 
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteFood(id))
            {
                BadRequest();
            }

            return RedirectToRoute(new { controller = "FoodMvc", action = "Index" });
        }
    }
}

