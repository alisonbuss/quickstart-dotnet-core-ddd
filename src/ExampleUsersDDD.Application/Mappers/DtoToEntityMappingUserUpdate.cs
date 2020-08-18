
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class DtoToEntityMappingUserUpdate : Profile
    {
        public DtoToEntityMappingUserUpdate()
        {
            this.DtoToEntityMapping();
        }

        private void DtoToEntityMapping()
        {
            CreateMap<DtoUserUpdate, User>()
                .ForMember(entity => entity.Id,         opt => opt.MapFrom(dto => dto.Id))
                .ForMember(entity => entity.Email,      opt => opt.MapFrom(dto => dto.Email))
                .ForMember(entity => entity.Password,   opt => opt.Ignore())
                .ForMember(entity => entity.Photo,      opt => opt.MapFrom(dto => dto.Photo))
                .ForMember(entity => entity.Nickname,   opt => opt.MapFrom(dto => dto.Nickname))
                .ForMember(entity => entity.FirstName,  opt => opt.MapFrom(dto => dto.FirstName))
                .ForMember(entity => entity.LastName,   opt => opt.MapFrom(dto => dto.LastName))
                .ForMember(entity => entity.Phone,      opt => opt.MapFrom(dto => dto.Phone))
                .ForMember(entity => entity.BirthDate,  opt => opt.MapFrom(dto => dto.BirthDate))
                .ForMember(entity => entity.Gender,     opt => opt.MapFrom(dto => dto.Gender))
                .ForMember(entity => entity.Status,     opt => opt.MapFrom(dto => dto.Status))
                .ForMember(entity => entity.Registered, opt => opt.Ignore())
                .ForMember(entity => entity.Group,      opt => opt.MapFrom(dto => dto.Group))
                .ForMember(entity => entity.Roles,      opt => opt.MapFrom(dto => dto.Roles));
        }

    }
}
