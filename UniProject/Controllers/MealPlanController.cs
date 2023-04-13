using Microsoft.AspNetCore.Mvc;

namespace UniProject.Controllers
{
    public class MealPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
