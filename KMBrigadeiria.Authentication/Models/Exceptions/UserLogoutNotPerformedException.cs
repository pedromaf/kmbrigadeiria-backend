using KMBrigadeiria.Authentication.Resources;

namespace KMBrigadeiria.Authentication.Models.Exceptions
{
    public class UserLogoutNotPerformedException : Exception
    {
        public UserLogoutNotPerformedException() : base(StringMessages.LOGOUT_NOT_PERFORMED)
        {

        }
    }
}
