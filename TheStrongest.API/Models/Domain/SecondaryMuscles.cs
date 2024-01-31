namespace TheStrongest.API.Models.Domain
{
    public class SecondaryMuscles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseInfo> Exercises { get; set; }
    }
}