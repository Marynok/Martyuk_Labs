using DeliveryService.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ControllersMVC
{
    public class FoodMvcController : Controller
    {
        private readonly IFoodService _service;

        public FoodMvcController(IFoodService foodService)
        {
            _service = foodService;
        }

        public IActionResult Index()
        {
            return View(_service.Get());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_service.SearchFood(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_service.SearchFood(id));
        }

        [HttpPost]
        public IActionResult Edit(Food food)
        {
            if (!ModelState.IsValid)
                return View(food);

            return _service.UpdateFood(food) is null ?
                View(food) : 
                RedirectToRoute(new { controller = "FoodMvc", action = "Index" }); 
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            if (!ModelState.IsValid)
                return View(food);

            return _service.CreateFood(food) is null ?
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

