using KMBrigadeiria.Resources;

namespace KMBrigadeiria.Models.Exceptions.ServiceExceptions
{
    public class AddressInexistentException : Exception
    {
        public AddressInexistentException() : base(StringMessages.ADDRESS_INEXISTENT)
        {

        }
    }
}
