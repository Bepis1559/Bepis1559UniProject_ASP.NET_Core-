using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class MealPlan :  IId, IName
    {

        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? MacroNutrients { get; set; }

        public MealPlan()
        {
            Id = Guid.NewGuid().ToString();
        }



        // relations

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public List<Meal> Meals { get; set; } = new();


    }
}
