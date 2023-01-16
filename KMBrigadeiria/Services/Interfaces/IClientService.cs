using KMBrigadeiria.Models.DTOs;

namespace KMBrigadeiria.Services.Interfaces
{
    public interface IClientService
    {
        public void Create(CreateClientDTO dto);
        public void Update(UpdateClientDTO dto);
        public void Delete(long id);
        public ReadClientDTO GetById(long id);
        public IEnumerable<ReadClientDTO> GetAll();
        void AddAddress(long clientId, CreateAddressDTO addressDTO);
        void UpdateAddress(long clientId, UpdateAddressDTO updateAddressDTO);
        void DeleteAddress(long clientId);
    }
}
