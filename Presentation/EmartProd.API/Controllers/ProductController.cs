using AutoMapper;
using EmartProd.API.Responses;
using EmartProd.Application.DTOs;
using EmartProd.Application.Interfaces;
using EmartProd.Application.Specifications;
using EmartProd.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmartProd.API.Controllers
{
    public class ProductController:BaseAPIController
    {
        public IGenericRepository<ProductBrands> _productBrandRepo;
        public IGenericRepository<ProductTypes> _productTypesRepo;
        public IGenericRepository<Products> _productRepo;
        public readonly IMapper _mapper;
        public ProductController(IGenericRepository<ProductBrands> prodctBrandRepo,IGenericRepository<ProductTypes> productTypesRepo,
        IGenericRepository<Products> productRepo,IMapper mapper)
        {
            this._productRepo = productRepo;
            this._productTypesRepo = productTypesRepo;
            this._productBrandRepo = prodctBrandRepo;
            this._mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetProduct(string sort)
        {
             //var products =  await _productRepo.GetListAsync();
            var spec = new ProductWithBrandAndTypes(sort);
            var products = await _productRepo.ListAsync(spec);
            var newProd = _mapper.Map<IReadOnlyList<Products>,IReadOnlyList<ProductResponseDTO>>(products);

            return Ok(newProd);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndTypes(id);
            var prodduct = await _productRepo.GetEntityWithSpec(spec);
            if(prodduct == null) return NotFound(new APIResponse(404));
            var productRes = _mapper.Map<Products,ProductResponseDTO>(prodduct);
            return Ok(productRes);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDTO>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetListAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductTypeDTO>>> GetProductTypes()
        {
            return Ok(await _productTypesRepo.GetListAsync());
        }
    }
}