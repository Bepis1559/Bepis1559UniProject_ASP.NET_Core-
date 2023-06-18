using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class CalorieTracker : IId, IUserId
    {
        [Key]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string? MealName { get; set; }

        public int CalorieCount { get; set; }

        public CalorieTracker()
        {
            Id = Guid.NewGuid().ToString();
        }


        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }
    }
}
