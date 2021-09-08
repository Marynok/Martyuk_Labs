﻿using DeliveryService.Interfaces;
using DeliveryServiceEF.Domain;
using DeliveryServiceWebApi.ViewModels;
using DeliveryServiceWebApi.ViewModels.ViewModelHelpers;
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
        private readonly FoodMapper _mapper;

        public FoodMvcController(IFoodService foodService, FoodMapper mapper)
        {
            _service = foodService;
            _mapper = mapper;
        }

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

        [HttpPost]
        public IActionResult Edit(FoodModel food)
        {
            if (!ModelState.IsValid)
                return View(food);

            return _service.UpdateFood(_mapper.Map(food)) is null ?
                View(food) : 
                RedirectToRoute(new { controller = "FoodMvc", action = "Index" }); 
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
