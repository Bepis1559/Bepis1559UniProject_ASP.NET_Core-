using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class Meal : ISetIdNameDesc
    {
        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Ingredients { get; set; }

        public int CalorieCount { get; set; }

        public Meal()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations



        [ForeignKey(nameof(MealPlan))]

        public string? MealPlanId { get; set; }





    }
}
