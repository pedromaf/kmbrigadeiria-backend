using KMBrigadeiria.Data;
using KMBrigadeiria.Models.Entities;
using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Repositories.Interfaces;
using KMBrigadeiria.Util;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly DbSet<Address> _addresses;

        public AddressRepository(KMContext context) : base(context)
        {
            _addresses = context.Addresses;
        }

        public new Address Get(long id)
        {
            Address address = _addresses.Find(id);

            EntityUtil.VerifyEntityNotNull(address, EntitiesEnum.ADDRESS);

            return address;
        }
    }
}
