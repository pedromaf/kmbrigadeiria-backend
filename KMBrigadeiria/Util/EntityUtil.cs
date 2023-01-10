using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Models.Exceptions.RepositoryExceptions;
using KMBrigadeiria.Models.Exceptions.ServiceExceptions;

namespace KMBrigadeiria.Util
{
    public static class EntityUtil
    {
        public static void VerifyEntityNotNull(object entity, EntitiesEnum entityType)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException(entityType);
            }
        }

        public static void VerifyClientAndAddressRelationship(long? clientAddressId, long addressId)
        {
            if (clientAddressId == null || clientAddressId != addressId)
            {
                throw new InvalidAddressIdException();
            }
        }
    }
}
