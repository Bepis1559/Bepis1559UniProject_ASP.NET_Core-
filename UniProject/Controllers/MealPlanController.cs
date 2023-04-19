using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;
using UniProject.ViewModels.MealPlan;

namespace UniProject.Controllers
{
    public class MealPlanController : Controller
    {
        private readonly MealPlansService mealPlansService;
        public MealPlanController(ApplicationDbContext dbContext)
        {
            mealPlansService = new MealPlansService(dbContext);
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var MealPlans = await mealPlansService.GetAllAsync();
            return View("Index", MealPlans);
        }

        [HttpPost]
        public async Task<IActionResult> AddMealPlan(MealPlan mealPlan)
        {
            if (ModelState.IsValid)
            {
                await mealPlansService.CreateAsync(mealPlan);
                return View("Index", mealPlan);
            }
            return View(mealPlan);
        }





    }
}
