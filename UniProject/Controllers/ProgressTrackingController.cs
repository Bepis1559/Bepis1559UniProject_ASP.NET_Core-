using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniProject.Data.Services.Classes;
using UniProject.Models.Classes;
using UniProject.Models.Interfaces;
using UniProject.ViewModels;

namespace UniProject.Controllers
{
    public class ProgressTrackingController : Controller
    {
        private readonly ServiceRepository _serviceRepository;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProgressTrackingController> _logger;

        private string HandleUserNotFoundWhenSearchingByUserId() => "You tried to get all results by userId foreign key,bubt there is no such current user.";

        public ProgressTrackingController(ServiceRepository serviceRepository, UserManager<User> userManager, ILogger<ProgressTrackingController> logger)
        {
            _serviceRepository = serviceRepository;
            _userManager = userManager;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        //var deadliftResults = await _serviceRepository.GetAllAsync<DeadliftTracker>();
        //var benchResults = await _serviceRepository.GetAllAsync<BenchTracker>();
        //var squatResults = await _serviceRepository.GetAllAsync<SquatTracker>();

        //List<List<BaseProgressTracker>> results = new()
        //    {
        //        deadliftResults.Cast<BaseProgressTracker>().ToList(),
        //        benchResults.Cast<BaseProgressTracker>().ToList(),
        //        squatResults.Cast<BaseProgressTracker>().ToList(),
        //    };


        public async Task<JsonResult> GetAllDeadliftResults()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser != null) {
                var deadliftResults = await _serviceRepository.GetAllByUserIdAsync<DeadliftTracker>(currentUser.Id);
                return Json(deadliftResults);
            }
            else
            {
                throw new ArgumentNullException(HandleUserNotFoundWhenSearchingByUserId());
            }
           
           
        }

        public async Task<JsonResult> GetAllBenchResults()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var benchResults = await _serviceRepository.GetAllByUserIdAsync<BenchTracker>(currentUser.Id);
                return Json(benchResults);
            }
            else
            {
                throw new ArgumentNullException(HandleUserNotFoundWhenSearchingByUserId());
            }


        } 
        
        public async Task<JsonResult> GetAllSquatResults()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var squatResults = await _serviceRepository.GetAllByUserIdAsync<SquatTracker>(currentUser.Id);
                return Json(squatResults);
            }
            else
            {
                throw new ArgumentNullException(HandleUserNotFoundWhenSearchingByUserId());
            }


        }



        public async Task<IActionResult> CreateBenchRecord(BenchTracker newRecord, string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser.Id == userId)
            {
                ProgressTrackingViewModel viewModel = new()
                {
                    // Set the BenchTracker property
                    BenchTracker = newRecord
                };

                await _serviceRepository.CreateAsync(newRecord);
                return View("Index", viewModel);
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> CreateSquatRecord(SquatTracker newRecord, string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser.Id == userId)
            {
                ProgressTrackingViewModel viewModel = new()
                {
                    // Set the SquatTracker property
                    SquatTracker = newRecord
                };

                await _serviceRepository.CreateAsync(newRecord);
                return View("Index", viewModel);
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> CreateDeadliftRecord(DeadliftTracker newRecord, string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser.Id == userId)
            {
                ProgressTrackingViewModel viewModel = new()
                {
                    // Set the DeadliftTracker property
                    DeadliftTracker = newRecord
                };

                await _serviceRepository.CreateAsync(newRecord);
                return View("Index", viewModel);
            }
            else
            {
                return View("Error");
            }
        }


        public async Task<JsonResult> GetCurrentUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            return Json(currentUser);
        }


    }
}
