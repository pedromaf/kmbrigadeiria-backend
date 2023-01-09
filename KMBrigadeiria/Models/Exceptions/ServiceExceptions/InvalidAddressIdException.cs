using KMBrigadeiria.Resources;

namespace KMBrigadeiria.Models.Exceptions.ServiceExceptions
{
    public class InvalidAddressIdException : Exception
    {
        public InvalidAddressIdException() : base(StringMessages.INVALID_ADDRESS_ID)
        {

        }
    }
}
