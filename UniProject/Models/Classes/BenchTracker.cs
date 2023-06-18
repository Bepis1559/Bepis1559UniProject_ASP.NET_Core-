using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class BenchTracker : BaseProgressTracker
    {
        public override string Type => "bench";

    }
}
