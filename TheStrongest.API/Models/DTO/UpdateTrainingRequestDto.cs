namespace TheStrongest.API.Models.DTO
{
    public class UpdateTrainingRequestDto
    {
        public DateTime TrainingDate { get; set; }
        public double TotalWeightLifted { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }
        public List<PerformedExerciseDto>? PerformedExercises { get; set; }
    }
}