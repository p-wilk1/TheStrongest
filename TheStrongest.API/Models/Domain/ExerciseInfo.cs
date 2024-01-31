using Newtonsoft.Json;
using TheStrongest.API.Mappings;

namespace TheStrongest.API.Models.Domain
{
    public class ExerciseInfo
    {
        public string BodyPart { get; set; }
        public string Equipment { get; set; }
        public string GifUrl { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }

        public ICollection<SecondaryMuscles> SecondaryMuscles { get; set; } = new List<SecondaryMuscles>();

        public ICollection<Instructions> Instructions { get; set; } = new List<Instructions>();
    }
}