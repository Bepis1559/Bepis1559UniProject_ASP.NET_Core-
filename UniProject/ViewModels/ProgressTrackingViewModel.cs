using UniProject.Models.Classes;

namespace UniProject.ViewModels
{
    public class ProgressTrackingViewModel
    {
        public BenchTracker? BenchTracker { get; set; }
        public SquatTracker? SquatTracker { get; set; }
        public DeadliftTracker? DeadliftTracker { get; set; }
    }
}
