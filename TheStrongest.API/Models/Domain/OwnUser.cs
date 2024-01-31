using Microsoft.AspNetCore.Identity;

namespace TheStrongest.API.Models.Domain
{
    public class OwnUser : IdentityUser
    {
        public ICollection<Training>? Trainings { get; set; }
    }
}