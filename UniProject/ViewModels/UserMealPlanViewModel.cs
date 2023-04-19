

namespace UniProject.ViewModels.MealPlan
{
    public class UserMealPlanViewModel
    {
        public Models.Classes.MealPlan? MealPlan { get; set; }

        public List<Models.Classes.MealPlan>? MealPlans { get; set; } = new()
        {
            new Models.Classes.MealPlan()
            {
               Id = "2",
               Name = "Friday plan",
               Description = "140g protein,100g fat , 300g carbs",
               MacroNutrients = "140g protein,100g fat , 300g carbs",
               UserId = "be7d18a6-ba66-4765-86b9-f693388a25e3",

            }

        };
        
    }
}
