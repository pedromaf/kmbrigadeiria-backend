using KMBrigadeiria.Data;
using KMBrigadeiria.Models.Entities;
using KMBrigadeiria.Repositories.Interfaces;

namespace KMBrigadeiria.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(KMContext context) : base(context)
        {
        }

    }
}
