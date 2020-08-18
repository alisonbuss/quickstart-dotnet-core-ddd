
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class EntityToDtoMappingUserUpdate : Profile
    {
        public EntityToDtoMappingUserUpdate()
        {
            this.EntityToDtoMapping();
        }

        private void EntityToDtoMapping()
        {
            CreateMap<User, DtoUserUpdate>()
                .ForMember(dto => dto.Id,         opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Email,      opt => opt.MapFrom(entity => entity.Email))
                .ForMember(dto => dto.Photo,      opt => opt.MapFrom(entity => entity.Photo))
                .ForMember(dto => dto.Nickname,   opt => opt.MapFrom(entity => entity.Nickname))
                .ForMember(dto => dto.FirstName,  opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(dto => dto.LastName,   opt => opt.MapFrom(entity => entity.LastName))
                .ForMember(dto => dto.Phone,      opt => opt.MapFrom(entity => entity.Phone))
                .ForMember(dto => dto.BirthDate,  opt => opt.MapFrom(entity => entity.BirthDate))
                .ForMember(dto => dto.Gender,     opt => opt.MapFrom(entity => entity.Gender))
                .ForMember(dto => dto.Status,     opt => opt.MapFrom(entity => entity.Status))
                .ForMember(dto => dto.Group,      opt => opt.MapFrom(entity => entity.Group))
                .ForMember(dto => dto.Roles,      opt => opt.MapFrom(entity => entity.Roles));
        }

    }
}
