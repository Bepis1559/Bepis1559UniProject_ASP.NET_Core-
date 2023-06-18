using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class WorkoutSchedule : IId,IUserId
    {
        [Key]
        public string Id { get; set; }

        public string? DayOfWeek { get; set; }

        public string? WorkoutType { get; set; }

        public TimeSpan TimeOfDay { get; set; }

        public WorkoutSchedule()
        {
            Id = Guid.NewGuid().ToString();
        }


        // relations

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }
    }
}
