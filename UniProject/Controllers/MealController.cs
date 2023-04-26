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
        private readonly MealsService _mealsService;
        private readonly ILogger<MealController> _logger;
        public MealController(MealsService mealsService, ILogger<MealController> logger)
        {
            _mealsService = mealsService;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllMealsBasedOnMealPlanId(string mealPlanId)
        {
            var mealPlans = await _mealsService.GetAllAsync();
            var mealsOfChosenPlan = mealPlans.Where(mp => mp.MealPlanId == mealPlanId).ToList();
            //_logger.LogWarning(mealPlanId);
            return Json(mealsOfChosenPlan);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(Meal meal)
        {
            _logger.LogInformation("This is a log message before valid model check.");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("This is a log message.");
                await _mealsService.CreateAsync(meal);
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



    }
}
