using Microsoft.AspNetCore.Mvc;

namespace UniProject.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
