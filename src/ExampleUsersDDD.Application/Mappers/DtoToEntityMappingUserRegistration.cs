
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class DtoToEntityMappingUserRegistration : Profile
    {
        public DtoToEntityMappingUserRegistration()
        {
            this.DtoToEntityMapping();
        }

        private void DtoToEntityMapping()
        {
            CreateMap<DtoUserRegistration, User>()
                .ForMember(entity => entity.Id,       opt => opt.Ignore())
                .ForMember(entity => entity.Email,    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(entity => entity.Password, opt => opt.MapFrom(dto => dto.Password))
                .ForMember(entity => entity.Group,    opt => opt.MapFrom(dto => dto.Group));
        }

    }
}
