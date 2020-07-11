
using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Mappers
{
    public class DtoToEntityMappingProduct : Profile
    {
        public DtoToEntityMappingProduct()
        {
            ProdutoMap();
        }

        private void ProdutoMap()
        {
            CreateMap<DtoProduct, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Price))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description));
        }
    }
}
