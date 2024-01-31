using TheStrongest.API.Models.DTO;

namespace TheStrongest.API.Models.Domain
{
    public class Set
    {
        public Guid Id { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}