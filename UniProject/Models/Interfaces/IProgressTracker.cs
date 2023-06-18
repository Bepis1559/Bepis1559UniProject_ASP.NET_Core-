namespace UniProject.Models.Interfaces
{
    public interface IProgressTracker
    {
        public string Id { get; set; }

        public float? BodyWeight { get; set; }
        public float? LiftedWeight { get; set; }

        public string Type { get; }
    }
}
