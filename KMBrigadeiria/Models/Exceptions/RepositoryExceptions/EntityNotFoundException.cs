using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Resources;
using System.Runtime.Versioning;

namespace KMBrigadeiria.Models.Exceptions.RepositoryExceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(EntitiesEnum entity) : base(GetErrorMessage(entity))
        {
            
        }

        private static string GetErrorMessage(EntitiesEnum entity)
        {
            return entity switch
            {
                EntitiesEnum.ADDRESS => StringMessages.ADDRESS_NOT_FOUND,
                EntitiesEnum.CLIENT => StringMessages.CLIENT_NOT_FOUND,
                _ => StringMessages.ENTITY_NOT_FOUND
            };
        }
    }
}
