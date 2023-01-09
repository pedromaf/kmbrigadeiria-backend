using AutoMapper;
using KMBrigadeiria.Models.DTOs;
using KMBrigadeiria.Models.Entities;

namespace KMBrigadeiria.Data.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDTO, Client>();
            CreateMap<UpdateClientDTO, Client>();
            CreateMap<Client, ReadClientDTO>();
        }
    }
}
