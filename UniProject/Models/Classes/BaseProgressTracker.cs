using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class BaseProgressTracker : IProgressTracker, IId, IUserId
    {
        [Key]
        public string Id { get; set; }

        public float? BodyWeight { get; set; }
        public float? LiftedWeight { get; set; }
        public virtual string Type { get; set; } = "Base";
        public BaseProgressTracker()
        {
            Id = Guid.NewGuid().ToString();
        }

        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }

        
    }
}
