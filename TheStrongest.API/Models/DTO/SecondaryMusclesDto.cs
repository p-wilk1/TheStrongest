using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Models.DTO
{
    public class SecondaryMusclesDto
    {
        public string Name { get; set; }
        public List<ExerciseInfoDto> Exercises { get; set; } = new List<ExerciseInfoDto>();
    }
}