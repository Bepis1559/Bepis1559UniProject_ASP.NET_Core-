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
        private readonly MealPlansService mealPlansService;
        private readonly UserManager<User> UserManager;
        public MealPlanController(ApplicationDbContext dbContext,UserManager<User> userManager)
        {
            mealPlansService = new MealPlansService(dbContext);
            UserManager = userManager;
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
                var user = await UserManager.GetUserAsync(User);
                if(user != null)
                {
                    mealPlan.UserId = user.Id;
                    await mealPlansService.CreateAsync(mealPlan);
                    return View("Index", mealPlan);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMealPlanById(string id)
        {
            
                await mealPlansService.DeleteByIdAsync(id);
                return View("Index");
            
            

        }

        [HttpGet]
        public async Task<IActionResult> GetMealPlanById(string id)
        {
               
              MealPlan mealPlan = await mealPlansService.GetByIdAsync(id);
               return Json(mealPlan);
        }
    }
}
