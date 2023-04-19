using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMealPlan(MealPlan mealPlan)
        {
            if(ModelState.IsValid)
            {
                await mealPlansService.CreateAsync(mealPlan);
                return RedirectToAction("Index");
            }
            return View(mealPlan);
        }

        public async Task<IActionResult> GetMealPlans()
        {
               //UserMealPlanViewModel ump = new();
              var MealPlans = await mealPlansService.GetAllAsync();
               return View(MealPlans);
           
            
        }
    }
}
