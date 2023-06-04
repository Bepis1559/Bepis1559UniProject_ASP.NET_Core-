using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class Workout : IId
    {
        [Key]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public Workout()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }

        public User? User { get; set; }

        [ForeignKey(nameof(WorkoutPlan))]

        public string? WorkoutPlanId { get; set; }

        public WorkoutPlan? WorkoutPlan { get; set; }

        // Navigation property to represent the many-to-many relationship with Workout

        public ICollection<Exercise_Workout>? ExerciseWorkouts { get; set; }

    }
}
