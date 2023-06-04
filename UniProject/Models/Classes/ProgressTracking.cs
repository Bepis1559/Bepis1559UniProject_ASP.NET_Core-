using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class ProgressTracking : IId
    {
        [Key]
        public string Id { get; set; }

        public float? BodyWeight { get; set; }
        public float? Bench { get; set; }
        public float? Squat { get; set; }
        public float? Deadlift { get; set; }
        public ProgressTracking()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }
    }
}
