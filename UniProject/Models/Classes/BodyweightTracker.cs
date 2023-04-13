using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniProject.Models.Classes
{
    public class BodyweightTracker
    {
        [Key]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public float Weight { get; set; }

        public BodyweightTracker()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }







    }
}
