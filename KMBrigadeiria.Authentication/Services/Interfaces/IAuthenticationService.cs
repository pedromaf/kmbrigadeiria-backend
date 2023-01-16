using KMBrigadeiria.Authentication.Models;
using KMBrigadeiria.Authentication.Models.Requests;

namespace KMBrigadeiria.Authentication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Token UserLogin(LoginRequest request);
    }
}
