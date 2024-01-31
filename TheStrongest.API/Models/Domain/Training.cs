namespace TheStrongest.API.Models.Domain
{
    public class Training
    {
        public Guid Id { get; set; }
        public DateTime TrainingDate { get; set; }
        public double TotalWeightLifted { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }
        public ICollection<PerformedExercise> PerformedExercises { get; set; }
        public string? AuthorId { get; set; }
    }
}