
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class EntityToDtoMappingUser : Profile
    {
        public EntityToDtoMappingUser()
        {
            ApplyMap();
        }

        private void ApplyMap()
        {
            CreateMap<User, DtoUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.MapFrom(x => x.Group));
        }

    }
}
