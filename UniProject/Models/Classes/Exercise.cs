using System.ComponentModel.DataAnnotations;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class Exercise : ISetIdNameDesc
    {
        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? MuscleGroups { get; set; }
        public string? EquipmentNeeded { get; set; }

        public Exercise()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        // Navigation property to represent the many-to-many relationship with Workout

        public ICollection<Exercise_Workout>? ExerciseWorkouts { get; set; }

    }
}
