using Microsoft.AspNetCore.Mvc;
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
       
      //  private readonly MealsService _mealsService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<MealController> _logger;
        private readonly ServiceRepository _serviceRepository;
        public MealPlanController(UserManager<User> userManager,ServiceRepository serviceRepository, ILogger<MealController> logger)
        {
            _serviceRepository = serviceRepository;
            _userManager = userManager;
            _logger = logger;
        }

       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
             
            var MealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
            return View("Index", MealPlans);
        }

        [HttpPost]
        public async Task<IActionResult> AddMealPlan(MealPlan mealPlan)
        {
           

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    mealPlan.UserId = user.Id;
                    await _serviceRepository.CreateAsync(mealPlan);
                    var allMealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
                    return View("Index", allMealPlans);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealPlanById(string id)
        {
            // delete all meals of this plan 
            var user = await _userManager.GetUserAsync(User);
            var mealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
            
            foreach (MealPlan mealPlan in mealPlans)
            {
                if(mealPlan.Id  == id)
                {
                    await _serviceRepository.DeleteAllAsync(mealPlan.Meals);
                }
            }
            // delete the meal plan

            await _serviceRepository.DeleteByIdAsync<MealPlan>(id);
            return View("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetMealPlans()
        {
            // Retrieve a list of MealPlans from the database
            var user = await _userManager.GetUserAsync(User);
            var mealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);

            // Return the list of MealPlans as JSON
            return Json(mealPlans);
        }


        [HttpGet]

        public async Task<JsonResult> GetMealPlanById(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserMealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
            var result = currentUserMealPlans.Find(currentUserMealPlan => currentUserMealPlan.Id == id);
            return Json(result);

        }

        [HttpGet]

        public async Task<JsonResult> GetMealPlanByName(string name)
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserMealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
            var result = currentUserMealPlans.Find(currentUserMealPlan => currentUserMealPlan.Name == name);
            return Json(result);

        }

        [HttpGet]

        public async Task<JsonResult> GetAllMealPlans()
        {
            var user = await _userManager.GetUserAsync(User);
            var currentUserMealPlans = await _serviceRepository.GetAllByUserIdAsync<MealPlan>(user.Id);
            return Json(currentUserMealPlans);

        }


    }
}
