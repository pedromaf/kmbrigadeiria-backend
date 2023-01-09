using KMBrigadeiria.Resources;

namespace KMBrigadeiria.Models.Exceptions.ServiceExceptions
{
    public class ClientAlreadyHaveAddressException : Exception
    {
        public ClientAlreadyHaveAddressException() : base(StringMessages.CLIENT_ALREADY_HAVE_ADDRESS)
        {

        }
    }
}
