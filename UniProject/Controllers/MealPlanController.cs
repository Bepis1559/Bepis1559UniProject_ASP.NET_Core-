using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using UniProject.Data.Classes;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;

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
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealPlanById(string id)
        {
            if (ModelState.IsValid)
            {
                await mealPlansService.DeleteByIdAsync(id);
                return View("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> GetMealPlanById(string id)
        {
               
              MealPlan mealPlan = await mealPlansService.GetByIdAsync(id);
               return Json(mealPlan);
        }
    }
}
