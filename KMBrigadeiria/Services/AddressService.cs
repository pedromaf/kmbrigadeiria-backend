using AutoMapper;
using KMBrigadeiria.Models.DTOs;
using KMBrigadeiria.Models.Entities;
using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Repositories.Interfaces;
using KMBrigadeiria.Services.Interfaces;
using KMBrigadeiria.Util;

namespace KMBrigadeiria.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _repository;

        public AddressService(IMapper mapper, IAddressRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void Create(CreateAddressDTO dto)
        {
            Address newAddress = _mapper.Map<Address>(dto);

            _repository.Add(newAddress);
        }

        public void Delete(long id)
        {
            Address address = _repository.Get(id);

            EntityUtil.VerifyEntityNotNull(address, EntitiesEnum.ADDRESS);

            _repository.Delete(address);
        }

        public ReadAddressDTO Get(long id)
        {
            Address address = _repository.Get(id);

            EntityUtil.VerifyEntityNotNull(address, EntitiesEnum.ADDRESS);

            ReadAddressDTO dto = _mapper.Map<ReadAddressDTO>(address);

            return dto;
        }

        public void Update(UpdateAddressDTO dto)
        {
            Address address = _repository.Get(dto.Id);

            EntityUtil.VerifyEntityNotNull(_mapper.Map<Address>(address), EntitiesEnum.ADDRESS);

            _mapper.Map(dto, address);

            _repository.Update(address);
        }
    }
}
