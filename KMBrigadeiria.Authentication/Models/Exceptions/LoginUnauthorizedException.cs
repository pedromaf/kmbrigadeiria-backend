using KMBrigadeiria.Authentication.Resources;

namespace KMBrigadeiria.Authentication.Models.Exceptions
{
    public class LoginUnauthorizedException : Exception
    {
        public LoginUnauthorizedException() : base(StringMessages.LOGIN_UNAUTHORIZED)
        {

        }
    }
}
