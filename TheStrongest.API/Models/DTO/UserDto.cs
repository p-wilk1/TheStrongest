using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Models.DTO
{
    public class UserDto
    {
        public List<Training>? Trainings { get; set; } = new List<Training>();
    }
}