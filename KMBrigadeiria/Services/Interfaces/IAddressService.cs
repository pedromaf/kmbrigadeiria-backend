using KMBrigadeiria.Models.DTOs;

namespace KMBrigadeiria.Services.Interfaces
{
    public interface IAddressService
    {
        public void Create(CreateAddressDTO dto);
        public void Update(UpdateAddressDTO dto);
        public void Delete(long id);
        public ReadAddressDTO Get(long id);
    }
}
