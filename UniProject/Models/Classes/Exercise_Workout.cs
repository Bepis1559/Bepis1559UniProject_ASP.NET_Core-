using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniProject.Models.Classes
{
    public class Exercise_Workout
    {
        [Key]
        public string Id { get; set; }


        [ForeignKey(nameof(Exercise))]
        public string ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }


        [ForeignKey(nameof(Workout))]
        public string WorkoutId { get; set; }
        public Workout? Workout { get; set; }

        public Exercise_Workout()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
