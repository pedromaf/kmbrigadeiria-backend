using AutoMapper;
using KMBrigadeiria.Models.DTOs;
using KMBrigadeiria.Models.Entities;

namespace KMBrigadeiria.Data.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
        }
    }
}
