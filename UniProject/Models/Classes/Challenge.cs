using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniProject.Models.Interfaces;

namespace UniProject.Models.Classes
{
    public class Challenge : ISetIdNameDesc
    {
        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }



        public Challenge()
        {
            Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(User))]

        public string? UserId { get; set; }



    }
}
