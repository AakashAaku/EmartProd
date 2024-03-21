using AutoMapper;
using EmartProd.Application.DTOs;
using EmartProd.Application.MappingResolver;
using EmartProd.Domain.Entities;

namespace EmartProd.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Products,ProductResponseDTO>()
            .ForMember(d=>d.ProductBrands,o=>o.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(d=>d.ProductTypes,o=>o.MapFrom(s=>s.ProductType.Name))
            .ForMember(d=>d.ImageUrl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}