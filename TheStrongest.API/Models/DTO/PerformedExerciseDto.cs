using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Models.DTO
{
    public class PerformedExerciseDto
    {
        public string Name { get; set; }

        public List<SetDto> Sets { get; set; } = new List<SetDto>();
    }
}