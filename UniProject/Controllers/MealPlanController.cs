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
        private readonly UserManager<User> UserManager;
        private readonly ILogger<MealController> _logger;
        private readonly ServiceRepository _serviceRepository;
        public MealPlanController(UserManager<User> userManager,ServiceRepository serviceRepository, ILogger<MealController> logger)
        {
            _serviceRepository = serviceRepository;
            UserManager = userManager;
            _logger = logger;
        }

       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var MealPlans = await _serviceRepository.GetAllAsync<MealPlan>();
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
                    await _serviceRepository.CreateAsync(mealPlan);
                    var allMealPlans = await _serviceRepository.GetAllAsync<MealPlan>();
                    return View("Index", allMealPlans);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealPlanById(string id)
        {
            // delete all meals of this plan 
            List<Meal> allMeals = await _serviceRepository.GetAllAsync<Meal>();
            List<Meal> currentPlanMeals = allMeals.Where(meal => meal.MealPlanId == id).ToList();
            await _serviceRepository.DeleteAllAsync(currentPlanMeals);
            // delete the meal plan itself
            await _serviceRepository.DeleteByIdAsync<MealPlan>(id);
            return View("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetMealPlans()
        {
            // Retrieve a list of MealPlans from the database
            var mealPlans = await _serviceRepository.GetAllAsync<MealPlan>();

            // Return the list of MealPlans as JSON
            return Json(mealPlans);
        }


        [HttpGet]

        public async Task<JsonResult> GetMealPlanById(string id)
        {

            var result = await _serviceRepository.GetByIdAsync<MealPlan>(id);
            return Json(result);

        }

        [HttpGet]

        public async Task<JsonResult> GetMealPlanByName(string name)
        {

            var result = await _serviceRepository.GetByNameAsync<MealPlan>(name);
           
            return Json(result);

        }


    }
}
