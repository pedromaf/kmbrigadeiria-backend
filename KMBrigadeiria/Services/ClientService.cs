using AutoMapper;
using KMBrigadeiria.Models.DTOs;
using KMBrigadeiria.Models.Entities;
using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Models.Exceptions.ServiceExceptions;
using KMBrigadeiria.Repositories.Interfaces;
using KMBrigadeiria.Services.Interfaces;
using KMBrigadeiria.Util;

namespace KMBrigadeiria.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IAddressRepository addressRepository, IMapper mapper)
        {
            _clientRepository = repository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public void Create(CreateClientDTO dto)
        {
            Client newClient = _mapper.Map<Client>(dto);

            _clientRepository.Add(newClient);
        }

        public void Delete(long id)
        {
            Client client = _clientRepository.Get(id);
            Address address;

            if (client.AddressId != null)
            {
                address = _addressRepository.Get(client.AddressId);

                _addressRepository.Delete(address);
            }

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);

            _clientRepository.Delete(client);
        }

        public IEnumerable<ReadClientDTO> GetAll()
        {
            IEnumerable<Client> clientList = _clientRepository.GetAll();

            IEnumerable<ReadClientDTO> readClientDTOList = _mapper.Map<IEnumerable<ReadClientDTO>>(clientList);

            return readClientDTOList;
        }

        public ReadClientDTO GetById(long id)
        {
            Client client = _clientRepository.Get(id);

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);

            ReadClientDTO readClientDTO = _mapper.Map<ReadClientDTO>(client);
            
            return readClientDTO;
        }

        public void Update(UpdateClientDTO dto)
        {
            Client client = _clientRepository.Get(dto.Id);

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);

            _mapper.Map(dto, client);

            _clientRepository.Update(client);
        }

        public void AddAddress(long clientId, CreateAddressDTO addressDTO)
        {
            Client client = _clientRepository.Get(clientId);

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);

            if (client.AddressId != null)
            {
                throw new ClientAlreadyHaveAddressException();
            }

            Address address = _mapper.Map<Address>(addressDTO);

            address.Client = client;

            _addressRepository.Add(address);

            client.Address = address;
            client.AddressId = address.Id;

            _clientRepository.Update(client);
        }

        public void UpdateAddress(long clientId, UpdateAddressDTO addressDTO)
        {
            Client client = _clientRepository.Get(clientId);

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);
            EntityUtil.VerifyClientAndAddressRelationship(client.AddressId, addressDTO.Id);

            Address address = _addressRepository.Get(addressDTO.Id);
            
            EntityUtil.VerifyEntityNotNull(address, EntitiesEnum.ADDRESS);

            _mapper.Map(addressDTO, address);

            _addressRepository.Update(address);
        }

        public void DeleteAddress(long clientId)
        {
            Client client = _clientRepository.Get(clientId);

            EntityUtil.VerifyEntityNotNull(client, EntitiesEnum.CLIENT);

            if (client.AddressId == null) 
            {
                throw new AddressInexistentException();
            }

            Address address = _addressRepository.Get(client.AddressId);

            EntityUtil.VerifyEntityNotNull(address, EntitiesEnum.ADDRESS);

            _addressRepository.Delete(address);

            client.Address = null;
            client.AddressId = null;

            _clientRepository.Update(client);
        }
    }
}
