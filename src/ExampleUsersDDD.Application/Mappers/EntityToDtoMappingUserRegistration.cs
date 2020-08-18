
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class EntityToDtoMappingUserRegistration : Profile
    {
        public EntityToDtoMappingUserRegistration()
        {
            this.EntityToDtoMapping();
        }

        private void EntityToDtoMapping()
        {
            CreateMap<User, DtoUserRegistration>()
                .ForMember(dto => dto.Id,         opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Email,      opt => opt.MapFrom(entity => entity.Email))
                .ForMember(dto => dto.Password,   opt => opt.Ignore())
                .ForMember(dto => dto.Group,      opt => opt.MapFrom(entity => entity.Group));
        }

    }
}
