
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class EntityToDtoMappingProduct : Profile
    {
        public EntityToDtoMappingProduct()
        {
            ProdutoDtoMap();
        }
        private void ProdutoDtoMap()
        {
            CreateMap<Product, DtoProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description));
        }
    }
}
