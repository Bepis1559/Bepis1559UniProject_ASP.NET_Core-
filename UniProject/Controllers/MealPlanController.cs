﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;
using Microsoft.AspNetCore.Identity;

namespace UniProject.Controllers
{
    public class MealPlanController : Controller
    {
        private readonly MealPlansService _mealPlansService;
        private readonly UserManager<User> UserManager;
        private readonly ILogger<MealController> _logger;
        public MealPlanController(UserManager<User> userManager,MealPlansService mealPlansService, ILogger<MealController> logger)
        {
            _mealPlansService = mealPlansService;
            UserManager = userManager;
            _logger = logger;
        }

       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var MealPlans = await _mealPlansService.GetAllAsync();
            return View("Index", MealPlans);
        }

        [HttpPost]
        public async Task<IActionResult> AddMealPlan(MealPlan mealPlan)
        {
           

            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(User);
                if(user != null)
                {
                    mealPlan.UserId = user.Id;
                    await _mealPlansService.CreateAsync(mealPlan);
                    var allMealPlans = await _mealPlansService.GetAllAsync();
                    return View("Index", allMealPlans);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealPlanById(string id)
        {
            
                await _mealPlansService.DeleteByIdAsync(id);
                return View("Index");
            
            

        }

        [HttpGet]
        public async Task<JsonResult> GetMealPlans()
        {
            // Retrieve a list of MealPlans from the database
            var mealPlans = await _mealPlansService.GetAllAsync();

            // Return the list of MealPlans as JSON
            return Json(mealPlans);
        }


        [HttpGet]

        public async Task<JsonResult> GetMealPlanById(string id)
        {

            var result = await _mealPlansService.GetByIdAsync(id);
            return Json(result);

        }

        [HttpGet]

        public async Task<JsonResult> GetMealPlanByName(string name)
        {

            var result = await _mealPlansService.GetByNameAsync(name);
            //_logger.LogDebug(result.ToString());
            return Json(result);

        }


    }
}
