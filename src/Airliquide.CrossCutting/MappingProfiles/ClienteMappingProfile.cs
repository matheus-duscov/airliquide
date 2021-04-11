using Airliquide.Contracts.Contracts;
using Airliquide.Domain.Entities;
using AutoMapper;

namespace Airliquide.CrossCutting.MappingProfiles
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
