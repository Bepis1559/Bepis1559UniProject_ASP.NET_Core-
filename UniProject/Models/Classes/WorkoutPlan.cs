using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class WorkoutPlan : ISetIdNameDesc
    {
        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public WorkoutPlan()
        {
            Id = Guid.NewGuid().ToString();
        }



        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }

        public List<Workout> Workouts { get; set; } = new();
    }
}
