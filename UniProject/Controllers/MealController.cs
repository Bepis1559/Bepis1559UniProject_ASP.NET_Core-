using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;

namespace UniProject.Controllers
{
    public class MealController : Controller
    {
       // private readonly MealsService _mealsService;
        private readonly ILogger<MealController> _logger;
        private readonly ServiceRepository _serviceRepository;
        public MealController( ILogger<MealController> logger, ServiceRepository serviceRepository)
        {
            _logger = logger;
            _serviceRepository = serviceRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllMealsBasedOnMealPlanId(string mealPlanId)
        {

            var allMeals = await _serviceRepository.GetAllAsync<Meal>();      
            var mealsOfChosenPlan = allMeals.Where(meal => meal.MealPlanId == mealPlanId).ToList();
            return Json(mealsOfChosenPlan);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(Meal meal)
        {
            _logger.LogInformation("This is a log message before valid model check.");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("This is a log message.");
                await _serviceRepository.CreateAsync(meal);
                return View("Index", meal);
            }
            else
            {
                _logger.LogWarning("Model state is not valid.");
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealById(string id)
        {
            await _serviceRepository.DeleteByIdAsync<Meal>(id);
            return View("Index");
        }



    }
}
