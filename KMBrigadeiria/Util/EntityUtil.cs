using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Models.Exceptions.RepositoryExceptions;

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
    }
}
