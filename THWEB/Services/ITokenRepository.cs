using Microsoft.AspNetCore.Identity;
namespace THWEB.Services
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
