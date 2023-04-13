using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniProject.Models.Classes
{
    public class WaterIntake
    {
        [Key]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public float? Amount { get; set; }

        public WaterIntake()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }
    }
}
