using Microsoft.AspNetCore.Identity;

namespace TheStrongest.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}