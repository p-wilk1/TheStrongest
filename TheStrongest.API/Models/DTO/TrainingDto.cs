using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Models.DTO
{
    public class TrainingDto
    {
        public Guid Id { get; set; }

        public DateTime TrainingDate { get; set; }
        public double TotalWeightLifted { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }

        //public string? AuthorId { get; set; }
        public List<PerformedExerciseDto> PerformedExercises { get; set; } = new List<PerformedExerciseDto>();
    }
}