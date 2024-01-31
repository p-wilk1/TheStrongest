using TheStrongest.API.Models.DTO;

namespace TheStrongest.API.Models.Domain
{
    public class PerformedExercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Set> Sets { get; set; }
    }
}