using AutoMapper;
using EmartProd.Application.DTOs;
using EmartProd.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace EmartProd.Application.MappingResolver
{
    public class ProductUrlResolver : IValueResolver<Products, ProductResponseDTO, string>
    {
        public readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            this._config = config;
        }

        public string Resolve(Products source, ProductResponseDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["APIUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}