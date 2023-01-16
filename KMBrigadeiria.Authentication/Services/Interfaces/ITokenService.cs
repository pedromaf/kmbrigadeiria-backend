using KMBrigadeiria.Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace KMBrigadeiria.Authentication.Services.Interfaces
{
    public interface ITokenService
    {
        public Token CreateToken(IdentityUser<int> user, string role);
    }
}
