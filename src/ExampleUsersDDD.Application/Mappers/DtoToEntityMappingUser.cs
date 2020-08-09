
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class DtoToEntityMappingUser : Profile
    {
        public DtoToEntityMappingUser()
        {
            ApplyMap();
        }

        private void ApplyMap()
        {
            CreateMap<DtoUser, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(x => x.Password))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(x => x.Group));
        }

    }
}
