using AutoMapper;
using EmartProd.Application.DTOs;
using EmartProd.Domain.Entities;

namespace EmartProd.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Products,ProductResponseDTO>();

        }
    }
}