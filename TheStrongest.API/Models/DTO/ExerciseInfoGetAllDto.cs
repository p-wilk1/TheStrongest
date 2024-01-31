namespace TheStrongest.API.Models.DTO
{
    public class ExerciseInfoGetAllDto
    {
        public string BodyPart { get; set; }
        public string Equipment { get; set; }
        public string GifUrl { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }

        public List<SecondaryMusclesGetDto> SecondaryMuscles { get; set; }
        public List<InstructionsDto> Instructions { get; set; }
    }
}