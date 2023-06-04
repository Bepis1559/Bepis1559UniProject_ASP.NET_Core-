using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class BodyweightTracker : IId
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
